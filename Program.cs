// A minDistance program assignment 2
// Joshua Tucker n9689907
// David Duhig n9683038
using System;
namespace minDistance
{   
    class minDistance
    {   
        public static long testCounter = 0;
        public static int numberRangeLow = 1;
        public static int numberRangeHigh = 100;
        public static int numberRangeArraySizeLow = 2;
        public static int numberRangeArraySizeHigh = 100;
        public static int numberRangeArraySizeMultiplier = 100;
        public static int numberOfArrays = 100;
        static void Main() {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch(); // Create a stopwatch
            
            int[][] myArrayOfArrays = genArrayOfArray(numberOfArrays); // create a list of random arrays

            foreach (int[] myArray in myArrayOfArrays) // for each array in list
            {
                //printArray(myArray);

                watch.Start(); // start timer
                float myminDistance1 = minDistance1(myArray);
                watch.Stop(); // stop timer
                
                //Console.Write(("arrayLength = ");
                Console.Write(myArray.Length + ", ");

                //Console.Write("timer1 = ");
                Console.Write(watch.Elapsed.TotalMilliseconds + ", ");
                watch.Reset();
                //Console.Write("testCounter-minDistance1 = ");
                Console.Write(testCounter + ", ");

                //Console.Write("expected-testCounter-minDistance1 = ");
                Console.Write(myArray.Length* myArray.Length + ", ");


                watch.Start(); // start timer
                float myminDistance2 = minDistance2(myArray);
                watch.Stop(); // stop timer
                
                //Console.Write("timer2 = ");
                Console.Write(watch.Elapsed.TotalMilliseconds + ", ");
                watch.Reset();
                //Console.Write("testCounter-minDistance2 = ");
                Console.Write(testCounter + ", ");

                //Console.Write("expected-testCounter-minDistance2 = ");
                Console.Write(((myArray.Length-1) * myArray.Length)/2 + ", ");

                //Console.WriteLine("testCounter minDistance2 = " + testCounter);
                //Console.WriteLine("minDistance1 dmin = " + minDistance1(myArray));
                //Console.WriteLine("minDistance2 dmin = " + minDistance2(myArray));
                Console.WriteLine();
            }
            
            
        }

        public static float minDistance1(int[] A)
        {
            testCounter = 0;                                       // reset the testCounter to 0
            float zero = 0;                                        // create zero for infinity
            float dmin = 1 / zero;                                 // create infinity float

            for (int i = 0; i < A.Length; i++)                      // for loop from 0 to size of array
            {
                for (int j = 0; j < A.Length; j++)                  // nest for loop from 0 to size of array
                {  
                    if (testCounter++>0 && (i != j)
                        && (Math.Abs(A[i] - A[j]) < dmin))          // Basic Operation // Counter for test purpose
                    {
                        dmin = Math.Abs(A[i] - A[j]);               // assign new minimum distance to dmin 
                    }
                }
            }
            return dmin;                                            // return dmin
        }

        static float minDistance2(int[] A){
            testCounter = 0;                                        // reset the testCounter to 0
            float zero = 0;                                         // create zero for infinity
            float dmin = 1 / zero;                                  // create infinity float
            long arrayLength = A.Length;                            // assign array size to arrayLength
            
            for (int i = 0; i < arrayLength-1; i++){                // nest for loop from j to size of array
                for (int j = i+1; j < arrayLength; j++){            // Nested loop, for each element in array
                    int temp = Math.Abs(A[i] - A[j]);               // assign absolute difference of elements to temp              
                    if (testCounter++ > 0 &&  temp < dmin){         // if temp is less than dmin // Counter for test purpose
                        dmin = temp ;                               // assign temp value to dmin 
                    }               
                }         
            }
            return dmin;                                            //return dmin
        }
        public static int[] genArray(int mySize)
        {
            Random rnd = new Random();
            int[] myArray = new int[mySize];

            for (int i = 0; i < mySize; i++)
            {
                myArray[i] = rnd.Next(numberRangeLow, numberRangeHigh);
            }
            return myArray;
        }

        public static int[][] genArrayOfArray(int numOfArray)
        {
            int[][] myArrayOfArrays = new int[numOfArray][];
            Random rnd = new Random();
            
            int eachArraySize;
            for (int i = 0; i < numOfArray; i++)
            {
                eachArraySize = rnd.Next(numberRangeArraySizeLow, numberRangeArraySizeHigh);
                eachArraySize = eachArraySize * numberRangeArraySizeMultiplier;
                myArrayOfArrays[i] = genArray(eachArraySize);
            }
            return myArrayOfArrays;
        }

        public static void printArrayOfArray(int[][] myArrayOfArray)
        {
            Console.WriteLine("All the arrays :");
            foreach (var item in myArrayOfArray)
            {
                //Console.WriteLine("Array size = " + item.Length); //print size of array
                foreach (var item2 in item)
                {
                    Console.Write(item2.ToString() + ",");

                }
                Console.WriteLine();
            }
        }

        public static void printArray(int[] myArrayOfArray)
        {
            Console.WriteLine("Array :");
            foreach (var item in myArrayOfArray)
            {
                Console.Write(item.ToString() + ",");

            }
            Console.WriteLine();
        }

    }
}
