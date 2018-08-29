using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace MobilePlanningMap
{
    public class DrawableMap : Map
    {
        public IList<Worksite> Worksites { get; set; }
        public DrawableMap()
        {
            Worksites = new List<Worksite>();
        }
    }
}
