<Query Kind="Program" />

// Project EUler - Problem 221
// https://projecteuler.net/problem=221

//TODO: Include a loop that checks if a smaller AlexNumber might have been generated with a 
// higher (or the same) value of p
//if A is AlexInt, make sense to check at least until Math.Floor(sqrt(A/4,3))

void Main()
{
	List<AlexStruct> AlexSet = new List<AlexStruct>();
	int x = 1;
	while (AlexSet.Count() <600)
	{
		int r = x+1;
		while (r < x*x + x +1)
		{
			int q = r+1;
			while (q < x*x + x +2)
			{
				AlexSet.Add(new AlexStruct 
				{
					product  =x*r*q,
					p_value = x,
					r_value = r,
					q_value = q
				});
			q++;
			}
		r++;
		}
	x++;
	}
	//AlexSet.Dump();
	//AlexSet.Select(a=>a.product).Distinct().OrderBy(ef=>ef).Dump();
	
	var dict = AlexSet.GroupBy(w=>w.p_value).ToDictionary(g=> g.Key, g=>g.Select(m=>m.product).Distinct().OrderBy(m=>m));
	dict.Select(kvp => kvp.Key.ToString() + ": " + String.Join(", ", kvp.Value.Select(c=>c.ToString()))).Dump();
}

public struct AlexStruct
{
	public int product { get; set; }
	public int p_value { get; set; }
	public int r_value { get; set; }
	public int q_value { get; set; }

}