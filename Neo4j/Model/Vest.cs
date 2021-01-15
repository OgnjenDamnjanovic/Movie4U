using System;

namespace Neo4j.Model
{
    public class Vest
    {
        public string id {get; set;}
        public string naslov {get; set;}
        public string opis {get; set;}
        public DateTime datumPostavljanja {get; set;}
        public int brojLajkova {get; set;}
    }
}