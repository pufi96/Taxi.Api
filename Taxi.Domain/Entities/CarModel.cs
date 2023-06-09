﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Domain.Entities
{
    public class CarModel : Entity
    {
        public string CarModelName { get; set; }
        public int CarBrandId { get; set; }

        public virtual CarBrand CarBrand { get; set; }
        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
