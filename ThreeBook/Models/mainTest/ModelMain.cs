using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using ThreeBook.Models.mainTest;

namespace ThreeBook.Models
{
    public class ModelMain
    {
        public ModelMain()
        {
            Dictionary<string, Book> dictionaryBook = new Dictionary<string, Book>() { ["kol"] = new Book { } };

            System.Diagnostics.Debug.WriteLine(" name dict book = " + dictionaryBook["kol"]);
            Book book = new Book();
            book.Name = "kol";
            ChangeName(book);
            System.Diagnostics.Debug.WriteLine(" name ="+ book.Name);
            ChangeName(ref book);
            System.Diagnostics.Debug.WriteLine("REF name =" + book.Name);
            int i = 5;
            System.Diagnostics.Debug.WriteLine("00 =" +i);
            long kol = (long)i;
            System.Diagnostics.Debug.WriteLine("000 =" + kol);
            object o = i;
            System.Diagnostics.Debug.WriteLine("01 ="+o);
            long job = (int)o;
            System.Diagnostics.Debug.WriteLine("001 =" + job);
            //long j = (long)o;
            //System.Diagnostics.Debug.WriteLine("REF name j =" + j);

            Book bookProd =  new Book();
            bookProd.Name = "null=============";
            bookProd.Count = 51;
            var koll = bookProd?.Name ?? "Error";
            System.Diagnostics.Debug.WriteLine("002 =" + koll);
            /*
            switch (bookProd.Count)
            {
                case 12:
                    System.Diagnostics.Debug.WriteLine("003 =  12" );
                    break;
                case 50:
                    //System.Diagnostics.Debug.WriteLine("003 =" + intValue);
                    break;
                case var intValue when intValue > 50:
                    break;
                //case int intValue when intValue > 50:
                default:
                    break;
            };*/
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

    }
}