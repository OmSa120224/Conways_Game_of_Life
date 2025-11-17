
using System;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        int life_cycles = 100;

        int[,] currentBoard = new int[17,17]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0},
            {0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0},
            {0,0,0,0,0,1,1,0,0,0,1,1,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,1,1,1,0,0,1,1,0,1,1,0,0,1,1,1,0},
            {0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0},
            {0,0,0,0,0,1,1,0,0,0,1,1,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,1,1,0,0,0,1,1,0,0,0,0,0},
            {0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0},
            {0,1,1,1,0,0,1,1,0,1,1,0,0,1,1,1,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,1,1,0,0,0,1,1,0,0,0,0,0},
            {0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0},
            {0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
        };

        
        int rows = currentBoard.GetLength(0);
        int cols = currentBoard.GetLength(1);

        for (int cycle = 0; cycle < life_cycles; cycle++)
        {
            int[,] newBoard = new int[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    int neighbors = 0;

                    /*
                    (-1,-1) | (-1,0) | (-1,1)
                    --------|--------|--------
                    (0,-1)  | (0,0)  | (0,1)
                    --------|--------|--------
                    (1,-1)  | (1,0)  | (1,1)
                    */
                    int[] x_cord = {-1, -1, -1,  0, 0,  1, 1, 1};
                    int[] y_cord = {-1,  0,  1, -1, 1, -1, 0, 1};


                    for (int k = 0; k < 8; k++)
                    {
                        //Console.WriteLine($"k={k} row={r} + {x_cord[k]}, col={c} + {y_cord[k]}");
                        int new_row = r + x_cord[k];
                        int new_col = c + y_cord[k];
                        //Console.WriteLine($"k={k} new row={new_row}, new col={new_col}");

                        if ((new_row >= 0 && new_row < rows) && (new_col >= 0 && new_col < cols))
                        {
                            neighbors += currentBoard[new_row, new_col];   
                            //Console.WriteLine($"k={k} elem ={currentBoard[new_row, new_col]}, N={neighbors}");
                        }
                    }
                    //Console.WriteLine();
                    //Console.WriteLine();

                    if (currentBoard[r,c] == 1)
                    {
                        newBoard[r,c] = (neighbors == 2 || neighbors == 3) ? 1 : 0;
                    }
                    else
                    {
                        newBoard[r,c] = (neighbors == 3) ? 1 : 0;
                    }
                }
            }

            currentBoard = newBoard;
            for (int r = 0; r < rows; r++)
            {
                for(int c = 0; c < cols; c++)
                {
                    if (currentBoard[r,c] == 1) 
                    {
                        Console.Write("■ ");
                    }
                    else
                    {
                        Console.Write("□ ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        Thread.Sleep(500);
        }
        
    }
}






