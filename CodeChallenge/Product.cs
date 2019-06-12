using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    public class Product
    {
        private string name;
        private string id;
        private SortedDictionary<int, double> list;

        public Product(string name, string id)
        {
            this.name = name;
            this.id = id;
            list = new SortedDictionary<int, double>();
        }

        public string getName()
        {
            return this.name;
        }

        public string getId()
        {
            return this.id;
        }

        public double getPrice(int qty)
        {
            return list[qty];
        }

        public void setDeals(int packQty, double price)
        {

            list.Add(packQty, price);
        }

        public void getDeals()
        {
            foreach (var x in this.list)
            {
                Console.WriteLine(x.Key + ": " + x.Value);
            }
        }

        /* My algorithm was to re-arrange the array to the largest qty first (As assumed that a higher qty
         * had a lower price) so that if a higher qty of a product fit into the users qty total. The loop will
         * then iterate through each pack qty and if it matched it will break out of the loop
         */
        public int[] calc(int items)
        {
            int qty;
            int[] temp = new int[list.Count];

            int count = list.Count;


            foreach (var k in list)
            {
                int num = k.Key;
                temp[count - 1] = num;
                count--;
            }


            //boolean to break out of loop when a match has been found
            bool success = false;
            ArrayList resultStack = new ArrayList();

            int startPos = 0;
            do
            {
                //create 2 variables. one for starting position and one for iterating
                //empty list and start from second
                qty = items;
                resultStack.Clear();
                int x = startPos;

                for (; x < temp.Length; x++)
                {
                    while ((qty - temp[x]) >= 0)
                    {
                        qty = qty - temp[x];
                        resultStack.Add(temp[x]);
                        if (qty == 0)
                        {
                            success = true;
                            break;
                        }
                    }

                }

                if (startPos == (temp.Length - 1))
                {
                    Console.WriteLine("Nothing Found");
                    break;
                }
                startPos++;

            } while (success == false);

            int[] results = resultStack.Cast<int>().ToArray();

            return results;
        }


        public void print(int[] results, int count)
        {
            int[] items = results;
            string showResults = "";
            double totalPrice = 0;
            Dictionary<int, double> output = new Dictionary<int, double>();

            for (int x = 0; x < results.Length; x++)
            {
                totalPrice += getPrice(results[x]);
                if (output.ContainsKey(results[x]))
                {
                    output[results[x]]++;
                }
                else
                {
                    output.Add(results[x], 1);
                }
            }

            foreach (var y in output)
            {
                showResults += y.Value + " x " + y.Key + " $" +
                    this.getPrice(y.Key) + "\n";
            }

            Console.Write(count + " " + getId() + " " + "$" + totalPrice
                + "\n" + showResults + "\n");
        }
    }
}
