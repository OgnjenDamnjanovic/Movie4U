using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Neo4j.Model;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace MyApp.Namespace
{
    public class NewsModel : PageModel
    {
        public List<Vest> vestiMostLiked { get; set; }
        public List<Vest> vestiByDate { get; set; }
        public string Message {get; set;}
         private IWebHostEnvironment  _environment;
        public NewsModel(IWebHostEnvironment env)
        {
            
            _environment=env;
        }
        public void OnGetAsync(int id)
        {
               Neo4jClient.GraphClient client = ClientManager.GetSession();

               string email = HttpContext.Session.GetString("email");
                if(!String.IsNullOrEmpty(email))
                    Message = "Welcome " + email;

            var query = new Neo4jClient.Cypher.CypherQuery($"match(vest:Vest) return vest order by vest.datumPostavljanja desc limit 5",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);

             vestiByDate = ((IRawGraphClient)client).ExecuteGetCypherResults<Vest>(query).ToList();

             foreach (Vest v in vestiByDate)
             {
                 v.opis=(v.opis.Length>170)?v.opis.Substring(0,165)+"...":v.opis;
                 
             }
             query=new Neo4jClient.Cypher.CypherQuery($"match(vest:Vest) return vest order by vest.brojLajkova desc limit 6",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);
            vestiMostLiked = ((IRawGraphClient)client).ExecuteGetCypherResults<Vest>(query).ToList();
            HttpContext.Session.Remove("pagingState");
            
             HttpContext.Session.SetInt32("pagingState",vestiByDate.Count);
           
        }
        public JsonResult  OnGetLoadMore()
        {       
            Neo4jClient.GraphClient client = ClientManager.GetSession();
            int? pagingState=HttpContext.Session.GetInt32("pagingState");
            if(pagingState==null) return new JsonResult("error");

             var query=new Neo4jClient.Cypher.CypherQuery($"match(vest:Vest) return vest order by vest.datumPostavljanja desc skip {pagingState} limit 5 ",
                                                           new Dictionary<string, object>(), CypherResultMode.Set);

               List<Vest> noveVesti = ((IRawGraphClient)client).ExecuteGetCypherResults<Vest>(query).ToList();

            HttpContext.Session.SetInt32("pagingState",noveVesti.Count+(int)pagingState);
            foreach(Vest vest in noveVesti)
            {
               vest.slika=LoadImage(vest.slika);
                vest.opis=(vest.opis.Length>170)?vest.opis.Substring(0,165)+"...":vest.opis;
               
            }

            return new JsonResult(noveVesti);
        }

           public string LoadImage(string imgURL)
        {
            var file = Path.Combine(_environment.ContentRootPath, "wwwroot/"+imgURL);
            try{
            byte[] imgRaw=System.IO.File.ReadAllBytes(file);
            string imgString=Convert.ToBase64String(imgRaw);
            imgString="data:image/png;base64,"+imgString;
            return imgString;
                }
            catch(FileNotFoundException ex)
            {
                return "";
            }
            
        }
     }
}
