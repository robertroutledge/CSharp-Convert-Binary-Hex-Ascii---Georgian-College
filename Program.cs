using BDAT1001_Assignment1_Routledge.Models;
using System;
using System.IO;
using System.Text;

namespace BDAT1001_Assignment1_Routledge
{
    class Program
    {

        /// Prints Binary from Ascii, Ascii from Binary, Hex from ASCII and ASCII from Hex.
        static void Main(string[] args)
        {
            PrintBinaryfromASCII();
            PrintAsciifromBinary();
            PrintHexfromASCII();
            PrintASCIIfromHex();
            PrintAsciifromB64();
            PrintBase64fromASCII();
        }

        /// Requests a string and returns it as binary
        static void PrintBinaryfromASCII()
        {
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();

            BinaryConverter converter = new BinaryConverter();
            string binaryname = converter.ConvertTo(name);
            Console.WriteLine("Your Name in Binary name is: " + binaryname);
        }

        /// Requests a binary value and converts it to ASCII
        static void PrintAsciifromBinary()
        {
            try
            {
                Console.WriteLine("Please enter a binary value to covert to ASCII, (visible characters range from 0010 0001 to 0111 1110)");
                string userbinary = Console.ReadLine();
                userbinary = userbinary.PadLeft(8, '0');
                BinaryConverter asciiconverter = new BinaryConverter();
                string asciiname = asciiconverter.ConvertBinaryToString(userbinary);
                Console.WriteLine($"The ASCII value of {userbinary} is {asciiname}");
            }
            catch
            {
                Console.WriteLine("Please try again: ");
                string userbinary = Console.ReadLine();
                BinaryConverter asciiconverter = new BinaryConverter();
                string asciiname = asciiconverter.ConvertBinaryToString(userbinary);
                Console.WriteLine($"The ASCII value of {userbinary} is {asciiname}");
            }
        }

        /// Asks user for word, prints Hex value of that word
        static void PrintHexfromASCII()
        {

            Console.WriteLine("Please enter a word to covert to Hexadecimal: ");
            string username = Console.ReadLine();
            HexadecimalConverter hexconverter = new HexadecimalConverter();
            string hexname = hexconverter.ConvertTo(username);
            Console.WriteLine($"The Hex value of {username} is {hexname}");

        }

        /// Asks users for Hex, prints Ascii value
        static void PrintASCIIfromHex()
        {
            try
            {
                Console.WriteLine("Please enter Hex to print as ASCII (visible characters from 021 to 07e): ");
                string userhex = Console.ReadLine();
                HexadecimalConverter hexconverter = new HexadecimalConverter();
                string hexname = hexconverter.ConveryFromHexToASCII(userhex);
                Console.WriteLine($"The Hex value of {userhex} is {hexname}");
            }
            catch
            {
                Console.WriteLine("Please try again: ");
                string userhex = Console.ReadLine();
                HexadecimalConverter hexconverter = new HexadecimalConverter();
                string hexname = hexconverter.ConveryFromHexToASCII(userhex);
                Console.WriteLine($"The Hex value of {userhex} is {hexname}");
            }
        }
        static void PrintAsciifromB64()
        {
            Console.WriteLine("Please enter ASCII to print as Base64: ");
            string userascii = Console.ReadLine();
            string nameBase64Encoded = Base64Converter.StringToBase64(userascii);
            Console.WriteLine(nameBase64Encoded);
        }

        static void PrintBase64fromASCII()
        {
            try
            {
                Console.WriteLine("Please enter Base64 to print as ASCII: ");
                string userb64 = Console.ReadLine();
                string nameASCIIEncoded = Base64Converter.Base64ToString(userb64);
                Console.WriteLine(nameASCIIEncoded);
            }
            catch
            {
                Console.WriteLine("Please try again: ");
                string userb64 = Console.ReadLine();
                BinaryConverter asciiconverter = new BinaryConverter();
                string nameASCIIEncoded = Base64Converter.Base64ToString(userb64);
                Console.WriteLine(nameASCIIEncoded);
            }
        }
    }
}
