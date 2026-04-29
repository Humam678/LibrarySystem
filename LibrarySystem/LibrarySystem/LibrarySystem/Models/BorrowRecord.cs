using System;

namespace LibrarySystem.Models
{

    //يتتبع تاريخ الاعادة والاستعارة ويحسب حالة التاخير
    public class BorrowRecord
    {
        private Member _member;
        private LibraryItem _item;
        private DateTime _borrowDate;
        private DateTime? _returnDate;
        private DateTime _dueDate;

        public DateTime DueDate
        {
            get { return _dueDate; }
        }
        public Member Member
        {
            get { return _member; }
        }

        public LibraryItem Item
        {
            get { return _item; }
        }

        public DateTime BorrowDate
        {
            get { return _borrowDate; }
        }

        public DateTime? ReturnDate
        {
            get { return _returnDate; }
            set { _returnDate = value; }
        }

        //انشاء سجل استعارة جديد وضبط التواريخ تلقائيا
        public BorrowRecord(Member member, LibraryItem item)
        {
            _member = member;
            _item = item;
            _borrowDate = DateTime.Now;
            _returnDate = null;
            _dueDate = DateTime.Now.AddDays(14);
        }

        //التحقق من تجاوز مدة الاعارة
        public bool IsOverdue()
        {
            if (_returnDate != null)
                return false;
            return DateTime.Now > _dueDate; //  
        }

        //ارجاع معلومات السجل
        public string GetRecordInfo()
        {
            return "[Member]" + Member.Name + " | Item: " + _item.Title + " | Due: " + _dueDate.ToShortDateString() + " | Overdue: " + IsOverdue();
        }
    }
}