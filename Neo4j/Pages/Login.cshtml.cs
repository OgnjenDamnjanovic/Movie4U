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
    public class LoginModel : PageModel
    {
        [BindProperty]
        public int WhatToShow { get; set; }
        [BindProperty]
        public string email {get; set;}
        [BindProperty]
        public string sifra {get; set;}
        public string ErrorMessage {get; set;}
        public string ErrorMessage2 {get; set;}

        [BindProperty]
        public Korisnik noviKorisnik {get; set;}
        public string Message {get; set;}
        public void OnGet()
        {
            WhatToShow = 1;
        }

        public IActionResult OnPostLogin()
        {
            Neo4jClient.GraphClient client = ClientManager.GetSession();

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("email", this.email);
            queryDict.Add("sifra", this.sifra);

            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match(n:Korisnik) where n.email = {email} and n.sifra = {sifra} return n",
                                                           queryDict, CypherResultMode.Set);

            Korisnik k = ((IRawGraphClient)client).ExecuteGetCypherResults<Korisnik>(query).FirstOrDefault();

            if(k==null)
            {
                ErrorMessage = "Invalid email address or password!";
                WhatToShow = 1;
                return Page();
            }
            
            HttpContext.Session.SetString("email", email);
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostSignUp()
        {
            Neo4jClient.GraphClient client = ClientManager.GetSession();

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("email", noviKorisnik.email);

            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match(n:Korisnik) where n.email = {email} return n",
                                                           queryDict, CypherResultMode.Set);

            Korisnik k = ((IRawGraphClient)client).ExecuteGetCypherResults<Korisnik>(query).FirstOrDefault();

            if(k!=null)
            {
                ErrorMessage2="This email address is already used";
                WhatToShow = 0;
                return Page(); 
            }

            client.Cypher
                .Create("(n:Korisnik {newUser})")
                .WithParam("newUser", noviKorisnik)
                .ExecuteWithoutResults();

            HttpContext.Session.SetString("email", noviKorisnik.email);
            return RedirectToPage("/Index");
        }
    }
}
