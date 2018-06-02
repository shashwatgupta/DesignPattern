using System;

namespace StructuralDesignPattern
{
    public class Bridge
    {
        public static void Run()
        {
            Shape x = new MoveAbleShape();
            x.DrawXX();
        }

        public abstract class Shape
        {
            public void SetColor()
            {
                _imp.ShapeColor = "Green";
            }

            public ShapeImp GetShapeImpl()
            {
                if (_imp == null)
                {
                    _imp = Factory.GetInstance().MakeShape();
                }
                return _imp;
            }

            public abstract void DrawXX();

            public ShapeImp _imp;
        }


        public class  MoveAbleShape : Shape
        {
            public override void DrawXX()
            {
                _imp = GetShapeImpl();
                _imp.Draw();
            }
        }

        public class NonMoveAbleShape : Shape
        {
            public override void DrawXX()
            {
                throw new Exception("not moveable");
            }
        }

        public abstract class ShapeImp
        {
            public abstract void Draw();

            public string ShapeColor {get; set;} 
        }

        public class CirCleImp : ShapeImp
        {
            public override void Draw()
            {
                Console.WriteLine("Drawing Circle");
            }
        }

        public class Square : ShapeImp
        {
            public override void Draw()
            {
                Console.WriteLine("Drawing Square");
            }
        }


        public class Factory
        {
            public static Factory instance;

            public static Factory GetInstance()
            {
                if (instance == null)
                {
                    instance = new Factory();
                }

                return instance;
            }

            public ShapeImp MakeShape()
            {
                return new Square();
            }
        }
    }
}
