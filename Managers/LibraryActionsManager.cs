﻿using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Operations;

namespace LibraryManagementSystem.Managers;

public class LibraryActionsManager: ILibraryService
{
    public void BookLending()
    {
        lendingRepeat:
        LibraryOperations.PrintMembers(Repository.Members, true, out bool continueMemberExecution);
        if (!continueMemberExecution) return;

        Console.Write("Kitap ödünç verilecek üyenin id numarasını girin : ");
        int memberId = Convert.ToInt32(Console.ReadLine().Trim());

        LibraryOperations.PrintBooks(Repository.Books, out bool continueBookExecution);
        if (!continueBookExecution) return;

        Console.Write("Ödünç verilecek kitabın id numarasını girin : ");
        int bookId = Convert.ToInt32(Console.ReadLine().Trim());

        int searchMemberIndex = Repository.Members.FindIndex((member) => member.Id == memberId);
        int searchBookIndex = Repository.Books.FindIndex((book) => book.Id == bookId);

        if ((searchMemberIndex != -1) && (searchBookIndex != -1))
        {
            Console.WriteLine(
                $"{Repository.Members[searchMemberIndex].FirstName} {Repository.Members[searchMemberIndex].LastName} kütüphane üyesine " +
                $"{Repository.Books[searchBookIndex].Name} adlı kitap ödünç verilecektir. Onaylıyor musunuz ?"
            );
            Console.WriteLine("(1) Evet \n(2) Hayır");
            int isLend = Convert.ToInt32(Console.ReadLine());

            if (isLend == 1)
            {
                Console.WriteLine(
                    $"{Repository.Members[searchMemberIndex].FirstName} {Repository.Members[searchMemberIndex].LastName} kütüphane üyesine " +
                    $"{Repository.Books[searchBookIndex].Name} adlı kitap ödünç verildi."
                );
                Repository.Members[searchMemberIndex].BorrowedBooks.Add(Repository.Books[searchBookIndex]);
            }
            else
                return;
        }
        else
        {
            Console.WriteLine(
                "Kütüphanede girilen id numaralarına ait kitap veya üye kaydı bulunmamaktadır.Tekrar denemek ister misiniz ?");
            Console.WriteLine("(1) Evet \n(2) Hayır");
            int isRepeat = Convert.ToInt32(Console.ReadLine());

            if (isRepeat == 1)
                goto lendingRepeat;
            else return;
        }
    }

    public void BookDelivery()
    {
        try
        {
            memberRepeat:
            LibraryOperations.PrintMembers(Repository.Members, true, out bool continueMemberExecution);
            if (!continueMemberExecution) return;

            Console.Write("Kitap teslim edecek üyenin id numarasını girin : ");
            int memberId = Convert.ToInt32(Console.ReadLine().Trim());
            int searchMemberIndex = Repository.Members.FindIndex((member) => member.Id == memberId);

            if (searchMemberIndex == -1)
            {
                Console.WriteLine(
                    "Kütüphane üyelerinde belirtilen id numarasına sahip üye bulunamadı. Tekrar denemek ister misiniz ?");
                Console.WriteLine("(1) Evet \n(2) Hayır");
                int isRepeat = Convert.ToInt32(Console.ReadLine());

                if (isRepeat == 1)
                    goto memberRepeat;
                else return;
            }

            if (Repository.Members[searchMemberIndex].BorrowedBooks.Count == 0)
            {
                Console.WriteLine(
                    $"{Repository.Members[searchMemberIndex].FirstName} " +
                    $"{Repository.Members[searchMemberIndex].LastName} kütüphane üyesinin ödünç alınmış kitabı yoktur.\nBaşka bir üye seçiniz!!!!"
                );
                goto memberRepeat;
            }

            LibraryOperations.PrintBooks(Repository.Members[searchMemberIndex].BorrowedBooks,
                out bool continueBookExecution);
            if (!continueBookExecution) return;

            memberBookRepeat:
            Console.Write(
                $"{Repository.Members[searchMemberIndex].FirstName} " +
                $"{Repository.Members[searchMemberIndex].LastName} üyesinin teslim edeceği kitabın id numarasını girin : "
            );
            int bookId = Convert.ToInt32(Console.ReadLine().Trim());
            int searchBookIndex = Repository.Members[searchMemberIndex].BorrowedBooks
                .FindIndex((book) => book.Id == bookId);

            if (searchBookIndex == -1)
            {
                Console.WriteLine(
                    $"{Repository.Members[searchMemberIndex].FirstName} " +
                    $"{Repository.Members[searchMemberIndex].LastName} " +
                    $"Üyesinin id numarasına sahip ödünç aldığı kitap bulunmamaktadır.\nTekrar denemek ister misiniz ?"
                );
                Console.WriteLine("(1) Evet \n(2) Hayır");
                int isRepeat = Convert.ToInt32(Console.ReadLine());

                if (isRepeat == 1)
                    goto memberBookRepeat;
                else return;
            }

            Console.WriteLine(
                $"{Repository.Books[searchBookIndex].Name} adlı kitap kütüphaneye teslim edilecektir. Onaylıyor musunuz ?");
            Console.WriteLine("(1) Evet \n(2) Hayır");
            int isLend = Convert.ToInt32(Console.ReadLine());

            if (isLend == 1)
            {
                Console.WriteLine($"{Repository.Books[searchBookIndex].Name} adlı kitap kütüphaneye teslim edildi.");
                Repository.Members[searchMemberIndex].BorrowedBooks.RemoveAt(searchBookIndex);
            }
            else
                return;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Exception : {exception.Message}");
        }
    }
}