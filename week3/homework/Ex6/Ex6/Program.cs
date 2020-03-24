using System;

namespace Ex6
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray64 simpleBitArray = new BitArray64(9);

            Console.WriteLine(simpleBitArray);

            simpleBitArray[2] = 1;            
            
            //throws ex: simpleBitArray[65] = 1; 

            Console.WriteLine(simpleBitArray);


            Console.WriteLine(simpleBitArray[2] == simpleBitArray[3]);
            
            
            Console.WriteLine(simpleBitArray[1] == simpleBitArray[3]);


            foreach (var value in simpleBitArray)
            {
                Console.WriteLine(value);
            }

            BitArray64 otherBitArray = new BitArray64(4);
            
            BitArray64 latestBitArray = new BitArray64(13);

            bool areEqual = simpleBitArray.Equals(otherBitArray);
            Console.WriteLine("simpleBitArray == otherBitArray -> {0}", areEqual);            
            
            bool areEqual2 = simpleBitArray.Equals(latestBitArray);
            Console.WriteLine("simpleBitArray == latestBitArray -> {0}", areEqual2);

            Console.WriteLine(simpleBitArray.GetHashCode());

        }
    }
}
