using System.Collections.Generic;

namespace Neo4j.Model
{
    public class Serija
    {
        public string id {get; set;}
        public string nazivSerije {get; set;}
        public string opis {get; set;}
        public string zanr {get; set;}
        public string jezik {get; set;}
        public bool zavrsena {get; set;}
        public float zbirOcena {get; set;} = 0;
        public int brOcena {get; set;} = 0;
        public List<Sezona> sezone {get; set;}
        public Reziser reziser {get; set;}
        public List<Uloga> glavniGlumci {get; set;}
        public List<Recenzija> recenzije {get; set;}
    }
}