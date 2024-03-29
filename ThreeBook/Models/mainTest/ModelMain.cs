﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Services.Description;
using ThreeBook.Models.mainTest;
using static System.Math;
using Microsoft.Extensions.DependencyInjection;

namespace ThreeBook.Models
{
    public class ModelMain
    {
        public ModelMain()
        {
            var serverCollection = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            serverCollection.AddTransient<IBook, Book>();
            serverCollection.AddScoped<IBook, Book>();
            serverCollection.AddSingleton<IBook, Book>();

            var container = serverCollection.BuildServiceProvider();

            
            Book bookContainer0 = container.GetService<Book>();
            IBook bookContainer = container.GetRequiredService<IBook>();
            IEnumerable<IBook> bookAll_ar = container.GetRequiredService<IEnumerable<IBook>>();

            System.Diagnostics.Debug.WriteLine("0000   dict book = " + bookAll_ar.Count());
            using(var kolBook = new Book())
            {
                kolBook.Name = "STOP-stop";
                System.Diagnostics.Debug.WriteLine("0000 name kolBook = " + kolBook.Name);
            }


            Dictionary<string, Book> dictionaryBook = new Dictionary<string, Book>() { ["kol"] = new Book { } };

            System.Diagnostics.Debug.WriteLine("000 name dict book = " + dictionaryBook["kol"]);
            Book book = new Book();
            book.Name = "k";
            System.Diagnostics.Debug.WriteLine("000 name dict book = ");
            ChangeName(book);
            System.Diagnostics.Debug.WriteLine(" name ="+ book.Name);
            ChangeName(ref book);
            System.Diagnostics.Debug.WriteLine("REF name =" + book.Name);
            int i = 5;
            System.Diagnostics.Debug.WriteLine("00 =" +i+"    PI"+PI);
            long kol = (long)i;
            System.Diagnostics.Debug.WriteLine("000 =" + kol);
            object o = i;
            System.Diagnostics.Debug.WriteLine("01 ="+o);
            long job = (int)o;
            System.Diagnostics.Debug.WriteLine("001 =" + job);
            book.Name = "крикунов";
            //long j = (long)o;
            //System.Diagnostics.Debug.WriteLine("REF name j =" + j);

            Book bookProd =  new Book();
            bookProd.Name = "null=============";
            bookProd.Count = 51;
            string koll = bookProd?.Name ?? "Error";
            System.Diagnostics.Debug.WriteLine("002 =" + koll);
            Book[] book_ar = { 
                new Book(),
                new Book("krik"),
                new Book(true), 
                new Book(true) 
            };
            var stop = book_ar.Where(a => a?.Name?[0]== 'k').ToList();

            System.Diagnostics.Debug.WriteLine("02  name L =" + stop.Count);
            System.Diagnostics.Debug.WriteLine("03  name L =" + stop[0].Name);
            System.Diagnostics.Debug.WriteLine("04  name =" + nameof(bookProd));
            System.Diagnostics.Debug.WriteLine("05  name =" + nameof(book_ar));
            System.Diagnostics.Debug.WriteLine("06  name =" + nameof(i));
            System.Diagnostics.Debug.WriteLine("07  name =" + nameof(job));
            System.Diagnostics.Debug.WriteLine("08  name =" + nameof(bookProd.Read));
            System.Diagnostics.Debug.WriteLine("09 _________ name =" + nameof(List<int>)+ "   book_ar.count ="+ book_ar.Count());

            var ttt = FilterBookRead(book_ar);
            System.Diagnostics.Debug.WriteLine("10  count =" + ttt.Count());
         
            BlockingCollection<int> bCollection = new BlockingCollection<int>(boundedCapacity: 2);
            bCollection.Add(1);
            bCollection.Add(2);

            if (bCollection.TryAdd(4, TimeSpan.FromSeconds(1)))
            {
                System.Diagnostics.Debug.WriteLine("Item added");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Item does not added");
            }
            int progress = 0;
            // A simple blocking consumer with no cancellation.
            Task.Run(() =>
            {
                int ii = -1;
                while (!bCollection.IsCompleted)
                {
                    try
                    {
                        ii = bCollection.Take();
                        ii++;
                    }
                    catch (InvalidOperationException)
                    {
                        System.Diagnostics.Debug.WriteLine("Adding was completed!");
                        break;
                    }
                    System.Diagnostics.Debug.WriteLine("Take:{0} ", ii);

                    progress++;
                    System.Diagnostics.Debug.WriteLine("progress:{0} ", progress);
                    // Simulate a slow consumer. This will cause
                    // collection to fill up fast and thus Adds wil block.
                    Thread.SpinWait(100000);
                }
                System.Diagnostics.Debug.WriteLine("\r\nNo more items to take. Press the Enter key to exit.");
            });

            // Increase or decrease this value as desired.
            int itemsToAdd = 8;
            // A simple blocking producer with no cancellation.
            Task.Run(() =>
            {
                for (int i0 = 0; i0 < itemsToAdd; i0++)
                {
                    bCollection.Add(i);
                    Console.WriteLine("Add:{0} Count={1}", i0, bCollection.Count);
                }

                // See documentation for this method.
                bCollection.CompleteAdding();
            });

            
            Console.WriteLine("===============================================" );
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
        public static IEnumerable<Book> FilterBookRead(IEnumerable<Book> book_ar)
        {
            foreach(Book book in book_ar)
            {
                System.Diagnostics.Debug.WriteLine("-00011  book.Read =" + book.Read);
                if (book.Read)
                {
                    System.Diagnostics.Debug.WriteLine("-11  name =" + book.Name);
                    yield return book;
                    System.Diagnostics.Debug.WriteLine("-22  name =" + book.Name);
                    yield return book;
                    System.Diagnostics.Debug.WriteLine("-33  name =" + book.Name);
                    yield return book;
                }
            }
            //yield return new Book();
        }
    }

}