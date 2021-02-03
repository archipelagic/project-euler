<Query Kind="Program" />

// Project Euler - Problem 49

void Main()
{
	//Get all four-digit primes until you can no longer add 6660 and still be in the four-digit range
	var primes = GetPrimesInRange(1000,9999-6660);
	var primesFitSchema = primes.Where(p=> arePermutations(p,p+3330) &&
											arePermutations(p,p+6660) &&
											isNumberPrime(p+3330) &&
											isNumberPrime(p+6660));
													

	foreach(var prime in primesFitSchema)
	{
		var concatPrimes = (prime.ToString() +((prime+3330).ToString()) + ((prime+6660).ToString())).Dump();
	}
}

// Returns a list of all prime numbers between two given numbers
// (if either of them happens to be a prime, it is included)
public List<int> GetPrimesInRange(int lowerBound, int upperBound)
{
	return Enumerable.Range(lowerBound, upperBound).Where(r => isNumberPrime(r)).ToList();
}

public bool isNumberPrime(int testNumber)
{
	if(testNumber == 1)
	{
		return false;
	}
	//we know two is prime, so automate the check
	if(testNumber == 2)
	{
		return true;
	}
	var listOfAllPrimes = new List<int>() { 2 };
	//generate range up to sqrt of testNumber, remove even numbers
	var maxDivisor = Convert.ToInt32(Math.Floor(Math.Sqrt(testNumber)));
	var testRange = Enumerable.Range(2, maxDivisor)
								.Where(r => r%2 !=0);

	foreach(var number in testRange)
	{
		var isPrime = true;
		foreach(var prime in listOfAllPrimes)
		{
			if(number%prime == 0)
			{
				isPrime = false;
				break;
			}
		}
		if(isPrime)
		{
			listOfAllPrimes.Add(number);
			var sieve = Enumerable.Range(2, maxDivisor/number);
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

public bool arePermutations(int number1, int number2)
{
	return intAsList(number1).SequenceEqual(intAsList(number2));
}

public IEnumerable<string> intAsList(int number)
{
	return number.ToString().Select(p =>p.ToString()).OrderBy(c=>c);
}