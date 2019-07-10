using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm
{
    public interface IFitnessHelper
    {
        double Fitness(string chromosome);
    }
}
