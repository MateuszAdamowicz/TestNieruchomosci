using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context;
using Models.ViewModels;
using Services.CalcService;

namespace Services.CalcService.Implementation
{
    public class CalcService : ICalcService
    {

        private readonly IApplicationContext _context;

        public CalcService(IApplicationContext context)
        {
            _context = context;
        }
        public CalcViewModel BuildViewModel()
        {

            var clats = _context.Clats.ToList();
            var properties = _context.CostProperties.ToList();

            var model = new CalcViewModel()
            {
                ClatList = clats,
                CostPropertiesList = properties
            };

            return model;
        }

        public CalcViewModel BuildViewModel(string viewPrice, string viewOwnership)
        {

            var clats = _context.Clats.ToList();
            var properties = _context.CostProperties.ToList();
            decimal price;
            decimal.TryParse(viewPrice, out price);


            var modelView = new CalcView()
            {
                Price = price,
                OwnershipForm = viewOwnership
            };

            var model = new CalcViewModel()
            {
                ModelCalcView = modelView,
                ClatList = clats,
                CostPropertiesList = properties
            };

            return model;
        }


    }
}


