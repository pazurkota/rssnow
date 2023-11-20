using SQLite;
using rssnow.Model;

namespace rssnow;

public class RssLinkRepository
{
    string _dbPath;

    SQLiteAsyncConnection conn;
    
    public string StatusMessage { get; set; }

    void Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteAsyncConnection(_dbPath);
        conn.CreateTableAsync<RssLink>();
    }

    public RssLinkRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public async void AddNewLink(string link)
    {
        int result = 0;

        try
        {
            Init();

            if (string.IsNullOrEmpty(link))
                throw new Exception("URL is not valid!");

            result = await conn.InsertAsync(new RssLink() { Link = link });

            StatusMessage = $"{result} has been added (URL: {link})";
        }
        catch (Exception e)
        {
            StatusMessage = $"Failed to add {link}. Error: {e.Message}";
        }
    }

    public async Task<List<RssLink>> GetAllLinks()
    {
        try
        {
            Init();

            return await conn.Table<RssLink>().ToListAsync();
        }
        catch (Exception e)
        {
            StatusMessage = $"Failed to retrieve data: {e.Message}";
        }

        return new List<RssLink>();
    }

    public async void EditLink(string link, string updatedLink)
    {
        try
        {
            Init();
            
            var existingLink = await conn.Table<RssLink>().Where(x => x.Link == link).FirstOrDefaultAsync();

            if (existingLink != null)
            {
                existingLink.Link = updatedLink;

                int result = await conn.UpdateAsync(existingLink);

                StatusMessage = $"{result} record(s) updated (URL: {link})";
            }
            else
            {
                StatusMessage = $"No record found (URL: {link})";
            }
        }
        catch (Exception e)
        {
            StatusMessage = $"Failed to edit {link} (Error: {e.Message})";
        }
    }

    public async void DeleteLink(int id)
    {
        try
        {
            Init();

            int result = await conn.Table<RssLink>().Where(x => x.Id == id).DeleteAsync();

            StatusMessage = $"{result} record(s) deleted (ID: {id})";
        }
        catch (Exception e)
        {
            StatusMessage = $"Failed to delete channel with ID: {id} (Error: {e.Message})";
        }
    }
}