using System;

namespace _05.Collect_the_Coins
{
    class Program
    {
        static void Main()
        {
            var array = new char[4][];
            for (int i = 0; i < 4; i++)
            {
                array[i] = Console.ReadLine().ToCharArray();
            }

            string actions = Console.ReadLine();
            int row = 0;
            int col = 0;
            int wallsHit = 0;
            int coins = 0;

            if (array[0][0].Equals('$'))
            {
                coins++;
            }

            for (int i = 0; i < actions.Length; i++)
            {
                switch (actions[i])
                {
                    case '<':
                        MoveLeft(ref array, ref row, ref col, ref wallsHit, ref coins);                       
                        break;

                    case '>':
                        MoveRight(ref array, ref row, ref col, ref wallsHit, ref coins);
                        break;

                    case '^':
                        MoveUp(ref array, ref row, ref col, ref wallsHit, ref coins);
                        break;

                    case 'V':
                        MoveDown(ref array, ref row, ref col, ref wallsHit, ref coins);
                        break;

                    case 'v':
                        MoveDown(ref array, ref row, ref col, ref wallsHit, ref coins);
                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine("Coins collected: " + coins);
            Console.WriteLine("Walls hit: " + wallsHit);
        }

        static void MoveLeft(ref char[][] array,ref int row, ref int col, ref int wallsHit, ref int coins)
        {
                if (col - 1 > 0)
                {
                    --col;
                    if (array[row][col].Equals('$'))
                    {
                        coins++;
                    }
                }
                else
                {
                    wallsHit++;
                }

        }

        static void MoveRight(ref char[][] array, ref int row, ref int col, ref int wallsHit, ref int coins)
        {
            if (col + 1 < array[row].Length)
            {
                ++col;
                if (array[row][col].Equals('$'))
                {
                    coins++;
                }
            }
            else
            {
                wallsHit++;
            }
        }

        static void MoveUp(ref char[][] array, ref int row, ref int col, ref int wallsHit, ref int coins)
        {
            if (row - 1 >= 0 && col < array[row - 1].Length)
            {
                --row;
                if (array[row][col].Equals('$'))
                {
                    coins++;
                }
            }
            else
            {
                wallsHit++;
            }
        }

        static void MoveDown(ref char[][] array, ref int row, ref int col, ref int wallsHit, ref int coins)
        {
            if (row + 1 < array.Length && col < array[row+1].Length)
            {
                ++row;
                if (array[row][col].Equals('$'))
                {
                    coins++;
                }
            }
            else
            {
                wallsHit++;
            }
        }
    }
}
