using System;
using System.Linq;

namespace Bomb
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
            char[,] matrix = new char[n, n];
            int sapperRow = 0;
            int sapperCol = 0;
            int countOfBombs = 0;
            for (int row = 0; row < n; row++)
            {
                string[] curr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = char.Parse(curr[col]);
                    if (matrix[row, col] == 's')
                    {
                        sapperRow = row;
                        sapperCol = col;
                    }
                    else if (matrix[row, col] == 'B')
                    {
                        countOfBombs++;
                    }
                }
            }

            bool isExit = false;
            for (int i = 0; i < commands.Length; i++)
            {
                string currCommand = commands[i];
                if (currCommand == "up")
                {


                    if (IsOnField(n, sapperRow - 1, sapperCol))
                    {
                        if (IsFoundExit(matrix[sapperRow - 1, sapperCol]))
                        {
                            Console.WriteLine($"END! {countOfBombs} bombs left on the field");
                            isExit = true;
                        }
                        else if (IsFoundBomb(matrix[sapperRow - 1, sapperCol]))
                        {
                            countOfBombs--;
                            Console.WriteLine($"You found a bomb!");
                        }
                        matrix[sapperRow - 1, sapperCol] = 's';
                        matrix[sapperRow, sapperCol] = '+';
                        sapperRow--;
                    }
                }
                else if (currCommand == "down")
                {
                    if (IsOnField(n, sapperRow + 1, sapperCol))
                    {
                        if (IsFoundExit(matrix[sapperRow + 1, sapperCol]))
                        {
                            Console.WriteLine($"END! {countOfBombs} bombs left on the field");
                            isExit = true;
                        }
                        else if (IsFoundBomb(matrix[sapperRow + 1, sapperCol]))
                        {
                            countOfBombs--;
                            Console.WriteLine($"You found a bomb!");
                        }
                        matrix[sapperRow + 1, sapperCol] = 's';
                        matrix[sapperRow, sapperCol] = '+';
                        sapperRow++;
                    }
                }
                else if (currCommand == "left")
                {
                    if (IsOnField(n, sapperRow, sapperCol - 1))
                    {
                        if (IsFoundExit(matrix[sapperRow, sapperCol - 1]))
                        {
                            Console.WriteLine($"END! {countOfBombs} bombs left on the field");
                            isExit = true;
                        }
                        else if (IsFoundBomb(matrix[sapperRow, sapperCol - 1]))
                        {
                            countOfBombs--;
                            Console.WriteLine($"You found a bomb!");
                        }
                        matrix[sapperRow, sapperCol - 1] = 's';
                        matrix[sapperRow, sapperCol] = '+';
                        sapperCol--;
                    }
                }
                else if (currCommand == "right")
                {
                    if (IsOnField(n, sapperRow, sapperCol + 1))
                    {
                        if (IsFoundExit(matrix[sapperRow, sapperCol + 1]))
                        {
                            Console.WriteLine($"END! {countOfBombs} bombs left on the field");
                            isExit = true;
                        }
                        else if (IsFoundBomb(matrix[sapperRow, sapperCol + 1]))
                        {
                            countOfBombs--;
                            Console.WriteLine($"You found a bomb!");
                        }
                        matrix[sapperRow, sapperCol + 1] = 's';
                        matrix[sapperRow, sapperCol] = '+';
                        sapperCol++;
                    }
                }
                if (isExit)
                {
                    break;
                }
                else if (countOfBombs == 0)
                {
                    Console.WriteLine("Congratulations! You found all bombs!");
                    break;
                }
                //Console.WriteLine();
                //PrintMatrix(matrix);
            }
            if (!isExit && countOfBombs > 0)
            {
                Console.WriteLine($"{countOfBombs} bombs left on the field. Sapper position: ({sapperRow},{sapperCol})");
            }
            //Console.WriteLine();
            //PrintMatrix(matrix);
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        static bool IsOnField(int n, int row, int col)
        {
            bool IsValid = false;
            if (row >= 0 && row < n && col >= 0 && col < n)
            {
                IsValid = true;
            }
            return IsValid;
        }
        static bool IsFoundExit(char e)
        {
            bool isFound = false;
            if (e == 'e')
            {
                isFound = true;
            }
            return isFound;
        }
        static bool IsFoundBomb(char b)
        {
            bool isFoundBomb = false;
            if (b == 'B')
            {
                isFoundBomb = true;
            }
            return isFoundBomb;
        }
    }
}
