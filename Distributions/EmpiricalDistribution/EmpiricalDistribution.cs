namespace Distributions.EmpiricalDistribution
{
    using DiscreteDistribution;
    
    /// <summary>
    /// Empirical Distribution
    /// </summary>
    public class EmpiricalDistribution : IDistribution
    {
        private readonly LinkedList<EmpiricalData> _empDataList;
        private readonly DiscreteUniformDistribution _discreteUniformDistribution;
        private readonly Random _randomGenerator;
        private readonly Random _seed;
        private double _acumulatePercents;

        /// <summary>
        /// Empirical distribution
        /// </summary>
        /// <param name="seed">Seed of universal generator</param>
        public EmpiricalDistribution(Random seed)
        {
            this._seed = seed;
            this._empDataList = new LinkedList<EmpiricalData>();
            this._randomGenerator = new Random(this._seed.Next());
            this._discreteUniformDistribution = new DiscreteUniformDistribution(this._randomGenerator, 0, 0);
            this._acumulatePercents = 0;
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
            var data = new EmpiricalData(new Random(this._seed.Next()), valueA, valueB, this._acumulatePercents);
            _empDataList.AddLast(data);
        }

        /// <summary>
        /// Empirical Distribution.
        /// </summary>
        /// <returns>Return number from empirical distribution</returns>
        public double GetDistribution()
        {
            var randomNumber = _randomGenerator.NextDouble();
            var result = -1;

            if (randomNumber >= 0 && randomNumber < this._empDataList.ElementAt(0).ValueC)
            {
                result = this.ComputeDistribution(0);
            }
            else if (randomNumber >= this._empDataList.ElementAt(this._empDataList.Count - 1).ValueC)
            {
                result = this.ComputeDistribution(this._empDataList.Count - 1);
            }
            else
            {
                for (int i = 0; i < this._empDataList.Count; i++)
                {
                    if (randomNumber >= this._empDataList.ElementAt(i).ValueC && randomNumber < this._empDataList.ElementAt(i + 1).ValueC)
                    {
                        result = this.ComputeDistribution(i + 1);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Compute distribution
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>Distribution probability</returns>
        private int ComputeDistribution(int index)
        {
            this._discreteUniformDistribution.DistributionGenerator = this._empDataList.ElementAt(index).Random;
            this._discreteUniformDistribution.SetParameters(this._empDataList.ElementAt(index).ValueA, this._empDataList.ElementAt(index).ValueB);
            return (int)this._discreteUniformDistribution.GetDistribution();
        }
    }
}
