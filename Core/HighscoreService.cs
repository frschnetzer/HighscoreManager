using Domain;
using Domain.Extentions;

namespace Core
{
    public abstract class HighscoreService : IHighscoreService<HighscoreModel>
    {
        public virtual void Save(HighscoreModel item)
        {
            item.Validate();
        }

        public abstract List<HighscoreModel> GetAll();
        public abstract void Dispose();
    }
}