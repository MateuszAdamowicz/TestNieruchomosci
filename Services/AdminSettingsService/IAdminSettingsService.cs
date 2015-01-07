using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityModels;
using Models.ViewModels;

namespace Services.AdminSettingsService
{
    public interface IAdminSettingsService
    {
       void EditClat(Clat clatModel);
       void DeleteClat(int id);
       void EditCostPropList(CostProperty costPropModel);
       void AddClat(Clat clat);
       AddClatViewModel AddClat();
    }
}
