namespace Distributions.TrigonometryDistribution
{
    /// <summary>
    /// Trigonometry distribution
    /// </summary>
    public class TrigonometryDistribution : IDistribution
    {
        private readonly Random _random;

        private readonly double _min;
        private readonly double _max;
        private readonly double _modus;

        /// <summary>
        /// Constructor for Trigonometry distribution
        /// </summary>
        /// <param name="random">Random instance</param>
        /// <param name="min">Minimal value</param>
        /// <param name="max">Maximal value</param>
        /// <param name="modus">The most probably value</param>
        public TrigonometryDistribution(Random random, double min, double max, double modus)
        {
            this._random = new Random(random.Next());
            this._min = min;
            this._max = max;
            this._modus = modus;
        }

        /// <summary>
        /// Return Trihonometry distribution
        /// </summary>
        /// <returns>Trihonometry distribution</returns>
        public double GetDistribution()
        {
            var u = this._random.NextDouble();
            var f = (this._modus - this._min) / (this._max - this._min);
            if (u <= f)
                return this._min + Math.Sqrt(u * (this._max - this._min) * (this._modus - this._min));
            return this._max - Math.Sqrt((1 - u) * (this._max - this._min) * (this._max - this._modus));
        }
    }
}
