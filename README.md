# Distributions 
Distributions for random values generators

[![Build Status](https://travis-ci.org/Marbulinek/Distributions.svg?branch=master)](https://travis-ci.org/Marbulinek/Distributions)
[![Issue Count](https://codeclimate.com/github/Marbulinek/Distributions/badges/issue_count.svg)](https://codeclimate.com/github/Marbulinek/Distributions)
![CodeCoverity](https://scan.coverity.com/projects/8950/badge.svg)

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
