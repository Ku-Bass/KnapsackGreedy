int ammountOfItems = 1000;
int maxSize = 100;
int maxValue = 100000;
int bagSize = 1000;
List<Tuple<int,int>> items = new List<Tuple<int, int>>();

// key is size, value is value

for (int i = 0; i < ammountOfItems; i++)
{
	items.Add(new Tuple<int,int>(Random.Shared.Next(1,maxSize), Random.Shared.Next(1, maxValue)));
}

// greedy algorythm 
var sortedItems = items.OrderByDescending(x => x.Item2 / x.Item1).ToList();
int currentSize = 0;
int currentValue = 0;

var pickedItems = new List<Tuple<int, int>>();
foreach (var item in sortedItems)
{
	if (currentSize + item.Item1 <= bagSize)
	{
		pickedItems.Add(item);
		currentSize += item.Item1;
		currentValue += item.Item2;
	}
}
//output to console sum of values and sum of sizes of items in bag and aoutput each item size and value
Console.WriteLine($"Total value: {currentValue}");
Console.WriteLine($"Total size: {currentSize}");
/*foreach (var item in pickedItems)
{
	Console.WriteLine($"Size: {item.Item1} Value: {item.Item2}");
}*/

//now make a brute force solution
// brute force solution
int bestValue = 0;
int bestSize = 0;
List<Tuple<int, int>> bestItems = new List<Tuple<int, int>>();
for (int i = 0; i < Math.Pow(2, ammountOfItems); i++)
{
	Console.CursorLeft = 0;
	int size = 0;
	int value = 0;
	List<Tuple<int, int>> currentItems = new List<Tuple<int, int>>();
	for (int j = 0; j < ammountOfItems; j++)
	{
		if ((i & (1 << j)) != 0)
		{
			size += items[j].Item1;
			value += items[j].Item2;
			currentItems.Add(items[j]);
		}
	}
	if (size <= bagSize && value > bestValue)
	{
		bestValue = value;
		bestSize = size;
		bestItems = currentItems;
	}
}
Console.WriteLine($"Total value: {bestValue}");
Console.WriteLine($"Total size: {bestSize}");
/*foreach (var item in bestItems)
{
	Console.WriteLine($"Size: {item.Item1} Value: {item.Item2}");
}*/

