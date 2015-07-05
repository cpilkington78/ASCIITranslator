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
                Console.WriteLine("Please specify the input data type for console input ASCII translation (Bin, Oct, or Hex).");
                string dataType = Console.ReadLine().ToLower();

                if (dataType != "bin" && dataType != "oct" && dataType!= "hex")
                {
                    Console.WriteLine("Invalid input data type.");
                    Console.WriteLine("Rerun program and provide a valid input data type.");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }

                else if (dataType == "bin")
                {
                    Console.WriteLine("Enter a binary message for ASCII translation.");
                    string binString = Console.ReadLine().ToLower();

                    if (!BinaryCheck(binString))
                    {
                        Console.WriteLine("Not a valid binary message.");
                        Console.WriteLine("Re-run program and enter a valid binary message.");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }

                    else
                    {
                        if (ValidByteCheck(binString) != 0)
                        {
                            Console.WriteLine("Binary message not in bytes, or mutliples of 8.");
                            Console.WriteLine("Rerun program and enter valid binary message in byte format.");
                            Thread.Sleep(3000);
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

                            Console.WriteLine(userMessage);
                            Console.WriteLine("Press any key to exit.");
                            Console.ReadLine();
                        }
                    }
                }

                else if (dataType == "oct")
                {
                    Console.WriteLine("Enter an octal message for ASCII translation.");
                    string octString = Console.ReadLine().ToLower();

                    if (!OctalCheck(octString))
                    {
                        Console.WriteLine("Not a valid octal message.");
                        Console.WriteLine("Rerun program and enter valid octal message.");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }

                    else
                    {
                        if (ValidOctCheck(octString) != 0)
                        {
                            Console.WriteLine("Invalid Octal message.  Octal message not in multiples of 3.");
                            Console.WriteLine("Rerun program and enter valid octal message in multiples of 3.");
                            Thread.Sleep(3000);
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

                            Console.WriteLine(userMessage);
                            Console.WriteLine("Press any key to exit.");
                            Console.ReadLine();
                        }
                    }
                }

                else if (dataType == "hex")
                {
                    Console.WriteLine("Enter a hexadecimal message for ASCII translation.");
                    string hexString = Console.ReadLine().ToLower();

                    if (!HexadecimalCheck(hexString))
                    {
                        Console.WriteLine("Not a valid hexadecimal message.");
                        Console.WriteLine("Rerun program and enter valid hexadecimal message.");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }

                    else
                    {
                        if (ValidHexCheck(hexString) != 0)
                        {
                            Console.WriteLine("Invalid Hexadecimal message.  Hexadecimal message not in multiples of 2.");
                            Console.WriteLine("Rerun program and enter valid hexadecimal message in multiples of 2.");
                            Thread.Sleep(3000);
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
                    char type = char.MinValue;
                    string data = "";
                    if (!ReadFile(userPath, ref type, ref data))
                    {
                        Console.WriteLine("File does not exist.");
                        Console.WriteLine("Re-run program with a valid path to a file.");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }
                    else
                    {
                        if (type == 'b')
                        {
                            StringBuilder userMessage = new StringBuilder();

                            for (int i = 0; i < data.Length; i += 8)
                            {
                                string userBinaryString = data.Substring(i, 8);
                                byte binaryInput = Convert.ToByte(userBinaryString, 2);
                                char byteResult = Convert.ToChar(binaryInput);
                                userMessage.Append(byteResult);
                            }

                            Console.WriteLine(userMessage);
                            Console.WriteLine("Press any key to exit.");
                            Console.ReadLine();
                        }

                        else if (type == 'o')
                        {
                            StringBuilder userMessage = new StringBuilder();

                            for (int i = 0; i < data.Length; i += 3)
                            {
                                string userOctalString = data.Substring(i, 3);
                                int octalInput = Convert.ToInt32(userOctalString, 8);
                                char octalResult = Convert.ToChar(octalInput);
                                userMessage.Append(octalResult);
                            }

                            Console.WriteLine(userMessage);
                            Console.WriteLine("Press any key to exit.");
                            Console.ReadLine();
                        }

                        else if (type == 'h')
                        {
                            StringBuilder userMessage = new StringBuilder();

                            for (int i = 0; i < data.Length; i += 2)
                            {
                                string userHexString = data.Substring(i, 2);
                                int hexInput = Convert.ToInt32(userHexString, 16);
                                char hexResult = Convert.ToChar(hexInput);
                                userMessage.Append(hexResult);
                            }

                            Console.WriteLine(userMessage);
                            Console.WriteLine("Press any key to exit.");
                            Console.ReadLine();
                        }

                        else
                        {
                            Console.WriteLine("Invalide file type.  File type must be b, o, or h.");
                            Console.WriteLine("Re-run the program with a valid file type.");
                            Thread.Sleep(3000);
                            
                            Environment.Exit(0);
                        }
                    }
                }

                else
                {
                    Console.WriteLine("Invalid parameter input.  The only valid parameter is \"/F\".");
                    Console.WriteLine("Re-run program with valid input parameters.");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
            }

            else
            {
                Console.WriteLine("Invalid parameter input.  Only 2 parameters are allowed, \"/F\" and a file path.");
                Console.WriteLine("Re-run program with valid input parameters.");
                Thread.Sleep(3000);
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
                        Console.WriteLine("File is blank.");
                        Console.WriteLine("Re-run program with a valid file to convert.");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }
                }
                return true;
            }
            return false;
        }
    }
}
