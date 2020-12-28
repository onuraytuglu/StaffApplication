using PersonelProject.ToDo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonelProject.ToDo.Entities.Concrete
{
    public class Urgency : ITablo
    {
        public int Id { get; set; }
        public string Definition { get; set; }

        public List<Mission> Missions { get; set; }
    }
}
