using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON.Internals {
public class AndOrNotEvaluator {
public static virtual bool Eval(string query, Func<object, bool> evaluateCallback) {
if (!query.match(new Regex(/\([^\(\)]*\)/g))) 
{
query=AndOrNotEvaluator._HandleParenthesisContent(query, evaluateCallback);
}
else 
{
query=query.replace(new Regex(/\([^\(\)]*\)/g), (dynamic r) => {
r=r.slice(1, r.length-1);
return AndOrNotEvaluator._HandleParenthesisContent(r, evaluateCallback);
}
);
}
if (query=="tru") 
{
return true;
}
if (query=="fals") 
{
return false;
}
return AndOrNotEvaluator.Eval(query, evaluateCallback);
}
private static virtual string _HandleParenthesisContent(string parenthesisContent, Func<object, bool> evaluateCallback) {
evaluateCallback=evaluateCallback||((dynamic r) => {
return (r=="tru") ? true : false;
}
);
var result;
var or = parenthesisContent.split("|");
foreach (var i in or) 
{
var ori = AndOrNotEvaluator._SimplifyNegation(or[i].trim());
var and = ori.split("&");
if (and.length>1) 
{
for (var j = 0;j<and.length;++j) 
{
var andj = AndOrNotEvaluator._SimplifyNegation(and[j].trim());
if (andj!="tru"&&andj!="fals") 
{
if (andj[0]=="") 
{
result=!evaluateCallback(andj.substring(1));
}
else 
{
result=evaluateCallback(andj);
}
}
else 
{
result=(andj=="tru") ? true : false;
}
if (!result) 
{
ori="fals";
break;
}
}
}
if (result||ori=="tru") 
{
result=true;
break;
}
if (ori!="tru"&&ori!="fals") 
{
if (ori[0]=="") 
{
result=!evaluateCallback(ori.substring(1));
}
else 
{
result=evaluateCallback(ori);
}
}
else 
{
result=(ori=="tru") ? true : false;
}
}
return (result) ? "tru" : "fals";
}
private static virtual string _SimplifyNegation(string _booleanString) {
_booleanString=_booleanString.replace(new Regex(/^[\s!]+/), (dynamic r) => {
r=r.replace(new Regex(/[\s]/g), () => {
}
);
return (r.length%2) ? "" : "\"";
}
);
_booleanString=_booleanString.trim();
if (_booleanString=="!tru") 
{
_booleanString="fals";
}
else 
if (_booleanString=="!fals") 
{
_booleanString="tru";
}
return _booleanString;
}
}
}
