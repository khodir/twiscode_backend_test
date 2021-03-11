using System;

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

        public static bool CheckPalindrome(string str1, string str2)
        {
            bool result = true;
            str1 = str1.ToLower();
            str2 = str2.ToLower();

            if(str1.Length > str1.Length) {
                str1 = str1.Substring(0, str2.Length);
            }

            if(str2.Length > str1.Length) {
                str2 = str2.Substring(1, str1.Length);
            }

            for (int i = 0; i < str1.Length; i++) {
                if(str1[i] != str2[str2.Length - 1 - i]) {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public static string GetMaxPalindrome(string Text)
        {
            string result = string.Empty;
            string[] arr = Text.Split(" ");
            int maxLength = 0;
            
            for(var i = 0; i < arr.Length - 1; i++) {
                for(var j = 1; j < arr.Length; j++) {
                    if (CheckPalindrome(arr[i], arr[j])) {
                        int strLen = arr[i].Length + arr[j].Length;
                        
                        if(strLen > maxLength) {
                            maxLength = strLen;
                            result = string.Format("{0} {1}", arr[i], arr[j]);
                        }
                    }
                }
            }

            return result;
        }
    }
}
