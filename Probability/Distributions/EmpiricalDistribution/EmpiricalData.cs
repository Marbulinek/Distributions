using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributions.EmpiricalDistribution
{
    public class EmpiricalData
    {
        private int _valueA;
        private int _valueB;
        private double _valueC;
        private Random _random;

        public int ValueA { get { return _valueA; } }
        public int ValueB { get { return _valueB; } }
        public double ValueC { get { return _valueC; } }
        public Random Random { get { return _random; } }

        public EmpiricalData(Random random, int valueA, int valueB, double valueC)
        {
            _random = random;
            _valueA = valueA;
            _valueB = valueB;
            _valueC = valueC;
        }
    }
}
