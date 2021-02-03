<Query Kind="Program" />

// Project EUler - Problem 26
// https://projecteuler.net/problem=26

void Main()
{
	// We know that 2 and 5 don't yield cyclic decimal representations, so their product(s) won't either
	// What are the maximal exponents?
	var max2Exponent = maxExponent(2,1000);
	var max5Exponent = maxExponent(5,1000);
	
	var toExcludeList = new List<int>();
	
	//Find all their products
	for(int i =2; i<1000; i++)
	{
		for(int k = 0; k <= max2Exponent; k++)
		{
			for(int l = 0; l <= max5Exponent; l++)
			{
				var factor1 = Convert.ToInt32(Math.Pow(2,k));
				var factor2 = Convert.ToInt32(Math.Pow(5,l));
				
				if(factor1 * factor2 == i)
				{
					toExcludeList.Add(i);
					break;
				}
			}
		}
	}
	//remove them from list
	var itemsToCheck = Enumerable.Range(2,999).Except(toExcludeList);


	
}

//calculates the maximum power p of a number n such that n^p < ceiling
public int maxExponent(int factor, int ceiling)
{
	int counter = 1;
	int exponent = 1;
	while(counter < ceiling)
	{
		counter = Convert.ToInt32(Math.Pow(factor,exponent));
		exponent ++;
	}
	return exponent;
}