using System.Collections.Generic;

namespace Neo4j.Model
{
    public class Sezona
    {
        public Serija serija {get; set;}
        public List<Epizoda> epizode {get; set;}
        public int brojSezone {get; set;}
    }
}