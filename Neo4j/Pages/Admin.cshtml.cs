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
    public class AdminModel : PageModel
    {
        [BindProperty]
        public List<Vest> vesti {get; set;}
        [BindProperty]
        public List<Recenzija> recenzijeF {get;set;}
        [BindProperty]
        public List<Recenzija> recenzijeS {get;set;}
        public string Message {get; set;}

        public void OnGet()
        {
            Neo4jClient.GraphClient client = ClientManager.GetSession();
            string email = HttpContext.Session.GetString("email");
            if(!String.IsNullOrEmpty(email))
                Message = "Welcome " + email;

            var query = new Neo4jClient.Cypher.CypherQuery("match (vest:Vest) where vest.objavio='"+email+"'return vest",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);
            
            vesti = ((IRawGraphClient)client).ExecuteGetCypherResults<Vest>(query).ToList();

            var query2 = new Neo4jClient.Cypher.CypherQuery("match (korisnik)-[r:RECENZIJA]->(film:Film) return r{korisnik, film, .ocena, .komentar}",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);

            recenzijeF = ((IRawGraphClient)client).ExecuteGetCypherResults<Recenzija>(query2).ToList();

            var query3 = new Neo4jClient.Cypher.CypherQuery("match (korisnik)-[r:RECENZIJA]->(serija:Serija) return r{korisnik, serija, .ocena, .komentar}",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);

            recenzijeS = ((IRawGraphClient)client).ExecuteGetCypherResults<Recenzija>(query3).ToList();
        }

        public IActionResult OnPostObrisiRecF(string naziv, string email)
        {
            Neo4jClient.GraphClient client = ClientManager.GetSession();
            client.Cypher.Match("(k:Korisnik)-[r:RECENZIJA]->(film:Film)").Where((Korisnik k)=>k.email==email).AndWhere((Film film)=>film.nazivFilma==naziv).DetachDelete("r").ExecuteWithoutResults();
            return RedirectToPage();          
        }

        public IActionResult OnPostObrisiRecS(string naziv, string email)
        {
            Neo4jClient.GraphClient client = ClientManager.GetSession();
            client.Cypher.Match("(k:Korisnik)-[r:RECENZIJA]->(serija:Serija)").Where((Korisnik k)=>k.email==email).AndWhere((Serija serija)=>serija.nazivSerije==naziv).DetachDelete("r").ExecuteWithoutResults();
            return RedirectToPage();          
        }

        public IActionResult OnPostObrisiVest(string id)
        {
            Neo4jClient.GraphClient client = ClientManager.GetSession();
            client.Cypher.Match("(vest:Vest)").Where((Vest vest)=>vest.id==id).DetachDelete("vest").ExecuteWithoutResults();
            return RedirectToPage();          
        }
    }
}
