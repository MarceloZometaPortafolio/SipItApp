using SipItApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SipItApp.ViewModels
{
    [QueryProperty("ItemName", "name")]
    public class ItemDetailViewModel : INotifyPropertyChanged
    {
        public string ItemName
        {
            set
            {
                String item = RecommendedData.Items.FirstOrDefault(m => m == Uri.UnescapeDataString(value));

                if (item != null)
                {
                    Name = item;
                }
            }
        }
        public string Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
