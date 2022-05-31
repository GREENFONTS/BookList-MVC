namespace BookApp.Models
{
    public class BookDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CollectionsName { get; set; } = null!;
    }
}
