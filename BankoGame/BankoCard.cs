using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankoGame
{
    public class BankoCard
    {
        // card 3 rows 9 colomns
        public int[,] Numbers { get; set; }
        public bool[,] Marked { get; set; }

      // constructor create new BankoCard
        public BankoCard()
        {
            Numbers = new int[3,9];
            Marked = new bool[3,9];
            GenerateCard();
            
        }

        //method to generate the card with numbers
        private void GenerateCard()
        {
            Random random = new Random();
            for (int col =0; col <9; col++)
            {
                int min = col * 10 + 1;
                int max = (col == 8) ? 90 : (col + 1) * 10;

                for (int row = 0; row < 3; row ++)
                {
                    int number;
                    do
                    {
                        number = random.Next(min, max + 1);

                    }
                    while (IsNumberInColumn(number, col));

                    Numbers [row, col] = number;

                }
            }

        }

        // check the method to see if a number is already in a column
        private bool IsNumberInColumn(int number, int col)
        {
            for (int row = 0; row < 3; row++)
            {
                if (Numbers[row, col] == number)
                {
                    return true;
                }
            }

            return false;
        }
        
        // method to mark a number (int number)
        public void MarkNumber (int number)
        {
            for(int row = 0; row < 3; row ++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (Numbers[row, col] == number)
                    {
                        Marked[row , col] = true;
                        return;
                    }
                }
            }
        }

        // method to display the card
        public void DisplayCard()
        {
            for (int row = 0; row <3; row ++)
            {
                for (int col = 0; col < 9; col ++)
                {
                    if (Marked[row, col])
                    {
                        Console.Write("[XX]");
                    }
                    else
                    {
                        Console.Write($"{Numbers[row, col]: D2}");
                    }
                }

                Console.WriteLine();
            }
        }

    }
}
