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
        enum ErrorCodes
        {
            InvalidDataType,
            InvalidBinary,
            NotCompleteByte,
            InvalidOctal,
            NotCompleteOctal,
            InvalidHex,
            NotCompleteHex,
            NoFile,
            InvalidFileType,
            InvalidInputParameter,
            InvalidNumParameters,
            BlankFile,
            InvalidBinaryFile,
            NotCompleteByteFile,
            InvalidOctalFile,
            NotCompleteOctalFile,
            InvalidHexFile,
            NotCompleteHexFile,
            OK
        }

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please specify the input data type for console input ASCII translation (Bin, Oct, or Hex).\n");
                string dataType = Console.ReadLine().ToLower();

                if (dataType != "bin" && dataType != "oct" && dataType!= "hex")
                {
                    Console.WriteLine(GetErrorMessage(ErrorCodes.InvalidDataType));
                    Thread.Sleep(3200);
                    Environment.Exit(0);
                }

                else if (dataType == "bin")
                {
                    Console.WriteLine("\nEnter a binary message for ASCII translation.\n");
                    string binString = Console.ReadLine().ToLower();

                    if (!BinaryCheck(binString))
                    {
                        Console.WriteLine(GetErrorMessage(ErrorCodes.InvalidBinary));
                        Thread.Sleep(3200);
                        Environment.Exit(0);
                    }

                    else
                    {
                        if (ValidByteCheck(binString) != 0)
                        {
                            Console.WriteLine(GetErrorMessage(ErrorCodes.NotCompleteByte));
                            Thread.Sleep(3200);
                            Environment.Exit(0);
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

                            Console.WriteLine("\nYour binary message translated to ASCII is:\n\n{0}", userMessage);
                            Console.WriteLine("\nPress any key to exit.");
                            Console.ReadLine();
                        }
                    }
                }

                else if (dataType == "oct")
                {
                    Console.WriteLine("\nEnter an octal message for ASCII translation.\n");
                    string octString = Console.ReadLine().ToLower();

                    if (!OctalCheck(octString))
                    {
                        Console.WriteLine(GetErrorMessage(ErrorCodes.InvalidOctal));
                        Thread.Sleep(3200);
                        Environment.Exit(0);
                    }

                    else
                    {
                        if (ValidOctCheck(octString) != 0)
                        {
                            Console.WriteLine(GetErrorMessage(ErrorCodes.NotCompleteOctal));
                            Thread.Sleep(3200);
                            Environment.Exit(0);
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

                            Console.WriteLine("\nYour octal message translated to ASCII is:\n\n{0}", userMessage);
                            Console.WriteLine("\nPress any key to exit.");
                            Console.ReadLine();
                        }
                    }
                }

                else if (dataType == "hex")
                {
                    Console.WriteLine("\nEnter a hexadecimal message for ASCII translation.\n");
                    string hexString = Console.ReadLine().ToLower();

                    if (!HexadecimalCheck(hexString))
                    {
                        Console.WriteLine(GetErrorMessage(ErrorCodes.InvalidHex));
                        Thread.Sleep(3200);
                        Environment.Exit(0);
                    }

                    else
                    {
                        if (ValidHexCheck(hexString) != 0)
                        {
                            Console.WriteLine(GetErrorMessage(ErrorCodes.NotCompleteHex));
                            Thread.Sleep(3200);
                            Environment.Exit(0);
                        }
                        
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
            }

            else if (args.Length == 2)
            {
                string userArgs = args[0];
                string userPath = args[1];

                if (userArgs == "/f")
                {
                    char type = char.MinValue;
                    string data = "";
                    if (!ReadFile(userPath, ref type, ref data))
                    {
                        Console.WriteLine(GetErrorMessage(ErrorCodes.NoFile));
                        Thread.Sleep(3200);
                        Environment.Exit(0);
                    }
                    else
                    {
                        if (type == 'b')
                        {
                            if (!BinaryCheck(data))
                            {
                                Console.WriteLine(GetErrorMessage(ErrorCodes.InvalidBinaryFile));
                                Thread.Sleep(3200);
                                Environment.Exit(0);
                            }

                            else
                            {
                                if (ValidByteCheck(data) != 0)
                                {
                                    Console.WriteLine(GetErrorMessage(ErrorCodes.NotCompleteByteFile));
                                    Thread.Sleep(3200);
                                    Environment.Exit(0);
                                }

                                else
                                {
                                    StringBuilder userMessage = new StringBuilder();

                                    for (int i = 0; i < data.Length; i += 8)
                                    {
                                        string userBinaryString = data.Substring(i, 8);
                                        byte binaryInput = Convert.ToByte(userBinaryString, 2);
                                        char byteResult = Convert.ToChar(binaryInput);
                                        userMessage.Append(byteResult);
                                    }

                                    Console.WriteLine("\nYour binary message translated to ASCII is:\n\n{0}", userMessage);
                                    Console.WriteLine("\nPress any key to exit.");
                                    Console.ReadLine();
                                }
                            }
                        }

                        else if (type == 'o')
                        {
                            if (!OctalCheck(data))
                            {
                                Console.WriteLine(GetErrorMessage(ErrorCodes.InvalidOctal));
                                Thread.Sleep(3200);
                                Environment.Exit(0);
                            }

                            else
                            {
                                if (ValidOctCheck(data) != 0)
                                {
                                    Console.WriteLine(GetErrorMessage(ErrorCodes.NotCompleteOctal));
                                    Thread.Sleep(3200);
                                    Environment.Exit(0);
                                }

                                else
                                {
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
                            }
                        }

                        else if (type == 'h')
                        {
                            if (!HexadecimalCheck(data))
                            {
                                Console.WriteLine(GetErrorMessage(ErrorCodes.InvalidHex));
                                Thread.Sleep(3200);
                                Environment.Exit(0);
                            }

                            else
                            {
                                if (ValidHexCheck(data) != 0)
                                {
                                    Console.WriteLine(GetErrorMessage(ErrorCodes.NotCompleteHex));
                                    Thread.Sleep(3200);
                                    Environment.Exit(0);
                                }

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
                        }

                        else
                        {
                            Console.WriteLine(GetErrorMessage(ErrorCodes.InvalidFileType));
                            Thread.Sleep(3200);
                            
                            Environment.Exit(0);
                        }
                    }
                }

                else
                {
                    Console.WriteLine(GetErrorMessage(ErrorCodes.InvalidInputParameter));
                    Thread.Sleep(3200);
                    Environment.Exit(0);
                }
            }

            else
            {
                Console.WriteLine(GetErrorMessage(ErrorCodes.InvalidNumParameters));
                Thread.Sleep(3200);
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
                        Console.WriteLine(GetErrorMessage(ErrorCodes.BlankFile));
                        Thread.Sleep(3200);
                        Environment.Exit(0);
                    }
                }
                return true;
            }
            return false;
        }

        private static string GetErrorMessage(ErrorCodes err)
        {
            switch (err)
            {
                case ErrorCodes.InvalidDataType:
                    return "\nInvalid input data type.\nRe-run program and provide a valid input data type.";
                case ErrorCodes.InvalidBinary:
                    return "\nInvalid binary message.\nRe-run program and enter a valid binary message.";
                case ErrorCodes.NotCompleteByte:
                    return "\nInvalid message.  Binary units must be in bytes, or mutliples of 8.\nRe-run program and enter valid binary message in byte format.";
                case ErrorCodes.InvalidOctal:
                    return "\nInvalid octal message.\nRe-run program and enter a valid octal message.";
                case ErrorCodes.NotCompleteOctal:
                    return "\nInvalid message.  Octal units must be in multiples of 3.\nRe-run program and enter valid octal message with units in multiples of 3.";
                case ErrorCodes.InvalidHex:
                    return "\nInvalid hexadecimal message.\nRe-run program and enter a valid hexadecimal message.";
                case ErrorCodes.NotCompleteHex:
                    return "\nInvalid message.  Hexadecimal units must be in multiples of 2.\nRe-run program and enter valid hexadecimal message with units in multiples of 2.";
                case ErrorCodes.NoFile:
                    return "\nFile does not exist.\nRe-run program with a valid path to a file.";
                case ErrorCodes.InvalidFileType:
                    return "\nInvalide file type.  File type must be b, o, or h.\nRe-run the program with a valid file type.";
                case ErrorCodes.InvalidInputParameter:
                    return "\nInvalid parameter input.  The only valid parameter is \"/F\".\nRe-run program with valid input parameters.";
                case ErrorCodes.InvalidNumParameters:
                    return "\nInvalid parameter input.  Only 2 parameters are allowed, \"/F\" and a file path.\nRe-run program with valid input parameters.";
                case ErrorCodes.BlankFile:
                    return "\nInvalid text file.  File is blank.\nRe-run program with a valid file to translate.";
                case ErrorCodes.InvalidBinaryFile:
                    return "\nInvalid text file.\nRe-run program and provide a path to a valid binary text file.";
                case ErrorCodes.NotCompleteByteFile:
                    return "\nInvalid text file.  Binary units must be in bytes, or mutliples of 8.\nRe-run program and enter a path to a valid binary file in byte format.";
                case ErrorCodes.InvalidOctalFile:
                    return "\nInvalid text file.\nRe-run program and provide a path to a valid octal text file.";
                case ErrorCodes.NotCompleteOctalFile:
                    return "\nInvalid text file.  Octal units must be in multiples of 3.\nRe-run program and enter a path to a valid octal text file with units in multiples of 3.";
                case ErrorCodes.InvalidHexFile:
                    return "\nInvalid text file.\nRe-run program and provide a path to a valid hexadecimal text file.";
                case ErrorCodes.NotCompleteHexFile:
                    return "\nInvalid text file.  Hexadecimal units must be in multiples of 2.\nRe-run program and enter a path to a valid hexadecimal text file with units in multiples of 2.";
                default:
                    return "\nUnknown error.";
            }
        }
    }
}
