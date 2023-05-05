using Domain;
using Domain.Extentions;

namespace Core
{
    public abstract class HighscoreService : IHighscoreService<HighscoreModel>
    {
        public virtual void Save(HighscoreModel item)
        {
            // Calling extention methods to validate the values of the item
            item.Validate();
        }

        public abstract List<HighscoreModel> GetAll();
        public abstract void Dispose();
    }
}