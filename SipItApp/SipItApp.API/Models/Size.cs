﻿using System;
using System.Collections.Generic;

namespace SipItApp.API.Models
{
    public partial class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Volume { get; set; }
        public decimal Price { get; set; }
    }
}
