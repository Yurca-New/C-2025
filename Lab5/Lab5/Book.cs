using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal abstract class Book
    {
        private string _title;
        private string _author;

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Author
        {
            get => _author;
            set => _author = value;
        }
        public Book(string title, string author)
        {
            _title = title;
            _author = author;
        }

    }
}
