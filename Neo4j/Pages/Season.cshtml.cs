using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Neo4j.Model;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace MyApp.Namespace
{
    public class SeasonModel : PageModel
    {
        [BindProperty]
        public Serija serija {get;set;}
        [BindProperty]
        public Sezona sezona {get;set;}
        [BindProperty]
        public List<Epizoda> epizode {get;set;}
        public string Message {get; set;}

        public void OnGet(string tvShow, string season)
        {
            string email = HttpContext.Session.GetString("email");
            if(!String.IsNullOrEmpty(email))
                Message = "Welcome " + email;

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("season", season);
            queryDict.Add("tvShow", tvShow);
            Neo4jClient.GraphClient client = ClientManager.GetSession();
            
            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (serija)-[:SEASON]->(sezona) where sezona.nazivSezone = {season} and serija.nazivSerije = {tvShow} return sezona",
                                                           queryDict, CypherResultMode.Set);

            sezona = ((IRawGraphClient)client).ExecuteGetCypherResults<Sezona>(query).FirstOrDefault();

            var query2 = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match(n:Serija) where n.nazivSerije = {tvShow} return n",
                                                           queryDict, CypherResultMode.Set);

            serija = ((IRawGraphClient)client).ExecuteGetCypherResults<Serija>(query2).FirstOrDefault();

            var query3 = new Neo4jClient.Cypher.CypherQuery("match (sezona)-[r:EPISODE]->(epizoda) where sezona.nazivSezone = {season} return epizoda",
                                                           queryDict, CypherResultMode.Set);

            epizode = ((IRawGraphClient)client).ExecuteGetCypherResults<Epizoda>(query3).OrderBy(x=>x.datumObjave).ToList();
        }
    }
}
