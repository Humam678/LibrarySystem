using LibrarySystem.Core;
using LibrarySystem.Models;
using LibrarySystem.Utilities;
using System;

namespace LibrarySystem
{
    class Program
    {
        static void HandleOverdue(string memberName, string itemTitle, int daysOverdue)
        {
            Console.WriteLine("[ALERT] " + memberName + " تأخر " + daysOverdue + " يوم في إعادة: " + itemTitle);
        }
        static void Main(string[] args)
        {
            Library library = new Library();
            library.OnItemOverdue += HandleOverdue;

            // التحقق بالـ Validator قبل الإنشاء
            string email = "ahmad@email.com";
            string id = "MEM001";
            if (Validator.IsValidEmail(email) && Validator.IsValidId(id))
            {
                Member member1 = new Member(id, "Ahmad", email);
                library.AddMember(member1);
                Console.WriteLine("Member added: " + member1.GetInfo());
            }

            Book book1 = new Book("B001", "Clean Code",
                                  "Robert C. Martin", "978-0132350884", 464);
            Magazine mag1 = new Magazine("M001", "National Geographic", 256, "NG Media");
            DVD dvd1 = new DVD("D001", "Inception", "Christopher Nolan", 148);

            library.AddItem(book1);
            library.AddItem(mag1);
            library.AddItem(dvd1);

            library.GetAllItems();

            // استعارة وإعادة 
            Console.WriteLine("\n----- Borrowing -----");
            library.BorrowItem("MEM001", "B001");
            library.GetAllItems();

            Console.WriteLine("\n----- Returning -----");
            library.ReturnItem("MEM001", "B001");
            library.GetAllItems();

           

            library.CheckOverdueItems(); // يطلق الـ Event إن وجد متأخر

            Console.WriteLine("\nTotal Borrows: " + Library.TotalBorrows);
            Console.ReadKey();
        }
    
    }
}