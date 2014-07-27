using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class Tags {
public static virtual void EnableFor(object obj) {
obj._tags=obj._tags||new dynamic();
obj.hasTags=() => {
return Tags.HasTags(obj);
}
;
obj.addTags=(dynamic tagsString) => {
return Tags.AddTagsTo(obj, tagsString);
}
;
obj.removeTags=(dynamic tagsString) => {
return Tags.RemoveTagsFrom(obj, tagsString);
}
;
obj.matchesTagsQuery=(dynamic tagsQuery) => {
return Tags.MatchesQuery(obj, tagsQuery);
}
;
}
public static virtual void DisableFor(object obj) {
obj._tags = null;
obj.hasTags = null;
obj.addTags = null;
obj.removeTags = null;
obj.matchesTagsQuery = null;
}
public static virtual bool HasTags(object obj) {
if (!obj._tags) 
{
return false;
}
return !BABYLON.Tools.IsEmpty(obj._tags);
}
public static virtual object GetTags(object obj) {
if (!obj._tags) 
{
return null;
}
return obj._tags;
}
public static virtual void AddTagsTo(object obj, string tagsString) {
if (!tagsString) 
{
return;
}
var tags = tagsString.split("");
foreach (var t in tags) 
{
Tags._AddTagTo(obj, tags[t]);
}
}
public static virtual void _AddTagTo(object obj, string tag) {
tag=tag.trim();
if (tag=="\""||tag=="tru"||tag=="fals") 
{
return;
}
if (tag.match(new Regex(/[\s]/))||tag.match(new Regex(/^([!]|([|]|[&]){2})/))) 
{
return;
}
Tags.EnableFor(obj);
obj._tags[tag]=true;
}
public static virtual void RemoveTagsFrom(object obj, string tagsString) {
if (!Tags.HasTags(obj)) 
{
return;
}
var tags = tagsString.split("");
foreach (var t in tags) 
{
Tags._RemoveTagFrom(obj, tags[t]);
}
}
public static virtual void _RemoveTagFrom(object obj, string tag) {
obj._tags[tag] = null;
}
public static virtual bool MatchesQuery(object obj, string tagsQuery) {
if (tagsQuery==undefined) 
{
return true;
}
if (tagsQuery=="\"") 
{
return Tags.HasTags(obj);
}
return Internals.AndOrNotEvaluator.Eval(tagsQuery, (dynamic r) => {
}
);
}
}
}
