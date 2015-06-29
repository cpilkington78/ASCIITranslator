using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                    Console.WriteLine("Rerun program and provide a valid input data type.");
                    Thread.Sleep(3500);
                    Environment.Exit(0);
                }

                else if (dataType == "bin")
                {
                    Console.WriteLine("Enter a binary message for ASCII translation.");
                    string binString = Console.ReadLine().ToLower();

                    if (!BinaryCheck(binString))
                    {
                        Console.WriteLine("Not a valid binary message.");
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadLine();
                    }

                    else
                    {
                        StringBuilder userMessage = new StringBuilder();

                        for (int i = 0; i < binString.Length; i += 8)
                        {
                            string userBinaryString = binString.Substring(i, 8);
                            byte binaryInput = Convert.ToByte(userBinaryString, 2);
                            char byteResult = Convert.ToChar(binaryInput);
                            userMessage.Append(byteResult);
                        }

                        Console.WriteLine(userMessage);
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadLine();
                    }
                }

                else if (dataType == "oct")
                {
                    Console.WriteLine("Enter an octal message for ASCII translation.");
                    string octString = Console.ReadLine().ToLower();

                    if (!OctalCheck(octString))
                    {
                        Console.WriteLine("Not a valid octal message.");
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadLine();
                    }

                    else
                    {
                        StringBuilder userMessage = new StringBuilder();

                        for (int i = 0; i < octString.Length; i += 3)
                        {
                            string userOctalString = octString.Substring(i, 3);
                            int octalInput = Convert.ToInt32(userOctalString, 8);
                            char octalResult = Convert.ToChar(octalInput);
                            userMessage.Append(octalResult);
                        }

                        Console.WriteLine(userMessage);
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadLine();
                    }
                }

                else if (dataType == "hex")
                {
                    Console.WriteLine("Enter a hexadecimal message for ASCII translation.");
                    string hexString = Console.ReadLine().ToLower();

                    if (!HexadecimalCheck(hexString))
                    {
                        Console.WriteLine("Not a valid hexadecimal message.");
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadLine();
                    }

                    else
                    {
                        StringBuilder userMessage = new StringBuilder();

                        for (int i = 0; i < hexString.Length; i += 2)
                        {
                            string userHexString = hexString.Substring(i, 2);
                            int hexInput = Convert.ToInt32(userHexString, 16);
                            char hexResult = Convert.ToChar(hexInput);
                            userMessage.Append(hexResult);
                        }

                        Console.WriteLine(userMessage);
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadLine();
                    }
                }
            }

            else if (args.Length == 2)
            {
                string userArgs = args[0];
                string userPath = args[1];

                if (userArgs == "/f")
                {
                    Console.WriteLine("This is just a test.  Correct parameter was passed.");
                    Console.WriteLine("The path provided is:  {0}", userPath);
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadLine();
                }

                else
                {
                    Console.WriteLine("Invalid parameter input.  The only valid parameter is \"/F\".");
                    Console.WriteLine("Rerun program with valid input parameters.");
                    Thread.Sleep(3500);
                    Environment.Exit(0);
                }
            }

            else
            {
                Console.WriteLine("Invalid parameter input.  Only 2 parameters are allowed, \"/F\" and a file path.");
                Console.WriteLine("Rerun program with valid input parameters.");
                Thread.Sleep(3500);
                Environment.Exit(0);
            }
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

        private static bool OctalCheck(string userInput)
        {
            foreach (char c in userInput)
            {
                if (c >= '0' && c <= '7')
                    return true;
            }
            return false;
        }

        private static bool HexadecimalCheck(string userInput)
        {
            foreach (char c in userInput)
            {
                if ((c < '0' || c > '9') && (c < 'a' || c > 'f'))
                    return false;
            }
            return true;
        }
    }
}
