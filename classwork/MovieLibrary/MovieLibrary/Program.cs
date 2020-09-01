using System;

namespace MovieLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            //FunWithTypes();
            //FunWithVariables();

            string title = "";
            string description = "";
            string rating = "";
            int duration;
        }

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

        //Blackboard is down - class is done for this evening, have a good week
        //Don't forget to push repository to Github
    }
}
