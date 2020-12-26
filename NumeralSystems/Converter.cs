using System;
using System.Text;

namespace NumeralSystems
{
    public static class Converter
    {
        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the octal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the octal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveOctal(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Thrown if number is less than zero.");
            }

            int num;
            StringBuilder octalNum = new StringBuilder();
            num = number;
            while (num != 0)
            {
                octalNum.Insert(0, num % 8);
                num /= 8;
            }

            return octalNum.ToString();
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the decimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the decimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveDecimal(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Thrown if number is less than zero.");
            }

            int num;
            StringBuilder dec = new StringBuilder();
            num = number;
            while (num != 0)
            {
                dec.Insert(0, num % 10);
                num /= 10;
            }

            return dec.ToString();
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the hexadecimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the hexadecimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveHex(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Thrown if number is less than zero.");
            }

            int num;
            StringBuilder hex = new StringBuilder();
            num = number;
            while (num != 0)
            {
                switch (num % 16)
                {
                    case 10:
                        hex.Insert(0, 'A');
                        break;
                    case 11:
                        hex.Insert(0, 'B');
                        break;
                    case 12:
                        hex.Insert(0, 'C');
                        break;
                    case 13:
                        hex.Insert(0, 'D');
                        break;
                    case 14:
                        hex.Insert(0, 'E');
                        break;
                    case 15:
                        hex.Insert(0, 'F');
                        break;
                    default:
                        hex.Insert(0, num % 16);
                        break;
                }
                
                num /= 16;
            }

            return hex.ToString();
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveRadix(this int number, int radix)
        {
            if (number < 0)
            {
                throw new ArgumentException("Thrown if number is less than zero.");
            }

            if (radix != 8 ^ radix != 10 ^ radix != 16)
            {
                throw new ArgumentException("Thrown if radix is not equal 8, 10 or 16.");
            }

            switch (radix)
            {
                case 8:
                    return GetPositiveOctal(number);
                case 16:
                    return GetPositiveHex(number);
                default:
                    return GetPositiveDecimal(number);
            }
        }

        /// <summary>
        /// Gets the value of a signed integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        public static string GetRadix(this int number, int radix)
        {
            if (radix != 8 ^ radix != 10 ^ radix != 16)
            {
                throw new ArgumentException("Thrown if radix is not equal 8, 10 or 16.");
            }

            StringBuilder result = new StringBuilder();

            switch (radix)
            {
                case 8:
                    result.Append(GetPositiveOctal(number & int.MaxValue));
                    result = (result.Length == 0) ? result.Append("20000000000") : result.Replace('1', '3', 0, 1);
                    break;
                case 16:
                    result.Append(GetPositiveHex(number & int.MaxValue));
                    result = (result.Length == 0) ? result.Append("80000000") : result.Replace('7', 'F', 0, 1);
                    break;
                default:
                    result.Append(GetPositiveDecimal(number & int.MaxValue));
                    break;
            }

            return result.ToString();
        }
    }
}
