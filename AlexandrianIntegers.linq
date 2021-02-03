<Query Kind="Program" />

// Project Euler - Problem 221
// https://projecteuler.net/problem=221

// From A =pqr and 1/A = 1/p-1/q -1/r, we deduce 1+r^2 = (r-p)(r+q)
// so we need to find the divisors for 1+r^2

void Main()
{

	var limitValue = 150000;

	var allNumbers = AlexHashFunction(limitValue).Distinct();
	allNumbers.OrderBy(x=>x).ToList()[limitValue-1].Dump();

	//solution should be: 1884161251122450
	//but is              37375106923392


}

public long AlexNumber(long p, long q, long r)
{
	return (p * q * r);
}

// Build a hash set with all AlexNumbers found so far (not ordered) 
public HashSet<long> AlexHashFunction(long limitValue)
{
	HashSet<long> AlexHash = new HashSet<long> {}; 

	for (int r = 2; r <= limitValue; r++)
	{
		var newAlexNumbers = GenerateDivisorPairs(r).Select(t => AlexNumber(r,t.Item1, t.Item2)).ToHashSet();
		AlexHash.UnionWith(newAlexNumbers);
	}

	return AlexHash;
}


// finds all the divisor pairs (s.t. r > p > 1) of r^2 + 1
public HashSet<Tuple<long, long>> GenerateDivisorPairs(long r)
{
	var divisorTuple = new HashSet<Tuple<long, long>>();
	
		foreach (var p in Enumerable.Range(1, (int)(r - 1)))
		{
			if ((1 + r * r) % p == 0) divisorTuple.Add(new Tuple<long, long>(r-p,(1+r*r)/p -r));
		}
	
	return divisorTuple;
}