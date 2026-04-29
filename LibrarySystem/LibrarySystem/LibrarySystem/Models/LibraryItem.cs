using LibrarySystem.Interfaces;
using System;

namespace LibrarySystem.Models
{
   public abstract class LibraryItem: IBorrowable
    {
       private  string _itemId;
        private string _title;
        private bool _isAvailable;

        public string ItemId {  get { return _itemId; } private set { _itemId = value; } }
        public string Title {  get { return _title; } private set { _title = value; } }
        public bool IsAvailable { get { return _isAvailable; }private set { _isAvailable = value; }  }

        public LibraryItem(string itemId, string _title)
        {
            ItemId= itemId;
            Title = _title;
            IsAvailable = true;
        }

       public void Borrow()
        {
            IsAvailable = false;
        }
        public void Return()
        {
            IsAvailable= true;
        }

        public abstract string GetDetails();
        
        
    }
}
