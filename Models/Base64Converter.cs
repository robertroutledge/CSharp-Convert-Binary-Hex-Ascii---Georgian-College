using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BDAT1001_Assignment1_Routledge.Models
{
   public class Base64Converter
    {/// <summary>
     /// Encodes a String to a Base64 String
     /// </summary>
     /// <param name="data">String data</param>
     /// <returns>Base64 Encoded String</returns>
        public static string StringToBase64(string data)
        {
            byte[] bytearray = Encoding.ASCII.GetBytes(data);

            string result = Convert.ToBase64String(bytearray);

            return result;
        }


        public static string Base64ToString(string base64String)
        {
            byte[] bytearray = Convert.FromBase64String(base64String);

            using (var ms = new MemoryStream(bytearray))
            {
                using (StreamReader reader = new StreamReader(ms))
                {
                    string text = reader.ReadToEnd();
                    return text;
                }
            }

        }
    }
}
