﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string CustomerName { get; set; }
        public string BrandName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnTime { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}