using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SipItApp.Droid
{
    public class Constants
    {
        public const string ListenConnectionString = "Endpoint=sb://sipitapp.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=GaM/iaR4wDScGxTXChRVcJvh8NV3cMzSDk8Ljytlusg=";
        public const string NotificationHubName = "SipItSoda";
    }
}