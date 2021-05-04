using SQLite;

namespace DavidFacts
{
    public class DavidFact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}