using LibrarySystem.Models;
using System;
using System.Collections.Generic;

namespace LibrarySystem.Core
{

    // تعريف الـ Delegate
    //تحديد الدالة التي ستستقبل اشعار التأخير
    public delegate void OverdueNotifier(string memberName, string itemTitle, int daysOverdue);

    //يدير المواد والاعضاء وسجلات الاستعارة 
    public class Library
    {
        private List<LibraryItem> _items;
        private List<Member> _members;
        private List<BorrowRecord> _records;

        //يحسب اجمالي عدد عمليات الاستعارة منذ بدء النظام
        private static int _totalBorrows;
        public static int TotalBorrows {  get { return _totalBorrows; }}

        //حدث عند اكتشاف عضو متاخر
        public event OverdueNotifier OnItemOverdue;
        public Library()
        {
            _items = new List<LibraryItem>();
            _members = new List<Member>();
            _records = new List<BorrowRecord>();
        }

       public void AddItem(LibraryItem item)//تضيف مادة للقائمة
        {
            _items.Add(item); 
        }
        public void AddMember(Member member)//تضيف عضو للقائمة 
        {
            _members.Add(member); 
        }

        public void CheckOverdueItems()//يفحص جميع السجلات ويطلق شعارا لكل متأخر
        {
            foreach (BorrowRecord record in _records)//المرور على كل سجلات الاستعارة 
            {
                if (record.IsOverdue())//هل تجاوز الموعد للاعادة؟
                {
                    int days = (DateTime.Now - record.DueDate).Days;
                    // إطلاق الـ Event إذا كان هناك مشتركون
                    if (OnItemOverdue != null)
                        OnItemOverdue(record.Member.Name, record.Item.Title, days);
                }
            }
        }

        public void BorrowItem(string memberId, string itemId)
        {
            //  ابحث عن العضو
            Member foundMember = null;
            foreach (Member m in _members)
            {
                if (m.MemberId == memberId)
                {
                    foundMember = m;
                    break;
                }
            }

            //  ابحث عن المادة
            LibraryItem foundItem = null;
            foreach (LibraryItem i in _items)
            {
                if (i.ItemId == itemId)
                {
                    foundItem = i;
                    break;
                }
            }

            //  إذا وجدناهما والمادة متاحة
            if (foundMember != null && foundItem != null && foundItem.IsAvailable)
            {
                BorrowRecord record = new BorrowRecord(foundMember, foundItem);
                _records.Add(record);
                foundItem.Borrow();
                _totalBorrows++;
            }
        }

        public void ReturnItem(string memberId, string itemId)
        {
            // ابحث عن السجل المطابق في _records
            foreach (BorrowRecord record in _records)
            {
                if (record.Member.MemberId == memberId && record.Item.ItemId == itemId  && record.ReturnDate == null) // لم يُعد بعد
                {
                    record.Item.Return();
                    record.ReturnDate = DateTime.Now;
                    break;
                }
            }
        }
        public void GetAllItems()
        {
            foreach (LibraryItem item in _items)
            {
                Console.WriteLine(item.GetDetails());
            }
        }
    }
}
