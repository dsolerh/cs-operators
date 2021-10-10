using System;
using System.IO;

using static System.Console;

namespace cs_operators
{
    class Program
    {
        static void Main(string[] args)
        {
            Clear();
            WriteLine("\nUnary operators:\n");
            int a = 3;
            int b = a++;
            WriteLine($"a is {a}, b is {b}");

            int c = 3;
            int d = ++c; // increment c before assigning it
            WriteLine($"c is {c}, d is {d}");

            WriteLine("\nArithmetic operators:\n");
            int e = 11;
            int f = 3;
            WriteLine($"e is {e}, f is {f}");
            WriteLine($"e + f = {e + f}");
            WriteLine($"e - f = {e - f}");
            WriteLine($"e * f = {e * f}");
            WriteLine($"e / f = {e / f}");
            WriteLine($"e % f = {e % f}");

            double g = 11.0;
            WriteLine($"g is {g:N1}, f is {f}");
            WriteLine($"g / f = {g / f}");

            WriteLine("\nBoolean operators:\n");
            bool x = true;
            bool y = false;
            WriteLine($"AND | x     | y     ");
            WriteLine($"x   | {x & x,-5} | {x & y,-5} ");
            WriteLine($"y   | {y & x,-5} | {y & y,-5} ");
            WriteLine();
            WriteLine($"OR  | x     | y     ");
            WriteLine($"x   | {x | x,-5} | {x | y,-5} ");
            WriteLine($"y   | {y | x,-5} | {y | y,-5} ");
            WriteLine();
            WriteLine($"XOR | x     | y     ");
            WriteLine($"x   | {x ^ x,-5} | {x ^ y,-5} ");
            WriteLine($"y   | {y ^ x,-5} | {y ^ y,-5} ");

            WriteLine($"a & DoStuff() = {x & DoStuff()}");
            WriteLine($"b & DoStuff() = {y & DoStuff()}");

            WriteLine("\nBitwise and binary shift operators:\n");

            a = 10; // 0000 1010
            b = 6; // 0000 0110

            WriteLine($"a = {a}");
            WriteLine($"b = {b}");
            WriteLine($"a & b = {a & b}"); // 2-bit column only
            WriteLine($"a | b = {a | b}"); // 8, 4, and 2-bit columns
            WriteLine($"a ^ b = {a ^ b}"); // 8 and 4-bit columns

            // 0101 0000 left-shift a by three bit columns
            WriteLine($"a << 3 = {a << 3}");
            // multiply a by 8
            WriteLine($"a * 8 = {a * 8}");
            // 0000 0011 right-shift b by one bit column
            WriteLine($"b >> 1 = {b >> 1}");

            WriteLine("\nBranching with the if statement:\n");

            if (args.Length == 0)
            {
                WriteLine("There are no arguments.");
            }
            else
            {
                WriteLine("There is at least one argument.");
            }

            // add and remove the "" to change the behavior
            object o = "3";
            int j = 4;
            if (o is int i)
            {
                WriteLine($"{i} x {j} = {i * j}");
            }
            else
            {
                WriteLine("o is not an int so it cannot multiply!");
            }

            WriteLine("\nBranching with the switch statement:\n");

        A_label:
            var number = (new Random()).Next(1, 7);
            WriteLine($"My random number is {number}");

            switch (number)
            {
                case 1:
                    WriteLine("One");
                    break; // jumps to end of switch statement
                case 2:
                    WriteLine("Two");
                    goto case 1;
                case 3:
                case 4:
                    WriteLine("Three or four");
                    goto case 1;
                case 5:
                    // go to sleep for half a second
                    System.Threading.Thread.Sleep(500);
                    goto A_label;
                default:
                    WriteLine("Default");
                    break;
            } // end of switch statement

            string path = "/mnt/Storage/Projects/netcore/c#book-code/cs-operators";

            Stream s = File.Open(
                Path.Combine(path, "file.txt"), FileMode.OpenOrCreate
            );

            string message = string.Empty;

            switch (s)
            {
                case FileStream writeableFile when s.CanWrite:
                    message = "The stream is a file that I can write to.";
                    break;
                case FileStream readOnlyFile:
                    message = "The stream is a read-only file.";
                    break;
                case MemoryStream ms:
                    message = "The stream is a memory address.";
                    break;
                default: // always evaluated last despite its current position
                    message = "The stream is some other type.";
                    break;
                case null:
                    message = "The stream is null.";
                    break;
            }
            WriteLine(message);

            message = s switch
            {
                FileStream writeableFile when s.CanWrite
                => "The stream is a file that I can write to.",
                FileStream readOnlyFile
                => "The stream is a read-only file.",
                MemoryStream ms
                => "The stream is a memory address.",
                null
                => "The stream is null.",
                _
                => "The stream is some other type."
            };
            WriteLine(message);

            WriteLine("\nLooping:\n");

            int x1 = 0;
            while (x1 < 10)
            {
                WriteLine(x1);
                x1++;
            }

            // string password = string.Empty;
            // do
            // {
            //     Write("Enter your password: ");
            //     password = ReadLine();
            // }
            // while (password != "Pa$$w0rd");
            // WriteLine("Correct!");

            for (int _i = 1; _i <= 10; _i++)
            {
                WriteLine(_i);
            }

            string[] names = { "Adam", "Barry", "Charlie" };
            foreach (var name in names)
            {
                WriteLine($"{name} has {name.Length} characters.");
            }

            WriteLine("\nCasting and converting between types\n");

            a = 10;
            double b_ = a; // an int can be safely cast into a double
            WriteLine(b);

            // allocate array of 128 bytes
            byte[] binaryObject = new byte[128];
            // populate array with random bytes
            (new Random()).NextBytes(binaryObject);
            WriteLine("Binary Object as bytes:");
            for (int index = 0; index < binaryObject.Length; index++)
            {
                Write($"{binaryObject[index]:X} ");
            }
            WriteLine();
            // convert to Base64 string and output as text
            string encoded = Convert.ToBase64String(binaryObject);
            WriteLine($"Binary Object as Base64: {encoded}");

            int age = int.Parse("27");
            DateTime birthday = DateTime.Parse("4 July 1980");
            WriteLine($"I was born {age} years ago.");
            WriteLine($"My birthday is {birthday}.");
            WriteLine($"My birthday is {birthday:D}.");

            WriteLine("\nExeptions:\n");
            Write("What is your age? ");
            string input = "1";//Console.ReadLine();
            try
            {
                age = int.Parse(input);
                WriteLine($"You are {age} years old.");
            }
            catch (FormatException)
            {
                WriteLine("The age you entered is not a valid number format.");
            }
            catch (OverflowException)
            {
                WriteLine("Your age is a valid number format but it is either too big or small.");
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }

            WriteLine("\nChecking for overflow\n");

            try
            {
                checked
                {
                    int val = int.MaxValue - 1;
                    WriteLine($"Initial value: {val}");
                    val++;
                    WriteLine($"After incrementing: {val}");
                    val++;
                    WriteLine($"After incrementing: {val}");
                    val++;
                    WriteLine($"After incrementing: {val}");
                }
            }
            catch (OverflowException)
            {
                WriteLine("Code overflow");
                WriteLine($"byte(m) {byte.MaxValue}");
            }

            Clear();
            for (int v = 1; v <= 100; v++)
            {
                var output = $"{v} ";
                if (v % 3 == 0 && v % 5 == 0)
                {
                    output = "FizzBuzz ";
                }
                else if (v % 3 == 0)
                {
                    output = "Fizz ";
                }
                else if (v % 5 == 0)
                {
                    output = "Buzz ";
                }
                Write(output);
            }
            WriteLine();
        }

        private static bool DoStuff()
        {
            WriteLine("I am doing some stuff.");
            return true;
        }
    }
}
