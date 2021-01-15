using System.Collections.Generic;

namespace Neo4j.Model
{
    public class Glumac
    {
        public string id {get; set;}
        public string ime {get; set;}
        public string prezime {get; set;}
        public string biografija {get; set;}
        public string godinaRodjenja {get; set;}
        public string mestoRodjenja {get; set;}
        public string nacionalnost {get; set;}
        public List<Film> filmovi {get; set;}
        
    }
}