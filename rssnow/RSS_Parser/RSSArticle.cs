using System.Xml;

namespace rssnow.RSS_Parser;

public class RSSArticle
{
    private readonly string articleTitle;
    private readonly string articleLink;
    private readonly string articleDesc;
    private readonly Dictionary<string, XmlNode> articleVariables;

    public string ArticleTitle => articleTitle;
    public string ArticleLink => articleLink;
    public string ArticleDesc => articleDesc;
    public Dictionary<string, XmlNode> ArticleVariables => articleVariables;

    public RSSArticle(string ArticleTitle, string ArticleLink, string ArticleDesc,
        Dictionary<string, XmlNode> ArticleVariables)
    {
        articleTitle = !string.IsNullOrWhiteSpace(ArticleTitle) ? ArticleTitle.Trim() : "";
        articleLink = !string.IsNullOrWhiteSpace(ArticleLink) ? ArticleLink.Trim() : "";
        articleDesc = !string.IsNullOrWhiteSpace(ArticleDesc) ? ArticleDesc.Trim() : "";
        articleVariables = ArticleVariables;
    }
}