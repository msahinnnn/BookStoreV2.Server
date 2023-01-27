using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.ViewModels.Author;
using Entities.ViewModels.Book;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, BookStoreDbContext>, IBookDal
    {

        public bool AddBookToAuthor(Guid authorId, Book book)
        {
            using (BookStoreDbContext context = new BookStoreDbContext())
            {
                Author? author = context.Authors.FirstOrDefault(x => x.Id == authorId);
                if (author != null)
                {

                    book.Authors = new HashSet<BookAuthor>()
                    {
                        new(){AuthorId = authorId}
                    };

                    context.Add(book);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool AddBookWithAuthors(Book book, List<Author> authors)
        {
            using (BookStoreDbContext context = new BookStoreDbContext())
            {
                Book? newBook = context.Books.FirstOrDefault(x => x.BookISBN == book.BookISBN);
                if (newBook != null)
                {
                    foreach(Author aut in authors)
                    {
                        newBook.Authors = new HashSet<BookAuthor>() { new() { Author = aut } };
                    }
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Book> GetAllBooksDetailDetails()
        {
            using (BookStoreDbContext context = new BookStoreDbContext())
            {
                List<Book>? result = context.Books.Include(b => b.Authors.Where(a => a.BookId == a.BookId)).ToList();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
