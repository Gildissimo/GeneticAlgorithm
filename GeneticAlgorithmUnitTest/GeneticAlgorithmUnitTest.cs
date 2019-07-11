using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticAlgorithm;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithmUnitTest
{
    [TestClass]
    public class GeneticAlgorithmTest
    {
        private GeneticAlgorithm.GeneticAlgorithm GA = new GeneticAlgorithm.GeneticAlgorithm();
        private const int CL = 15;
        private Random random = new Random();
        private IFitnessHelper FH;

        [TestMethod]
        public void TestCrossover()
        {
            string s = "hello", r = "world";
            var chkArr = (s + r).ToArray();

            Array.Sort(chkArr);


            var res = GA.Crossover(s, r);

            List<string> checkList = new List<string>(res);

            var testArr = (checkList[0] + checkList[1]).ToArray();

            Array.Sort(testArr);

            Assert.AreEqual(new string(chkArr), new string(testArr));
        }

        [TestMethod]
        public void SmallTests()
        {
            StringBuilder sb;
            string goal;
            Func<string, double> f;
            int size = 4;

            for (int i = 0; i < 4; ++i)
            {
                sb = new StringBuilder(size);

                for (int j = 0; j < size; ++j)
                {
                    sb.Append(Math.Floor(2 * random.NextDouble()).ToString());
                }
                goal = sb.ToString();
                FH = new BitStringFitnessHelper(goal);
                f = FH.Fitness;

                Assert.AreEqual(goal, GA.Run(f, size, 0.6, 0.002));
            }
        }


        [TestMethod]
        public void MediumTests()
        {
            StringBuilder sb;
            string goal;
            Func<string, double> f;
            int size = 8;

            for (int i = 0; i < 3; ++i)
            {
                sb = new StringBuilder(size);

                for (int j = 0; j < size; ++j)
                {
                    sb.Append(Math.Floor(2 * random.NextDouble()).ToString());
                }
                goal = sb.ToString();
                FH = new BitStringFitnessHelper(goal);
                f = FH.Fitness;

                Assert.AreEqual(goal, GA.Run(f, size, 0.6, 0.002));
            }
        }

        [TestMethod]
        public void LargeTests()
        {
            StringBuilder sb;
            string goal;
            Func<string, double> f;
            int size = 20;

            for (int i = 0; i < 3; ++i)
            {
                sb = new StringBuilder(size);

                for (int j = 0; j < size; ++j)
                {
                    sb.Append(Math.Floor(2 * random.NextDouble()).ToString());
                }
                goal = sb.ToString();
                FH = new BitStringFitnessHelper(goal);
                f = FH.Fitness;

                Assert.AreEqual(goal, GA.Run(f, size, 0.6, 0.002, 600));
            }
        }

        [TestMethod]
        public void XLTests()
        {
            StringBuilder sb;
            string goal;
            Func<string, double> f;
            int size = 25;

            for (int i = 0; i < 1; ++i)
            {
                sb = new StringBuilder(size);

                for (int j = 0; j < size; ++j)
                {
                    sb.Append(Math.Floor(2 * random.NextDouble()).ToString());
                }
                goal = sb.ToString();
                FH = new BitStringFitnessHelper(goal);
                f = FH.Fitness;

                Assert.AreEqual(goal, GA.Run(f, size, 0.6, 0.002, 2000));
            }
        }

        [TestMethod]
        public void SmallSumTest()
        {
            // representation of 10 in terms of summand inclusion
            // SumFitnessHelper could be adapted to take an int
            String goal = "1111";
            int[] summands = new int[]{1, 2, 3, 4};

            FH = new SumFitnessHelper(summands, goal);
            Func<string, double> f;
            f = FH.Fitness;

            int size = goal.Length;

            string hypothesis = GA.Run(f, size, 0.6, 0.002, 500);

            Assert.AreEqual(goal, hypothesis);
        }
        
        [TestMethod]
        public void SmallSumDecTest()
        {
            // representation of 10 in terms of summand inclusion
            // SumFitnessHelper could be adapted to take an int
            String goal = "0011";
            int[] summands = new int[]{1, 2, 3, 4};

            FH = new SumDecFitnessHelper(summands, goal);
            Func<string, double> f;
            f = FH.Fitness;

            int size = goal.Length;

            string hypothesis = GA.Run(f, size, 0.6, 0.002, 500);

            Assert.AreEqual(goal, hypothesis);
        }

        
    }
}
