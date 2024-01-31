namespace LibraryManagementSystem.Entities
{
    public class Book
    {
        private static int _lastId = 0;
        private int _id;
        private string _name;
        private string _author;
        private DateTime _releaseYear;

        public Book(string name, string author, DateTime releaseYear)
        {
            this._id = ++_lastId;
            this._name = name;
            this._author = author;
            this._releaseYear = releaseYear;
        }
        
        public static int LastId
        {
            set => _lastId = value;
        }

        public int Id
        {
            get => _id;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Author
        {
            get => _author;
            set => _author = value;
        }

        public DateTime ReleaseYear
        {
            get => _releaseYear;
            set => _releaseYear = value;
        }
    }
}