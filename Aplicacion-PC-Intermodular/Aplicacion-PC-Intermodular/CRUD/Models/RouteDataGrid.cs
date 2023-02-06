using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_PC_Intermodular.CRUD.Models
{
    public class RouteDataGrid
    {
        public RouteDataGrid(int index,string name, string category, string distance, string difficulty, string duration)
        {
            this.Index= index;
            this.Name = name;
            this.Category = category;
            this.Distance = distance;
            this.Difficulty = difficulty;
            this.Duration = duration;
        }

        public int Index { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Distance { get; set; }
        public string Difficulty { get; set; }
        public string Duration { get; set; }
    }
}
