
using System;
using System.Collections.Generic;

namespace CreationalDesignPattern
{
    class ProtoType
    {
        public static void Run()
        {
            AnimalFactory af = new AnimalFactory();
            Cow cow = new Cow();
            List<Animal> cowchild = af.CreateChildren(cow);
            foreach (var animalchild in cowchild)
            {
                Console.WriteLine(animalchild.NumberOfLegs());
            }
        }
    }


    public class AnimalFactory
    {
        public List<Animal> CreateChildren(Animal x)
        {
            // A new kind of animal can be cloned w/o modifying this. W/i creating a new factory classes.
            List<Animal> allAnimals = new List<Animal>();
            Animal child1 = x.CloneIt();
            Animal child2 = x.CloneIt();
            allAnimals.Add(child1);
            allAnimals.Add(child2);
            return allAnimals;
        }
    }

    public abstract class Animal
    {
        public abstract int NumberOfLegs();

        public abstract bool IsMammel();

        public bool IsAlive() { return true; }

        public void SetOwner(string owner) { this.owner = owner; }

        public string GetOwner() { return this.owner;  }

        public abstract Animal CloneIt();

        public void SetAge(int x) { age = x; }

        private string owner;

        private int age;
    }

    public class Cow : Animal
    {
        public override bool IsMammel()
        {
            return true;
        }

        public override int NumberOfLegs()
        {
            return 4;
        }

        public override Animal CloneIt() { return (Animal)this.MemberwiseClone(); }
    }

    public class Bird : Animal
    {
        public override bool IsMammel()
        {
            return false;
        }

        public override int NumberOfLegs()
        {
            return 2;
        }

        public override Animal CloneIt() { return (Animal)this.MemberwiseClone(); }
    }
}
