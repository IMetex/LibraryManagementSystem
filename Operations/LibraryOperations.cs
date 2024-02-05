using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Operations;

public class LibraryOperations
{
    public static void PrintMembers(List<Member> memberList, bool isBookList, out bool continueExecution)
    {
        if (memberList.Count != 0)
        {
            continueExecution = true;
            foreach (Member member in memberList)
            {
                Console.WriteLine("|------------------------------------------------------------|");
                Console.WriteLine(
                    $"Id: {member.Id}\n" +
                    $"Ad: {member.FirstName}\n" +
                    $"Soyad: {member.LastName}\n" +
                    $"Üyelik Numarası: {member.MembershipNumber}"
                );
                if (member.BorrowedBooks.Count > 0 && isBookList)
                {
                    Console.WriteLine(
                        $"Ödünç Alınan Kitap Sayısı: {member.BorrowedBooks.Count}\n" +
                        $"|----------> Ödünç Alınan Kitaplar"
                    );
                    foreach (Book book in member.BorrowedBooks)
                    {
                        Console.WriteLine($"Kitap Adı : {book.Name}");
                    }
                }
                Console.WriteLine("|------------------------------------------------------------|");
            }
        }
        else
        {
            Console.WriteLine("Kütüphanede üye bulunmamaktadır.");
            continueExecution = false;
        }
    }
    
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