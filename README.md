# Distributions 
Distributions for random values generators

![Deployment](https://travis-ci.org/Marbulinek/Distributions.svg?branch=master)

## Supported Distributions
* Uniform Distributions 
  * Continuous Uniform Distribution
  * Discrete Uniform Distribution
* Empirical Distribution
* Exponential Distribution
* Trigonometry Distribution

## Implementation
```c
//init seed
Random seed = new Random();

//init trigonometry distribution with seed, min value, max value and median
var trigonometryDistribution = new TrigonometryDistribution(seed, 100, 300, 150);

// return value
var result = trigonometryDistribution.GetDistribution();
```
