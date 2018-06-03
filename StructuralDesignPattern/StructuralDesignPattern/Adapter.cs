using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPattern
{
    public class Adapter
    {
        public static void Run()
        {
            Man m = new Man()
            {
                boss = "AwesomeBoss",
                IsIndian = true
            };
            List<Animal> animalList = new List<Animal>()
            {
                new Cow(), new Chicken(),new ManAdapter(m)
            };

            foreach (Animal x in animalList)
            {
                Console.WriteLine(x.GetOwner());
            }
        }
    }

    public abstract class Animal
    {
        public abstract int GetLegs();

        public virtual void SetOwner(string owner)
        {
            this.owner = owner;
        }

        public virtual string GetOwner()
        {
            return owner;
        }

        private string owner = "Default";

    }

    public class Cow : Animal
    {
        public override int GetLegs() { return 4; }
    }

    public class Chicken : Animal
    {
        public override int GetLegs() { return 2; }
    }

    public class Man
    {
        public bool IsIndian { get; set; }

        public string boss { get; set; }
    }

    public class ManAdapter : Animal
    {
        public ManAdapter(Man m)
        {
            _m = m;
        }

        public override int GetLegs()
        {
            return 5;
        }

        public override string GetOwner()
        {
            return _m.boss;
        }

        public override void SetOwner(string owner)
        {
            _m.boss = owner;
        }

        private Man _m;
    }

}
