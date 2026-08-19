using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Tasks
{
    public class CLeetCode_Tasks
    {
        public static string MergeAlternately_1768(string word1, string word2)
        {
            StringBuilder sb = new StringBuilder(word1.Length + word2.Length);
            int minLen = Math.Min(word1.Length, word2.Length);

            // Mix letters
            for (int i = 0; i < minLen; i++)
            {
                sb.Append(word1[i]);
                sb.Append(word2[i]);
            }

            // Append word's tail
            if (minLen < word1.Length)
            {
                sb.Append(word1, minLen, word1.Length - minLen);
            }

            if (minLen < word2.Length)
            {
                sb.Append(word2, minLen, word2.Length - minLen);
            }

            return sb.ToString();
        }
    }
}
