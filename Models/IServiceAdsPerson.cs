namespace WebApplication6.Models
{
    /// <summary>
    /// интерфейс за показване на публикуваните обяви
    /// </summary>
    public interface IServiceAdsPerson
    {
        IEnumerable<AdsPerson> Read();

    }
}
