using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Champ_Proj5_ASCIITranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please specify the input data type for console input ASCII translation (Bin, Oct, or Hex).\n");
                string dataType = Console.ReadLine().ToLower().Trim();

                ValidateDataType(dataType);

                if (dataType == "bin")
                {
                    Console.WriteLine("\nEnter a binary message for ASCII translation.\n");
                    string binString = Console.ReadLine().ToLower();

                    string userMessage = BinTranslator.Translate(binString);
                    Console.WriteLine("\nYour binary message translated to ASCII is:\n\n{0}", userMessage);
                    Console.WriteLine("\nPress any key to exit.");
                    Console.ReadLine();
                }

                else if (dataType == "oct")
                {
                    Console.WriteLine("\nEnter an octal message for ASCII translation.\n");
                    string octString = Console.ReadLine().ToLower();

                    ValidateOctData(octString);
                    
                        StringBuilder userMessage = new StringBuilder();
                        for (int i = 0; i < octString.Length; i += 3)
                        {
                            string userOctalString = octString.Substring(i, 3);
                            int octalInput = Convert.ToInt32(userOctalString, 8);
                            char octalResult = Convert.ToChar(octalInput);
                            userMessage.Append(octalResult);
                        }

                        Console.WriteLine("\nYour octal message translated to ASCII is:\n\n{0}", userMessage);
                        Console.WriteLine("\nPress any key to exit.");
                        Console.ReadLine();
                }

                else if (dataType == "hex")
                {
                    Console.WriteLine("\nEnter a hexadecimal message for ASCII translation.\n");
                    string hexString = Console.ReadLine().ToLower();

                    ValidateHexData(hexString);

                    StringBuilder userMessage = new StringBuilder();
                    for (int i = 0; i < hexString.Length; i += 2)
                    {
                        string userHexString = hexString.Substring(i, 2);
                        int hexInput = Convert.ToInt32(userHexString, 16);
                        char hexResult = Convert.ToChar(hexInput);
                        userMessage.Append(hexResult);
                    }

                    Console.WriteLine("\nYour hexadecimal message translated to ASCII is:\n\n{0}", userMessage);
                    Console.WriteLine("\nPress any key to exit.");
                    Console.ReadLine();
                }
            }

            else if (args.Length == 2)
            {
                string userArgs = args[0].ToLower();
                string userPath = args[1];

                if (userArgs == "/f")
                {
                    char type = char.MinValue;
                    string data = "";
                    ValidateFilePath(userPath, ref type, ref data);

                    if (type == 'b')
                    {
                        string userMessage = BinTranslator.Translate(data);
                        Console.WriteLine("\nYour binary message translated to ASCII is:\n\n{0}", userMessage);
                        Console.WriteLine("\nPress any key to exit.");
                        Console.ReadLine();
                    }

                    else if (type == 'o')
                    {
                        ValidateOctData(data);

                        StringBuilder userMessage = new StringBuilder();
                        for (int i = 0; i < data.Length; i += 3)
                        {
                            string userOctalString = data.Substring(i, 3);
                            int octalInput = Convert.ToInt32(userOctalString, 8);
                            char octalResult = Convert.ToChar(octalInput);
                            userMessage.Append(octalResult);
                        }

                        Console.WriteLine("\nYour octal message translated to ASCII is:\n\n{0}", userMessage);
                        Console.WriteLine("\nPress any key to exit.");
                        Console.ReadLine();
                    }

                    else if (type == 'h')
                    {
                        ValidateHexData(data);
                            
                        StringBuilder userMessage = new StringBuilder();
                        for (int i = 0; i < data.Length; i += 2)
                        {
                            string userHexString = data.Substring(i, 2);
                            int hexInput = Convert.ToInt32(userHexString, 16);
                            char hexResult = Convert.ToChar(hexInput);
                            userMessage.Append(hexResult);
                        }

                        Console.WriteLine("\nYour hexadecimal message translated to ASCII is:\n\n{0}", userMessage);
                        Console.WriteLine("\nPress any key to exit.");
                        Console.ReadLine();
                    }

                    else
                    {
                        Console.WriteLine(ErrorCodes.GetErrorMessage(ErrorCodes.Codes.InvalidFileType));
                        Thread.Sleep(3200);
                        Environment.Exit(0);
                    }
                }

                else
                {
                    Console.WriteLine(ErrorCodes.GetErrorMessage(ErrorCodes.Codes.InvalidInputParameter));
                    Thread.Sleep(3200);
                    Environment.Exit(0);
                }
            }

            else
            {
                Console.WriteLine(ErrorCodes.GetErrorMessage(ErrorCodes.Codes.InvalidNumParameters));
                Thread.Sleep(3200);
                Environment.Exit(0);
            }
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

        private static bool HexadecimalCheck(string userInput)
        {
            foreach (char c in userInput)
            {
                if ((c < '0' || c > '9') && (c < 'a' || c > 'f') && (c < 'A' || c > 'F'))
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

        private static bool ReadFile(string strFile, ref char type, ref string data)
        {
            if (File.Exists(strFile))
            {
                using (StreamReader myReader = new StreamReader(strFile))
                {
                    if (myReader.Peek() >= 0)
                    {
                        type = Convert.ToChar(myReader.Read());
                        data = myReader.ReadToEnd().Replace("\r", "").Replace("\n", "");
                    }
                    else
                    {
                        Console.WriteLine(ErrorCodes.GetErrorMessage(ErrorCodes.Codes.BlankFile));
                        Thread.Sleep(3200);
                        Environment.Exit(0);
                    }
                }
                return true;
            }
            return false;
        }

        private static bool ValidateDataType(string dataType)
        {
            if (dataType != "bin" && dataType != "oct" && dataType != "hex")
            {
                Console.WriteLine(ErrorCodes.GetErrorMessage(ErrorCodes.Codes.InvalidDataType));
                Thread.Sleep(3200);
                Environment.Exit(0);
                return false;
            }
            return true;
        }

        private static bool ValidateFilePath(string userPath, ref char type, ref string data)
        {
            type = char.MinValue;
            data = "";
            if (!ReadFile(userPath, ref type, ref data))
            {
                Console.WriteLine(ErrorCodes.GetErrorMessage(ErrorCodes.Codes.NoFile));
                Thread.Sleep(3200);
                Environment.Exit(0);
                return false;
            }
            return true;
        }

        private static bool ValidateOctData(string data)
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

        private static bool ValidateHexData(string data)
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
    }
}
