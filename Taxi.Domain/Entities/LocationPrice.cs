﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Domain.Entities
{
    public class LocationPrice : Entity
    {
        public double Price { get; set; }
        public int LocationStartId { get; set; }
        public int LocationEndId { get; set; }

        public virtual Location LocationStart { get; set; }
        public virtual Location LocationEnd { get; set; }
        public virtual ICollection<Ride> Rides { get; set; } = new HashSet<Ride>();
    }
}
