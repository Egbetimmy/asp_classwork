using System;

public class MatrixDeterminant
{
    public static double Determinant(double[][] matrix)
    {
        // Check for matrix size
        int n = matrix.Length;
        if (n <= 0 || n != matrix[0].Length)
        {
            throw new ArgumentException("Matrix must be square and have at least one row and column");
        }

        // Handle 1x1 and 2x2 matrices explicitly
        if (n == 1)
        {
            return matrix[0][0];
        }
        else if (n == 2)
        {
            return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
        }

        // Calculate determinant using recursion and cofactor expansion
        double det = 0;
        for (int i = 0; i < n; i++)
        {
            double[][] minorMatrix = new double[n - 1][];
            for (int j = 0; j < n - 1; j++)
            {
                minorMatrix[j] = new double[n - 1];
                for (int k = 0; k < n; k++)
                {
                    if (k != i)
                    {
                        minorMatrix[j][k < i ? k : k - 1] = matrix[j + 1][k];
                    }
                }
            }
            det += Math.Pow(-1, i) * matrix[0][i] * Determinant(minorMatrix);
        }

        return det;
    }

    // Example usage
    static void Main(string[] args)
    {
        // Define the matrix
        double[][] matrix = new double[][] {
            new double[] { 2, 4, 5, 6 },
            new double[] { 2, 9, 5, 6 },
            new double[] { 1, 3, 6, 7 },
            new double[] { 2, 8, 5, 10 },
        };

        // Calculate and print the determinant
        double determinant = Determinant(matrix);
        Console.WriteLine("The determinant of the matrix is: " + determinant);
    }
}

/*
using System;

class Program
{
    static void Main()
    {
        int[,] matrix =
        {
            { 2, 4, 5, 6 },
            { 2, 9, 5, 6 },
            { 1, 3, 6, 7 },
            { 2, 8, 5, 10 },
        };

        int determinant = CalculateDeterminant(matrix);
        Console.WriteLine("Determinant: " + determinant);
    }

    static int CalculateDeterminant(int[,] matrix)
    {
        int determinant = 0;

        for (int i = 0; i < 4; i++)
        {
            int product = 1;
            for (int j = 0; j < 4; j++)
            {
                product *= matrix[(i + j) % 4, j];
            }
            determinant += product;
        }

        for (int i = 0; i < 4; i++)
        {
            int product = 1;
            for (int j = 0; j < 4; j++)
            {
                product *= matrix[(i + 4 - j) % 4, j];
            }
            determinant -= product;
        }

        return determinant;
    }
}


using System;

class MatrixDeterminant
{
    static double Determinant(double[][] matrix)
    {
        int n = matrix.Length;
        double det = 0;

        if (n == 1)
        {
            return matrix[0][0];
        }
        else if (n == 2)
        {
            return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                double[][] subMatrix = new double[n - 1][];
                for (int j = 0; j < n - 1; j++)
                {
                    subMatrix[j] = new double[n - 1];
                }

                for (int row = 1; row < n; row++)
                {
                    int colIndex = 0;
                    for (int col = 0; col < n; col++)
                    {
                        if (col != i)
                        {
                            subMatrix[row - 1][colIndex++] = matrix[row][col];
                        }
                    }
                }

                det += Math.Pow(-1, i) * matrix[0][i] * Determinant(subMatrix);
            }
        }

        return det;
    }

    static void Main()
    {
        double[][] matrix = {
            new double[] { 2, 4, 5, 6 },
            new double[] { 2, 9, 5, 6 },
            new double[] { 1, 3, 6, 7 },
            new double[] { 2, 8, 5, 10 }
        };

        double result = Determinant(matrix);
        Console.WriteLine("Determinant: " + result);
    }
}



using System;

namespace MatrixDeterminant
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] ages = {
                { 2, 4, 5, 6 },
                { 2, 9, 5, 6 },
                { 1, 3, 6, 7 },
                { 2, 8, 5, 10 },
            };

            int determinant = CalculateDeterminant(ages);

            Console.WriteLine($"Determinant of the matrix: {determinant}");
        }
 
        static int CalculateDeterminant(int[,] matrix)
        {
            int determinant = 0;

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sign = (col % 2 == 0) ? 1 : -1;

                int subMatrixSize = matrix.GetLength(0) - 1;
                int[,] subMatrix = new int[subMatrixSize, subMatrixSize];

                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    int subMatrixCol = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (j != col)
                        {
                            subMatrix[i - 1, subMatrixCol] = matrix[i, j];
                            subMatrixCol++;
                        }
                    }
                }

                int subMatrixDeterminant = CalculateDeterminant(subMatrix);

                determinant += sign * matrix[0, col] * subMatrixDeterminant;
            }

            return determinant;
        }
    }
}





namespace ArrayAssignment
{
    public class ArrayAssignment
    {
        public static void Main(string[] args)
        {
            int[,] ages = 
                {

                    { 2, 4, 5, 6 },
                    { 2, 9, 5, 6 },
                    { 1, 3, 6, 7 },
                    { 2, 8, 5, 10 },
                };

            int determinant = CalculateDeterminant(ages);
            Console.WriteLine("Determinant: " + determinant);

            // Function to calculate the determinant of a 4x4 matrix
            int CalculateDeterminant(int[,] matrix)
            {
                int det = 0;

                for (int i = 0; i < 4; i++)
                {
                    det += matrix[0, i] * (
                        matrix[1, (i + 1) % 4]  matrix[2, (i + 2) % 4]  matrix[3, (i + 3) % 4] -
                        matrix[1, (i + 3) % 4]  matrix[2, (i + 2) % 4]  matrix[3, (i + 1) % 4]
                    );
            }

            return det;
        }

        
        int[,] ages ={  //dynamic
            { 2, 4, 5, 6, 11 },
            { 2, 4, 5, 6, 11 },
            { 1, 3, 6, 7, 8 },
        };


        // 3d

        int[,,] storeysOfClassRoom = new int[4, 3, 2]
        {
                {
                {5,7 },
                {3,9 },
                {0,2 }

            },
                 {
            {8,4 },
                { 1,1},
                {10,6 }
            },
                  {
                {9,4 },
                {2,19 },
                {0,4 }
            },
             {
                {13,6 },
                { 9,4},
                {78,23 }
            }
        };


        // Assuming 'ages' is already defined as a two-dimensional array of integers

        // Loop to reduce the ages for football reasons
        for (int row = 0; row < ages.GetLength(0); row++)
        {
            for (int col = 0; col < ages.GetLength(1); col++)
            {
                ages[row, col] -= 3;
            }
        }

        // Print the updated ages array
        for (int row = 0; row < ages.GetLength(0); row++)
        {
            for (int col = 0; col < ages.GetLength(1); col++)
            {
                Console.Write(ages[row, col] + " ");
            }
            Console.WriteLine(); // Move to the next line for the next row
        }


        int[,,] floorsOfClassRoom = new int[3, 2, 4]
        {
            {
                { 10, 20, 30, 40 },
                { 50, 60, 70, 80 }
            },
            {
                { 90, 100, 110, 120 },
                { 130, 140, 150, 160 }
            },
            {
                { 170, 180, 190, 200 },
                { 210, 220, 230, 240 }
            }
        };

        int[,,,] blocksOfClasses = new int[3, 5, 4, 6]
        {
            // Layer 1
            {
                // Rows (5)
                {
                    // Columns (4)
                    { 2, 4, 6, 8, 10, 12 },
                    { 14, 16, 18, 20, 22, 24 },
                    { 26, 28, 30, 32, 34, 36 },
                    { 38, 40, 42, 44, 46, 48 }
                },
                // Rows (5)
                {
                    // Columns (4)
                    { 50, 52, 54, 56, 58, 60 },
                    { 62, 64, 66, 68, 70, 72 },
                    { 74, 76, 78, 80, 82, 84 },
                    { 86, 88, 90, 92, 94, 96 }
                },
                {
                    // Columns (4)
                    { 50, 52, 54, 56, 58, 60 },
                    { 62, 64, 66, 68, 70, 72 },
                    { 74, 76, 78, 80, 82, 84 },
                    { 86, 88, 90, 92, 94, 96 }
                },

                {
                    // Columns (4)
                    { 50, 52, 54, 56, 58, 60 },
                    { 62, 64, 66, 68, 70, 72 },
                    { 74, 76, 78, 80, 82, 84 },
                    { 86, 88, 90, 92, 94, 96 }
                },

                {
                    // Columns (4)
                    { 50, 52, 54, 56, 58, 60 },
                    { 62, 64, 66, 68, 70, 72 },
                    { 74, 76, 78, 80, 82, 84 },
                    { 86, 88, 90, 92, 94, 96 }
                },
            },

            //... (remaining layers)
            {
                // Rows (5)
                {
                    // Columns (4)
                    { 2, 4, 6, 8, 10, 12 },
                    { 14, 16, 18, 20, 22, 24 },
                    { 26, 28, 30, 32, 34, 36 },
                    { 38, 40, 42, 44, 46, 48 }
                },
                // Rows (5)
                {
                    // Columns (4)
                    { 50, 52, 54, 56, 58, 60 },
                    { 62, 64, 66, 68, 70, 72 },
                    { 74, 76, 78, 80, 82, 84 },
                    { 86, 88, 90, 92, 94, 96 }
                },
                {
                    // Columns (4)
                    { 50, 52, 54, 56, 58, 60 },
                    { 62, 64, 66, 68, 70, 72 },
                    { 74, 76, 78, 80, 82, 84 },
                    { 86, 88, 90, 92, 94, 96 }
                },

                {
                    // Columns (4)
                    { 50, 52, 54, 56, 58, 60 },
                    { 62, 64, 66, 68, 70, 72 },
                    { 74, 76, 78, 80, 82, 84 },
                    { 86, 88, 90, 92, 94, 96 }
                },

                {
                    // Columns (4)
                    { 50, 52, 54, 56, 58, 60 },
                    { 62, 64, 66, 68, 70, 72 },
                    { 74, 76, 78, 80, 82, 84 },
                    { 86, 88, 90, 92, 94, 96 }
                },
            },{
                // Rows (5)
                {
                    // Columns (4)
                    { 2, 4, 6, 8, 10, 12 },
                    { 14, 16, 18, 20, 22, 24 },
                    { 26, 28, 30, 32, 34, 36 },
                    { 38, 40, 42, 44, 46, 48 }
                },
                // Rows (5)
                {
                    // Columns (4)
                    { 50, 52, 54, 56, 58, 60 },
                    { 62, 64, 66, 68, 70, 72 },
                    { 74, 76, 78, 80, 82, 84 },
                    { 86, 88, 90, 92, 94, 96 }
                },
                {
                    // Columns (4)
                    { 50, 52, 54, 56, 58, 60 },
                    { 62, 64, 66, 68, 70, 72 },
                    { 74, 76, 78, 80, 82, 84 },
                    { 86, 88, 90, 92, 94, 96 }
                },

                {
                    // Columns (4)
                    { 50, 52, 54, 56, 58, 60 },
                    { 62, 64, 66, 68, 70, 72 },
                    { 74, 76, 78, 80, 82, 84 },
                    { 86, 88, 90, 92, 94, 96 }
                },

                {
                    // Columns (4)
                    { 50, 52, 54, 56, 58, 60 },
                    { 62, 64, 66, 68, 70, 72 },
                    { 74, 76, 78, 80, 82, 84 },
                    { 86, 88, 90, 92, 94, 96 }
                },
            }, 

        };

        // Rest of your code...
    }
        
    }
}

    }
*/
