using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            int rows = int.Parse(input1.Split(' ').First());
            int cols = int.Parse(input1.Split(' ').ElementAt(1));
            string input;
            var array = new char[rows][];
            var listTuples = new List<Tuple<int, int>>();
            var playerCoords = new Tuple<int, int>(0,0);

            for (int i = 0; i < rows; i++)
            {
                input = Console.ReadLine();              
                array[i] = input.ToCharArray();
            }




            for (int x = 0; x < rows; ++x)
            {
                for (int y = 0; y < cols; ++y)
                {
                    if (array[x][y].Equals('P'))
                    {
                        playerCoords = new Tuple<int, int>(x, y);
                    }
                }
            }


            input = Console.ReadLine();
            bool win = false;
            bool dead = false;
            int uf = 0;

            while (win == false && dead == false && uf < input.Length)
            {
                
                if (array[playerCoords.Item1][playerCoords.Item2] == 'B')
                {
                    dead = true;
                }

                if (!dead && !win && uf < input.Length)
                {
                    switch (input[uf])
                    {
                        
                        case 'L':
                            if (playerCoords.Item2 > 0)
                            {
                                array[playerCoords.Item1][playerCoords.Item2] = '.';
                                array[playerCoords.Item1][playerCoords.Item2 - 1] = 'P';
                                playerCoords = new Tuple<int, int>(playerCoords.Item1, playerCoords.Item2 - 1);
                            }
                            else
                            {
                                array[playerCoords.Item1][playerCoords.Item2] = '.';
                                win = true;
                            }
                            break;
                        case 'R':
                            if (playerCoords.Item2 < cols - 1)
                            {
                                array[playerCoords.Item1][playerCoords.Item2] = '.';
                                array[playerCoords.Item1][playerCoords.Item2 + 1] = 'P';
                                playerCoords = new Tuple<int, int>(playerCoords.Item1, playerCoords.Item2 + 1);
                            }
                            else
                            {
                                array[playerCoords.Item1][playerCoords.Item2] = '.';
                                win = true;
                            }
                            break;
                        case 'U':
                            if (playerCoords.Item1 > 0)
                            {
                                array[playerCoords.Item1][playerCoords.Item2] = '.';
                                array[playerCoords.Item1 - 1][playerCoords.Item2] = 'P';
                                playerCoords = new Tuple<int, int>(playerCoords.Item1 -1, playerCoords.Item2);
                            }
                            else
                            {
                                array[playerCoords.Item1][playerCoords.Item2] = '.';
                                win = true;
                            }
                            break;
                        case 'D':
                            if (playerCoords.Item1 < rows - 1)
                            {
                                array[playerCoords.Item1][playerCoords.Item2] = '.';
                                array[playerCoords.Item1 + 1][playerCoords.Item2] = 'P';
                                playerCoords = new Tuple<int, int>(playerCoords.Item1 +1, playerCoords.Item2);
                            }
                            else
                            {
                                array[playerCoords.Item1][playerCoords.Item2] = '.';
                                win = true;
                            }
                            break;
                    }

                    for (int x = 0; x < rows; ++x)
                    {
                        for (int y = 0; y < cols; ++y)
                        {
                            if (array[x][y].Equals('B'))
                            {
                                listTuples.Add(new Tuple<int, int>(x, y));
                            }
                        }
                    }

                    foreach (var item in listTuples)
                    {
                        if (item.Item2 + 1 < cols)
                            array[item.Item1][item.Item2 + 1] = 'B';
                        if (item.Item2 - 1 >= 0)
                            array[item.Item1][item.Item2 - 1] = 'B';
                        if (item.Item1 + 1 < rows)
                            array[item.Item1 + 1][item.Item2] = 'B';
                        if (item.Item1 - 1 >= 0)
                            array[item.Item1 - 1][item.Item2] = 'B';
                    }
                }
                else
                {
                    break;
                }

                uf++;
            }




                for (int k = 0; k < rows; k++)
            {
                string result = String.Join("", array[k]);
                Console.WriteLine(result);
            }

            if (dead)
            {
                Console.WriteLine("dead: " + playerCoords.Item1 + " " + playerCoords.Item2);
            }

            if (win)
            {
                Console.WriteLine("won: " + playerCoords.Item1 + " " + playerCoords.Item2);
            }
        }
    }
}
