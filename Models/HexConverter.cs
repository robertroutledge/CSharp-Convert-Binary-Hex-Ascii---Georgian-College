using System;

namespace BDAT1001_Assignment1_Routledge.Models
{
    public class HexadecimalConverter
    {
        int[] positionvalues = { 8, 4, 2, 1 };

        private BinaryConverter _binaryConverter = new BinaryConverter();

        /// <summary>
        /// Converts a string value into a Hexadecimal string equivalent
        /// </summary>
        /// <param name="word">A string of characters</param>
        /// <returns>word converted to Hexadecimal</returns>
        public string ConvertTo(string word)
        {
            string output = "";

            //Iterate over all elements in the array of characters
            for (int i = 0; i < word.Length; i++)
            {
                //Get one letter
                string letter = word.Substring(i, 1);

                //Convert the letter to a char data type
                char charletter = System.Convert.ToChar(letter);

                string binaryvalue = _binaryConverter.ConvertTo(letter);
                string hexvalue = ConvertBinaryToHexadecimal(binaryvalue);

                //Append the binary output to the final output
                output += hexvalue;
            }

            return (output);
        }

        /// <summary>
        /// Converts Hexadecimal to Binary
        /// </summary>
        /// <param name="hexvalue">Hexadecimal formated string</param>
        /// <returns>Binary string</returns>
        public string ConveryFromHexToBinary(string hexvalue)
        {
            string output = "";

            char[] hexparts = hexvalue.ToUpper().ToCharArray();
            for (int i = 0; i < hexvalue.Length; i += 2)
            {
                int hexpart1ascii = HexPartToASCII(hexparts[i]);
                int hexpart2ascii = HexPartToASCII(hexparts[i + 1]);

                output += String.Format("{0}{1}",
                            HexPartToBinary(hexpart1ascii),
                            HexPartToBinary(hexpart2ascii));
            }

            return (output.Trim());
        }

        /// <summary>
        /// Converts Hexadecimal from Binary to ASCII string
        /// </summary>
        /// <param name="hexvalue">Hexadecimal formated string</param>
        /// <returns>ASCII string</returns>
        public string ConveryFromHexToASCII(string hexvalue)
        {
            string output = "";
            string binary = ConveryFromHexToBinary(hexvalue);

            output = _binaryConverter.ConvertBinaryToString(binary);

            return (output.Trim());
        }

        public int HexPartToASCII(char hexpart)
        {
            if (hexpart > 47 && hexpart < 58) //0 - 9 Decimal Value
            {
                return (System.Convert.ToInt32(hexpart));
            }

            if (hexpart > 64 && hexpart < 71) //A - F Value 10 - 16
            {
                int ret = hexpart - 55;
                return (ret);
            }

            return (0);
        }

        public string HexPartToBinary(int asciivalue)
        {
            string output = String.Format("{0}{1}{2}{3}",
                _binaryConverter.BitValue(PostionalValue(asciivalue, 8)),
                _binaryConverter.BitValue(PostionalValue(asciivalue, 4)),
                _binaryConverter.BitValue(PostionalValue(asciivalue, 2)),
                _binaryConverter.BitValue(PostionalValue(asciivalue, 1)));

            return (output);
        }

        public string ConvertBinaryToHexadecimal(string binaryvalue)
        {
            string output = "";

            if (binaryvalue.Length < 8)
                throw new Exception("Invalid binary octet, format 00000000");

            string part1 = binaryvalue.Substring(0, 4); //Get first 16 bits of binary set
            string part2 = binaryvalue.Substring(4, 4); //Get second 16 bits of binary set

            string part1product = NumbersToHex(Bit8(part1) + Bit4(part1) + Bit2(part1) + Bit1(part1));
            string part2product = NumbersToHex(Bit8(part2) + Bit4(part2) + Bit2(part2) + Bit1(part2));

            //Format an output conprised of the combination of all binary bits
            output = String.Format("{0}{1}",
                part1product,
                part2product
                );

            return (output);
        }

        private string NumbersToHex(int decimalvalue)
        {
            string output = System.Convert.ToString(decimalvalue);

            if (decimalvalue > 9)
            {
                char charvalue = (char)(64 + decimalvalue - 9);
                output = new String(charvalue, 1);

                return output;
            }

            return (output);
        }

        public int Bit8(string binaryvalue)
        {
            int position = 0;
            int bit = positionvalues[position];

            string part = binaryvalue.Substring(position, 1);

            int value = System.Convert.ToInt32(part);

            if (value == 1)
                return (bit);

            return (0);
        }

        public int Bit4(string binaryvalue)
        {
            int position = 1;
            int bit = positionvalues[position];

            string part = binaryvalue.Substring(position, 1);

            int value = System.Convert.ToInt32(part);

            if (value == 1)
                return (bit);

            return (0);
        }

        public int Bit2(string binaryvalue)
        {
            int position = 2;
            int bit = positionvalues[position];

            string part = binaryvalue.Substring(position, 1);

            int value = System.Convert.ToInt32(part);

            if (value == 1)
                return (bit);

            return (0);
        }

        public int Bit1(string binaryvalue)
        {
            int position = 3;
            int bit = positionvalues[position];

            string part = binaryvalue.Substring(position, 1);

            int value = System.Convert.ToInt32(part);

            if (value == 1)
                return (bit);

            return (0);
        }

        public decimal PostionalValue(int value, int bit)
        {
            //Get the remainder of ASCII value divided by previous bit value
            decimal modout = value % (bit * 2);

            //Divide the remainder by the current bit value
            decimal binaryoutput = modout / bit;

            return (binaryoutput);
        }

    }
}
