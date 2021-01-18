using System;
using System.Collections.Generic;
using System.Text;
using Test.Domain.Models;

namespace Test.Application.ViewModels
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual ICollection<Weather> Weathers { get; set; }
    }
}
