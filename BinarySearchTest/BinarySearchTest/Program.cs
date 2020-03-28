using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTest
{
    class Program
    {
        public static string result = "UNKNOW";
        public static Random random = new Random();
        public static int maxNumber = 100;
        public static int time = 0;
        public static int find = 0;
        public static int oldFind = 0;
        public static int difference = 0;
        public static int oldDifference = -1;
        private static int target = 0;
        public static List<int> NumList = new List<int>();

        static void Main(string[] args)
        {
            MyMethod();
        }

        public static void MakeNewTask()
        {
            Console.Clear();
            target = random.Next(0, maxNumber);
            result = "UNKNOW";
            time = 12;
            find = 0;
            oldFind = 0;
            difference = 0;
            oldDifference = -1;
        }

        public static void MyMethod()
        {
            MakeNewTask();

            int count = 0;
            int max = 0;
            int min = 0;
            string oldResult = "";
            bool check = false;
          
            while (true)
            {
                count++;               
                if (result == "WARMER")
                {
                    if (check)
                    {
                        check = false;
                        oldFind = find;                      
                        if (oldResult == "WARMER" || oldResult == "UNKNOW")
                        {
                            max = find;
                                                   
                            find = max = max + (max - min) / 2;
                            min = oldFind;
                        }
                        else if (oldResult == "COLDER")
                        {
                            min = oldFind;
                            --max;
                            find = min + (max - min) / 2;
                        }
                        else if (oldResult == "SAME")
                        {
                            find = max = max + (max - min) / 2;
                        }                       
                    }
                    else
                    {
                        ++find; check = true;
                    }
                    oldResult = "WARMER";
                }
                if (result == "COLDER")
                {
                    if (check)
                    {
                        check = false;
                        oldFind = find;
                        max = oldFind;
                        if (oldResult == "COLDER" || oldResult == "UNKNOW")
                        {
                            --max;
                            find = (max - (max - min) / 2) - 1;
                        }
                        else if (oldResult == "WARMER")
                        {
                            --max;
                            find = (max - (max - min) / 2) - 1;                           
                        }
                        else if (oldResult == "SAME")
                        {
                            find = max = max - (max - min) / 2;
                        }                       
                    }
                    else
                    {
                        ++find; check = true;                       
                    }
                    oldResult = "COLDER";
                }
                if (result == "SAME")
                {                   
                    if (oldResult == "WARMER")
                    {
                        find = oldFind + (find - oldFind) / 2;
                    }
                    else if (oldResult == "COLDER")
                    {
                        find = find + (oldFind - find) / 2;
                    }
                    else
                    {
                        ++find;
                        max = find;
                    }                   
                    oldResult = "SAME";
                }
                if (result == "UNKNOW")
                {
                    if (oldResult == "UNKNOW")
                    {
                        ++find;
                        max = find;
                        check = true;
                    }
                    else
                    {
                        find = max = maxNumber / 2;
                        check = false;
                    }
                                       
                    oldResult = "UNKNOW";
                }
                OutPut(find);
            }
        }

        public static void OutPut(int find)
        {
            if (find > target) { difference = find - target; }
            if (find < target) { difference = target - find; }

            if (oldDifference == -1)
            {
                result = "UNKNOW";
            }
            else if (difference < oldDifference)
            {
                result = "WARMER";
            }
            else if (difference > oldDifference)
            {
                result = "COLDER";
            }
            else if (difference == oldDifference)
            {
                result = "SAME";
            }          
            oldDifference = difference;

            //  PRINT 
            NumList.Add(find);
            Console.WriteLine("TURNS remain: " + time.ToString("0#") + "   TARGET: " + target.ToString() + "   find: " + find.ToString() + "   RESULT: " + result);
            if (find == target)
            {
                Console.Write("\n\npath: ");
                foreach (int num in NumList)
                {
                    Console.Write(num + " ");
                }
               
                Console.WriteLine("\n\nTarget is found: " + target + " : " + find);
                NumList.Clear();
                AskForAgain();                                            
            };
            time--;
            if (time <= 0)
            {
                NumList.Clear();
                Console.WriteLine("\nTarget is not found!");            
                AskForAgain();
            }
        }

        public static void AskForAgain()
        {
            Console.WriteLine("\nAgain? ( y / n )");
            char ans = Console.ReadKey().KeyChar;
            if (ans == 'y')
            {
                Console.Clear();
                MyMethod();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
