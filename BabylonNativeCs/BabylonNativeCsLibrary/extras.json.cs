// --------------------------------------------------------------------------------------------------------------------
// <copyright file="extras.json.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------
#define JSMN_PARENT_LINKS // must be defined for speed
//#define JSMN_STRICT

namespace BABYLON
{
    /// <summary>
    /// </summary>
    internal enum JsmnType
    {
        /// <summary>
        /// </summary>
        NotSet = 0,

        /// <summary>
        /// </summary>
        Primitive = 1,

        /// <summary>
        /// </summary>
        Object = 2,

        /// <summary>
        /// </summary>
        Array = 3,

        /// <summary>
        /// </summary>
        String = 4,

        /// <summary>
        /// </summary>
        Any = 0xff,
    }

    /// <summary>
    /// </summary>
    internal enum JsmnError
    {
        /* Not enough tokens were provided */

        /// <summary>
        /// </summary>
        NoMemory = -1,

        /* Invalid character inside JSON string */

        /// <summary>
        /// </summary>
        Invalid = -2,

        /* The string is not a full JSON packet, more bytes expected */

        /// <summary>
        /// </summary>
        Part = -3
    };

    /**
 * JSON token description.
 * @param		type	type (object, array, string etc.)
 * @param		start	start position in JSON data string
 * @param		end		end position in JSON data string
 */

    /// <summary>
    /// </summary>
    internal class JsmnTok
    {
        /// <summary>
        /// </summary>
        internal JsmnType type;

        /// <summary>
        /// </summary>
        internal int start;

        /// <summary>
        /// </summary>
        internal int end;

        /// <summary>
        /// </summary>
        internal int size;
#if JSMN_PARENT_LINKS

        /// <summary>
        /// </summary>
        internal int parent;
#endif
    }

    /**
 * JSON this. Contains an array of token blocks available. Also stores
 * the string being parsed now and current position in that string
 */

    /// <summary>
    /// </summary>
    public class JsmnParser
    {
        /// <summary>
        /// </summary>
        internal int pos; /* offset in the JSON string */

        /// <summary>
        /// </summary>
        internal int toknext; /* next token to allocate */

        /// <summary>
        /// </summary>
        internal int toksuper; /* superior token node, e.g parent object or array */

        /// <summary>
        /// </summary>
        internal JsmnTok[] tokens;

        public JsmnParser(int tokensCount = 255)
        {
            this.Init();
            this.tokens = new JsmnTok[tokensCount];
        }

        /**
         * Allocates a fresh unused token from the token pull.
         */
        JsmnTok AllocateToken()
        {
            JsmnTok tok;
            if (this.toknext >= tokens.Length)
            {
                return default(JsmnTok);
            }
            tok = tokens[this.toknext++] = new JsmnTok();
            tok.type = JsmnType.Any;
            tok.start = tok.end = -1;
            tok.size = 0;
#if JSMN_PARENT_LINKS
            tok.parent = -1;
#endif
            return tok;
        }

        /**
         * Fills token type and boundaries.
         */
        void FillToken(ref JsmnTok token, JsmnType type,
                                    int start, int end)
        {
            token.type = type;
            token.start = start;
            token.end = end;
            token.size = 0;
        }

        /**
         * Fills next available token with JSON primitive.
         */
        JsmnError ParsePrimitive(string js,
                int len, JsmnTok[] tokens, int num_tokens)
        {
            JsmnTok token;
            int start;

            start = this.pos;

            for (; this.pos < len && js[this.pos] != '\0'; this.pos++)
            {
                switch (js[this.pos])
                {
#if !JSMN_STRICT
                    /* In strict mode primitive must be followed by "," or "}" or "]" */
                    case ':':
#endif
                    case '\t':
                    case '\r':
                    case '\n':
                    case ' ':
                    case ',':
                    case ']':
                    case '}':
                        goto found;
                }
                if (js[this.pos] < 32 || js[this.pos] >= 127)
                {
                    this.pos = start;
                    return JsmnError.Invalid;
                }
            }
#if JSMN_STRICT
            /* In strict mode primitive must be followed by a comma/object/array */
            this.pos = start;
            return JsmnError.Part;
#endif

        found:
            if (tokens == null)
            {
                this.pos--;
                return 0;
            }
            token = AllocateToken();
            if (token == default(JsmnTok))
            {
                this.pos = start;
                return JsmnError.NoMemory;
            }
            FillToken(ref token, JsmnType.Primitive, start, this.pos);
#if JSMN_PARENT_LINKS
            token.parent = this.toksuper;
#endif
            this.pos--;
            return 0;
        }

        /**
         * Filsl next token with JSON string.
         */
        JsmnError ParseString(string js)
        {
            JsmnTok token;
            var len = js.Length;

            int start = this.pos;

            this.pos++;

            /* Skip starting quote */
            for (; this.pos < len; this.pos++)
            {
                char c = js[this.pos];

                /* Quote: end of string */
                if (c == '\"')
                {
                    if (tokens == null)
                    {
                        return 0;
                    }
                    token = AllocateToken();
                    if (token == default(JsmnTok))
                    {
                        this.pos = start;
                        return JsmnError.NoMemory;
                    }
                    FillToken(ref token, JsmnType.String, start + 1, this.pos);
#if JSMN_PARENT_LINKS
                    token.parent = this.toksuper;
#endif
                    return 0;
                }

                /* Backslash: Quoted symbol expected */
                if (c == '\\' && this.pos + 1 < len)
                {
                    int i;
                    this.pos++;
                    switch (js[this.pos])
                    {
                        /* Allowed escaped symbols */
                        case '\"':
                        case '/':
                        case '\\':
                        case 'b':
                        case 'f':
                        case 'r':
                        case 'n':
                        case 't':
                            break;
                        /* Allows escaped symbol \uXXXX */
                        case 'u':
                            this.pos++;
                            for (i = 0; i < 4 && this.pos < len && js[this.pos] != '\0'; i++)
                            {
                                /* If it isn't a hex character we have an error */
                                if (!((js[this.pos] >= 48 && js[this.pos] <= 57) || /* 0-9 */
                                            (js[this.pos] >= 65 && js[this.pos] <= 70) || /* A-F */
                                            (js[this.pos] >= 97 && js[this.pos] <= 102)))
                                { /* a-f */
                                    this.pos = start;
                                    return JsmnError.Invalid;
                                }
                                this.pos++;
                            }
                            this.pos--;
                            break;
                        /* Unexpected symbol */
                        default:
                            this.pos = start;
                            return JsmnError.Invalid;
                    }
                }
            }
            this.pos = start;
            return JsmnError.Part;
        }

        /**
         * Parse JSON string and fill tokens.
         */
        internal JsmnError Parse(string js)
        {
            JsmnError r;
            int i;
            JsmnTok token;
            int count = 0;
            int num_tokens = tokens.Length;
            int len = js.Length;

            for (; this.pos < len && js[this.pos] != '\0'; this.pos++)
            {
                char c;
                JsmnType type;

                c = js[this.pos];
                switch (c)
                {
                    case '{':
                    case '[':
                        count++;
                        if (tokens == null)
                        {
                            break;
                        }
                        token = AllocateToken();
                        if (token == default(JsmnTok))
                            return JsmnError.NoMemory;
                        if (this.toksuper != -1)
                        {
                            tokens[this.toksuper].size++;
#if JSMN_PARENT_LINKS
                            token.parent = this.toksuper;
#endif
                        }
                        token.type = (c == '{' ? JsmnType.Object : JsmnType.Array);
                        token.start = this.pos;
                        this.toksuper = this.toknext - 1;
                        break;
                    case '}':
                    case ']':
                        if (tokens == null)
                            break;
                        type = (c == '}' ? JsmnType.Object : JsmnType.Array);
#if JSMN_PARENT_LINKS
                        if (this.toknext < 1)
                        {
                            return JsmnError.Invalid;
                        }
                        token = tokens[this.toknext - 1];
                        for (; ; )
                        {
                            if (token.start != -1 && token.end == -1)
                            {
                                if (token.type != type)
                                {
                                    return JsmnError.Invalid;
                                }
                                token.end = this.pos + 1;
                                this.toksuper = token.parent;
                                break;
                            }
                            if (token.parent == -1)
                            {
                                break;
                            }
                            token = tokens[token.parent];
                        }
#else
                        for (i = this.toknext - 1; i >= 0; i--)
                        {
                            token = tokens[i];
                            if (token.start != -1 && token.end == -1)
                            {
                                if (token.type != type)
                                {
                                    return JsmnError.Invalid;
                                }
                                this.toksuper = -1;
                                token.end = this.pos + 1;
                                break;
                            }
                        }
                        /* Error if unmatched closing bracket */
                        if (i == -1) return JsmnError.Invalid;
                        for (; i >= 0; i--)
                        {
                            token = tokens[i];
                            if (token.start != -1 && token.end == -1)
                            {
                                this.toksuper = i;
                                break;
                            }
                        }
#endif
                        break;
                    case '\"':
                        r = ParseString(js);
                        if (r < 0) return r;
                        count++;
                        if (this.toksuper != -1 && tokens != null)
                            tokens[this.toksuper].size++;
                        break;
                    case '\t':
                    case '\r':
                    case '\n':
                    case ' ':
                        break;
                    case ':':
                        this.toksuper = this.toknext - 1;
                        break;
                    case ',':
                        if (tokens != null &&
                                tokens[this.toksuper].type != JsmnType.Array &&
                                tokens[this.toksuper].type != JsmnType.Object)
                        {
#if JSMN_PARENT_LINKS
                            this.toksuper = tokens[this.toksuper].parent;
#else
                            for (i = this.toknext - 1; i >= 0; i--)
                            {
                                if (tokens[i].type == JsmnType.Array || tokens[i].type == JsmnType.Object)
                                {
                                    if (tokens[i].start != -1 && tokens[i].end == -1)
                                    {
                                        this.toksuper = i;
                                        break;
                                    }
                                }
                            }
#endif
                        }
                        break;
#if JSMN_STRICT
                    /* In strict mode primitives are: numbers and booleans */
                    case '-':
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case 't':
                    case 'f':
                    case 'n':
                        /* And they must not be keys of the object */
                        if (tokens != null)
                        {
                            var t = tokens[this.toksuper];
                            if (t.type == JsmnType.Object ||
                                    (t.type == JsmnType.String && t.size != 0))
                            {
                                return JsmnError.Invalid;
                            }
                        }
#else
                    /* In non-strict mode every unquoted value is a primitive */
                    default:
#endif
                        r = ParsePrimitive(js, len, tokens, num_tokens);
                        if (r < 0) return r;
                        count++;
                        if (this.toksuper != -1 && tokens != null)
                            tokens[this.toksuper].size++;
                        break;

#if JSMN_STRICT
                    /* Unexpected char in strict mode */
                    default:
                        return JsmnError.Invalid;
#endif
                }
            }

            for (i = this.toknext - 1; i >= 0; i--)
            {
                /* Unmatched opened object or array */
                if (tokens[i].start != -1 && tokens[i].end == -1)
                {
                    return JsmnError.Part;
                }
            }

            return (JsmnError)count;
        }

        /**
         * Creates a new parser based over a given  buffer with an array of tokens
         * available.
         */
        void Init()
        {
            this.pos = 0;
            this.toknext = 0;
            this.toksuper = -1;
        }
    }
}