using WebApplication6.Models;

namespace WebApplication6.Interfaces
{
    /// <summary>
    /// интерфейс за показване на публикуваните обяви
    /// </summary>
    public interface IAdsPersonService
    {
        IEnumerable<AdsPerson> Read();

    }
}
