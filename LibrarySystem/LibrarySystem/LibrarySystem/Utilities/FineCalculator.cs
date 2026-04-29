using LibrarySystem.Models;
using System;

namespace LibrarySystem.Utilities
{
    public static class FineCalculator// لحساب غرامات التأخير
    {
        public static double CalculateFine(BorrowRecord record)
        {

            if (record == null)
            {
                return 0;
            }
            else
            {
                int Days = (DateTime.Now - record.DueDate).Days;// عدد ايام التأخير
                if (Days <= 0)
                    return 0;
                else
                    return Days * 100;
            }
           
        }
    }
}
