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
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public List<Film> watchlist {get; set;}
        [BindProperty]
        public Korisnik korisnik {get; set;}
        [BindProperty]
        public string password {get; set;}
        [BindProperty]
        public string newPassword {get; set;}
        public string Message {get; set;}
        [BindProperty]
        public string ErrorMessage {get; set;}
        public int WhatToShow {get; set;}

        public void OnGet()
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

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("email", email);

            var query = new Neo4jClient.Cypher.CypherQuery("match (k:Korisnik) where k.email = {email} return k",
                                                           queryDict, CypherResultMode.Set);

            korisnik = ((IRawGraphClient)client).ExecuteGetCypherResults<Korisnik>(query).FirstOrDefault();

            var query1 = new Neo4jClient.Cypher.CypherQuery("match (k)-[r:WATCHLIST]->(f) where k.email = {email} return f",
                                                           queryDict, CypherResultMode.Set);

            watchlist = ((IRawGraphClient)client).ExecuteGetCypherResults<Film>(query1).ToList();

        }

        public IActionResult OnPostSacuvaj()
        {
            /*if(password!=newPassword)
            {
                if(korisnik.sifra != password)
                {
                    ErrorMessage = "The old password you have entered is incorrect";
                    return RedirectToPage("/Profile", new {Message=ErrorMessage});
                }
            }*/

            Neo4jClient.GraphClient client = ClientManager.GetSession();

            string oldemail = HttpContext.Session.GetString("email");
            //string oldemail = "milos.mitic@gmail.com";

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("oldemail", oldemail);
            queryDict.Add("email", korisnik.email);
            queryDict.Add("ime", korisnik.ime);
            queryDict.Add("prezime", korisnik.prezime);
            queryDict.Add("sifra", newPassword);

            var query = new Neo4jClient.Cypher.CypherQuery("match (k:Korisnik) where k.email = {oldemail} set k+={email:{email}, ime:{ime}, prezime:{prezime}, sifra:{sifra}} return k",
                                                           queryDict, CypherResultMode.Set);

            Korisnik k = ((IRawGraphClient)client).ExecuteGetCypherResults<Korisnik>(query).FirstOrDefault();
            HttpContext.Session.SetString("email", k.email);

            return RedirectToPage();
        }

        public IActionResult OnPostRemove(string movie)
        {
            Neo4jClient.GraphClient client = ClientManager.GetSession();

            string email = HttpContext.Session.GetString("email");
            //string email = "milos.mitic@gmail.com";

            client.Cypher.Match("(k:Korisnik)-[r:WATCHLIST]->(f:Film)")
                .Where((Korisnik k) => k.email == email)
                .AndWhere((Film f) => f.nazivFilma == movie)
                .DetachDelete("r")
                .ExecuteWithoutResults();

            return RedirectToPage();
        }
    }
}
