using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    static class ArrayExtensions

    {
        public static int[] sortArray(this int[] array)
        {
            int limit = array.Length;
            for (int j = 0; j < limit; j++)
            {
                for (int i = 0; i + 1 != array.Length; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int n = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = n;
                    }
                }
            }
            return array;
        }
        public static int[] fillWithRandonNumber(this int[] array,int min,int max)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++) { array[i] = (int)rnd.Next(min, max); }
            return array;
        }
        public static void ShowArray (this int[] array)
        {
            foreach (int i in array.sortArray())
            {
                Console.Write(i + " ");
            }
            
        }
        public static int BynarySearch (this int[] array,int numberToFind)
        {
            int positionFound = (int)Math.Floor((double)array.Length / 2);
            int maxRange = array.Length - 1;
            int minRange = 0;
            while (minRange != maxRange)
            {
                positionFound = (maxRange + minRange) / 2;
                //Console.WriteLine("The number in position " + positionFound + " is " + array[positionFound]);
                if (array[positionFound] > numberToFind)
                {
                    maxRange = positionFound;
                }
                else if (array[positionFound] < numberToFind)
                {
                    minRange = positionFound;
                }
                else
                {                    
                    Console.WriteLine("The closest number to " + numberToFind + " is " + array[positionFound] + " in position " + positionFound);
                    break;
                }
            }
            return positionFound;
        }

    }

    
    class Program
    {
        static void Main(string[] args)
        {          
            int[] numbers = new int[98];
            numbers.fillWithRandonNumber(100, 300).sortArray().ShowArray();
            Console.WriteLine("A posicao do 280 é "+numbers.BynarySearch(280));            
            Console.ReadKey();
            
        }
       

    }
}
