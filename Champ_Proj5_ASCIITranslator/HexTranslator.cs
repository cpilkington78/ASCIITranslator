using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Champ_Proj5_ASCIITranslator
{
    public class HexTranslator
    {
        public static string Translate(string hexString)
        {
            StringBuilder userMessage = new StringBuilder();
            if (ValidateData(hexString))
            {
                for (int i = 0; i < hexString.Length; i += 2)
                {
                    string userHexString = hexString.Substring(i, 2);
                    int hexInput = Convert.ToInt32(userHexString, 16);
                    char hexResult = Convert.ToChar(hexInput);
                    userMessage.Append(hexResult);
                }
            }
            return userMessage.ToString();
        }

        private static bool ValidateData(string data)
        {
            if (!HexadecimalCheck(data))
            {
                Console.WriteLine(ErrorCodes.GetErrorMessage(ErrorCodes.Codes.InvalidHex));
                Thread.Sleep(3200);
                Environment.Exit(0);
                return false;
            }

            else if (ValidHexCheck(data) != 0)
            {
                Console.WriteLine(ErrorCodes.GetErrorMessage(ErrorCodes.Codes.NotCompleteHex));
                Thread.Sleep(3200);
                Environment.Exit(0);
                return false;
            }
            return true;
        }

        private static bool HexadecimalCheck(string userInput)
        {
            foreach (char c in userInput)
            {
                if ((c < '0' || c > '9') && (c < 'a' || c > 'f') && (c < 'A' || c > 'F'))
                    return false;
            }
            return true;
        }

        private static int ValidHexCheck(string hexString)
        {
            int hexCount = 0;
            int mod;

            foreach (char c in hexString)
            {
                hexCount += 1;
            }

            mod = hexCount % 2;
            return mod;
        }
    }
}
