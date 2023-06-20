using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThreeBook.Models.mainTest
{
    [MyBook(13,"sdfsd")]
    public class Book:IBook,IDisposable
    {
        [Required(ErrorMessage = "Введите имя")]
        [MinLength(2, ErrorMessage = "Слишком маленькое название")]
        [MaxLength(22,ErrorMessage ="Слишком длинное название")]
        public string Name { get; set; }
        [Range(0, 10,ErrorMessage ="Недопустимый диапозон")]
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

        void IBook.Read()
        {
            System.Diagnostics.Debug.WriteLine(" Name = "+GetType().Name);

        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}