using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeBook.Models.mainTest
{
    public class Book
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public bool Read { get; set; }
        public Book() { 
        
        }
        public Book(string name)
        {
        this.Name = name;
        }
        public Book(bool read)
        {
            this.Read = read;
        }

    }
}