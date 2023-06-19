using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeBook.Models.mainTest
{
    public class MyBook : Attribute,IMyBook
    {
        public string Name { get; set; }
        public int Count { get; set; }


        public MyBook(int count, string name)
        {
            Console.WriteLine("==============================================   count =" + count);
            this.Count = count;
            this.Name = name;
            //return this;
        }
        public MyBook(IBook book) { 
        
        }
    }

}