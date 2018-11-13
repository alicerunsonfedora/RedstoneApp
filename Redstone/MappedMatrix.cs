using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace Redstone
{
    public class MappedMatrix
    {

        //Create a jagged array with four rows.
        public int[][] DefaultMatrix = new int[4][];

        //Randomly assign a number based upon input
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public void CreateRandomMatrix()
        {
            //For every element in the matrix, randomly assign a value between 0 and the highest number according to the last object's ID + 1.
            for (int i = 0; i < DefaultMatrix.Length; i++)
            {
                for (int j = 0; j < DefaultMatrix[i].Length; j++)
                {
                    DefaultMatrix[i][j] = RandomNumber(0, 8);
                }
            }

            System.Console.WriteLine("Matrix has been redone.");
        }

        public void CreateDefaultMatrix()
        {
            for (int i = 0; i < DefaultMatrix[0].Length; i++)
            {
                DefaultMatrix[0][i] = 5;
                DefaultMatrix[2][i] = 5;
                DefaultMatrix[3][i] = 5;
            }

            DefaultMatrix[1][0] = 5;
            DefaultMatrix[1][1] = 0;
            DefaultMatrix[1][2] = 3;

            for (int j = 3; j < DefaultMatrix[1].Length; j++)
            {
                DefaultMatrix[1][j] = 5;
            }
        }

        public MappedMatrix()
        {
            //Create the row's data in arrays
            DefaultMatrix[0] = new int[6] { 0, 1, 2, 3, 4, 5 };
            DefaultMatrix[1] = new int[6] { 1, 2, 3, 4, 5, 0 };
            DefaultMatrix[2] = new int[6] { 2, 3, 4, 5, 0, 1 };
            DefaultMatrix[3] = new int[6] { 3, 4, 5, 0, 1, 2 };
        }

    }
}
