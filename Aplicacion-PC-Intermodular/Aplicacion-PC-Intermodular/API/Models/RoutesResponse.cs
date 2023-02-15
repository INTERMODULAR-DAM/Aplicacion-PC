using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_PC_Intermodular.API.Models
{
    public class AllRoutes
    {
        public int status { get; set; }
        public Route[] allPosts { get; set; }
    }

    public class RouteById
    {
        public Route data { get; set; }
    }

    public class Route
    {
        public Route() { }


        public Route(Route updatedRoute)
        {
            _id = updatedRoute._id;
            date = updatedRoute.date;
            name = updatedRoute.name;
            category = updatedRoute.category;
            distance= updatedRoute.distance;
            difficulty= updatedRoute.difficulty;
            track= updatedRoute.track;
            duration= updatedRoute.duration;
            description= updatedRoute.description;
            photos= updatedRoute.photos;
            privacity= updatedRoute.privacity;
            user= updatedRoute.user;
        }

        public string _id { get; set; }
        public DateTime date { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string distance { get; set; }
        public string difficulty { get; set; }
        public Track[] track { get; set; }
        public string duration { get; set; }
        public string description { get; set; }
        public int photos { get; set; }
        public bool privacity { get; set; }
        public string company { get; set; }
        public string user { get; set; }

        

        public bool equalRoute(Route route)
        {
            if (name == route.name && category == route.category && distance == route.distance && difficulty == route.difficulty && duration == route.duration && description == route.description && privacity == route.privacity)
                return true;
            return false;
        }
    }

    public class Track
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

}
