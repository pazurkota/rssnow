using SQLite;

namespace rssnow.Model;

public class RssLink
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    [Unique]
    public string Link { get; set; }
}
