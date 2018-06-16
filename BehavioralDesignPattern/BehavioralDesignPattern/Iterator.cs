using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralDesignPattern
{
    class Iterator
    {
        public static void Run()
        {
            ShoppingList shoppingList = new ShoppingList();
            var Iterator = shoppingList.GetIterator();
            for (; !Iterator.IsDone(); Iterator.Next())
            {
                Console.WriteLine(Iterator.GetCurrent().Name);
            }
        }
    }

    public class ShoppingItem
    {
        public string Name;

        public int price;
    }

    public class ShoppingList
    {
        public ShoppingIterator GetIterator()
        {
            return new ShoppingIterator(this);
        }
        public void Add(ShoppingItem x)
        {
            shoppingList[0] = x;
        }

        public ShoppingItem GetItem(int index)
        {
            return shoppingList[index];
        }

        public int Size()
        {
            return shoppingList.Count();
        }

        public ShoppingItem[]  shoppingList = new ShoppingItem[100];
    }

    public class ShoppingIterator
    {
        public ShoppingIterator(ShoppingList shoppingList)
        {
            _shoppingList = shoppingList;
        }
        public ShoppingItem First()
        {
            return _shoppingList.GetItem(0);
        }
        public void Next()
        {
            index++;
        }
        public ShoppingItem GetCurrent()
        {
            return _shoppingList.GetItem(index);
        }
        public bool IsDone()
        {
            return index == _shoppingList.Size();
        }

        private int index = 0;
        private ShoppingList _shoppingList;
    }
}
