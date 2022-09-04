using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Lesson : Entity
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
    }
}