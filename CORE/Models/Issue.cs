using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class Issue
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Cause { get; set; }
        public string Solution { get; set; }
        public string Image { get; set; }

    }
}
