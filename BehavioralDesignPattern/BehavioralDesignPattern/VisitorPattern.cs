using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralDesignPattern
{
    class VisitorPattern
    {
        public static void Run()
        {
            Cat c = new Cat("MyCat");
            c.Accept(new EatMoreVisitor());
            c.PerformVisitOperation();

        }
    }

    public abstract class Visitor
    {
        public abstract void VisitCat(Cat x);
        public abstract void VisitDog(Dog x);
    }

    public class EatMoreVisitor : Visitor
    {
        public override void VisitCat(Cat x)
        {
            x.EatFood();
            x.EatFood();
        }
        public override void VisitDog(Dog x)
        {
            x.EatFood();
            x.EatFood();
        }
    }

    public class SoundMoreVisitor : Visitor
    {
        public override void VisitCat(Cat x)
        {
            x.MakeSound();
            x.MakeSound();
        }
        public override void VisitDog(Dog x)
        {
            x.MakeSound();
            x.MakeSound();
        }
    }




    public abstract class Animal
    {
        public Animal (string name)
        {
            this.Name = name;
        }
        public virtual void Accept(Visitor v) { this._v = v; }
        public abstract void PerformVisitOperation();
        public abstract void MakeSound();
        public abstract void EatFood();
        protected string Name;
        protected Visitor _v;

    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name)
        {
         // Nothing here
        }

        public override void PerformVisitOperation()
        {
            _v.VisitCat(this);
        }

        public override void MakeSound()
        {
            Console.WriteLine("Make Mewww");

        }
        public override void EatFood()
        {
            Console.WriteLine("Eating Cat Food");
        }
    }

    public class Dog : Animal
    {

        public Dog(string name) : base(name)
        {
            // Nothing here
        }

        public override void PerformVisitOperation()
        {
            _v.VisitDog(this);
        }

        public override void MakeSound()
        {
            Console.WriteLine("Make Bhaoooo");
        }
        public override void EatFood()
        {
            Console.WriteLine("Eating Dog Food");
        }
    }



}
