/*
 * ITSE 1430 
 * Movie Library Console Application
 */
using System;

namespace MovieLibrary
{
    class Program
    {
        static void Main ( string[] args )
        {
            //FunWithTypes();
            //FunWithVariables();

            // while => while (E) S;
            // 0+ iterations, pre test condition
            while (true)
            {
                //Scope - lifetime of a variable : starts at declaration and continues until end of current scope
                char choice = DisplayMenu();
                if (choice == 'Q')
                    return;
                else if (choice == 'A')
                    AddMovie();
            };

            string title = "";
            string description = "";
            string rating = "";
            int duration;
        }

        static void AddMovie ()
        {
            //Get title
            Console.WriteLine("Movie title: ");
            //string title = Console.ReadLine();
            string title = ReadString(true);

            //Get description
            Console.WriteLine("Description (optional): ");
            //string description = Console.ReadLine();
            string description = ReadString(false);

            //Get rating
            Console.WriteLine("Rating: ");
            //string rating = Console.ReadLine();
            string rating = ReadString(false);

            //Get duration
            Console.WriteLine("Duration (in minutes): ");
            //string duration = Console.ReadLine();
            int duration = ReadInt32(0);

            //Get is classic
            Console.WriteLine("Is Classic (Y/N)? ");
            string isClassic = Console.ReadLine();
        }

        static char DisplayMenu ()
        {
            // 1+ iteration, post test
            // do S while (E);
            // block statement => { S* }
            do
            {
                Console.WriteLine("Movie Library");
                Console.WriteLine("-----------------");

                Console.WriteLine("A)dd Movie");
                Console.WriteLine("Q)uit");

                //Get input from user
                string value = Console.ReadLine();

                //C++: if (x = 10) ; //Not valid in C#
                // if (E) S;
                // if (E) S else S;
                if (value == "Q")   // 2 equal signs => equality 
                    return 'Q';
                else if (value == "A")
                    return 'A';

                DisplayError("Invalid option");
            } while (true);
        }

        //Displays an error
        private static void DisplayError ( string message )
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(message);

            Console.ResetColor();
        }

        //Reads an integer
        static int ReadInt32 ()
        {
            return ReadInt32(Int32.MinValue);
        }

        //Reads an integer with a minimum value
        static int ReadInt32 ( int minimumValue )
        {
            do
            {
                string value = Console.ReadLine();

                //Parse to int int Int32.Parse ( string ) - not safe
                //int result = Int32.Parse(value);

                // Parameter kinds
                //   Input parameter ("pass by value") - a copy of the argument is placed into parameter inside function definition
                //   Input/output parameter ("pass by reference") - a reference to the argument is passed to the function and both original argument and parameter reference same value ( C++: int& )
                //   Output paramter - function caller does not provide input, function always provides output (C++: return type)
                //bool Int32.TryParse ( string, out int result )
                // Double.Parse/TryParse
                // Single.Parse/TryParse
                // Boolean.Parse/TryParse 
                // Int16.Parse/TryParse
                int result;
                if (Int32.TryParse(value, out result) && result >= minimumValue)
                    return result;

                if (minimumValue != Int32.MinValue)   //Int32.MaxValue
                    DisplayError("Value must be at least " + minimumValue);  //String concatenation
                else                
                    DisplayError("Must be integral value");
            } while (true);
        }

        //Logical operators (booleans)
        // NOT => !E : boolean
        // AND => E && E : boolean
        // OR => E || E : boolean

        //Relational operators (primitives + a few extra)
        // equality => E == E
        // inequality => E != E
        // greater than => E > E
        // greater than or equal to => E >= E
        // less than => E < E
        // less than or equal to => E <= E
        //Reads a string, optionally required
        static string ReadString ( bool required )
        {
            do
            {
                string value = Console.ReadLine();

                //If not required or not empty return
                if (!required || value != "")
                    return value;
                
                DisplayError("Value is required");
            } while (true);
        }

        #region Demoing Language Features

        private static void FunWithVariables ()
        {
            //Definition before usage
            //value;

            //Declares hours of type int with initial value 10 (initializer expression)
            int hours = 10;

            //Definitely assigned rule
            int value;
            value = 10;
            int calculatedValue = value * 10;

            //Identifiers rule
            //  Must start with underscore or a letter
            //  Must consist of letters, digits or underscore
            //  Must be unique within scope
            //  Cannot be a keyword

            // Variable names
            //  camelCased - local variables and parameters
            //  nouns
            //  descriptive and no abbreviations or acronyms (e.g. okButton, nbrPeople

            //Multiple variable declaration
            int width, length;   // int width; int length;
            int grade1 = 50, grade = 60;

            //Block declarations
            // A: Easy to find
            // A: Easy to see what is being used
            // D: Cannot see usage
            // D: Hard to tell what is actually still used
            int x, y, z;
            double rate1, rate2;
            string name1, name2;
            //...
            name2 = "";

            //When needed
            //int x = 10;
            //int y = 20;
            //int z = x * y;

            // double rate1 = x * 0.5;

        }

        //Function definition - declaration + implementation
        // [modifiers] T id ([parameters) { S* }
        //Function signature - [return-type] name, parameter types
        static void FunWithTypes ()
        {
            //Variable - named memory location where you can read and write a value; name, type and value
            //
            //Literal - value that can be read, fixed at compilation; type and value

            //Body

            //Primitive - type implicitly known by the language

            //Integral - whole numbers
            // Signed 
            //   sbyte - 1 byte -128 to 127
            //   short - 2 bytes +-32K
            //   int   - 4 bytes, +-2 billion - DEFAULT  
            //   long  - 8 bytes, really big  - larger size
            // Unsigned
            //   byte - 1 byte 0 to 255
            //   ushort - 2 bytes 0 to 64K
            //   uint   - 4 bytes, 0 to 4 billion
            //   ulong  - 8 bytes, 0 to really big
            // Literals
            //   10, 20, 30 => int
            //   150L => long
            //   0xFFUL => ulong  or 0xFFU => uint
            //   decimal = 0-9, hex = 0-9A-F, binary = 0-1 (0b101010)
            //   32_766, 3_2_7_6_6, 0b1011_1010

            //Variable declaration - T id [ = E ];
            int hours = 10;
            int code = 0xFF;
            int ratio = hours * 40;

            //Floating point types - real numbers IEEE
            //  float - 4 bytes, +-E38, 7 to 9 precision 123.456789
            //  double - 8 bytes, +-E308, 15 to 17 precision - DEFAULT
            //  decimal - 16 bytes, precise => currency
            // Literals
            //    123.45F; => float
            //     123.45M => decimal
            double payRate = 123.456789;
            payRate = 123E12;
            decimal price = 456.746M;

            //boolean
            // bool - 1 byte, true or false (0) 
            bool isPassing = true;
            //bool success = 1;  //ERROR
            //int isPassing = 1;  //BAD

            //Textual
            //  char - 2 byte, '\0' to '\uFFFF'
            //  string - 0+ bytes
            //  'X' => char
            //  "abcf" => string literal
            char letterA = 'A';
            char digit0 = '1'; // != 1
            char hex = '\x0A'; // CR

            string name = "Bob";
            string empty = "";
        }

        #endregion
    }
}
