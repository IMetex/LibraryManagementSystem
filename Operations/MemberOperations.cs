using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Operations;

public class MemberOperations
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
}