using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobGetter.DAL.Entities
{
    public class MilitaryStatus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
