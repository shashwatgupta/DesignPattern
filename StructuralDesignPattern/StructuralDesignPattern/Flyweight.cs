using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDesignPattern
{
    public class Flyweight
    {
        public static void Run()
        {
            string text = " This is some random text. This needs to be represented in flyweight format";
            CharacterContext ctx = new CharacterContext();
            foreach (Char c in text)
            {
                FlyWeightCharacter fc = FlyWeightFactory.GetInstance().GetCharacter(c);
                Console.WriteLine(fc.GetFont(ctx));
            }
        }
    }

    public class FlyWeightFactory
    {
        private static FlyWeightFactory _flyWeightFactoryInstance;

        private FlyWeightFactory()
        { }

        public static FlyWeightFactory GetInstance()
        {
            if(_flyWeightFactoryInstance == null)
            {
                _flyWeightFactoryInstance = new FlyWeightFactory();
            }

            return _flyWeightFactoryInstance;
        }

        public FlyWeightCharacter GetCharacter(char key)
        {
            FlyWeightCharacter value;
            if (dict.TryGetValue(key, out value))
            {
                return value;
            }
            else
            {
                value = new FlyWeightCharacter(key);
                dict.Add(key, value);
                return value;
            }
        }

        Dictionary<char, FlyWeightCharacter> dict = new Dictionary<char, FlyWeightCharacter>();
    }

    public class FlyWeightCharacter
    {
        public FlyWeightCharacter(char x)
        {
            _x = x;
        }

        public void SetFont(CharacterContext ctx)
        {
            ctx.SetFont("NewFont");
        }

        public string GetFont(CharacterContext ctx)
        {
            return ctx.GetFont();
        }

        private char _x;
    }

    public class CharacterContext
    {
        public string GetFont()
        {
            string newFont;

            if(IndexToFontMapping.TryGetValue(_index,out newFont))
            {
                return newFont;
            }
            else
            {
                return "DefaultFont";
            }
        }

        public void NextIndex()
        {
            _index++;
        }

        public void SetFont(string font)
        {
             IndexToFontMapping.Add(_index, font);
        }

        Dictionary<int, string> IndexToFontMapping = new Dictionary<int, string>();

        private int _index = 0;
    }
}
