using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Struct;

public struct BookOperations
{
    public static void PrintBooks(List<Book> bookList, out bool continueExecution)
    {
        if (bookList.Count != 0)
        {
            continueExecution = true;
            foreach (Book book in bookList)
            {
                Console.WriteLine("|------------------------------------------------------------|");
                Console.WriteLine(
                    $"Id: {book.Id}\n" +
                    $"Ad: {book.Name}\n" +
                    $"Yazar: {book.Author}\n" +
                    $"Yayınlanma Yılı: {book.ReleaseYear.Year}"
                );
                Console.WriteLine("|------------------------------------------------------------|");
            }
        }
        else
        {
            Console.WriteLine("Kütüphanede kitap bulunmamaktadır.");
            continueExecution = false;
        }
    }
}