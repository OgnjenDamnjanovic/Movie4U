using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Neo4j.Model;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace MyApp.Namespace
{
    public class MovieModel : PageModel
    {
        [BindProperty]
        public Film film {get; set;}
        [BindProperty]
        public Reziser reziser {get; set;}
        [BindProperty]
        public List<Glumac> glumci {get; set;}
        [BindProperty]
        public List<Recenzija> recenzije {get; set;}
        [BindProperty]
        public List<Film> slicniFilmovi {get; set;}
        [BindProperty]
        public string komentar {get;set;}
        [BindProperty]
        public int ocena {get;set;}
        public string Message {get; set;}

        public void OnGet(string movie)
        {
            Neo4jClient.GraphClient client = ClientManager.GetSession();

            string email = HttpContext.Session.GetString("email");
            if(!String.IsNullOrEmpty(email))
            {
                Dictionary<string, object> queryDict0 = new Dictionary<string, object>();
                queryDict0.Add("email", email);

                var query0 = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match(k:Korisnik) where k.email = {email} return k",
                                                           queryDict0, CypherResultMode.Set);

                Korisnik k = ((IRawGraphClient)client).ExecuteGetCypherResults<Korisnik>(query0).FirstOrDefault();
                if(k.tip == 1)
                    Message = "Admin";
                else Message = "User";
            }

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("movie", movie);

            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match(n:Film) where n.nazivFilma = {movie} return n",
                                                           queryDict, CypherResultMode.Set);

            film = ((IRawGraphClient)client).ExecuteGetCypherResults<Film>(query).FirstOrDefault();

            var query2 = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:DIRECTED]->(m) where m.nazivFilma = {movie} return n",
                                                           queryDict, CypherResultMode.Set);

            reziser = ((IRawGraphClient)client).ExecuteGetCypherResults<Reziser>(query2).FirstOrDefault();

            var query3 = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:ACTED_IN]->(m) where m.nazivFilma = {movie} return n",
                                                           queryDict, CypherResultMode.Set);

            glumci = ((IRawGraphClient)client).ExecuteGetCypherResults<Glumac>(query3).ToList();

            var query4 = new Neo4jClient.Cypher.CypherQuery("match (korisnik)-[r:RECENZIJA]->(film) where film.nazivFilma = {movie} return r{korisnik, film, .ocena, .komentar}",
                                                           queryDict, CypherResultMode.Set);

            recenzije = ((IRawGraphClient)client).ExecuteGetCypherResults<Recenzija>(query4).ToList();

            Dictionary<string, object> queryDict2 = new Dictionary<string, object>();
            queryDict2.Add("zanr", film.zanr);

            var query5 = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match(n:Film) where n.zanr = {zanr} return n",
                                                           queryDict2, CypherResultMode.Set);

            slicniFilmovi= ((IRawGraphClient)client).ExecuteGetCypherResults<Film>(query5).ToList();

        }
        public IActionResult OnPostRec()
        {
            Neo4jClient.GraphClient client = ClientManager.GetSession();

            string email = HttpContext.Session.GetString("email");
            if(String.IsNullOrEmpty(email))
                return RedirectToPage("/Login");

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("email", email);
            queryDict.Add("nazivFilma", film.nazivFilma);
            queryDict.Add("ocena", ocena);
            queryDict.Add("komentar", komentar);

            var query = new Neo4jClient.Cypher.CypherQuery("MATCH (k:Korisnik),(f:Film) WHERE k.email = {email} AND f.nazivFilma = {nazivFilma} CREATE (k)-[r:RECENZIJA {ocena:{ocena}, komentar:{komentar}}]->(f) return r",
                                                           queryDict, CypherResultMode.Set);

            List<Recenzija> novaRec = ((IRawGraphClient)client).ExecuteGetCypherResults<Recenzija>(query).ToList();

            film.zbirOcena += ocena;
            film.brOcena++;
            film.avgOcena = film.zbirOcena / film.brOcena;

            queryDict.Add("zbirOcena", film.zbirOcena);
            queryDict.Add("brOcena", film.brOcena);
            queryDict.Add("avgOcena", film.avgOcena);

            var query1 = new Neo4jClient.Cypher.CypherQuery("MATCH (f:Film) WHERE f.nazivFilma = {nazivFilma} SET f+={zbirOcena:{zbirOcena}, brOcena:{brOcena}, avgOcena:{avgOcena} }  return f",
                                                           queryDict, CypherResultMode.Set);

            List<Film> azuriraniFilm = ((IRawGraphClient)client).ExecuteGetCypherResults<Film>(query1).ToList();

            return RedirectToPage("/Movie", new {movie=film.nazivFilma});
        }


        public IActionResult OnPostAdd()
        {
            Neo4jClient.GraphClient client = ClientManager.GetSession();

            string email = HttpContext.Session.GetString("email");
            if(String.IsNullOrEmpty(email))
                return RedirectToPage("/Login");

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("email", email);
            queryDict.Add("nazivFilma", film.nazivFilma);

            var query = new Neo4jClient.Cypher.CypherQuery("MATCH (k)-[r:WATCHLIST]->(f) WHERE k.email = {email} AND f.nazivFilma = {nazivFilma} return k",
                                                           queryDict, CypherResultMode.Set);

            Korisnik k = ((IRawGraphClient)client).ExecuteGetCypherResults<Korisnik>(query).FirstOrDefault();

            if(k!=null)
            {
                return RedirectToPage("/Movie", new {movie=film.nazivFilma, success="false"}); //vec ima ovaj film u watchlist
            }

            var query1 = new Neo4jClient.Cypher.CypherQuery("MATCH (k:Korisnik),(f:Film) WHERE k.email = {email} AND f.nazivFilma = {nazivFilma} CREATE (k)-[r:WATCHLIST]->(f) return r",
                                                           queryDict, CypherResultMode.Set);

            List<string> novaVeza = ((IRawGraphClient)client).ExecuteGetCypherResults<string>(query1).ToList();

            return RedirectToPage("/Movie", new {movie=film.nazivFilma, success="true"});
        }
    }
}
