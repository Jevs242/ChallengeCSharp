// See https://aka.ms/new-console-template for more information


using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        //day1();
        day5();
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
    }

    static void day1()
    {
        var url = "day1.txt";
        string[] calories = File.ReadAllLines(url);
        List<Int32> listSumCalories = new List<Int32>();
        Int32 fixNumber = 0;
        Int32 verificationNumber = 0;

        foreach (string cal in calories)
        {
            if(int.TryParse(cal, out verificationNumber))
            {
                fixNumber += verificationNumber;
            }
            else
            {
                listSumCalories.Add(fixNumber);
                fixNumber = 0;
            }
        }

        listSumCalories.Sort();
        listSumCalories.Reverse();
        Console.WriteLine("\nResult = " + listSumCalories.First());

        int sum = listSumCalories[0] + listSumCalories[1] + listSumCalories[2];

        Console.WriteLine("\nResult = " + sum);
    }


    static void day5()
    {
        var url = "day4.txt";
        string[] doc = File.ReadAllLines(url);
        List<string> table = new List<string>();
        List<string> command = new List<string>();
        bool space = false;

        foreach(string line in doc)
        {
            if(line == "")
            {
                space = true;
            }

            if(space)
            {
                command.Add(line);
            }
            else
            {
                table.Add(line);
            }
        }

        table.RemoveAt(table.Count - 1);
        for(int i = 0; i < table.Count();i++)
        {
            table[i] = table[i].Replace(" [", "");
            table[i] = table[i].Replace("]", "");
            table[i] = table[i].Replace("[", "");
        }

        foreach(string line in table)
        {
            Console.WriteLine(line);
        }

        foreach (string line in command)
        {
           //Console.WriteLine(line);
        }
        Console.WriteLine("====");
        List<string> fixTable = new List<string>();

        for(int i = 0; i < 9; i++)
        {
            fixTable.Add("");
        }

        for(int j = 0; j < table.Count; j++)
        {
            for(int i = 0; i < fixTable.Count; i++)
            {
                fixTable[i] += table[j][i] + "";
            }
        }

        

        List<int> move = new List<int>();
        List<int> from = new List<int>();
        List<int> to = new List<int>();
        int number;

        foreach(string line in command)
        {
            int i = 0;
            bool b = false;
            string f = "";
            int index= 0;
            foreach (char character in line)
            {
                if(int.TryParse(character + "" ,out number))
                {
                    switch(i)
                    {
                        case 0: 
                            b = true;
                            f = character + "";
                            if (int.TryParse(line[index + 1] + "" , out number))
                            {
                                f += number + "";
                            }

                            if(int.TryParse(f +  "", out number))
                            {
                                move.Add(number);
                            }
                            break;
                        case 1:
                            from.Add(number);
                            break;
                        case 2:
                            to.Add(number);
                            break;
                        default:
                            break;
                    }
                    if(b != false)
                    {
                        i++;

                    }

                }
                else
                {
                    b = false;
                }
                index++;
            }
        }

        for(int i = 0; i < fixTable.Count; i++)
        {
            fixTable[i] = new string(fixTable[i].Reverse().ToArray());
        }

        foreach (string line in fixTable)
        {
            Console.WriteLine(line);
        }
    }

}
