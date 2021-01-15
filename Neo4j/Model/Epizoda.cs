using System;
using System.Collections.Generic;

namespace Neo4j.Model
{
    public class Epizoda
    {
        public string id {get; set;}
        public string nazivEpizode {get; set;}
        public string opis {get; set;}
        public List<Glumac> glumci {get; set;}
        public DateTime datumObjave {get; set;}
    }
}