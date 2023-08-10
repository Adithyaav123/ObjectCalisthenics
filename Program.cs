using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDiceVersion2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rolledNumber = 0;
            int turnScore = 0;
            int totalScore = 0;
            int turn = 1;
            Console.WriteLine("Let's play PIG!");
            Instructions();
            Console.WriteLine("\nTURN: " + turn);
            Console.WriteLine("\nWelcome to the game of Pig!");

            while (true)
            {
                Roll(ref rolledNumber, ref turnScore, ref turn, ref totalScore);
                Win(turn, turnScore, totalScore);
            }
        }

        private static void Hold(ref int turnScore, ref int totalScore, ref int turn)
        {
            totalScore += turnScore;
            Console.WriteLine("Your turn score is " + turnScore + " and your total score is " + totalScore + " :");
            turnScore = 0;
            turn++;
            IncrementTurn(ref turn);
        }

        private static void IncrementTurn(ref int turn)
        {
            Console.WriteLine("TURN " + turn);
            Console.WriteLine("-------------------");
        }

        private static void Win(int turn, int turnScore, int totalScore)
        {
            if ((turnScore + totalScore) >= 20)
            {
                Console.WriteLine("You Win!. You finished in " + turn + " turns.");
                Console.WriteLine("\nGame Over!");
                Environment.Exit(0);
            }
        }

        private static void Roll(ref int rolledNumber, ref int turnScore, ref int turn, ref int totalScore)
        {
            Console.WriteLine("\nEnter r to roll again and h to hold:");
            string rollOrHold = Console.ReadLine();
            if (rollOrHold == "r")
            {
                RollingTheDice(rollOrHold, ref turn, ref turnScore, ref totalScore, ref rolledNumber);
            }
            else if (rollOrHold == "h")
            {
                Hold(ref turnScore, ref totalScore, ref turn);
            }
        }

        private static void RollingTheDice(string rollOrHold, ref int turn, ref int turnScore, ref int totalScore, ref int rolledNumber)
        {
            Random rnd = new Random();
            rolledNumber = rnd.Next(1, 7);

            Console.WriteLine("You rolled: " + rolledNumber);

            if (rolledNumber == 1)
            {
                Console.WriteLine("Turn over. No score.");
                turnScore = 0;
                turn++;
                Console.WriteLine("TURN: " + turn);
                Console.WriteLine("-------------------");
            }
            else
            {
                turnScore += rolledNumber;
                Console.WriteLine("Your turn score is " + turnScore + " and your total score is " + totalScore + ".");
                HoldMessage(ref turnScore, ref totalScore);
            }
        }

        private static void HoldMessage(ref int turnScore, ref int totalScore)
        {
            if ((turnScore + totalScore) < 20)
                Console.WriteLine("If you hold you will have " + (turnScore + totalScore) + " points.");
        }

        private static void Instructions()
        {
            Console.WriteLine("* See how many turns it takes you to get to 20.");
            Console.WriteLine("* Turn ends when you hold or roll a 1.");
            Console.WriteLine("* If you roll a 1, you lose all points for the turn.");
            Console.WriteLine("* If you hold, you save all points for the turn.");
        }
    }
}





