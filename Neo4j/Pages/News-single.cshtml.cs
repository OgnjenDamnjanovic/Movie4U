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
    public class News_singleModel : PageModel
    {
        public List<Vest> najnovijeVesti { get; set; }
        public List<Vest> slicneVesti {get; set;}
        [BindProperty]
         public Vest trazenaVest { get; set; }
         public string Message {get; set;}
        public IActionResult OnGet(string id)
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

            var query = new Neo4jClient.Cypher.CypherQuery($"match(vest:Vest) where vest.id='{id}' return vest;",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);

             trazenaVest = ((IRawGraphClient)client).ExecuteGetCypherResults<Vest>(query).ToList().FirstOrDefault();

             if(trazenaVest==null)
             return RedirectToPage("/Error");
             else
             {
                 query = new Neo4jClient.Cypher.CypherQuery($"match(vest:Vest) where NOT(vest.id='{trazenaVest.id}') return vest  order by vest.datumPostavljanja desc LIMIT 5; ",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);
                                                          
                 najnovijeVesti= ((IRawGraphClient)client).ExecuteGetCypherResults<Vest>(query).ToList();

                query = new Neo4jClient.Cypher.CypherQuery($"match (vestTr:Vest{{id:\"{trazenaVest.id}\"}})-[:ABOUT]->(media)<-[:ABOUT]-(vestSlicna:Vest) return vestSlicna ",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);
                                                          
                 slicneVesti= ((IRawGraphClient)client).ExecuteGetCypherResults<Vest>(query).ToList();
                
                 return Page();
            }
             
        }
        public IActionResult OnPostLike(string id)
        {
            string email = HttpContext.Session.GetString("email");
            if(String.IsNullOrEmpty(email))
                return RedirectToPage("/Login");

            Neo4jClient.GraphClient client = ClientManager.GetSession();
            trazenaVest.brojLajkova++;
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("id", id);
            queryDict.Add("brojLajkova", trazenaVest.brojLajkova);

            var query0 = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match(v:Vest) where v.id = {id} set v.brojLajkova = {brojLajkova} return v",
                                                           queryDict, CypherResultMode.Set);

            Vest azuriranaVest = ((IRawGraphClient)client).ExecuteGetCypherResults<Vest>(query0).FirstOrDefault();

            return RedirectToPage("/News-single", new {id=id});
        }
    }
}
