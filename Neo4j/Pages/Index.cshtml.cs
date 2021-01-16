using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void OnGet()
        {
            Neo4jClient.GraphClient client = ClientManager.GetSession();

            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:FRIEND]->(friend) return friend",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);

            List<User> users = ((IRawGraphClient)client).ExecuteGetCypherResults<User>(query).ToList();
            
        }
    }
}
