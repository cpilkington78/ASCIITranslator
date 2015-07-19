using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Champ_Proj5_ASCIITranslator
{
    public class OctTranslator
    {
        public static string Translate(string octString)
        {
            StringBuilder userMessage = new StringBuilder();
            if (ValidateData(octString))
            {
                for (int i = 0; i < octString.Length; i += 3)
                {
                    string userOctalString = octString.Substring(i, 3);
                    int octalInput = Convert.ToInt32(userOctalString, 8);
                    char octalResult = Convert.ToChar(octalInput);
                    userMessage.Append(octalResult);
                }
            }
            return userMessage.ToString();
        }

        private static bool ValidateData(string data)
        {
            if (!OctalCheck(data))
            {
                Console.WriteLine(ErrorCodes.GetErrorMessage(ErrorCodes.Codes.InvalidOctal));
                Thread.Sleep(3200);
                Environment.Exit(0);
                return false;
            }

            else if (ValidOctCheck(data) != 0)
            {
                Console.WriteLine(ErrorCodes.GetErrorMessage(ErrorCodes.Codes.NotCompleteOctal));
                Thread.Sleep(3200);
                Environment.Exit(0);
                return false;
            }
            return true;
        }

        private static bool OctalCheck(string userInput)
        {
            foreach (char c in userInput)
            {
                if (c < '0' || c > '7')
                    return false;
            }
            return true;
        }

        private static int ValidOctCheck(string octString)
        {
            int octCount = 0;
            int mod;

            foreach (char c in octString)
            {
                octCount += 1;
            }

            mod = octCount % 3;
            return mod;
        }
    }
}
