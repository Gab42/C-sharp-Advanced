using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            string singerName ="";
            string venueName = "";
            int ticketNum = 0;
            int ticketPrice = 0;
  
            int length;
            var venues = new Dictionary<string, List<List<string>>>();
            var singers = new List<List<string>>();
            var oneSinger = new List<string>();

            string input = "";
            while (input != "end" && input != "End")
            {
                input = Console.ReadLine();
                if (input != "End" && input != "end")
                {
                    singerName = input.Split('@').First().Trim();
                    input = input.Split('@').Last().Trim();
                    length = input.Split(' ').Count();
                    for (int i = 1; i <= length - 2; i++)
                    {
                        if (venueName == "")
                        {
                            venueName = input.Split(' ').ElementAt(i - 1);
                        }
                        else
                        {
                            venueName = venueName + " " + input.Split(' ').ElementAt(i - 1);
                        }
                    }
                    var tempArr = input.Split(' ').ToArray();
                    ticketPrice = int.Parse(tempArr[tempArr.Length - 1]);
                    ticketNum = int.Parse(tempArr[tempArr.Length - 2]);
                }
                else break;
            }

            bool flag = false;
            if (venues.ContainsKey(venueName))
            {
                foreach (var item in venues[venueName])
                {
                    if (item[0] == singerName)
                    {
                       
                        flag = true;
                        item[1] = item[1] + ticketNum*ticketPrice;
                        break;
                    }
                }
                if (!flag)
                {                                   
                    oneSinger = new List<string>();
                    oneSinger.Add(singerName);
                    oneSinger.Add((ticketNum * ticketPrice).ToString());
                    venues[venueName].Add(oneSinger);
                }


            }
            else
            {
                oneSinger = new List<string>();
                oneSinger.Add(singerName);
                oneSinger.Add((ticketNum*ticketPrice).ToString());
                singers.Add(oneSinger);
                venues.Add(venueName, singers);

            }

            foreach (var item in venues)
            {
                Console.WriteLine(item.Key);
                foreach (var item2 in item.Value)
                {
                    Console.WriteLine("#  " + item2[0] + " -> " + item2[1]);

                }
            }
        }
    }
}
