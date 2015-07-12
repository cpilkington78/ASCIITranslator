using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Champ_Proj5_ASCIITranslator
{
    public class BinTranslator
    {
        public static string Translate(string binString)
        {
            StringBuilder userMessage = new StringBuilder();
            if (ValidateData(binString))
            {
                for (int i = 0; i < binString.Length; i += 8)
                {
                    string userBinaryString = binString.Substring(i, 8);
                    byte binaryInput = Convert.ToByte(userBinaryString, 2);
                    char byteResult = Convert.ToChar(binaryInput);
                    userMessage.Append(byteResult);
                }
            }
            return userMessage.ToString();
        }

        private static bool ValidateData(string data)
        {
            if (!BinaryCheck(data))
            {
                Console.WriteLine(ErrorCodes.GetErrorMessage(ErrorCodes.Codes.InvalidBinary));
                Thread.Sleep(3200);
                Environment.Exit(0);
                return false;
            }

            else if (ValidByteCheck(data) != 0)
            {
                Console.WriteLine(ErrorCodes.GetErrorMessage(ErrorCodes.Codes.NotCompleteByte));
                Thread.Sleep(3200);
                Environment.Exit(0);
                return false;
            }
            return true;
        }

        private static bool BinaryCheck(string userInput)
        {
            foreach (char c in userInput)
            {
                if (c != '0' && c != '1')
                    return false;
            }
            return true;
        }

        private static int ValidByteCheck(string binString)
        {
            int bitCount = 0;
            int mod;

            foreach (char c in binString)
            {
                bitCount += 1;
            }

            mod = bitCount % 8;
            return mod;
        }
    }
}
