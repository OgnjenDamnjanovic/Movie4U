using System.Collections.Generic;

namespace Neo4j.Model
{
    public class Korisnik
    {
        public string id {get; set;}
        public string ime {get; set;}
        public string prezime {get; set;}
        public string email {get; set;}
        public int tip {get; set;}
        public string sifra {get; set;}
        public List<Film> watchlist {get; set;}

    }
}