using System;

namespace LibrarySystem.Models
{
    public class DVD:LibraryItem
    {
        private string _director;
        private int _duration;
        
        public string Director {  get { return _director; } }
        public int Duration { get { return _duration; } }

        public DVD(string itemId, string title, string director, int duration) : base(itemId, title)
        {
            _director = director;
            _duration = duration;
        }

        public override string GetDetails()
        {
            return "[DVD] Title: " + Title + " | Available: " + IsAvailable + "| Director: " + Director + "| Duration: " + Duration;

        }
    }
}
