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
    }
}
