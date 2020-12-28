using PersonelProject.ToDo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonelProject.ToDo.Entities.Concrete
{
    public class Report : ITablo
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public string Detail { get; set; }


        public int MissionId { get; set; }
        public Mission Mission { get; set; }

    }


}
