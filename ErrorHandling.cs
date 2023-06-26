using System;
using System.Text;

namespace Sorter{
    public enum ErrorType
    {
        INFO=0,
        WARNING=1,
        ERROR=2
    }
    public class Error{
        public static void Throw(ErrorType errorType, int errorNumber, string errorMessage){
            if(errorType == ErrorType.INFO){
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"INFO {errorNumber.ToString("00")}:");
            }else if(errorType == ErrorType.WARNING){
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"WARNING {errorNumber.ToString("00")}:");
            }else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"ERR {errorNumber.ToString("00")}:",ConsoleColor.Red);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" {errorMessage}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Environment.Exit(1);
        }
    }
}