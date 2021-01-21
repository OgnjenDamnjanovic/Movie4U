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
    public class TvShowModel : PageModel
    {
        [BindProperty]
        public Serija serija {get; set;}
        [BindProperty]
        public Reziser reziser {get; set;}
        [BindProperty]
        public List<Glumac> glumci {get; set;}
        [BindProperty]
        public List<Recenzija> recenzije {get; set;}
        [BindProperty]
        public List<Serija> slicneSerije {get; set;}
        [BindProperty]
        public List<Sezona> sezone {get;set;}
        [BindProperty]
        public string komentar {get;set;}
        [BindProperty]
        public int ocena {get;set;}
        public string Message {get; set;}

        public void OnGet(string tvShow)
        {
            Neo4jClient.GraphClient client = ClientManager.GetSession();

            string email = HttpContext.Session.GetString("email");
            if(!String.IsNullOrEmpty(email))
                Message = "Welcome " + email;

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("tvShow", tvShow);

            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match(n:Serija) where n.nazivSerije = {tvShow} return n",
                                                           queryDict, CypherResultMode.Set);

            serija = ((IRawGraphClient)client).ExecuteGetCypherResults<Serija>(query).FirstOrDefault();

            var query2 = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:DIRECTED]->(m) where m.nazivSerije = {tvShow} return n",
                                                           queryDict, CypherResultMode.Set);

            reziser = ((IRawGraphClient)client).ExecuteGetCypherResults<Reziser>(query2).FirstOrDefault();

            var query3 = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:ACTED_IN]->(m) where m.nazivSerije = {tvShow} return n",
                                                           queryDict, CypherResultMode.Set);

            glumci = ((IRawGraphClient)client).ExecuteGetCypherResults<Glumac>(query3).ToList();

            var query4 = new Neo4jClient.Cypher.CypherQuery("match (korisnik)-[r:RECENZIJA]->(serija) where serija.nazivSerije = {tvShow} return r{korisnik, serija, .ocena, .komentar}",
                                                           queryDict, CypherResultMode.Set);

            recenzije = ((IRawGraphClient)client).ExecuteGetCypherResults<Recenzija>(query4).ToList();

            Dictionary<string, object> queryDict2 = new Dictionary<string, object>();
            queryDict2.Add("zanr", serija.zanr);

            var query5 = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match(n:Serija) where n.zanr = {zanr} return n",
                                                           queryDict2, CypherResultMode.Set);

            slicneSerije = ((IRawGraphClient)client).ExecuteGetCypherResults<Serija>(query5).ToList();

            var query6 = new Neo4jClient.Cypher.CypherQuery("match (serija)-[:SEASON]->(sezona) where serija.nazivSerije = {tvShow} return sezona",
                                                           queryDict, CypherResultMode.Set);
            
            //string sezona = ((IRawGraphClient)client).ExecuteGetCypherResults<string>(query6).FirstOrDefault();
            sezone = ((IRawGraphClient)client).ExecuteGetCypherResults<Sezona>(query6).OrderBy(x=>x.brojSezone).ToList();
        }

        public IActionResult OnPostRec()
        {
            Neo4jClient.GraphClient client = ClientManager.GetSession();

            string email = HttpContext.Session.GetString("email");
            if(String.IsNullOrEmpty(email))
                return RedirectToPage("/Login");

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("email", email);
            queryDict.Add("nazivSerije", serija.nazivSerije);
            queryDict.Add("ocena", ocena);
            queryDict.Add("komentar", komentar);

            var query = new Neo4jClient.Cypher.CypherQuery("MATCH (k:Korisnik),(s:Serija) WHERE k.email = {email} AND s.nazivSerije = {nazivSerije} CREATE (k)-[r:RECENZIJA {ocena:{ocena}, komentar:{komentar}}]->(s) return r",
                                                           queryDict, CypherResultMode.Set);

            List<Recenzija> novaRec = ((IRawGraphClient)client).ExecuteGetCypherResults<Recenzija>(query).ToList();

            serija.zbirOcena += ocena;
            serija.brOcena++;
            serija.avgOcena = serija.zbirOcena / serija.brOcena;

            queryDict.Add("zbirOcena", serija.zbirOcena);
            queryDict.Add("brOcena", serija.brOcena);
            queryDict.Add("avgOcena", serija.avgOcena);

            var query1 = new Neo4jClient.Cypher.CypherQuery("MATCH (s:Serija) WHERE s.nazivSerije = {nazivSerije} SET s+={zbirOcena:{zbirOcena}, brOcena:{brOcena}, avgOcena:{avgOcena} }  return s",
                                                           queryDict, CypherResultMode.Set);

            List<Serija> azuriranaSerija = ((IRawGraphClient)client).ExecuteGetCypherResults<Serija>(query1).ToList();

            return RedirectToPage("/TvShow", new {tvShow=serija.nazivSerije});
        }
    }
}
