// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.andOrNotEvaluator.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON.Internals
{
    /// <summary>
    /// </summary>
    public partial class AndOrNotEvaluator
    {
        /*
        public static bool Eval(string query, System.Func<object, bool> evaluateCallback)
        {
            if (!(new Regex(@"\([^\(\)]*\)").Match(query).Success))
            {
                query = AndOrNotEvaluator._HandleParenthesisContent(query, evaluateCallback);
            }
            else
            {
                throw new NotImplementedException();
                ////query = query.replace(new Regex(@"\([^\(\)]*\)"), (r) => {
                ////    r = r.slice(1, r.Length - 1);
                ////    return AndOrNotEvaluator._HandleParenthesisContent(r, evaluateCallback);
                ////});
            }
            if (query == "true")
            {
                return true;
            }
            if (query == "false")
            {
                return false;
            }
            return AndOrNotEvaluator.Eval(query, evaluateCallback);
        }
        private static string _HandleParenthesisContent(string parenthesisContent, System.Func<object, bool> evaluateCallback)
        {
            evaluateCallback = evaluateCallback ?? ((string r) =>
            {
                return (r == "true") ? true : false;
            });
            var result;
            var or = parenthesisContent.Split("||");
            foreach (var i in or)
            {
                var ori = AndOrNotEvaluator._SimplifyNegation(or[i].Trim());
                var and = ori.Split("&&");
                if (and.Length > 1)
                {
                    for (var j = 0; j < and.Length; ++j)
                    {
                        var andj = AndOrNotEvaluator._SimplifyNegation(and[j].Trim());
                        if (andj != "true" && andj != "false")
                        {
                            if (andj[0] == "!")
                            {
                                result = !evaluateCallback(andj.Substring(1));
                            }
                            else
                            {
                                result = evaluateCallback(andj);
                            }
                        }
                        else
                        {
                            result = (andj == "true") ? true : false;
                        }
                        if (!result)
                        {
                            ori = "false";
                            break;
                        }
                    }
                }
                if (result || ori == "true")
                {
                    result = true;
                    break;
                }
                if (ori != "true" && ori != "false")
                {
                    if (ori[0] == "!")
                    {
                        result = !evaluateCallback(ori.Substring(1));
                    }
                    else
                    {
                        result = evaluateCallback(ori);
                    }
                }
                else
                {
                    result = (ori == "true") ? true : false;
                }
            }
            return (result) ? "true" : "false";
        }
        private static string _SimplifyNegation(string booleanString)
        {
            ////booleanString = booleanString.replace(new Regex(@"^[\s!]+"), (r) => {
            ////    r = r.replace(new Regex(@"[\s]"), () => "");
            ////    return (r.Length % 2) ? "!" : "";
            ////});
            booleanString = booleanString.Trim();
            if (booleanString == "!true")
            {
                booleanString = "false";
            }
            else
                if (booleanString == "!false")
                {
                    booleanString = "true";
                }
            return booleanString;
        }
         */
    }
}