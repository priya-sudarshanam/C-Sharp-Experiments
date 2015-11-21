using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MaxSubSeq
{
    class Program
    {
        //find the max sum of an array with negative and positive elements
         private static List<int> MaxSubArray(List<int> array)
         {
             List<int> finalList = new List<int>();
             int len = array.Count;
             int maxSum, sum, start, maxStart, end;
             start = maxStart = end = 0;
             sum = maxSum = array[0];
             for (int i = 1; i < len; i++) {                
                 sum += array[i];
                     if (maxSum < sum){
                         maxStart = start;
                         end = i;
                         maxSum = sum;
                     } 
                     else
                         //check for negative array
                         if (array[i] > sum + array[i]){
                             sum = array[i];
                             start = i;
                         }  
             }

             //adding elements to a list
             for (int i = maxStart; i <= end; i++)
             {
                 finalList.Add(array[i]);
             }

             //adding the maxSum at the end to print in the main function
             finalList.Add(maxSum);

             //return the finaList
             return finalList;
         }
        
         //separate negative and positive elements of an array
         private static void ArrayNumbers(List<int> array, out List<int> negArray, 
              out List<int> posArray)
         {
             List<int> negList = new List<int>();
             List<int> posList = new List<int>();

             foreach (int i in array){
                 if (i < 0){
                     negList.Add(i);
                 } else {
                     posList.Add(i);
                 }
             }

             negArray = negList;
             posArray = posList;

         }

        //find duplicates in an array
        private static void DuplArray(List<int> array, out List<int> unique)
        {
            List<int> uniqList = new List<int>();
            Dictionary<string, int> arrayDict = new Dictionary<string, int>();
            
            foreach(int i in array){
                if (arrayDict.ContainsKey(i.ToString())){
                    arrayDict[i.ToString()] += 1;
                } else {
                    arrayDict.Add(i.ToString(), 1);
                }
            }

            foreach(var entry in arrayDict){
                if (entry.Value == 1)
                    uniqList.Add(Int32.Parse(entry.Key));
            }
            unique = uniqList;
        }
        
        //divide a number into dividend equal parts
        private static void EqualParts(int n, int dividend)
        {
            List<int> equalList = new List<int>();
            int arrayCount = dividend / n;
            int remainingElem = dividend;
            
            for (int i = n;i >= 1; i -= 1) {
                int eltCount = remainingElem / i;
                equalList.Add(eltCount);
                remainingElem -= eltCount;
            }

            foreach (int i in equalList)
                Console.WriteLine(i);
            Console.ReadKey();
        } 

        //reverse a string
        private static void RevString(String s)
        {
            StringBuilder finalString = new StringBuilder();
            char end = '\0';

            foreach (char c in s)
            {
                finalString.Insert(0, c);
            }

            Console.WriteLine(finalString.Insert(0,end));
            Console.ReadKey();
        } 
        //check if two words are anagrams
        private static void Anagram(String a, String b)
        {
            Boolean isAnag = true;
            if (a.Length != b.Length)
            {
                isAnag = false;
            }
            else
            {
                char[] first = a.ToCharArray();
                char[] second = b.ToCharArray();
                Array.Sort(first);
                Array.Sort(second);
                Queue<char> firstQueue = new Queue<char>();
                Queue<char> secondQueue = new Queue<char>();
                foreach (char f in first)
                {
                    firstQueue.Enqueue(f);
                }
                foreach (char s in second)
                {
                    secondQueue.Enqueue(s);
                }
                while ((firstQueue.Count != 0) && isAnag)
                {
                    if (!(firstQueue.Dequeue() == secondQueue.Dequeue()))
                    {
                        isAnag = false;
                    }
                }
            }

            Console.WriteLine(isAnag);
        }

        private static void isSubstring(String a, String b)
        {
            bool isSub = a.Contains(b) ? true : false;
            Console.WriteLine(isSub);
        }

        private static void isRotation(String a, String b)
        {
            String fullString = a + a;
            isSubstring(fullString, b);
        } 

        private static Dictionary<int, int> cacheMap = new Dictionary<int, int>();
        private static HashSet<int> visitedNums = new HashSet<int>();
       
        //find all the pair that sums up to a particular sum
        private static void PairSum(int[] array, int sum)
        {
            Console.WriteLine("Pairs that sum up to " + sum);
            foreach(int j in array){
                int x = sum - j;
                if (cacheMap.ContainsKey(x) && (!(visitedNums.Contains(x)))){
                    Console.WriteLine(j + ":" + x);
                }
                visitedNums.Add(x);
                visitedNums.Add(j);
            }
        }

        private static void initCacheMap(int[] array)
        {
            foreach (int i in array)
            {
               if(!(cacheMap.ContainsKey(i))){
                   cacheMap[i] = 1;
               }
            }            
        }

        private static Dictionary<char, int> charInt = new Dictionary<char, int>();
          
        private static int ConvertToKey(String s)
        {
            int alphaKey = 1;
            charInt['a'] = 2;
            charInt['b'] = 3;
            charInt['c'] = 5;
            charInt['d'] = 7;
            charInt['e'] = 11;
            charInt['h'] = 19;
            charInt['t'] = 71;
            charInt['l'] = 37;
            charInt['i'] = 23;
            charInt['s'] = 67;
            charInt['p'] = 53;            
            charInt['o'] = 47;

            foreach (char x in s){
                alphaKey *= charInt[x];
            }
            return alphaKey;
        }

        private static string sortWordLexicographically(string word)
        {
            IEnumerable<string> sortedWord = Enumerable.Range(0, word.Length).Select(i => word.Substring(i)).OrderBy(s => s);
            return string.Join("",sortedWord);
        }

        private static Dictionary<int, List<String>> anagramDict = new Dictionary<int, List<string>>();

        private static void findAnagrams(List<string> dictionary){   
            foreach (string word in dictionary){
                int wordKey = ConvertToKey(word);
                if(!(anagramDict.ContainsKey(wordKey))){
                    anagramDict.Add(wordKey, new List<string>());
                   } 
                anagramDict[wordKey].Add(word);               
            }    
        }

        public static List<String> getAnagrams(String word){
            if (word == null){
                return null;
            }
            int wordkey = ConvertToKey(word);
            return anagramDict[wordkey];
        }

        private static void printAnagrams(String word){            
            if (word == null){
                Console.WriteLine("No word found");
            } else {
                List<string> wordList = getAnagrams(word);                
                if (wordList == null){                    
                    Console.WriteLine("No anagrams found for the word");
                } else {
                    foreach (string v in wordList){
                        Console.WriteLine(v);
                    }
                }
            }
        } 

        private static void FixArray(List<int> A)
        {
            int low, mid, high, left;
            List<int> temp = new List<int>();
            low = 0; high = A.Count - 1; mid = (low + high) / 2; left = mid - 1;
            while (!(A[left] > A[mid])) {
                    mid = left;
                    left -= 1;
                }           
            for (int i = low; i <= left; ++i){
                temp.Add(A[i]);
            }
            A.RemoveRange(low, left - low+1);
            A.AddRange(temp);                       
        }

        private static  int BinarySearch(List<int> A, int key)
        {
            int keyIndex = -1;
            int min, max, mid;
            min = 0; max = A.Count - 1;
            while (min <= max){
                 mid = (min + max) / 2;
                
                if (key == A[mid]) {
                    keyIndex = mid;
                    return keyIndex+1;                   
                } else if (key < A[mid]) {
                    max = mid - 1;
                } else {
                    min = mid + 1;
                }
            }
            return keyIndex;

        } 

        private static SortedDictionary<int,string> wordDict = new SortedDictionary<int,string>();

        private static void CreateDictionary(String text, List<string> tokens)
        {
            foreach (string i in tokens)
            {
                int j = text.IndexOf(i);
                if (!(j == -1)){
                    wordDict[j] = i;
                }
            }            
        }

        private static void GetSentFromRawText(String text, List<string> tokens)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string val in wordDict.Values)
            {
                sb.Append(val+" ");
            }
            
            Console.WriteLine(sb);
             
         } 

        private static int charPosition(char c)
        {
            int i = (char.ToLower(c) % 32) - 1;
            return i;
        }

        //find the first non repeating element in a list
        public static void FirstNonRepeatingList(String s)
        {
            List<int> alphaPositionList = Enumerable.Repeat(0, 26).ToList();
            List<char> nonRepeatableList = new List<char>();

            s = s.ToLower();

            foreach (char i in s){
                if (alphaPositionList[charPosition(i)] < 1){
                    nonRepeatableList.Add(i);
                    alphaPositionList[charPosition(i)] += 1;
                } else {
                    if (alphaPositionList[charPosition(i)] == 1) {
                        nonRepeatableList.Remove(i);
                    }
                }
                 
             }
              Console.WriteLine(nonRepeatableList[0]);
                     
            } 

        //dutch national flag problem
        private static void DutchNationalFlag(List<int> arr)
        {
            int j, tmp, p;
            p = 0; j = 0;
            int max = arr.Count() - 1;
            while (j <= max) {
                if (arr[j] == 0){                    
                    tmp = arr[p];
                    arr[p] = arr[j];
                    arr[j] = tmp;
                    p += 1;
                    j += 1;
                } else if (arr[j] == 2) {
                    tmp = arr[max];
                    arr[max] = arr[j];
                    arr[j] = tmp;
                    max -= 1;                    
                } else {
                    j += 1;
                }

              }
            foreach (int i in arr) {
                Console.WriteLine(i);
            }
        }

        //find the minimum element in the sorted and rotated array
        private static void MinEltRotatedArray(List<int> arr)
        {
            int low, high, mid;
            low = 0; high = arr.Count() - 1; mid = (low + high) / 2;

            int min = 0;
            //case 4,5,6,1,2,3
            if(arr[mid - 1] > arr[mid]  && arr[mid] < arr[mid+1]){
                min = arr[mid];
            } //case 3,4,5,6,1,2 
            else if (arr[mid] < arr[mid] && arr[mid] > arr[mid + 1]) {
                min = arr[mid + 1];
            } else // mid is in chronological order
            {
                if (arr[high] > arr[mid]) {
                    while (arr[mid] > arr[mid - 1]) {
                        mid -= 1;
                    }
                    min = arr[mid];
                } else {
                    while (arr[mid] < arr[mid + 1]) {
                        mid += 1;
                    }
                    min = arr[mid+1];
                }
            }
            Console.WriteLine("Min element is: " + min);
        } 

        /*private static int charPosition(char c)
        {
            int i = (char.ToLower(c) % 32) - 1;
            return i;
        }*/

        //find the max repeating element in a list
        public static void MaxRepeatingList(String s)
        {
            List<int> alphaPositionList = Enumerable.Repeat(0, 26).ToList();
            
            int maxCounter = 0;
            char maxChar = 'a';
            s = s.ToLower();

            foreach (char i in s){

                alphaPositionList[charPosition(i)] += 1;
                if (alphaPositionList[charPosition(i)] > maxCounter) {
                    maxCounter = alphaPositionList[charPosition(i)];
                    maxChar = i;
                }                 
            }
            Console.WriteLine(maxChar);
        } 
        

        //find the smallest positive number in an array
        private static void SmallestPositiveNumber(List<int> arr)
        {
            List<bool> boolList = Enumerable.Repeat(false, arr.Count).ToList();
            foreach (int i in arr){
                if (i > 0 && i < arr.Count)
                   boolList[i] = true;
            }
            for (int i = 1; i < boolList.Count(); i++) {
                if (!(boolList[i])) {
                    Console.WriteLine(i);
                    break;
                }
             }          
            
        }

        private static int rand(int l, int h)
        {
            Random rand = new Random();
            return l + (int)(rand.Next(h - l + 1));
           
        }

        private static List<int> RandomNumbers(List<int> arr, int m)
        {
            List<int> subset = new List<int>();
            List<int> array = new List<int>();
            array = arr;
            
            for (int i = 0; i < m; i++)
            {
                int r = rand(i, array.Count-1);
                subset.Add(array[r]);
                array[r] = array[i];
            }

            return subset;
        }
        //separate negatives and positives in an array without 
        //changing order with O(1) space
        private static void SeparateNegativesPositives(List<int> lst)
        {
            int k = 0;
            for (int i = 0; i < lst.Count; i++) {
                int temp = 0;
                //if the number is less than 0
                if (lst[i] < 0)                {
                    //hold the value in a temp variable
                    temp = lst[i];
                    //remove it from the list
                    lst.Remove(lst[i]);
                    //insert it at the kth position
                    lst.Insert(k, temp);
                    //increment k
                    k++;                                      
                }           
            }
            foreach (int i in lst){
                Console.WriteLine(i);
            }
        } 

        private static int DividedByThree(string s){
            if (s.Length == 1)
                return Int32.Parse(s);
            else
              return (Int32.Parse(s)) % 10 + DividedByThree(s.Substring(1, s.Length - 1));
        }

        private static bool IsPrime(int number)
        {
            //convert the number to string
            String numToString = number.ToString();
            int numLength = numToString.Length;
            String subNumToString = numToString.Substring(numToString.Length - 1);

            //create a list of evens
            List<int> evenList = new List<int> { 0, 2, 4, 6, 8 };
            List<int> oddList = new List<int> { 3,6,9 };
            //get the square root of the number
            int maxDivider = (int)number/2;

            //first case number is 2, only even prime number
            if (number == 2)
                return true;
            
            //check for number div by 3
            if (numToString.Length > 1){
                int div3 = DividedByThree(numToString);
                if (div3.ToString().Length > 1) {
                    div3 = DividedByThree(numToString);
                } else {
                    if (oddList.Contains(div3))
                        return true;
                }
            }

            //second case: check if the units position is even
            foreach (int i in evenList){
                if (numToString.EndsWith(i.ToString())){
                    return false;
                }
            }

            if (numToString.Length > 1) {
                string s = numToString.Substring(numToString.Length - 1, 1);
                if (s == "0" || s == "5") {
                    return false;
                }
            }

            //third case: check if the number has any factors between 3 and its square-root
            for (int divider = 3; divider <= maxDivider; divider += 2) {
                if (number % divider == 0) {
                    return false;
                }
            }
            return true;
        }

        //Find the next prime number
        private static int FindNextPrime(int startNumber){
            int number = startNumber;
            //run loop till the next prime number is found
            while (!IsPrime(number)) {
                number++;
            }
            return number;
        }
        //print the matrix of prime numbers
        private static void PrintMatrix(int dimension) {
            int currentPrime = 1;
            for (int row = 0; row < dimension; row++) {
                for (int col = 0; col < dimension; col++) {
                    int nextPrime = FindNextPrime(currentPrime + 1);
                    Console.Write("{0,0}\t ", nextPrime);
                    currentPrime = nextPrime;
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        } 

        
        static void Main(string[] args)
        {

            PrintMatrix(5);
           // sortNum();
            
            // Subarray();
            //initialize list and variables
            /*  List<int> l = new List<int>{1, -3, 5, -2, 9, -8, -6, -4};
              List<int> finalList = new List<int>();
              finalList = MaxSubArray(l);

              //retrieve the last element which is the maxSum
              int maxSum = finalList[finalList.Count-1];
              finalList.Remove(finalList.Last());

              //print the range and maxSum
              Console.WriteLine("MaxSum = {0}, Elements are: [{1}]",maxSum,string.Join(",",finalList));
              Console.ReadKey();*/

            // List<int> l = new List<int> { 1, 3, 5, 2, 3,1,2,4,5};
            // int[] m = new int[]{ 1, -3, 5, -2, -3, 1, -2, 4, 5};
            /*List<int> neg = new List<int>();
            List<int> pos = new List<int>();
            ArrayNumbers(l,out neg, out pos);

            foreach (int i in neg){
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");
            foreach (int i in pos)
            {
                Console.WriteLine(i);
            }
            
            List<int> uniq = new List<int>();
            DuplArray(l, out uniq);
            foreach(int i in uniq){
                Console.WriteLine(i);
            } 

          //  EqualParts(4,121);
           // RevString("hello");
           // Anagram("hello", "hellp");
           // isRotation("waterbottle", "erbottlewat");
           // int[] A = { 5, 9, 2, 11, 3, 8, 15, 7, 4, 12, 1 };
           // initCacheMap(A);
            //PairSum(A, 12);
            List<string> wordList = new List<string>() {"ate","slip","tea","ohell","lisp","eat","hello" };
            findAnagrams(wordList);
            printAnagrams("hello");
            List<int> A = new List<int>() { 10, 12, 56, 2, 3, 8, 9 }; 
            int key = 3;
            FixArray(A);
            int a = BinarySearch(A, key);
            Console.WriteLine("Index of the element " + key + " is: " + a); 
            string text = "iamastudentfromwaterloo";
            List<string> tokens = new List<string>{"from", "waterloo", "hi", "am", "as", "stud", "yes", "i", "a", "student"};
            CreateDictionary(text, tokens);
            GetSentFromRawText(text, tokens); 

            List<int> A = new List<int>() { 1, 2, 3 };
            findSubsets(A, 2);
            List<char> arr = new List<char>() {'A', 'A', 'A', 'C', 'C', 'B', 'B','A','A','A', 'C', 'C', 'C', 'B', 'C', 'C', 'A','A'};
            Console.WriteLine(findMajorityElement(arr));
            FirstNonRepeatingList("abcdecba");
            List<int> arr = new List<int>{2, 3, 3, 5, 3, 4, 1, 7};
            
            MaxRepeatingElement(arr);
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
            List<int> result = new List<int> {0, 1, 2, 2, 1, 0};
            DutchNationalFlag(result); 
            List<int> result = new List<int> { 3, 4, 5, 6, 1, 2 };
            List<int> result1 = new List<int> { 4, 5, 6, 1, 2, 3 };
            List<int> result2 = new List<int> { 5,6,1,2,3,4 };
            List<int> result3 = new List<int> {6,1,2,3,4,5 };
            List<int> result4 = new List<int> {2,3,4,5,6,1 };
            MinEltRotatedArray(result4);
            String arr = "1111221111333333311333333333333";
            MaxRepeatingList(arr);
            List<int> arr = new List<int>{2, 3, 7, 6, 8, -1, -10, 15};
            List<int> arr1 = new List<int> { 5, 7, 2, 1, 4 };
            SmallestPositiveNumber(arr1); 
            List<int> arr1 = new List<int>();
            List<int> result1 = new List<int> { 4, 5, 6, 1, 2, 3 };
            arr1 = RandomNumbers(result1, 3);
            foreach (int i in arr1)
            {
                Console.WriteLine(i);
            }
            List<int> lst = new List<int>(){-6,2,1,2,-10,-4,8};
            fixArray(lst);
            Console.ReadKey();

            String input = "The Dogman was no ordinary dog, nor man,"+
               "but rather a peculiar doglike man who barked like a dog," + 
               "and panted like a dog, he even ate like a dog.  He owned a dog " +
               "named Doglips, and interestingly enough, his favorite food was hotdogs.";
            //declare and initialize variables
            int index, count;
            index = 0; count = 0;
            string word = "dog";
            
            while(index > -1)
            {
                index = input.IndexOf(word, index + 1);
                if (index != -1)
                {
                    count++;
                    Console.WriteLine(count + ":" + index);                   
                }
            }
            Console.WriteLine("The word \"dog\" appears "+count+" times.");
            Console.ReadKey();
            
          } 
        int[] unsorted = new int[10];
        Random rnd = new Random();
        for(int i = 0; i < 10; i++)
          unsorted[i] = (int)(rnd.Next(i));
        Console.WriteLine("Here are the unsorted numbers:");
        for(int i = 0; i < 10; i++) Console.WriteLine(unsorted[i]+" ");
        Console.WriteLine();
        int[] sorted = new int[10];
        for(int i = 0; i < 10; i++)
        {
          int hi = -1;
          int hiIndex = -1;
          for(int j = 0; j < 10; j++)
          {
            if(unsorted[j] > hi)
            {
              hi = unsorted[j];
              hiIndex = j;
            }
          }
          sorted[i] = hi;
          unsorted[hiIndex] = -1;
        }
        Console.WriteLine("Here are the sorted numbers:");
        for(int i = 0; i < 10; i++) Console.WriteLine(sorted[i]+" ");
        Console.WriteLine();
       Console.ReadKey();
      }*/

        }
    }
                
    
}
