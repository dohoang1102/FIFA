﻿using System;

namespace Fifa.Core.Models
{
    public class UserStats : BaseEntity
    {
        public int Games { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public decimal WinRate { get; set; }

        public DateTime CalcDate { get; set; }
    }
}