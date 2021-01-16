using System.Collections.Generic;
namespace Neo4j.Model
{
    public class User
    {
        public string login { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public List<User> friends { get; set; }
    
        
        public void befriend(User user)
        {
            
        }
    }
}