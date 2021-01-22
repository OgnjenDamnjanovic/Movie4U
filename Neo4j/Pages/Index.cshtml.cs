using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Neo4j.Model;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace Neo4j.Pages
{
    public class IndexModel : PageModel
    {
         public List<Serija> serijeNoveEpizode{get;set;} 
        public List<Serija> najboljeOcenjeneSerije{get;set;} 
        public List<Film> najcenjenijiFilmovi{get;set;} 

        public List<Film> najnovijiFilmovi {get;set;}
        public List<Film> najboljeOcenjeniFilmovi {get;set;}
        public string Message {get; set;}
        public void OnGet()
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

            var query = new Neo4jClient.Cypher.CypherQuery(" match (film:Film) return film order by film.godina desc limit 6;",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);

            najnovijiFilmovi= ((IRawGraphClient)client).ExecuteGetCypherResults<Film>(query).ToList();
            foreach(var v in najnovijiFilmovi)
            {
                v.opis=(v.opis.Length>125)?v.opis.Substring(0,120)+"...":v.opis;
            }
              query = new Neo4jClient.Cypher.CypherQuery(" match (film:Film) return film order by film.avgOcena desc limit 8;",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);

            najboljeOcenjeniFilmovi= ((IRawGraphClient)client).ExecuteGetCypherResults<Film>(query).ToList();

             query = new Neo4jClient.Cypher.CypherQuery(" match (film:Film) return film order by film.avgOcena desc,film.brOcena desc limit 18;",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);

            najcenjenijiFilmovi= ((IRawGraphClient)client).ExecuteGetCypherResults<Film>(query).ToList();

              query = new Neo4jClient.Cypher.CypherQuery(" match (serija:Serija) return serija order by serija.avgOcena desc limit 18;",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);

            najboljeOcenjeneSerije= ((IRawGraphClient)client).ExecuteGetCypherResults<Serija>(query).ToList();
            
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("email");
            Message = null;
            return RedirectToPage("/Index");
        }
    }
}
