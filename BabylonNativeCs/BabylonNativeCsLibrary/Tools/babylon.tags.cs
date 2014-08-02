using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class Tags
    {
        /*
        public static void EnableFor(object obj)
        {
            obj._tags = obj._tags || new { };
            obj.hasTags = () =>
            {
                return Tags.HasTags(obj);
            };
            obj.addTags = (object tagsString) =>
            {
                return Tags.AddTagsTo(obj, tagsString);
            };
            obj.removeTags = (object tagsString) =>
            {
                return Tags.RemoveTagsFrom(obj, tagsString);
            };
            obj.matchesTagsQuery = (object tagsQuery) =>
            {
                return Tags.MatchesQuery(obj, tagsQuery);
            };
        }
        public static void DisableFor(object obj)
        {
            obj._tags = null;
            obj.hasTags = null;
            obj.addTags = null;
            obj.removeTags = null;
            obj.matchesTagsQuery = null;
        }
        public static bool HasTags(object obj)
        {
            if (!obj._tags)
            {
                return false;
            }
            return !BABYLON.Tools.IsEmpty(obj._tags);
        }
        public static object GetTags(object obj)
        {
            if (!obj._tags)
            {
                return null;
            }
            return obj._tags;
        }
        public static void AddTagsTo(object obj, string tagsString)
        {
            if (tagsString == null)
            {
                return;
            }
            var tags = tagsString.Split(' ');
            foreach (var t in tags)
            {
                Tags._AddTagTo(obj, tags[t]);
            }
        }
        public static void _AddTagTo(object obj, string tag)
        {
            tag = tag.Trim();
            if (tag == "" || tag == "true" || tag == "false")
            {
                return;
            }
            if (new Regex(@"[\s]").Match(tag).Success || new Regex(@"^([!]|([|]|[&]){2})").Match(tag).Success)
            {
                return;
            }
            Tags.EnableFor(obj);
            obj._tags[tag] = true;
        }
        public static void RemoveTagsFrom(object obj, string tagsString)
        {
            if (!Tags.HasTags(obj))
            {
                return;
            }
            var tags = tagsString.Split(' ');
            foreach (var t in tags)
            {
                Tags._RemoveTagFrom(obj, tags[t]);
            }
        }
        public static void _RemoveTagFrom(object obj, string tag)
        {
            obj._tags[tag] = null;
        }
        public static bool MatchesQuery(object obj, string tagsQuery)
        {
            if (tagsQuery == null)
            {
                return true;
            }
            if (tagsQuery == "")
            {
                return Tags.HasTags(obj);
            }
            return Internals.AndOrNotEvaluator.Eval(tagsQuery, (r) => Tags.HasTags(obj) && obj._tags[r]);
        }
        */
    }
}