using System;

namespace Twiscode
{
    public enum ConvertType
    {
        DecimalToBinary, BinaryToDecimal
    }

    public class ValueConverter
    {
        protected long ConvertDecimalToBin(long Value)
        {
            long remainder;
            string result = string.Empty;

            while (Value > 0)
            {
                remainder = Value % 2;
                Value /= 2;
                result = remainder.ToString() + result;
            }

            return long.Parse(result);
        }

        protected long ConvertBinToDecimal(long Value)
        {
            char[] array = Value.ToString().ToCharArray();
            long result = 0;
            Array.Reverse(array);

            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                    if (i == 0)
                    {
                        result += 1;
                    }
                    else
                    {
                        result += (int)Math.Pow(2, i);
                    }
                }

            }

            return result;
        }

        public long Convert(long Value, ConvertType type)
        {
            long result;
            if (type == ConvertType.DecimalToBinary) {
                result = ConvertDecimalToBin(Value);
            } else {
                result = ConvertBinToDecimal(Value);
            }

            return result;
        }
    }
}