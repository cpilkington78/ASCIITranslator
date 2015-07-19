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
                    string binString = Console.ReadLine().ToLower().Trim();

                    string userMessage = BinTranslator.Translate(binString);
                    Console.WriteLine("\nYour binary message translated to ASCII is:\n\n{0}", userMessage);
                    Console.WriteLine("\nPress any key to exit.");
                    Console.ReadLine();
                }

                else if (dataType == "oct")
                {
                    Console.WriteLine("\nEnter an octal message for ASCII translation.\n");
                    string octString = Console.ReadLine().ToLower().Trim();

                    string userMessage = OctTranslator.Translate(octString);
                    Console.WriteLine("\nYour octal message translated to ASCII is:\n\n{0}", userMessage);
                    Console.WriteLine("\nPress any key to exit.");
                    Console.ReadLine();
                }

                else if (dataType == "hex")
                {
                    Console.WriteLine("\nEnter a hexadecimal message for ASCII translation.\n");
                    string hexString = Console.ReadLine().ToLower().Trim();

                    string userMessage = HexTranslator.Translate(hexString);
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
                        string userMessage = OctTranslator.Translate(data);
                        Console.WriteLine("\nYour octal message translated to ASCII is:\n\n{0}", userMessage);
                        Console.WriteLine("\nPress any key to exit.");
                        Console.ReadLine();
                    }

                    else if (type == 'h')
                    {
                        string userMessage = HexTranslator.Translate(data);
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
    }
}
