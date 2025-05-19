using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class EBook: Book
    {
        private string _bookType;
        public EBook(string title, string author)
            : base(title, author)
        {
            _bookType = "Printed";
        }
        public string ChangeBookType(string newType)
        {
            _bookType = newType;
            return _bookType;
        }
        public string Read()
        {
            return "Reading an e-book";
        }
    }
}
