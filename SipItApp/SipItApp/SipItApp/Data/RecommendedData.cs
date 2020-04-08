using System;
using System.Collections.Generic;
using System.Text;

namespace SipItApp.Data
{
    public static class RecommendedData
    {
        public static IList<String> Items { get; private set; }

        //List to be shown in the Main Page in the 
        //Recommended box
        static RecommendedData()
        {
            Items = new List<String>();

            Items.Add("Dirty Dr. Pepper");
            Items.Add("Ironport");
        }
    }
}
