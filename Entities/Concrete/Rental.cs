using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Rental : IEntity//kiralama bilgisini tutan tablo
    {
        public int RentalId { get; set; }

        public int CarId { get; set; }

        public int CustomerId { get; set; }

        public DateTime RentDate { get; set; }//kiralama tarihi

        public DateTime? ReturnTime { get; set; }
    }
}