using static System.Net.Mime.MediaTypeNames;

namespace BalancedBrackets
{
    public class Stack
    {
        private int topChar = -1;
        private const int STACK_SIZE = 100;
        private char[] openArray = new char[STACK_SIZE]; // array to store open brackets

        public void push(char c)
        {
            if (topChar == 99)
            {
                Console.WriteLine("Error: Stack Full");
            }
            openArray[++topChar] = c;
        }

        public char pop(char c)
        {
            if (topChar == -1)
            {
                Console.WriteLine("Error: Stack Empty");
                return '\0';
            }
            char removedChar = openArray[topChar--];
            return removedChar;
        }

        // if openArray empty, return true
        public bool isEmpty()
        {
            if (topChar == -1)
            {
                return true;
            }
            return false;
        }
        public bool openBracketMatch(char c)
        {
            if (openArray[topChar] == c)
            {
                return true;
            }
            return false;
        }
        public bool bracketMatch (char c)
        {
            bool isMatch = false;
            switch (c)
            {
                case ')':
                    isMatch = openBracketMatch('(');
                    break;
                case ']':
                    isMatch = openBracketMatch('[');
                    break;
                case '}':
                    isMatch = openBracketMatch('{');
                    break;
                default:
                    break;
            }
            return isMatch;
        }

        // return true if brackets are balanced in input string
        public bool checkBalancedBrackets(string stringIn)
        {
            foreach (char c in stringIn)
            {
                if ("{[(".Contains(c))
                {
                    push(c);
                }
                else if ("}])".Contains(c))
                {
                    if (topChar == -1)
                    {
                        return false;
                    }
                    else
                    {
                        if (bracketMatch(c))
                        {
                            pop(c);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error: Invalid character in input string");
                    return false;
                }
            }
            
            return isEmpty();
        }
    }

    internal class Program
    {
        public static void printResult(Stack stackIn, string stringIn)
        {
            Console.WriteLine("Input string: " + stringIn);
            if(stackIn.checkBalancedBrackets(stringIn))
                Console.WriteLine("Balanced");
            else Console.WriteLine("Unbalanced");
        }

        static void Main(string[] args)
        {
            // string inputs
            string testA = "([{}])",            // balanced
                testB = "[(])",                 // unbalanced
                testC = "{(})[]",               // unbalanced
                testD = "{()[]}",               // balanced
                testE = "[()]{}{[()()]}()",     // balanced
                testF = "]{}()[";               // unbalanced

            // output balanced or unbalanced
            printResult(new Stack(), testA);
            printResult(new Stack(), testB);
            printResult(new Stack(), testC);
            printResult(new Stack(), testD);
            printResult(new Stack(), testE);
            printResult(new Stack(), testF);
        }
    }
}