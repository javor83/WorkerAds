using WebApplication6.Models;

namespace WebApplication6.AppInterface
{
    /// <summary>
    /// интерфейс за показване на публикуваните обяви
    /// </summary>
    public interface IServiceAdsPerson
    {
        IEnumerable<DTO_AdsPerson> Read();

    }
}
