using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON.Internals {
    public partial class AndOrNotEvaluator {
        public static bool Eval(string query, System.Func < object, bool > evaluateCallback) {
            if (!query.match(new Regex(/\([^\(\)]*\)/g))) {
                query = AndOrNotEvaluator._HandleParenthesisContent(query, evaluateCallback);
            } else {
                query = query.replace(new Regex(/\([^\(\)]*\)/g), (r) => {
                    r = r.slice(1, r.Length - 1);
                    return AndOrNotEvaluator._HandleParenthesisContent(r, evaluateCallback);
                });
            }
            if (query == "true") {
                return true;
            }
            if (query == "false") {
                return false;
            }
            return AndOrNotEvaluator.Eval(query, evaluateCallback);
        }
        private static string _HandleParenthesisContent(string parenthesisContent, System.Func < object, bool > evaluateCallback) {
            evaluateCallback = evaluateCallback || ((object r) => {
                return (r == "true") ? true : false;
            });
            var result;
            var or = parenthesisContent.Split("||");
            foreach(var i in or) {
                var ori = AndOrNotEvaluator._SimplifyNegation(or[i].trim());
                var and = ori.Split("&&");
                if (and.Length > 1) {
                    for (var j = 0; j < and.Length; ++j) {
                        var andj = AndOrNotEvaluator._SimplifyNegation(and[j].trim());
                        if (andj != "true" && andj != "false") {
                            if (andj[0] == "!") {
                                result = !evaluateCallback(andj.Substring(1));
                            } else {
                                result = evaluateCallback(andj);
                            }
                        } else {
                            result = (andj == "true") ? true : false;
                        }
                        if (!result) {
                            ori = "false";
                            break;
                        }
                    }
                }
                if (result || ori == "true") {
                    result = true;
                    break;
                }
                if (ori != "true" && ori != "false") {
                    if (ori[0] == "!") {
                        result = !evaluateCallback(ori.Substring(1));
                    } else {
                        result = evaluateCallback(ori);
                    }
                } else {
                    result = (ori == "true") ? true : false;
                }
            }
            return (result) ? "true" : "false";
        }
        private static string _SimplifyNegation(string booleanString) {
            booleanString = booleanString.replace(new Regex(/^[\s!]+/), (r) => {
                r = r.replace(new Regex(/[\s]/g), () => "");
                return (r.Length % 2) ? "!" : "";
            });
            booleanString = booleanString.trim();
            if (booleanString == "!true") {
                booleanString = "false";
            } else
            if (booleanString == "!false") {
                booleanString = "true";
            }
            return booleanString;
        }
    }
}