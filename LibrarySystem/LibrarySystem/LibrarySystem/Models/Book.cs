using System;

namespace LibrarySystem.Models
{
    public class Book:LibraryItem
    {
        private string _author;
        private string _isbn;
        private int _pages;

        public string Author { get { return _author; } }
        public string Isbn { get { return _isbn; } }
        public int Pages { get { return _pages; } }

        public Book(string itemId, string title, string author, string isbn, int pages) : base(itemId, title)
        {
            _author = author;
            _isbn = isbn;
            _pages = pages;
        }

       public override string GetDetails()
        {
            return "[Book] Title: " + Title + " | Author: " + Author + " | ISBN: " + Isbn + " | Pages: " + Pages + " | Available: " + IsAvailable;
        }
    
    }
}
