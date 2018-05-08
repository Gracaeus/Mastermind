using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        int lengthOfCode;
        int maxValueOfCode;
        int[] code;
        int[] codeCopy;
        int[] playerGuess;
        int Black;
        int White;
        static void Main(string[] args)
        {
            Program mastermind = new Program();
            mastermind.gameSetup();
            mastermind.codeGenerator();
            mastermind.CodeCopy();
            mastermind.playerGuesses();
            mastermind.Compare();
            Console.ReadKey();

        }

        public void gameSetup()
        {
            Console.WriteLine("How long would you like the code to be?");
            lengthOfCode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(lengthOfCode);

            Console.WriteLine("What would you like the max value of the code to be?");
            maxValueOfCode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(maxValueOfCode);

        }

        public void codeGenerator()
        {
            Random rnd = new Random();
            code = new int[lengthOfCode];

            for (int i = 0; i < code.Length; i++)
            {
                code[i] = rnd.Next(1, maxValueOfCode);

            }
            for (int i = 0; i < code.Length; i++)
            {
                Console.Write(code[i] + ",");
            }
        }
        public void CodeCopy()
        {
            codeCopy = new int[lengthOfCode];
            Console.WriteLine("");
            for (int i = 0; i < codeCopy.Length; i++)
            {
                codeCopy[i] =Convert.ToInt32(code[i]);
            }

            for (int i = 0; i < codeCopy.Length; i++)
            {
                Console.Write(codeCopy[i] + ",");
            }
        }
            

        public void playerGuesses()
        {
            playerGuess = new int[lengthOfCode];

            for (int i = 0; i<playerGuess.Length;i++)
            {
                int pos = i + 1;
                Console.WriteLine("\nPosition " + pos + ":");
                playerGuess[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < playerGuess.Length; i++)
            {
                Console.Write(playerGuess[i] + ",");
            }
        }

        public void Compare()
        {
            for (int i = 0;i < code.Length;i++)
            {
                if(code[i]==playerGuess[i])
                {
                    Black += 1;
                    codeCopy[i] = 0;
                }
            }
            for (int i=0; i < playerGuess.Length; i++)
            {
                for (int j =0; j <codeCopy.Length; j++)
                {
                    if (codeCopy[j]==playerGuess[i])
                    {
                        
                        for (int k=0; k < codeCopy.Length;k++)
                        {
                            if (codeCopy[j]==codeCopy[k])
                            {
                                codeCopy[k] = 0;
                            }
                        }
                        codeCopy[j] = 0;
                        j = codeCopy.Length;
                        White += 1;
                        Console.WriteLine("White added");
                    }
                }
            }
            Console.WriteLine("");
            for (int i = 0; i < codeCopy.Length; i++)
            {
                Console.Write(codeCopy[i] + ",");
            }
            Console.WriteLine("");
            Console.WriteLine("Black:" + Black + " White:" + White);
        }

    }
}
