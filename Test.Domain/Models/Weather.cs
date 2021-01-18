using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Domain.Models
{
    public partial class Weather: BaseEntity
    {
        public int Id { get; set; }
        public int Temperature { get; set; }
        public DateTime Date { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
