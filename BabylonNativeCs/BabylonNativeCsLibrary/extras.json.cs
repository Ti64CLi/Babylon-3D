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
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// </summary>
    public enum JsmnType
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
    public enum JsmnError
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
    public class JsmnTok
    {
        private string _value;

        /// <summary>
        /// </summary>
        public JsmnType type;

        /// <summary>
        /// </summary>
        public int start;

        /// <summary>
        /// </summary>
        public int end;

        /// <summary>
        /// </summary>
        public int size;

#if JSMN_PARENT_LINKS
        /// <summary>
        /// </summary>
        public int parent;
#endif

        public string source;

        public string Value
        {
            get
            {
                if (type != JsmnType.Primitive && type != JsmnType.String)
                {
                    return null;
                }

                if (_value == null)
                {
                    _value  = this.source.Substring(this.start, this.end - this.start);
                }

                return _value;
            }
        }

        public bool EqualsTo(string other)
        {
            return string.Compare(other, 0, this.source, this.start, Math.Max(other.Length, this.end - this.start)) == 0;
        }
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
        public int pos; /* offset in the JSON string */

        /// <summary>
        /// </summary>
        public int toknext; /* next token to allocate */

        /// <summary>
        /// </summary>
        public int toksuper; /* superior token node, e.g parent object or array */

        /// <summary>
        /// </summary>
        public Array<JsmnTok> tokens;

        /// <summary>
        /// </summary>
        public string _js;

        public JsmnParser(int tokensCount = 255)
        {
            this.Init();
            this.tokens = new Array<JsmnTok>();
            this.tokens.Capacity = tokensCount;
        }

        public static JsmnParserValue Parse(string data)
        {
            var parser = new JsmnParser(256);
            //var r = parser.Parse("{ \"name\" : \"Jack\", \"age\" : 27 }");
            var r = parser.ParseJson(data);

            var parsedData = new JsmnParserValue(0, parser.Tokens);
            return parsedData;
        }

        /**
         * Allocates a fresh unused token from the token pull.
         */
        JsmnTok AllocateToken()
        {
            JsmnTok tok;
            tok = tokens[this.toknext++] = new JsmnTok();
            tok.type = JsmnType.Any;
            tok.start = tok.end = -1;
            tok.size = 0;
#if JSMN_PARENT_LINKS
            tok.parent = -1;
#endif
#if DEBUG
            tok.source = this._js;
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
        JsmnError ParsePrimitive()
        {
            JsmnTok token;
            int start;
            var len = _js.Length;

            start = this.pos;

            for (; this.pos < len && _js[this.pos] != '\0'; this.pos++)
            {
                switch (_js[this.pos])
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
                if (_js[this.pos] < 32 || _js[this.pos] >= 127)
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
        JsmnError ParseString()
        {
            JsmnTok token;
            var len = _js.Length;

            int start = this.pos;

            this.pos++;

            /* Skip starting quote */
            for (; this.pos < len; this.pos++)
            {
                char c = _js[this.pos];

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
                    switch (_js[this.pos])
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
                            for (i = 0; i < 4 && this.pos < len && _js[this.pos] != '\0'; i++)
                            {
                                /* If it isn't a hex character we have an error */
                                if (!((_js[this.pos] >= 48 && _js[this.pos] <= 57) || /* 0-9 */
                                            (_js[this.pos] >= 65 && _js[this.pos] <= 70) || /* A-F */
                                            (_js[this.pos] >= 97 && _js[this.pos] <= 102)))
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
        public JsmnError ParseJson(string js)
        {
            JsmnError r;
            int i;
            JsmnTok token;
            int count = 0;
            int len = js.Length;

            this._js = js;

            for (; this.pos < len && _js[this.pos] != '\0'; this.pos++)
            {
                char c;
                JsmnType type;

                c = _js[this.pos];
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
                        r = ParseString();
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
                        r = ParsePrimitive();
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

        public Array<JsmnTok> Tokens
        {
            get
            {
                return this.tokens;
            }
        }
    }

    public struct JsmnParserValue
    {
        private int _selectedToken;

        private Array<JsmnTok> _tokens;

        public JsmnParserValue(int tokenIndex, Array<JsmnTok> tokens)
        {
            _selectedToken = tokenIndex;
            _tokens = tokens;
        }

        public JsmnParserValue this[string key]
        {
            get
            {
                return new JsmnParserValue(SeekValue(key), _tokens);
            }
        }

        public int Length
        {
            get
            {
                return this.GetArrayLength();
            }
        }

        public bool HasValue
        {
            get
            {
                return _selectedToken != -1;
            }
        }

        public bool IsNull
        {
            get
            {
                return !HasValue || IsNullHelper(this._selectedToken);
            }
        }

        public bool IsEmpty
        {
            get
            {
                return !HasValue || IsEmptyHelper(this._selectedToken);
            }
        }

        public JsmnType Type
        {
            get
            {
                return _tokens[this._selectedToken].type;
            }
        }

        public JsmnParserValue this[int index]
        {
            get
            {
                return new JsmnParserValue(SeekValue(index), _tokens);
            }
        }

        public static implicit operator bool(JsmnParserValue that)
        {
            if (!that.HasValue || that.IsNull)
            {
                return false;
            }

            if (that.Type == JsmnType.NotSet)
            {
                return false;
            }

            if (that.Type == JsmnType.Array || that.Type == JsmnType.Object)
            {
                return !that.IsEmpty;
            }

            if (that.Type == JsmnType.String)
            {
                return !that.IsEmpty;
            }

            var selectedValue = that.GetValue();

            try
            {
                return Convert.ToBoolean(selectedValue);
            }
            catch (FormatException)
            {
            }
            catch (Exception)
            {
                return false;
            }

            try
            {
                return (int)Convert.ToDouble(selectedValue) > 0;
            }
            catch (FormatException)
            {
            }

            return true;
        }

        public static implicit operator int(JsmnParserValue that)
        {
            var selectedValue = that.GetValue();
            return (int)Convert.ToDouble(selectedValue);
        }

        public static implicit operator double(JsmnParserValue that)
        {
            if (that.IsNull)
            {
                return 0.0;
            }

            var selectedValue = that.GetValue();
            return Convert.ToDouble(selectedValue);
        }

        public static implicit operator string(JsmnParserValue that)
        {
            if (that.IsNull)
            {
                return null;
            }

            var selectedValue = that.GetValue();
            return selectedValue;
        }

        public static implicit operator double[](JsmnParserValue that)
        {
            if (that.IsNull)
            {
                return null;
            }

            var index = 0;
            var values = new double[that.GetChildrenCount(that._selectedToken)];
            foreach (var childToken in that.GetChildrenTokens(that._selectedToken))
            {
                var selectedValue = that.GetValue(childToken);
                values[index++] = Convert.ToDouble(selectedValue);
            }

            return values;
        }

        public static implicit operator string[](JsmnParserValue that)
        {
            if (that.IsNull)
            {
                return null;
            }

            var index = 0;
            var values = new string[that.GetChildrenCount(that._selectedToken)];
            foreach (var childToken in that.GetChildrenTokens(that._selectedToken))
            {
                var selectedValue = that.GetValue(childToken);
                values[index++] = selectedValue;
            }

            return values;
        }

        private string GetValue()
        {
            if (_selectedToken == -1)
            {
                return null;
            }

            return _tokens[_selectedToken].Value;
        }

        private string GetValue(int token)
        {
            if (token == -1)
            {
                return null;
            }

            return _tokens[token].Value;
        }

        private int GetChildrenCount(int currentTokenIndex)
        {
            var current = _tokens[currentTokenIndex];
            return current.size;
        }

        private bool IsNullHelper(int currentTokenIndex)
        {
            var current = _tokens[currentTokenIndex];
            return current.EqualsTo("null");
        }

        private bool IsEmptyHelper(int currentTokenIndex)
        {
            var current = _tokens[currentTokenIndex];
            if (current.type == JsmnType.Array || current.type == JsmnType.Object)
            {
                return current.size == 0;
            }

            return current.type == JsmnType.Primitive &&
                   (current.start == current.end || current.start == -1 || current.end == -1);
        }

        private int SeekValue(string key)
        {
            var current = _tokens[_selectedToken];
            if (current.type != JsmnType.Object)
            {
                throw new NotSupportedException();
            }

            foreach (var childTokenIndex in this.GetChildrenTokens(_selectedToken))
            {
                var childToken = _tokens[childTokenIndex];
                if (childToken.EqualsTo(key))
                {
                    return GetFirstChildrenToken(childTokenIndex);
                }
            }

            return -1;
        }

        private int SeekValue(int indexToSelect)
        {
            var current = _tokens[_selectedToken];
            if (current.type != JsmnType.Array)
            {
                throw new NotSupportedException();
            }

            var index = -1;
            foreach (var childTokenIndex in this.GetChildrenTokens(_selectedToken))
            {
                if (++index == indexToSelect)
                {
                    return childTokenIndex;
                }
            }

            return -1;
        }

        private IEnumerable<int> GetChildrenTokens(int currentTokenIndex)
        {
            var current = _tokens[currentTokenIndex];
            var currentChildTokenIndex = currentTokenIndex + 1;
            var childToken = _tokens[currentChildTokenIndex];
            var size = current.size;
            while (size > 0)
            {
                if (childToken.parent == currentTokenIndex)
                {
                    size--;
                    yield return currentChildTokenIndex;
                }

                childToken = _tokens[++currentChildTokenIndex];
            }
        }

        private int GetFirstChildrenToken(int currentTokenIndex)
        {
            foreach (var childToken in this.GetChildrenTokens(currentTokenIndex))
            {
                return childToken;
            }

            throw new IndexOutOfRangeException();
        }

        private int GetArrayLength()
        {
            var current = _tokens[_selectedToken];

            if (current.type != JsmnType.Array)
            {
                throw new NotSupportedException();
            }

            return current.size;
        }
    }
}