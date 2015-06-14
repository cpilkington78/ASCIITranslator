using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champ_Proj5_ASCIITranslator
{
    class Program
    {
		//Chris Champion is now a contributor! yay.
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please specify the input data type for console input ASCII translation (Bin, Oct, or Hex).");
                string dataType = Console.ReadLine().ToLower();

                if (dataType != "bin" && dataType != "oct" && dataType!= "hex")
                {
                    Console.WriteLine("Invalid input data type.");
                    Console.ReadLine();
                }

                else if (dataType == "bin")
                {
                    Console.WriteLine("Enter a binary message for ASCII translation.");
                    string binString = Console.ReadLine().ToLower();
                    
                    StringBuilder userMessage = new StringBuilder();

                    for (int i = 0; i < binString.Length; i += 8)
                    {
                        string userBinaryString = binString.Substring(i, 8);
                        byte binaryInput = Convert.ToByte(userBinaryString, 2);
                        char byteResult = Convert.ToChar(binaryInput);
                        userMessage.Append(byteResult);
                    }

                    Console.WriteLine(userMessage);
                    Console.ReadLine();
                }

                else if (dataType == "oct")
                {
                    Console.WriteLine("Enter an octal message for ASCII translation.");
                    string octString = Console.ReadLine().ToLower();

                    StringBuilder userMessage = new StringBuilder();

                    for (int i = 0; i < octString.Length; i += 3)
                    {
                        string userOctalString = octString.Substring(i, 3);
                        int octalInput = Convert.ToInt32(userOctalString, 8);
                        char octalResult = Convert.ToChar(octalInput);
                        userMessage.Append(octalResult);
                    }

                    Console.WriteLine(userMessage);
                    Console.ReadLine();
                }

                else if (dataType == "hex")
                {
                    Console.WriteLine("Enter a hexidecimal message for ASCII translation.");
                    string hexString = Console.ReadLine().ToLower();

                    StringBuilder userMessage = new StringBuilder();

                    for (int i = 0; i < hexString.Length; i += 2)
                    {
                        string userHexString = hexString.Substring(i, 2);
                        int hexInput = Convert.ToInt32(userHexString, 16);
                        char hexResult = Convert.ToChar(hexInput);
                        userMessage.Append(hexResult);
                    }

                    Console.WriteLine(userMessage);
                    Console.ReadLine();
                }
            }
        }
    }
}
