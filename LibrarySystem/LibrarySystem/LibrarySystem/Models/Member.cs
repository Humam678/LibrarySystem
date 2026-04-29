using System;

namespace LibrarySystem.Models
{
    public class Member
    {
        private string _memberId;
        private string _name;
        private string _email;         
        public string Email             
        {
            get { return _email; }
            set { _email = value; }
        }
                       
        public string MemberId
        {
            get { return _memberId; }
        }

        public string Name
        {
            get { return _name; }
        }

        public Member(string memberId, string name,string email)
        {
            _memberId = memberId;
            _name = name;
            _email = email;
        }

        public string GetInfo()        
        {
            return "[ID]" + MemberId + " | Name" + Name + " | Email" + Email;
        }

    }
}