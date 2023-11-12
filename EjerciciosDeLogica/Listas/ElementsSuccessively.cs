namespace EjerciciosDeLogica;


/*
Design a data structure that can, effiently with respect to time used, store and check if the total any three
successively added elements is equal to a given total.

Form example, new MovingTotal() creates and empty container with no existing totals. 
Append{ 1, 2, 3, 4 } appends elements {1, 2, 3, 4}, which means that there are two existing totals 
(1+2+3=6 and 2+3+4=9).

Append({5}) appends element 5 and creates and additional total from {3,4,5}. There would now be three totals
(1+2+3=6, 2+3+4=9, and 3+4+5=12).At this point Contains(6), Contains(9), and Contains(12) should return true, while
Contains(7) should return false;
*/

public class MovingTotal
{
    readonly Dictionary<int, List<int>> numbersGroup = new();

    public void Append(int[] list)
    {
        int flagNumberOfSuccessiveSums = 3;
        int currentIndex = 0;
        bool exceptionThrow = false;
        List<int> numbers = GetLastList();
        numbers.AddRange(list);
        while (!exceptionThrow)
        {
            try
            {
                List<int> sumGroup =  numbers.GetRange(currentIndex, flagNumberOfSuccessiveSums);
                int sumTotal = sumGroup.Sum();
                numbersGroup.Add(sumTotal, sumGroup);
                currentIndex++;
            }
            catch (Exception)
            {
                exceptionThrow = true;
            }
        }
    }

    public bool Contains(int total)
    {
       return numbersGroup.ContainsKey(total);
    }

    private List<int> GetLastList()
    {
        if(numbersGroup.Count == 0) return new List<int>();
        var lastList = numbersGroup.Values.Select(x => x).Last();
        return lastList.GetRange(1, lastList.Count - 1);
    }

    public static void Test()
    {
        MovingTotal movingTotal = new();
        
        movingTotal.Append(new int[] { 1, 2, 3, 4 });
        
        Console.WriteLine(movingTotal.Contains(6));
        Console.WriteLine(movingTotal.Contains(9));
        Console.WriteLine(movingTotal.Contains(12));
        Console.WriteLine(movingTotal.Contains(7));

        movingTotal.Append(new int[] { 5 });

        Console.WriteLine(movingTotal.Contains(6));
        Console.WriteLine(movingTotal.Contains(9));
        Console.WriteLine(movingTotal.Contains(12));
        Console.WriteLine(movingTotal.Contains(7));
    }
}
