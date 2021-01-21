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
        [BindProperty]
         public Vest trazenaVest { get; set; }
         public string Message {get; set;}
        public IActionResult OnGet(string id)
        {
               
               Neo4jClient.GraphClient client = ClientManager.GetSession();

               string email = HttpContext.Session.GetString("email");
                if(!String.IsNullOrEmpty(email))
                    Message = "Welcome " + email;

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
                
                 return Page();}
             
        }
        public void OnPostLike(string id)
        {
           
        }
    }
}
