using System;

namespace Neo4j.Model
{
    public static class ClientManager
    {
        public static Neo4jClient.GraphClient client;

        public static Neo4jClient.GraphClient GetSession()
        {
            if(client == null)
            {
                client = new Neo4jClient.GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
            
                client.Connect();
            }

            return client;
        }
    }
}