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
    public class ContactModel : PageModel
    {
        public string Message {get; set;}

        public void OnGet()
        {
            Neo4jClient.GraphClient client = ClientManager.GetSession();
            string email = HttpContext.Session.GetString("email");
            /*if(!String.IsNullOrEmpty(email))
                Message = "Welcome " + email;*/
            if(!String.IsNullOrEmpty(email))
            {
                var query = new Neo4jClient.Cypher.CypherQuery("match (k:Korisnik) where k.email='"+email+"'return k",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);
            
                Korisnik k = ((IRawGraphClient)client).ExecuteGetCypherResults<Korisnik>(query).FirstOrDefault();
                if(k.tip==1)
                    Message="Admin";
                else
                    Message="User";
            }
        }
    }
}
