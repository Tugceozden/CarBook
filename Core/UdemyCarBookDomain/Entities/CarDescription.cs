using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBookDomain.Entities
{
	public class CarDescription
	{
        public int CarDescriptipnId { get; set; }
        public int  CarId { get; set; }
        public Car  Car { get; set; }
        public string Details { get; set; }


    }
}
