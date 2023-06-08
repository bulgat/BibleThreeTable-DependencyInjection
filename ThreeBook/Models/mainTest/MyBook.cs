using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeBook.Models.mainTest
{
    public class MyBook : Attribute
    {
 
        public MyBook(int count)
        {
            Console.WriteLine("==============================================   count =" + count);
            this.Count = count;
            //return this;
        }
        public int Count;
    }

}