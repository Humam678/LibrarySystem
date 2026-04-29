using System;

namespace LibrarySystem.Interfaces
{
    public interface IBorrowable
    {
        void Borrow();//تغير حالة المادة عند استعارتها الى غير متاح 
        void Return();//تغير حالة المادة الى متاح عند الاعادة 
        string GetDetails();//ترجع معلومات المادة

    }
}
