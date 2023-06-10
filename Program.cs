using System.Collections;
using System.Runtime.Remoting;
using Microsoft.VisualBasic.CompilerServices;

class Program
{

    public static void Main()
    {
        string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "\\milliveri.txt";
        Console.WriteLine("---------------------------------------------Project part 1---------------------------------------------");

        List<NationalPark> list1 = new List<NationalPark>(), list2 = new List<NationalPark>();
        List<NationalPark>[] genListArr = { list1, list2 }; //Generic List Array

        AddByArea(genListArr, filePath);
        WriteGenArr(genListArr);

        Console.WriteLine("---------------------------------------------Project part 2---------------------------------------------");

        var maxSize = 0;
        foreach (var i in genListArr) maxSize += i.Count; // maxsize identifying from Project 1 total Parks.
        var stackCherry = new StackCherry(maxSize);
        var qCherry = new QCherry(maxSize);
        var pqCherry = new PQCherry(maxSize);

        
        Console.WriteLine("------------STACK------------");
        stackCherry.AddAllItemsToStack(filePath);
        stackCherry.RemoveAllItemsInStack();
        
        Console.WriteLine("------------Queue------------");
        qCherry.AddAllItemsToQuee(filePath);
        qCherry.RemoveAllItemsInQ();


        Console.WriteLine("---------------------------------------------Project part 3---------------------------------------------");
        Console.WriteLine("------------PriorityQueue------------");
        pqCherry.AddAllItemsToQ(filePath);
        pqCherry.RemoveAllItemsInPQ();

        Console.WriteLine("---------------------------------------------Project part 4---------------------------------------------");
        Console.WriteLine("------------Queue/VS\\PriorityQueue------------");

        int[] numberOfProduct1 = { 8, 9, 6, 7, 10, 1, 11, 5, 3, 4, 2 };
        List<int> numberOfProduct2 = new List<int>(numberOfProduct1);

        var qCherry1 = new QCherry(numberOfProduct1);
        var pqCherry1 = new PQCherry(numberOfProduct2);
        var costumerQ = new CostumerQandPQ(qCherry1, pqCherry1);
        Console.WriteLine("Queue Average Of Waiting Time : " + costumerQ.CalculateQTime());
        Console.WriteLine("Priority Queue Average Of Waiting Time : " + costumerQ.CalculatePQtime());

        Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
        Console.ReadLine();
    }

    public static void AddByArea(List<NationalPark>[] genListArr, string filePath)
    {
        int MINIMUM_AREA = 15000;
        string line;
        string[] lineData;


        using (StreamReader reader = new StreamReader(filePath))
        {
            while ((line = reader.ReadLine()) != null)
            {
                lineData = line.Split("\t");

                var currentpark = new NationalPark(lineData[0], lineData[1], RemoveThousandSeparators(lineData[2]), lineData[3]);
                if (currentpark.parkArea < MINIMUM_AREA)
                {
                    genListArr[0].Add(currentpark);
                }
                else
                {
                    genListArr[1].Add(currentpark);
                }
            }
            reader.Close();
        }
    }

    public static int RemoveThousandSeparators(string includeThousandSeparatorsData)
    {
        return int.Parse(includeThousandSeparatorsData.Replace(",", ""));
    }

    public static void WriteGenArr(List<NationalPark>[] genArr)
    {
        int total = 0;
        Console.WriteLine("--------------------------------------------The Least of 15000--------------------------------------------\n");
        for (int i = 0; i < genArr.Length; i++)
        {
            for (int j = 0; j < genArr[i].Count; j++)
            {
                Console.WriteLine(genArr[i][j].ToString());
                total += genArr[i][j].parkArea;
            }
            Console.WriteLine("**** Total Area of List" + i + " : " + total + " ha(hectare)");
            total = 0;
            if (i == 0)
            {
                Console.WriteLine("--------------------------------------------The Above of 15000--------------------------------------------\n");
            }

        }
        Console.WriteLine("----------------------------------------------------------------------------------------------------------\n");
    }

}

public class NationalPark
{
    public string parkName;
    public string cityNames;
    public string acceptedDate;
    public int parkArea;

    public NationalPark(string parkName, string cityNames, int parkArea, string acceptedDate)
    {
        this.parkName = parkName;
        this.cityNames = cityNames;
        this.acceptedDate = acceptedDate;
        this.parkArea = parkArea;
    }

    public string ToString()
    {
        return parkName + ", " + cityNames + ", " + parkArea + ", " + acceptedDate;
    }
}

public class StackCherry
{
    private int maxSize;
    private NationalPark[] stackArray;
    private int top;

    public StackCherry(int maxSize)
    {
        this.maxSize = maxSize;
        stackArray = new NationalPark[maxSize];
        top = -1;
    }

    public void AddAllItemsToStack(string filePath)
    {
        string line;
        string[] lineData;


        using (StreamReader reader = new StreamReader(filePath))
        {

            while ((line = reader.ReadLine()) != null && (maxSize - 1 != top))
            {

                lineData = line.Split("\t");
                var currentpark = new NationalPark(lineData[0], lineData[1], int.Parse(lineData[2].Replace(",", "")), lineData[3]);
                Push(currentpark);
            }
        }

    }

    public void RemoveAllItemsInStack()
    {
        while (top != -1)
        {
            Console.WriteLine("Removed Item : " + pop().parkName);
        }
        Console.WriteLine("--------------------------------------------------------------------------------------------------------");

    }

    public void Push(NationalPark nationalPark)
    {
        stackArray[++top] = nationalPark;
    }

    public NationalPark pop()
    {
        return stackArray[top--];
    }

    public bool IsEmpty()
    {
        return top == -1;
    }

    public bool IsFull()
    {
        return (top == maxSize - 1);
    }


    public int GetMaxSize()
    {
        return maxSize;
    }

    public NationalPark[] GetStackArray()
    {
        return stackArray;
    }

    public int GetTop()
    {
        return top;
    }

}

public class QCherry
{
    public int maxSize;
    public Object queArray;
    public int front;
    public int rear;
    public int nItems;
    public QCherry(Object obj) // queArray could be int[] type so, the constructor have to Object class parameter. Object[] not able to because of int values are not objects. 
    {
        queArray = obj;
    }
    public QCherry(int s) // constructor
    {
        maxSize = s;
        front = 0;
        rear = -1;
        nItems = 0;
        queArray = new Object[maxSize];
    }

    public void AddAllItemsToQuee(string filePath)
    {
        string line;
        string[] lineData;

        using (StreamReader reader = new StreamReader(filePath))
        {

            while ((line = reader.ReadLine()) != null && (maxSize - 1 != rear) && !IsFull())
            {

                lineData = line.Split("\t");
                var currentPark = new NationalPark(lineData[0], lineData[1], int.Parse(lineData[2].Replace(",", "")), lineData[3]);
                Insert(currentPark);
            }
        }

    }

    public void RemoveAllItemsInQ()
    {
        while (rear != -1 && !IsEmpty())
        {
            Console.WriteLine("Removed Item : " + ((NationalPark)Remove()).parkName);
        }
        Console.WriteLine("--------------------------------------------------------------------------------------------------------");

    }

    public void Insert(NationalPark nationalPark)
    {
        if (rear == maxSize - 1)
        {
            rear = -1;
        } ((object[])queArray)[++rear] = nationalPark;
        nItems++;

    }

    public Object Remove()
    {
        Object temp = ((object[])queArray)[front++];
        if (front == maxSize)
        {
            front = 0;
        }
        nItems--;
        return temp;
    }

    public int RemoveProduct()
    {
        int temp = ((int[])queArray)[front++];

        if (front == maxSize)
        {
            front = 0;
        }
        nItems--;
        return temp;
    }

    public Object PeekFront()
    {
        return ((object[])queArray)[front];
    }

    public bool IsEmpty()
    {
        return nItems == 0;
    }

    public int size()
    {
        return nItems;
    }

    public bool IsFull()
    {
        return (nItems == maxSize - 1);
    }

}

public class PQCherry
{

    public int capacity;
    public Object pqList; // The type is Object because of Object type value contains the both of NationalPark[] int[] items. Object[] isn't be okay because of the int values are not object type.
    public int nItems;

    public PQCherry(int s) // constructor
    {
        capacity = s;
        pqList = new List<NationalPark>();
        nItems = 0;

    }
    public PQCherry(List<int> list) // constructor
    {
        capacity = list.Count;
        pqList = list;
        nItems = 0;

    }

    public void AddAllItemsToQ(string filePath)
    {
        string line;
        string[] lineData;


        using (StreamReader reader = new StreamReader(filePath))
        {

            while ((line = reader.ReadLine()) != null && !IsFull())
            {

                lineData = line.Split("\t");
                var currentpark = new NationalPark(lineData[0], lineData[1], int.Parse(lineData[2].Replace(",", "")), lineData[3]);
                Insert(currentpark);
            }
        }
    }

    public void RemoveAllItemsInPQ()
    {
        while (!IsEmpty())
        {
            Console.WriteLine("Removed Item : " + ((NationalPark)RemovePark()).parkName);
        }
        Console.WriteLine("--------------------------------------------------------------------------------------------------------");

    }

    public void Insert(NationalPark obj) // insert function for NationalPark items
    {
        ((List<NationalPark>)pqList).Add(obj);
        nItems++;
    }
    public void Insert(int value)
    {

        ((List<int>)pqList).Add((value));
        nItems++;
    }

    public NationalPark RemovePark() //Remove function for NationalPark items.
    {
        int minArea = 9999999;
        int tempI = 0;
        for (int i = 0; i < ((List<NationalPark>)pqList).Count; i++)
        {
            if (minArea > (((List<NationalPark>)pqList)[i]).parkArea) // This method created because of just NationalPark items so we know the pqList type. That is the reason of TypeCast.
            {
                minArea = ((List<NationalPark>)pqList)[i].parkArea;
                tempI = i;
            }
        }
        nItems--;
        var removedItem = ((List<NationalPark>)pqList)[tempI];
        ((List<NationalPark>)pqList).RemoveAt(tempI);

        return removedItem;
    }

    public int RemoveProducts() // Remoce function for List<int> type values.
    {
        List<int> tempArr;
        int tempInt = 99999;
        int tempIndex = 0;
        if (pqList.GetType() == typeof(List<int>))
        {
            tempArr = (List<int>)pqList;
            for (int i = 0; i < tempArr.Count; i++)
            {
                if (tempInt > tempArr[i])
                {
                    tempInt = tempArr[i];
                    tempIndex = i;
                }
            }
            ((List<int>)pqList).RemoveAt(tempIndex);
            return tempInt;
        }
        else
        {
            return tempInt; // impossible
        }
    }

    public object PeekFront()
    {
        if (pqList.GetType() == typeof(List<int>))
        {
            int[] value = (int[])pqList;
            return value.Last();
        }
        else
        {
            return ((List<NationalPark>)pqList).Last(); //
        }

    }

    public bool IsEmpty()
    {
        return nItems == 0;
    }

    public int Size()

    {
        return nItems;
    }

    public bool IsFull()
    {
        return (nItems == capacity - 1);
    }
}

public class CostumerQandPQ
{
    public QCherry qCherry;
    public PQCherry pqCherry;
    public double productWaiting;

    public CostumerQandPQ(QCherry qCherry, PQCherry pqCherry)
    {
        this.qCherry = qCherry;
        this.pqCherry = pqCherry;
        productWaiting = 3.0;  // default 3 seconds.
    }

    public double CalculateQTime() // using q class and enter the int type values so, qCherry.qArr is equals the int[].
    {
        int[] productQ = ((int[])qCherry.queArray); // read the upper sentence. Actually the qCherry.qArr type is object but we know the qCherry.qArr equals to int[]. That is the reason of type cast.
        double sumAllPeople = 0;
        double sumOnePerson = 0;
        double avarageSum;
        int tempProduct;

        Console.WriteLine("-------------------------------------Calculating Queue time...-------------------------------------");
        for (int i = 0; i < productQ.Length; i++)
        {
            tempProduct = qCherry.RemoveProduct();
            sumOnePerson += tempProduct * productWaiting;
            Console.WriteLine("Number Of Product : " + tempProduct + ", Waiting Time : " + sumOnePerson);
            sumAllPeople += sumOnePerson;
        }
        avarageSum = sumAllPeople / (double)productQ.Length;
        return avarageSum;
    }

    public double CalculatePQtime()  // using q class and enter the int type values so, pqCherry.qGenList is equals the int[].
    {
        List<int> collection = (List<int>)pqCherry.pqList; // read the upper sentence. Actually the pqCherry.qGenList type is object but we know the pqCherry.qGenList equals to List<int>. That is the reason of type cast.
        int collectionCount = collection.Count;
        double sumOnePerson = 0;
        double sumAllPeople = 0;
        double avarageSum;
        int tempProduct;

        Console.WriteLine("-------------------------------------Calculating Priority Queue time...-------------------------------------");
        for (int i = 0; i < collectionCount; i++)
        {
            tempProduct = pqCherry.RemoveProducts();
            sumOnePerson += tempProduct * productWaiting; // One person 
            Console.WriteLine( "Number Of Product : " + tempProduct + ", Waiting Time : " + sumOnePerson);
            sumAllPeople += sumOnePerson;
        }
        avarageSum = sumAllPeople / (double)collectionCount;

        return avarageSum;
    }

}