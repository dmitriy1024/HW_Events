using System;

namespace HW_Events
{
    class Student
    {
        private string _name;
        private Genre _preferedGenre;

        public string Name
        {
            get { return _name; }
        }

        public Genre PreferedGenre
        {
            get { return _preferedGenre; }
        }

        public Student(string name, Genre prefGenre, Library lib)
        {
            if (name == null || lib == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _name = name;
                _preferedGenre = prefGenre;

                lib.BookAdded += NewBook;
                lib.BookRemoved += BookWasRemoved;
            }
        }

        private void NewBook(object o, LibEventArgs args)
        {
            if(args.Genre == Genre.Computer && _preferedGenre == Genre.Computer)
            {
                Console.WriteLine("{0}: I'm going to go to the library. Trere is a new computer book!", _name);
            }

            if(args.Genre == Genre.Fantastic && _preferedGenre == Genre.Fantastic)
            {
                Console.WriteLine("{0}: I want a home delivery of a new fantastic book!", _name);
            }
        }

        private void BookWasRemoved(object o, LibEventArgs args)
        {
            if(_preferedGenre == Genre.Fantastic && args.Genre != Genre.Fantastic)
            {
                Console.WriteLine("{0}: I'm not going to read \"{1}\"", _name, args.Title);
            }
        }
    }
}
