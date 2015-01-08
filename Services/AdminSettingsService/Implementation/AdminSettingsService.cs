using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context;
using Models.EntityModels;
using Models.ViewModels;

namespace Services.AdminSettingsService.Implementation
{
    public class AdminSettingsService : IAdminSettingsService
    {
        private readonly IApplicationContext _applicationContext;

        public AdminSettingsService(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void EditClat(Clat clatModel)
        {
            var clat = _applicationContext.Clats.Find(clatModel.Id);
            clat.From = clatModel.From;
            clat.To = clatModel.To;
            clat.Percent = clatModel.Percent;
            clat.Price = clatModel.Price;
            clat.Max = clatModel.Max;

            _applicationContext.SaveChanges();
        }

        public void DeleteClat(int id)
        {
            Clat deleteOrderDetails = _applicationContext.Clats.First(x => x.Id == id);
            _applicationContext.Clats.Remove(deleteOrderDetails);
            _applicationContext.SaveChanges();
        }

        public void EditCostPropList(CostProperty costPropModel)
        {
            var costProp = _applicationContext.CostProperties.Find(costPropModel.Id);
            costProp.Value = costPropModel.Value;
            _applicationContext.SaveChanges();
        }

        public AddClatViewModel AddClat()
        {
            var clats = _applicationContext.Clats.OrderBy(x => x.From).ThenBy(x => x.To).ToList();
            var sum = 0.0;
            var clat = new Clat();
            List<Compartments> compartmentses = new List<Compartments>();

            foreach (var item in clats)
            {
                sum += item.To - item.From;
                if (sum != item.To)
                {
                    Compartments oneCompartment = new Compartments { To = item.From, From = item.From - item.To + sum };
                    compartmentses.Add(oneCompartment);
                    sum = item.To;
                }
            }
            var model = new AddClatViewModel { Clat = clat, CompartmentsList = compartmentses };
            return model;
        }

        public void AddClat(Clat clat)
        {
            Clat model = new Clat { To = clat.To, Max = clat.Max, Price = clat.Price, Percent = clat.Percent, From = clat.From };
            _applicationContext.Clats.Add(model);
            _applicationContext.SaveChanges();
       
        }

 }


}
