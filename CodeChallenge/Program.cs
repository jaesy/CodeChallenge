using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] ary = new Product[3];

            ary[0] = new Product("Sliced Ham", "SH3");
            ary[0].setDeals(3, 2.99);
            ary[0].setDeals(5, 4.49);

            ary[1] = new Product("Yoghurt", "YT2");
            ary[1].setDeals(4, 4.95);
            ary[1].setDeals(10, 9.95);
            ary[1].setDeals(15, 13.95);


            ary[2] = new Product("Toilet Rolls", "TR");
            ary[2].setDeals(3, 2.95);
            ary[2].setDeals(5, 4.45);
            ary[2].setDeals(9, 7.99);


            Console.WriteLine("Enter number of cases: ");
            int num = Convert.ToInt32(Console.ReadLine());
            string[] cases = new string[num];
            Console.WriteLine("Enter data: ");
            for (int x = 0; x < num; x++)
            {
                cases[x] = Console.ReadLine();
            }

            for (int x = 0; x < cases.Length; x++)
            {
                try
                {
                    string[] single = cases[x].Split(' ');
                    int temp = Convert.ToInt32(single[0]);

                    for (int n = 0; n < ary.Length; n++)
                    {
                        if (ary[n].getId().Equals(single[1]))
                        {

                            int[] tempID = ary[n].calc(temp);

                            ary[n].print(tempID, temp);
                            goto End;
                        }
                    }

                }
                catch (Exception e) //catch anything invalid from input and move to next case
                {
                    Console.WriteLine("Invalid number or product not found");
                }
            End:;
            }
            Console.ReadLine();
        }
    }
}
