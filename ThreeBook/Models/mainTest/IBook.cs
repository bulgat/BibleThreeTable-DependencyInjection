using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBook.Models.mainTest
{
    public interface IBook:ISuperBook
    {
        string Name { get; set; }
        void Read();
    }
}
