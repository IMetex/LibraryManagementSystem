namespace LibraryManagementSystem.Entities;

public class Member
{
    private static int _lastId = 0;
    private int _id;
    private string _firstName;
    private string _lastName;
    private int _membershipNumber;
    private List<Book> _borrowedBooks;

    public Member(string firstName, string lastName, int membershipNumber)
    {
        this._id = ++_lastId;
        this._firstName = firstName;
        this._lastName = lastName;
        this._membershipNumber = membershipNumber;
        this._borrowedBooks = new List<Book>();
    }

    public static int LastId
    {
        set => _lastId = value;
    }

    public int Id
    {
        get => _id;
    }

    public string FirstName
    {
        get => _firstName;
        set => _firstName = value;
    }

    public string LastName
    {
        get => _lastName;
        set => _lastName = value;
    }

    public int MembershipNumber
    {
        get => _membershipNumber;
        set => _membershipNumber = value;
    }

    public List<Book> BorrowedBooks
    {
        get => _borrowedBooks;
        set => _borrowedBooks = value;
    }
}