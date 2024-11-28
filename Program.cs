namespace task3
{
    public class Book
    {
        string Title;
        string Auther ;
        int Isbn ;
        string Avail;

        public Book(string title, string auther, int isbn, string avail)
        {
            this.Title = title;
            this.Auther = auther;
            this.Isbn = isbn;
            this.Avail = avail;
        }
        public void DisplayDetails()
        {
            Console.WriteLine($"Title: {Title}, Author: {Auther}, ISBN: {Isbn}, Available: {Avail}");
        }
    }
    public class Library
    {
        List<Book> books =new List<Book>();
        public void addbook(Book book)
        { 
            books.Add(book);
            Console.WriteLine($"ur book {book.Title} is added");
        }
        public void SearchBook(string search)
        {
            bool found = false;
            Console.WriteLine("remember to write in lowercase");
            for (int i = 0; i < books.Count; i++)
            {
                string title = books[i].Title.ToLower();
                string author = books[i].Author.ToLower();
                string searchLower = search.ToLower();
                if (title.IndexOf(searchLower) != -1 || author.IndexOf(searchLower) != -1)
                {
                    books[i].DisplayDetails();
                    found = true;
                }
            }
            if (!found) { Console.WriteLine("==== not available ===="); }


        }

        public void BorrowBook(string title)
        {
            bool bookFound = false;

            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine("remember to write in lowercase");
                if (books[i].Title.ToLower() == title.ToLower() && books[i].Avail)
                {
                    books[i].Avail = false; 
                    Console.WriteLine($"You borrowed the book: {books[i].Title}");
                    bookFound = true;
                    break; 
                }
            }

            if (!bookFound)
            {
                Console.WriteLine(" ==== not available ====");
            }
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            Console.ReadLine();
        }
    }
}
