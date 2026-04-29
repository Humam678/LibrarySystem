using System;

namespace LibrarySystem.Models
{
    public class Magazine:LibraryItem
    {
        private string _publisher;
        private int _issueNumber;

        public string Publisher { get { return _publisher; } }
        public int IssueNumber { get { return _issueNumber; } }

        public Magazine(string itemId, string title, int issueNumber, string publisher) : base(itemId, title)
        {
            _publisher = publisher;
            _issueNumber = issueNumber;
        }

        public override string GetDetails()
        {
            return "[Magazine] Title: " + Title + " | Available: " + IsAvailable + "| Publisher: " + Publisher + "| IssueNumber: " + IssueNumber;
        }

    }
}
