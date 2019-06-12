using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    [TestFixture]
    class MyTestCase
    {
        [TestCase]
        public void Add()
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

            int[] test = ary[1].calc(28);

            //As per output example on description, '28 YT2' should result in
            //all the items including 2 x 10 packs and 2 x 4 packs.
            Assert.AreEqual(10, test[0]);
            Assert.AreEqual(10, test[1]);
            Assert.AreEqual(4, test[2]);
            Assert.AreEqual(4, test[3]);

            Assert.AreEqual("SH3", ary[0].getId());
        }
    }
}
