using System;
using System.Collections.Generic;

namespace CreationalDesignPattern
{
    class FactoryMethod
    {
        public static void Run()
        {
            ShowApplication x = new ShowExcelpplication();
            x.ShowAllExtensionAndSetOwner();
            x.GetOwnerforApplication();
        }
    }

    public abstract class ShowApplication
    {
        public void ShowAllExtensionAndSetOwner()
        {
            document = FactoryMethod();
            foreach (string ext in document.SupportedExtension())
            {
                Console.WriteLine(ext);
            }
            document.SetOwner("Shashwat");
        }

        public void GetOwnerforApplication()
        {
            Console.WriteLine(document.GetOwner());
        }

       public abstract Document FactoryMethod();

       // This class only knows about document and not concrete implemention of Document.
       private Document document;
    }

    public class ShowExcelpplication : ShowApplication
    {
        public override Document FactoryMethod()
        {
            return new ExcelDocument();
        }

    }



    public abstract class Document
    {
        public abstract List<String> SupportedExtension();

        public void SetOwner(string owner)
        {
            _owner = owner;
        }
        public string GetOwner()
        {
            return _owner;
        }

        public string _owner;

    }

    public class PictureDocument : Document
    {
        public override List<String> SupportedExtension()
        {
            return new List<string>() { "jpg", "jpeg", "bmp" };
        }
    }

    public class ExcelDocument : Document
    {
        public override List<String> SupportedExtension()
        {
            return new List<string>() { "xls", "xlsx" };
        }
    }
}