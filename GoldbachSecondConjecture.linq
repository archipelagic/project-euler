<Query Kind="Program" />

void Main()
{
	int numberToTest = 9; //smallest potential candidate
	while(canNumberBeDecomposed(numberToTest))
	{
		//Pick the next odd composite number
		numberToTest = findNextHigherComposite(numberToTest);			
	}
	numberToTest.Dump();

}

//only checks for odd composite numbers
public bool canNumberBeDecomposed (int number)
{
	//The biggest number that can appear in the square would be the square root
	//of (x-3)/2, where x is the input
	int upperBound = Convert.ToInt32(Math.Floor(Math.Sqrt((number - 3) / 2)));
	var squaresToTest = Enumerable.Range(1, upperBound);

	foreach (var square in squaresToTest)
	{
		var potentialPrime = number - 2 * square * square;
		if (numberIsPrime(potentialPrime))
		{
			return true;
		}
	}
	return false;

}
public Tuple<int,int> GetDecomposition(int number)
{
	//The biggest number that can appear in the square would be the square root
	//of (x-3)/2, where x is the input
	int upperBound = Convert.ToInt32(Math.Floor(Math.Sqrt((number - 3)/2)));
	var squaresToTest = Enumerable.Range(1,upperBound);
	
	foreach(var square in squaresToTest)
	{
		var potentialPrime = number - 2*square*square;
		if(numberIsPrime(potentialPrime))
		{
			return new Tuple<int,int> (potentialPrime,square);
		}
	}
	return new Tuple<int,int>(0,0);
}
public bool numberIsComposite(int testNumber)
{
	return !numberIsPrime(testNumber) && (testNumber%2 == 1);
}

public int findNextHigherComposite(int testNumber)
{
	int nextHigher = testNumber + 1;
	while(!numberIsComposite(nextHigher))
	{
		nextHigher++;
	}
	return nextHigher;
}
public bool numberIsPrime(int testNumber)
{
	if (testNumber == 1)
	{
		return false;
	}
	//we know two is prime, so automate the check
	if (testNumber == 2)
	{
		return true;
	}
	var listOfAllPrimes = new List<int>() { 2 };
	//generate range up to sqrt of testNumber, remove even numbers
	var maxDivisor = Convert.ToInt32(Math.Floor(Math.Sqrt(testNumber)));
	var testRange = Enumerable.Range(2, maxDivisor)
								.Where(r => r % 2 != 0);

	foreach (var number in testRange)
	{
		var isPrime = true;
		foreach (var prime in listOfAllPrimes)
		{
			if (number % prime == 0)
			{
				isPrime = false;
				break;
			}
		}
		if (isPrime)
		{
			listOfAllPrimes.Add(number);
			var sieve = Enumerable.Range(2, maxDivisor / number);
			testRange = testRange.Except(sieve);
		}
	}

	foreach (var prime in listOfAllPrimes)
	{
		if (testNumber % prime == 0)
		{
			return false;
		}
	}
	return true;

}
