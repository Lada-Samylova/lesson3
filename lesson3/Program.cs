using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }

    public Book(string title, string author, int pages)
    {
        Title = title;
        Author = author;
        Pages = pages;
    }
    public string GetInfo()
    {
        return $"Название: {Title}; Автор: {Author}; Кол-во страниц: {Pages}";
    }
}
public class Library
{
    private List<Book> books = new List<Book>();
    public void AddBook(Book book)
    {
        books.Add(book);
    }
    public void ShowBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Таких книг нет в библиотеке");
            return;
        }
        else
        {
            Console.WriteLine("Доступные книги:");
            foreach (var book in books)
            {
                Console.WriteLine(book.GetInfo());
            }
        }
    }
    public Book FindBook(string title)
    {
        foreach (Book book in books)
        {
            if (book.Title.Contains(title))
            {
                return book;
            }
        }
        return null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        Book book1 = new Book("'Тревожные люди'", "Фредрик Бакман", 303);
        Book book2 = new Book("'Фаина раневская.История за час'", "Евгения Белогорцева", 51);
        Book book3 = new Book("'Убийства и кексики'", "Питер Боланд", 334);

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);
        library.ShowBooks();

        Console.WriteLine("\nВведите название книги для поиска с заглавной буквы:");
        string searchTitle = Console.ReadLine();

        Book foundBook = library.FindBook(searchTitle);
        if (foundBook != null)
        {
            Console.WriteLine("\nНайдена книга:");
            Console.WriteLine(foundBook.GetInfo());
        }
        else
        {
            Console.WriteLine("\nКнига не найдена.");
        }
    }
}