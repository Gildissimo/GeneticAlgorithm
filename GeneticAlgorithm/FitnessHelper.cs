using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm
{
    public class FitnessHelper
    {
        // assumes chromosome and solution are bitstrings
        private string solution;
        public double Fitness(string chromosome)
        {
            int editDistance = Compute(chromosome, solution);
            double score = 1.0 / (double)(editDistance + 1);

            return score;
        }

        public FitnessHelper(string targetSolution)
        {
            solution = targetSolution;
        }

        // https://en.wikipedia.org/wiki/Levenshtein_distance
        // https://www.dotnetperls.com/levenshtein
        // dynamic programming
        private static int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            var d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; ++i)
            {
                d[i, 0] = i;
            }
            for (int j = 0; j <= m; ++j)
            {
                d[j, 0] = j;
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost
                    );
                }
            }
            // Step 7
            return d[n, m];
        }
    }
}
