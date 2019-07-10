using System;

namespace GeneticAlgorithm{
    public class SumFitnessHelper : IFitnessHelper{
        private int target { get; set; }
        private int[] sumArray { get; set; }
        public SumFitnessHelper(int[] arr, string target){
            this.sumArray = arr;
            this.target = SumFitnessHelper.computeSum(this.sumArray, target);
        }

        public double Fitness(string chromosome){
            if(chromosome.Length != sumArray.Length){
                return 0.0;
            }
            int sum = SumFitnessHelper.computeSum(sumArray, chromosome);
            return 1.0 / (double)(Math.Abs(target - sum)+1.0);
        }

        public static int computeSum(int[] sumArray, string chromosome){
            int sum = 0;
            for(int i = 0; i < sumArray.Length; ++i){
                if(chromosome[i].CompareTo('1') == 0){
                    sum += sumArray[i];
                }
            }
            return sum;
        }
    }
}