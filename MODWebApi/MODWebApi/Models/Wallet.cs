﻿using System;
using System.Collections.Generic;

namespace MODWebApi.Models
{
    public partial class Wallet
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long Balance { get; set; }
    }
}
