using System;
using System.Collections.Generic;

namespace MonogameExercises
{
    class Program
    {
        public static void Main()
        {
            Program program;
            program = new Program();
            Console.WriteLine(program.ForFactorial(5));
            Console.WriteLine(program.RecFactorial(5));
        }

        #region Exercise 11.6
        string ThreeTimes(string text)
        {
            string returnText = "";
            for (int i = 0; i < 3; i++)
            {
                returnText += text;
            }
            return returnText;
        }
        string SixtyTimes(string text)
        {
            string returnText = "";
            for (int i = 0; i < 60; i++)
            {
                returnText += text;
            }
            return returnText;
        }
        string ManyTimes(string text, int times)
        {
            string returnText = "";
            for (int i = 0; i < times; i++)
            {
                returnText += text;
            }
            return returnText;
        }
        string Stripes(int number)
        {
            string stripes = "";
            for (int i = 0; i < number; i++)
            {
                stripes += "|";
            }
            return stripes;
        }
        string Cuneiform(int number)
        {
            string s = "";
            for (int digit = 0; number > 0; digit++)
            {
                s = Stripes(number % 10) + "--" +s;
                number /= 10;
            }
            return "--" + s;
        }
        #endregion

        #region Exercise 13.6
        private int CountZeros(int[] intArr)
        {
            int counter = 0;
            for (int i = 0;i < intArr.Length; i++)
            {
                if(intArr[i] == 0)
                {
                    counter += 1;
                }
            }
            return counter;
        }
        private int[] AddArrays(int[] intArr1, int[] intArr2)
        {
            int arrLength = intArr1.Length;
            int[] sumArr = new int[arrLength];
            for(int i = 0; i < arrLength;i++)
            {
                sumArr[i] = intArr1[i] + intArr2[i];
            }
            return sumArr;
        }

        private bool IsAllUppercase(string s)
        {
            for(int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c < 'A' || c > 'Z')
                    return false;
            }
            return true;
        }

        private string ToLowercase(string s)
        {
            string res = "";
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c > 'A' && c < 'Z')
                    res += (char)(c + ('a' - 'A'));
                else
                    res += c;
            }
            return res;
        }

        private int FirstPosition(string s, char c)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if(c == s[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private string Replace(string s, char first, char second)
        {
            string res = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == first)
                {
                    res += second;
                }
                else
                {
                    res += s[i];
                }
            }
            return res;
        }

        private bool EndsWith(string a, string b)
        {
            if(b.Length > a.Length)
            {
                return false;
            }
            int x = a.Length - 1;
            int y = b.Length - 1;
            while( 0 <= y)
            {
              if(b[y] != a[x])
                {
                    return false;
                }
                y--;
                x--;
            }
            return true;
        }

        void RemoveDuplicates(List<int> list)
        {

        }
        #endregion

        #region Exercise 14.7

        private int ForFactorial(int n)
        {
            int result = 1;
            for(;n > 0 ;n--)
            {
                result *= n;
            }
            return result;

        }

        private int RecFactorial(int n)
        {
            if (n == 1)
                return n;
            return RecFactorial(n - 1) * n;

        }
        private string Reverse(string s, int last, int first)
        {
            if (first > last)
                return "";
            if (first == last)
                return s[first].ToString();
            return s[last] + Reverse(s, first + 1, last - 1) + s[first];
        }

        #endregion

    }

}
