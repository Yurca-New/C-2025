using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class PrintedBook: Book
    {
        private string _bookType;
        public PrintedBook(string title, string author)
            : base(title, author)
        {
            _bookType = "Printed";
        }
        public void ChangeBookType(string newType)
        {
            _bookType = newType;
        }
        public void Read()
        {
            Console.WriteLine("Чтение печатной книги");
        }
    }
}
