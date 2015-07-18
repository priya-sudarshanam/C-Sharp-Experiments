using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CExperiments
{
    
    
   // class Program: access
    class Program
    {

        public static Boolean isUniqueChars(String str)
        {
            bool[] charSet = new bool[256];
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i];
                if (charSet[val]) return false;
                charSet[val] = true;
            }
            return true;
        }

        public static String revString(String str)
        {
            string revStr = "";
            char c = '\0';

            for (int i = 0; i < str.Length; i++)
            {
                revStr = str[i] + revStr;
            }
            return c + revStr;

        }

        public static char[] removeDups(String str)
        {
            char[] result = str.ToCharArray();
            return result;

        }

        static void Main(string[] args)
        {
            Console.Write(removeDups("hello"));
           Console.ReadLine();

                       
        }
    }
}
