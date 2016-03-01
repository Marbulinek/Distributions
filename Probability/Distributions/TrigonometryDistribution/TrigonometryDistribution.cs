using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.TrigonometryProbability
{
    /// <summary>
    /// Trigonometry distribution
    /// </summary>
    public class TrigonometryDistribution : IDistribution
    {
        private Random _random;

        private double _min;
        private double _max;
        private double _modus;

        /// <summary>
        /// Constructor for Trigonometry distribution
        /// </summary>
        /// <param name="random">Random instance</param>
        /// <param name="min">Minimal value</param>
        /// <param name="max">Maximal value</param>
        /// <param name="modus">The most probably value</param>
        public TrigonometryDistribution(Random random, double min, double max, double modus)
        {
            _random = new Random(random.Next());
            _min = min;
            _max = max;
            _modus = modus;
        }

        /// <summary>
        /// Return Trihonometry distribution
        /// </summary>
        /// <returns>Trihonometry distribution</returns>
        public double GetDistribution()
        {
            double U = _random.NextDouble();
            double F = (_modus - _min) / (_max - _min);
            if (U <= F)
                return _min + Math.Sqrt(U * (_max - _min) * (_modus - _min));
            return _max - Math.Sqrt((1 - U) * (_max - _min) * (_max - _modus));
        }
    }
}
