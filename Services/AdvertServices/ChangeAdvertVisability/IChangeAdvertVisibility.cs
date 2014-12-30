using System.Collections.Generic;

namespace Services.AdvertServices.ChangeAdvertVisability
{
    public interface IChangeAdvertVisibility
    {
        bool HideAdverts(IEnumerable<string> numbers);
        void DeleteAdverts(IEnumerable<string> numbers);
    }
}