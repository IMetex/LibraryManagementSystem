using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.Data
{
    public static class Repository
    {
        private static List<Member> _members = new List<Member>();
        private static List<Book> _books = new List<Book>();

        static Repository() 
        {
            _members.Add(new Member("Barış", "Mete", 1));
            _members.Add(new Member("George R.R.", "Martin", 5));
            _members.Add(new Member("Jack", "London", 3));

            _books.Add(new Book("Beyaz Diş", "Jack London", new DateTime(2005, 11, 1)));
            _books.Add(new Book("Puslu Kıtalar Atlası", "İhsan Oktay Anar", new DateTime(2021, 6, 2)));
            _books.Add(new Book("Piamater", "Serkan Karaismailoğlu", new DateTime(2019, 5, 28)));
        }

        public static List<Member> Members { get => _members; set => _members = value; }
        public static List<Book> Books { get => _books; set => _books = value; }

    }
}