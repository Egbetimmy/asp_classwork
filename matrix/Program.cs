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