﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeBook.Models.mainTest;

namespace ThreeBook.Models
{
    public class ModelMain
    {
        public ModelMain()
        {
            Book book = new Book();
            book.Name = "kol";
            ChangeName(book);
            System.Diagnostics.Debug.WriteLine(" name ="+ book.Name);
            ChangeName(ref book);
            System.Diagnostics.Debug.WriteLine("REF name =" + book.Name);
            int i = 5; object o = i; long j = (long)o;
            System.Diagnostics.Debug.WriteLine("REF name j =" + j);
        }
        private void ChangeName(Book book)
        {
            book.Name = "Krik";
            Book book0000 = new Book();
            book0000.Name = "Sting";
            book = book0000;
        }
        private void ChangeName(ref Book book)
        {
            book.Name = "KrikKolNikolay";
            Book book0000 = new Book();
            book0000.Name = "Sting Ping Floid";
            book = book0000;
        }

    }
}