﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace videoChat.Models
{
    public class CallerViewModel
    {
        public Guid CallerId { get; set; } 
        public Guid ReceiverId { get; set; }
    }
}