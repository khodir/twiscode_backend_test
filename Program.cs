using System;
using System.Text;
using System.Collections.Generic;

namespace Twiscode
{
    class Program
    {
        static void Main(string[] args)
        {
            ValueConverter converter = new ValueConverter();
            
            Console.WriteLine("TEST 1 :");
            Console.WriteLine("9  : " + converter.Convert(9, ConvertType.DecimalToBinary));
            Console.WriteLine("19 : " + converter.Convert(19, ConvertType.DecimalToBinary));

            Console.WriteLine("1001  : " + converter.Convert(1001, ConvertType.BinaryToDecimal));
            Console.WriteLine("10011 : " + converter.Convert(10011, ConvertType.BinaryToDecimal));
            Console.WriteLine("================================================================");

            Console.WriteLine("TEST 2 :");
            Console.WriteLine(GetMaxPalindrome("aku suka makan nasi"));
            Console.WriteLine(GetMaxPalindrome("di rumah saya ada kasur rusak"));
            Console.WriteLine(GetMaxPalindrome("abcde edcbza"));
        }

        public static string GetMaxPalindrome(string input)
        {
            var arr = input.Split(" ");
            var maxPalindrome = string.Empty;

            for (var i = 0; i < arr.Length - 1; i++) {
                string str1 = arr[i];
                string str2 = arr[i+1];

                char[] str1Arr = str1.ToCharArray();
                char[] str2Arr = str2.ToCharArray();

                Array.Reverse(str1Arr);
                Array.Reverse(str2Arr);

                string str1Reverse = new string(str1Arr);
                string str2Reverse = new string(str2Arr);

                // Reverse for str1
                if (str1[str1.Length -1] == str2[0]) {
                    int max = 0;
                    int minLength = Math.Min(str1.Length, str2.Length);

                    for (var j = 0; j < minLength; j++) {
                        if (str1Reverse[j] == str2[j]) {
                            max++;
                        }
                    }

                    string str1Pal = str1.Substring(str1.Length - max);
                    string str2Pal = str2.Substring(0, str2.Length - (str2.Length - max));
                    string combinePal = str1Pal + " " + str2Pal;
                    if(combinePal.Length > maxPalindrome.Length) {
                        maxPalindrome = combinePal;
                    }
                }

                // Reverse for str2
                if(str1[0] == str2[str2.Length - 1]) {
                    int minLength = Math.Min(str1.Length, str2.Length);
                    bool palindrome = true;

                    for (var j = 0; j < minLength; j++) {
                        if (str2Reverse[j] != str1[j]) {
                            palindrome = false;
                            break;
                        }
                    }

                    if (palindrome) {
                        string combineVal = str1 + " " + str2;
                        if (combineVal.Length > maxPalindrome.Length) {
                            maxPalindrome = combineVal;
                        }
                    }
                }
            }

            return maxPalindrome;
        }
    }
}
