using Distributions.DiscreteDistribution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.EmpiricalDistribution
{
    /// <summary>
    /// Empirical Distribution
    /// </summary>
    public class EmpiricalDistribution : IDistribution
    {
        private LinkedList<EmpiricalData> _empDataList;
        private DiscreteUniformDistribution _discreteUniformDistribution;
        private Random _randomGenerator;
        private Random _discreteGenerator;
        private Random _seed;
        private double _acumulatePercents;

        /// <summary>
        /// Empirical distribution
        /// </summary>
        /// <param name="seed">Seed of universal generator</param>
        public EmpiricalDistribution(Random seed)
        {
            _seed = seed;
            _empDataList = new LinkedList<EmpiricalData>();
            _randomGenerator = new Random(_seed.Next());
            _discreteGenerator = new Random(_seed.Next());
            _discreteUniformDistribution = new DiscreteUniformDistribution(_randomGenerator, 0, 0);
            _acumulatePercents = 0;
        }

        /// <summary>
        /// Add data into collection of empirical distribution.
        /// </summary>
        /// <param name="valueA">Value A, which min will be from</param>
        /// <param name="valueB">Value B, which max will be from</param>
        /// <param name="valueC">Probability</param>
        public void AddEmpiricalData(int valueA, int valueB, double valueC)
        {
            _acumulatePercents += valueC;
            EmpiricalData data = new EmpiricalData(new Random(_seed.Next()), valueA, valueB, _acumulatePercents);
            _empDataList.AddLast(data);
        }

        /// <summary>
        /// Empirical Distribution.
        /// </summary>
        /// <returns>Return number from empirical distribution</returns>
        public double GetDistribution()
        {
            double randomNumber = _randomGenerator.NextDouble();
            int result = -1;

            if (randomNumber >= 0 && randomNumber < _empDataList.ElementAt(0).ValueC)
            {
                _discreteUniformDistribution.DistributionGenerator = _empDataList.ElementAt(0).Random;
                _discreteUniformDistribution.SetParameters(_empDataList.ElementAt(0).ValueA, _empDataList.ElementAt(0).ValueB);
                return (int)_discreteUniformDistribution.GetDistribution();
            }
            else if (randomNumber >= _empDataList.ElementAt(_empDataList.Count - 1).ValueC)
            {
                _discreteUniformDistribution.DistributionGenerator = _empDataList.ElementAt(_empDataList.Count - 1).Random;
                _discreteUniformDistribution.SetParameters(_empDataList.ElementAt(_empDataList.Count - 1).ValueA, _empDataList.ElementAt(_empDataList.Count - 1).ValueB);
                return (int)_discreteUniformDistribution.GetDistribution();
            }
            else
            {
                for (int i = 0; i < _empDataList.Count; i++)
                {
                    if (randomNumber >= _empDataList.ElementAt(i).ValueC && randomNumber < _empDataList.ElementAt(i + 1).ValueC)
                    {
                        _discreteUniformDistribution.DistributionGenerator = _empDataList.ElementAt(i + 1).Random;
                        _discreteUniformDistribution.SetParameters(_empDataList.ElementAt(i + 1).ValueA, _empDataList.ElementAt(i + 1).ValueB);
                        return (int)_discreteUniformDistribution.GetDistribution();
                    }
                }
            }
            return result;
        }
    }
}
