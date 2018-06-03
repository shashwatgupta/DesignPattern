using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPattern
{
    class Composite
    {
        public static void Run()
        {
            Item[] list = new Item[3];
            list[0] = new Vegetable();
            list[1] = new Toy();
            list[2] = new ItemCart();
            list[2].Add(list[0]);
            list[2].Add(list[1]);

            foreach(Item x in list)
            {
                Console.WriteLine(x.GetPrice());
            }
        }

        public class Item
        {
            public virtual int GetPrice() { return 0; }
            public virtual void  Add(Item x) { }

            public virtual void Remove(Item x) { }

        }

        public class Toy : Item
        {
            public override int GetPrice()
            {
                return 100;
            }
        }

        public class Vegetable : Item
        {
            public override int GetPrice()
            {
                return 10;
            }
        }


        public class ItemCart: Item
        {
            public override void Add(Item x)
            {
                allItems.Add(x);
            }

            public override void Remove(Item x)
            {
                allItems.Remove(x);
            }

            public override int GetPrice()
            {
                int totalPrice = 0 ;

                foreach (Item x in allItems)
                {
                    totalPrice += x.GetPrice();
                }

                return totalPrice;
            }

            List<Item> allItems = new List<Item>();
        }

    }
}
