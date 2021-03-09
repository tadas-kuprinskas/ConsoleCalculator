using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer = "";
            
            do
            {
                ConsoleText();
                string operation = Console.ReadLine();
                string calcOperator = FindAnOperator(operation);
                List<double> listName = StoreNumbersToList(operation);
                Calculate(listName, calcOperator);
                answer = ContinueCounting();
                Console.Clear();
            } while (answer.ToLower() == "yes");
 
        }

        public static string FindAnOperator(string operation)
        {
            if(operation.IndexOf('+') != -1)
            {
                return "+";
            } 
            else if (operation.IndexOf('-') != -1)
            {
                return "-";
            }
            else if (operation.IndexOf('/') != -1)
            {
                return "/";
            }
            else if (operation.IndexOf('*') != -1)
            {
                return "*";
            }
            else
            {
                return "Invalid Operation";
            }
        }

        public static string[] FindTheNumbers(string operation)
        {
            string calculationOperator = FindAnOperator(operation);
            string[] numbers = operation.Split(calculationOperator);
            return numbers;
        }

        public static List<double> StoreNumbersToList(string operation)
        {
            string[] textNumbers = FindTheNumbers(operation);
            List<double> numbersList = new List<double>();

            ValidateOperation(numbersList, textNumbers);

            return numbersList;
        }

        public static void ValidateOperation(List<double> listName, string[] arrayName)
        {
            if (arrayName != null || arrayName.Length != 0)
            {
                foreach (var item in arrayName)
                {
                    item.Trim();

                    if (double.TryParse(item, out double result))
                    {
                        listName.Add(result);
                    }
                    else
                    {
                        Console.WriteLine("Invalid operation");
                    }
                }
            }
            else
                Console.WriteLine("No numbers found");
        }

        public static void Calculate(List<double> listName, string operation)
        {
            double? result = 0;

            for (int i = 0; i < listName.Count; i++)
            {
                if (operation == "+")
                {
                    if (i == 0)
                    {
                        result = listName[i];
                    }
                    else
                    {
                        result += listName[i];                    
                    }
                }
                else if (operation == "-")
                {
                    if (i == 0)
                    {
                        result = listName[i];
                    }
                    else
                    {
                        result -= listName[i];
                    }
                }
                else if (operation == "*")
                {
                    if (i == 0)
                    {
                        result = listName[i];
                    }
                    else
                    {
                        result *= listName[i];
                    }
                }
                else if (operation == "/")
                {
                    if (i == 0)
                    {
                        result = listName[i];
                    }
                    else if (listName[i] == 0)
                    {
                        Console.WriteLine("Division by zero");
                        result = null;
                    }
                    else
                    {
                        result /= listName[i];
                    }
                }
        }
                Console.WriteLine($"Result: {result}");
        }
        public static string ContinueCounting()
        {
            Console.WriteLine("Do you want to continue counting? (Yes/No)");
            string answer = Console.ReadLine();
            return answer;
        }

        public static void ConsoleText()
        {
            Console.WriteLine("          CALCULATOR");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("TYPE THE OPERATION TO CALCULATE");
            Console.WriteLine();
        }
    }
}
