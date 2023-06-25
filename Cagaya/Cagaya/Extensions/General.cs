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
}