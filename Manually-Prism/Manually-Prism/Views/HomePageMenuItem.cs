﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManuallyPrism.Views
{
    public class HomePageMenuItem
    {
        public HomePageMenuItem()
        {
            TargetType = typeof(HomePageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }

        public Type TargetType { get; set; }
    }
}
