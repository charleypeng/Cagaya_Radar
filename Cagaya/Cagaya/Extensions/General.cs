using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Linq;
using DynamicData;

namespace Cagaya;

public static class General
{
    /// <summary>
    /// To check whether the given string is null or empty white space
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsEmptyString(this string str)
    {
        return !string.IsNullOrWhiteSpace(str);
    }
    
    /// <summary>
    /// To assume a certain string reversely contains in a certain string 
    /// </summary>
    /// <param name="str1">basic string</param>
    /// <param name="str2">the given string</param>
    /// <returns></returns>
    public static bool ReverseContain(this string str1, string str2)
    {
        if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
            return false;

        return str2.Contains(str1);
    }
    /// <summary>
    /// Add Non-Null object into a list
    /// </summary>
    /// <param name="lst">non-empty list</param>
    /// <param name="item">item object</param>
    /// <typeparam name="T">given object type</typeparam>
    public static void AddNonNullListObject<T>(this IList<IEnumerable<T>>? lst, IEnumerable<T>? item)
    {
        if (item == null)
        {
            return;
        }

        var enumerable = item.ToList();
        if (!enumerable.IsNullOrEmpty())
        {
            lst?.Add(enumerable);
        }
    }
    /// <summary>
    /// To ensure whether the given list is null or empty
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? list)
    {
        return list == null || !list.Any();
    }
    public static void ReplaceIfNotEqual<T>(this ICollection<T> collection, Func<T,bool> match, T newItem)
    {
        var oldItem = collection.FirstOrDefault(match);
        if (oldItem == null)
        {
            return;
        }

        var index = collection.IndexOf(oldItem);

        if (index >= 0)
        {
            //collection[index] = newItem;
        }
    }
    public static double? Reset(this double? item, double max)
    {
        var rd = new Random();
        return item > max? rd.Next(0, (int)max) : item;
    }
    /// <summary>
    /// Name Generator
    /// </summary>
    public static class NameGenerator
    {
        /// <summary>
        /// Generate a random name
        /// </summary>
        /// <param name="len">length</param>
        /// <returns></returns>
        public static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            var b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }
    }
    
    /// <summary>
    /// returns a boolean where collection1 equals collection2 no matter the order
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="comparer1">integer list</param>
    /// <param name="comparer2">integer list</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static bool SameAs<T>(this IEnumerable<T>? comparer1, IEnumerable<T>? comparer2)
    {
        var myObject = Activator.CreateInstance<T>();

        var myLong = myObject as long?;

        if (myLong == null)
            throw new Exception($"the given type '{typeof(T)}' should be integer");

        if (comparer1 == null || comparer2 == null)
            return false;

        if (comparer1 == null && comparer2 == null)
            return true;

        if(comparer1?.Count() != comparer2?.Count())
            return false;

        var c1 = comparer1?.OrderBy(x=>x).ToList();
        var c2 = comparer2?.OrderBy(x=>x).ToList();

        bool isSame = false;
        for (var i = 0; i < c1?.Count; i++)
        {
            isSame = c1[i]!.Equals(c2![i]);

            if (!isSame)
                break;
        }

        return isSame;
    }
}