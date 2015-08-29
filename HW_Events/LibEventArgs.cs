using System;

namespace HW_Events
{
    class LibEventArgs : EventArgs
    {
        private readonly string _title;
        private readonly Genre _genre;

        public string Title
        {
            get { return _title; }
        }

        public Genre Genre
        {
            get { return _genre; }
        }
        public LibEventArgs(string title, Genre genre)
        {
            if(title == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _title = title;
                _genre = genre;
            }
        }
    }
}
