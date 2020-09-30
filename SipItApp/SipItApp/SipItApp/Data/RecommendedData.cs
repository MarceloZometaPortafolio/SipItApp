using System;
using System.Collections.Generic;
using System.Text;

namespace SipItApp.Data
{
    /// <summary>
    ///     List to be shown in the Main Page in the Recommended box
    ///     In the future this is is going to talk to the API and get 
    ///     recommended data elements for a specific user
    /// </summary>
    public static class RecommendedData
    {
        public static IList<String> Items { get; private set; }

        static RecommendedData()
        {
            Items = new List<String>();

            Items.Add("Dirty Dr. Pepper");
            Items.Add("Ironport");
        }
    }
}
