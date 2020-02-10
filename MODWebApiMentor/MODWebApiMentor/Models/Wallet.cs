using System;
using System.Collections.Generic;

namespace MODWebApiMentor.Models
{
    public partial class Wallet
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public double Balance { get; set; }
    }
}
