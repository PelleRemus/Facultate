using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishNotation
{
    public static class Engine
    {
        /*
          EXTRA INFO: For now the '/' symbol will return only ints,
          possible operations are: '+','*','/','-' and '^', and the characters
          in you notation must have only one space between them.
          PSEUDOCODE:
            S = new empty stack
            iterate through notation with i
                t = notation[i]
                if t is an operator
                    y = pop(S)
                    x = pop(S)
                    push(S, t(x, y))
                else
                    push(S, t)
                print the contents of the stack S
        */
        public static int PerformOperation(string symbol, int nr1, int nr2)
        {
            switch (symbol)
            {
                case "+":
                    return nr1 + nr2;
                case "-":
                    return nr1 - nr2;
                case "*":
                    return nr1 * nr2;
                case "/":
                    return nr1 / nr2;
                case "^":
                    return (int)Math.Pow((double)nr1, (double)nr2);
                default:
                    Console.WriteLine("Invalid expression. Wrong symbol.");
                    return -1000;
            }
        }

        public static int CalculateReversePolishNotation(string notation)
        {
            Stack<int> stack = new Stack<int>();
            string[] notationParts = notation.Split(' ');
            for (int i = 0; i < notationParts.Length; i++)
            {
                int currentNumber;
                string currentSymbol;
                if (Int32.TryParse(notationParts[i], out currentNumber))
                {
                    stack.Push(currentNumber);
                }
                else
                {
                    currentSymbol = notationParts[i];
                    int nr2 = stack.Pop();
                    int nr1 = stack.Pop();
                    int result = PerformOperation(currentSymbol, nr1, nr2);
                    stack.Push(result);
                }
            }
            int finalResult = stack.Pop();
            if (stack.Count != 0)
            {
                Console.WriteLine("Invalid expresion. Too many operands.");
                return -1000;
            }
            else
                return finalResult;
        }
    }
}
