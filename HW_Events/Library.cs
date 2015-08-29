using System;
using System.Collections.Generic;
using System.Threading;

namespace HW_Events
{
    class Library
    {
        private List<Book> _books = new List<Book>();
        public EventHandler<LibEventArgs> BookAdded;
        public EventHandler<LibEventArgs> BookRemoved;

        public void AddBook(Book book)
        {
            if(book == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _books.Add(book);

                OnBookAdded(new LibEventArgs(book.Title, book.Genre));
            }
        }

        public Book GetBook(string title)
        {           
            if (title == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                Book findedBook = _books.Find(x => String.Compare(x.Title, title, true) == 0);
                if(findedBook != null)
                {
                    _books.Remove(findedBook);
                    OnBookRemoved(new LibEventArgs(findedBook.Title, findedBook.Genre));
                }

                return findedBook;
            }
        }

        protected virtual void OnBookAdded(LibEventArgs args)
        {
            EventHandler<LibEventArgs> tmp = Volatile.Read(ref BookAdded);

            if (tmp != null)
            {
                tmp(this, args);
            }               
        }

        protected virtual void OnBookRemoved(LibEventArgs args)
        {
            EventHandler<LibEventArgs> tmp = Volatile.Read(ref BookRemoved);

            if (tmp != null)
            {
                tmp(this, args);
            }
        }
    }
}
