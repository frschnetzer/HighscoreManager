using Domain;

namespace Core
{
    public interface IHighscoreService<T> : IDisposable
    {
        void Save(T item);

        List<HighscoreModel> GetAll();
    }
}
