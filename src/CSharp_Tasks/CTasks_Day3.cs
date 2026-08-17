using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Tasks;


public class CTasks_Day3
{
    /*
     Дан отсортированный по возрастанию массив целых положительных чисел. И число Target - требуемая сумма. 
    Задача: найти хотя бы один вариант суммы двух чисел массива, равный Target. Ответ вернуть массивом двух индексов [0,1]
    Если сумма не найдена, вернуть [-1,-1]
    Решить за O(N)
     */
    public static int[] FindTwoSum(int[] input, int target)
    {
        /*
         Лучше всего подходит "алгоритм двух указателей". Так как сортированный массив - это монотонная неубывающая функция, то поиск прост: 
            - Если сумма больше, то двигаем правый указатель
            - Если сумма меньше, то двигаем левый указатель
            - Похоже на "метод градиентного спуска" при поиске локальных оптимумов. ПОскольку функция монотонная, мы придём к оптимуму, но не факт, что точно (сумма может не найтись)
         */
        if (input.Length < 2) return [-1,-1];

        int v_LeftPtr = 0;
        int v_RightPtr = input.Length - 1;

        while (v_LeftPtr < v_RightPtr)
        {
            int v_Sum = input[v_LeftPtr] + input[v_RightPtr];

            if (v_Sum == target)
            {
                return [v_LeftPtr, v_RightPtr]; // Found
            }
            else if (v_Sum < target)
            {
                v_LeftPtr++;    // Move left ptr, increase sum
            }
            else
            {
                v_RightPtr--;   // MOve right ptr, decrease sum
            }
        }

        return [-1, -1];    // Sum not found
    }

    /*
     Дана строка символов. Нужно за O(N) найти и вернуть первый уникальный (неповторяющийся) символ строки.
    Если таких символов нет, вернуть null.
     */
    public static char? FirstNonRepeating(string input)
    {
        /*
         Алгоритм простой: идём по строке и считаем повторы символов в словарь. Потом смотрим словарь и находим первый уникальный символ. В сумме будет N + N = O(N)
         */
        Dictionary<char, int> charCnt = new Dictionary<char, int>();

        for (int i=0; i<input.Length; i++)
        {
            char c = input[i];

            if (!charCnt.ContainsKey(c))
            {
                charCnt.Add(c, 1);
            }
            else
            {
                charCnt[c]++;
            }
        }

        foreach (KeyValuePair<char, int> pair in  charCnt)  // Порядок обхода важен. Здесь итератор пойдёт от начала словаря (~ от начала строки)
        {
            if (pair.Value == 1) return pair.Key;   // Found !!
        }

        return null;
    }

    /*
     Дана строка символов. Требуется за O(N) найти в ней подстроку максимальной длины из неповторяющихся символов. 
     Вернуть длину строки и строку
     */
    public static (int, string?) LongestSubstringWoRepeatingChars(string input)
    {
        /*
         Реализация - алгоритм "скользящего окна": расширением правой границы набираем уникальные символы, сокращением левой границы убираем неуникальные символы.
        Хэш-сет соответствует уникальному набору символов в текущем окне и позволяет быстро искать символы за O(1)
         */
        HashSet<char> chrHash = new HashSet<char>();

        if (String.IsNullOrEmpty(input)) return (0, null);

        int lftPtr = 0;
        int rtPtr = 0;
        int maxWndSize = 0;
        int maxWndPtr = 0;

        while (rtPtr < input.Length)
        {
            // Expanding wnd
            while (rtPtr < input.Length)
            {
                if (chrHash.Contains(input[rtPtr])) break; // duplicate found

                if (maxWndSize < (rtPtr - lftPtr + 1))
                {
                    maxWndSize = rtPtr - lftPtr + 1;
                    maxWndPtr = lftPtr;                    
                }

                chrHash.Add(input[rtPtr]);
                rtPtr++;
            }

            if (rtPtr >= input.Length) break;   // end of str
            
            // otherwise, we must collapse wnd
            while (lftPtr < rtPtr)
            {
                if (!chrHash.Contains(input[rtPtr])) break; // eliminated duplicate

                chrHash.Remove(input[lftPtr]);
                lftPtr++;
            }
        }

        return (maxWndSize, input.Substring(maxWndPtr, maxWndSize));
    }
}