using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Domain.Models
{
    public partial class City: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual ICollection<Weather> Weathers { get; set; }
    }
}
