namespace Neo4j.Model
{
    public class Recenzija
    {
        public string id {get; set;}
        public Korisnik korisnik {get; set;}
        public Film film {get; set;}
        public Serija serija {get;set;}
        public int ocena {get; set;}
        public string komentar {get; set;}
    }
}