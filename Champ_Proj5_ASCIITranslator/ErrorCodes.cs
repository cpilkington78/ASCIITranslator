﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champ_Proj5_ASCIITranslator
{
    public static class ErrorCodes
    {
        public enum Codes
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

        public static string GetErrorMessage(Codes err)
        {
            switch (err)
            {
                case Codes.InvalidDataType:
                    return "\nInvalid input data type.\nRe-run program and provide a valid input data type.";
                case Codes.InvalidBinary:
                    return "\nInvalid binary message.\nRe-run program and enter a valid binary message.";
                case Codes.NotCompleteByte:
                    return "\nInvalid message.  Binary units must be in bytes, or mutliples of 8.\nRe-run program and enter valid binary message in byte format.";
                case Codes.InvalidOctal:
                    return "\nInvalid octal message.\nRe-run program and enter a valid octal message.";
                case Codes.NotCompleteOctal:
                    return "\nInvalid message.  Octal units must be in multiples of 3.\nRe-run program and enter valid octal message with units in multiples of 3.";
                case Codes.InvalidHex:
                    return "\nInvalid hexadecimal message.\nRe-run program and enter a valid hexadecimal message.";
                case Codes.NotCompleteHex:
                    return "\nInvalid message.  Hexadecimal units must be in multiples of 2.\nRe-run program and enter valid hexadecimal message with units in multiples of 2.";
                case Codes.NoFile:
                    return "\nFile does not exist.\nRe-run program with a valid path to a file.";
                case Codes.InvalidFileType:
                    return "\nInvalide file type.  File type must be b, o, or h.\nRe-run the program with a valid file type.";
                case Codes.InvalidInputParameter:
                    return "\nInvalid parameter input.  The only valid parameter is \"/F\".\nRe-run program with valid input parameters.";
                case Codes.InvalidNumParameters:
                    return "\nInvalid parameter input.  Only 2 parameters are allowed, \"/F\" and a file path.\nRe-run program with valid input parameters.";
                case Codes.BlankFile:
                    return "\nInvalid text file.  File is blank.\nRe-run program with a valid file to translate.";
                case Codes.InvalidBinaryFile:
                    return "\nInvalid text file.\nRe-run program and provide a path to a valid binary text file.";
                case Codes.NotCompleteByteFile:
                    return "\nInvalid text file.  Binary units must be in bytes, or mutliples of 8.\nRe-run program and enter a path to a valid binary file in byte format.";
                case Codes.InvalidOctalFile:
                    return "\nInvalid text file.\nRe-run program and provide a path to a valid octal text file.";
                case Codes.NotCompleteOctalFile:
                    return "\nInvalid text file.  Octal units must be in multiples of 3.\nRe-run program and enter a path to a valid octal text file with units in multiples of 3.";
                case Codes.InvalidHexFile:
                    return "\nInvalid text file.\nRe-run program and provide a path to a valid hexadecimal text file.";
                case Codes.NotCompleteHexFile:
                    return "\nInvalid text file.  Hexadecimal units must be in multiples of 2.\nRe-run program and enter a path to a valid hexadecimal text file with units in multiples of 2.";
                default:
                    return "\nUnknown error.";
            }
        }
    }
}
