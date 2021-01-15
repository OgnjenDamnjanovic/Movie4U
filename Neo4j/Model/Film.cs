using System.Collections.Generic;

namespace Neo4j.Model
{
    public class Film
    {
        public string id {get; set;}
        public string nazivFilma {get; set;}
        public string opis {get; set;}
        public string zanr {get; set;}
        public string jezik {get; set;}
        public int vremeTrajanja {get; set;}
        public int godina {get; set;}
        public float zbirOcena {get; set;} = 0;
        public int brOcena {get; set;} = 0;
        public Reziser reziser {get; set;}
        public List<Uloga> glumci {get; set;}
        public List<Recenzija> recenzije {get; set;}

    }
}