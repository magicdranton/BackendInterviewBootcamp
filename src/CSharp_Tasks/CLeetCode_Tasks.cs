using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Tasks
{
    public class CLeetCode_Tasks
    {
        public static string MergeAlternately_1768(string word1, string word2)
        {
            StringBuilder sb = new StringBuilder(210);
            int charPtr = Math.Min(word1.Length, word2.Length);

            // Mix letters
            for (int i = 0; i < charPtr; i++)
            {
                sb.Append(word1[i]);
                sb.Append(word2[i]);
            }

            // Append word's tail
            if (charPtr < word1.Length)
            {
                sb.Append(word1.Substring(charPtr, word1.Length - charPtr));
            }

            if (charPtr < word2.Length)
            {
                sb.Append(word2.Substring(charPtr, word2.Length - charPtr));
            }

            return sb.ToString();
        }
    }
}
