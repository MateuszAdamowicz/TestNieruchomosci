﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityModels;

namespace Models.ViewModels
{
    public class SettingsViewModel
    {
        public List<Clat> ClatList { get; set; }
        public List<CostProperty> CostPropertiesList { get; set; }
    }
}
