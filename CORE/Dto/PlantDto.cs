using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Dto
{
    public class PlantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Watering { get; set; }
        public string Repotting { get; set; }
        public string Toxic { get; set; }
        public string Image { get; set; }
    }
}
