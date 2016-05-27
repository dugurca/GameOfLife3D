using System;
using System.Collections.Generic;

namespace Assets
{
    public class GameOfLife
    {
        public int N { get; private set; }
        public List<List<List<int>>> Grid { get; private set; }

        public GameOfLife(int n)
        {
            N = n;
            Random r = new Random();
            Grid = new List<List<List<int>>>();
            for (int i = 0; i < N; i++)
            {
                Grid.Add(new List<List<int>>(N));
                for (int j = 0; j < N; j++)
                {
                    Grid[i].Add(new List<int>(N));
                    for (int k = 0; k < N; k++)
                    {
                        Grid[i][j].Add(r.Next()%25 == 0 ? 1 : 0);
                    }
                }
            }
        }

        private int GetNumNeighbors(int i, int j, int k)
        {
            int numNeighbors = 0;

            for (int ii = i - 1; ii <= i + 1; ii++)
            {
                for (int jj = j - 1; jj <= j + 1; jj++)
                {
                    for (int kk = k - 1; kk <= k + 1; kk++)
                    {
                        if (InBounds(ii, jj, kk) && Grid[ii][jj][kk] == 1)
                            numNeighbors++;
                    }
                }
            }
            if (Grid[i][j][k] == 1) numNeighbors--;
            return numNeighbors;
        }

        private bool InBounds(int ii, int jj, int kk)
        {
            return ii >= 0 && ii < Grid.Count &&
                   jj >= 0 && jj < Grid[0].Count &&
                   kk >= 0 && kk < Grid[0][0].Count;
        }

        public void Next()
        {
            for (int i = 0; i < Grid.Count; i++)
            {
                for (int j = 0; j < Grid[0].Count; j++)
                {
                    for (int k = 0; k < Grid[0][0].Count; k++)
                    {
                        int numNeighbors = GetNumNeighbors(i, j, k);
                        if (Grid[i][j][k] == 1)
                        {
                            if (numNeighbors >= 3 && numNeighbors <= 5)
                                Grid[i][j][k] = 3;
                        }
                        else
                        {
                            if (numNeighbors == 4) Grid[i][j][k] = 2;
                        }
                    }
                }
            }

            for (int i = 0; i < Grid.Count; i++)
            {
                for (int j = 0; j < Grid[0].Count; j++)
                {
                    for (int k = 0; k < Grid[0][0].Count; k++)
                    {
                        Grid[i][j][k] >>= 1;
                    }
                }
            }
        }
    }
}