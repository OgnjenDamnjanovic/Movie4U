using System;
using System.Collections.Generic;
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
    public class AddNewsModel : PageModel
    {
        private IWebHostEnvironment  _environment;
        public AddNewsModel(IWebHostEnvironment environment)
        {
            _environment=environment;
        }
        [BindProperty]
        public string pomenuti { get; set; }
        [BindProperty]
        public Vest novaVest { get; set; }
        public string Message {get; set;}
        public ActionResult OnGet()
        {
            string email=HttpContext.Session.GetString("email");
            if (email==null) return RedirectToPage("Login");

           Neo4jClient.GraphClient client = ClientManager.GetSession();
           var query = new Neo4jClient.Cypher.CypherQuery($"match (korisnik:Korisnik{{email:\"{email}\"}}) return korisnik",new Dictionary<string, object>() , CypherResultMode.Set);

            Korisnik korisnik=((IRawGraphClient)client).ExecuteGetCypherResults<Korisnik>(query).First();
            if(korisnik.tip==0) return  RedirectToPage("/Index");
            else
            {
                Message = "Admin";
                return Page();
            }
        }

        public ActionResult OnPost()
        {   

            string email = HttpContext.Session.GetString("email");
            if(!String.IsNullOrEmpty(email))
                Message = "Welcome " + email;

              Neo4jClient.GraphClient client = ClientManager.GetSession();
               string fileName=saveBase64AsImage(novaVest.slika);
              novaVest.slika="images/"+"Library"+"/"+fileName;
            
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("naslov", novaVest.naslov);
            queryDict.Add("opis", novaVest.opis);
            queryDict.Add("objavio", HttpContext.Session.GetString("email"));
            queryDict.Add("slika", novaVest.slika);
            queryDict.Add("datum",DateTime.Now.ToString("yyyy-MM-dd"));
            queryDict.Add("id",Guid.NewGuid());
            var query = new Neo4jClient.Cypher.CypherQuery("CREATE (TestVest:Vest {id:{id},opis:{opis},datumPostavljanja: {datum},"+
                                            "brojLajkova: '0',objavio: {objavio},naslov: {naslov},slika:{slika} });",queryDict, CypherResultMode.Set);

            ((IRawGraphClient)client).ExecuteCypher(query);   
            if(pomenuti!=null){
            string[] tagovi=pomenuti.Split(";");
            foreach(string tag in tagovi)
            {
                if(tag.CompareTo("")==0) break;
                query = new Neo4jClient.Cypher.CypherQuery($"MATCH (vest:Vest {{ id:\"{queryDict["id"]}\" }}),(film:Film {{ nazivFilma: \"{tag}\" }}) CREATE (vest)-[:ABOUT]->(film);",queryDict, CypherResultMode.Set);

                  ((IRawGraphClient)client).ExecuteCypher(query);   
                   query = new Neo4jClient.Cypher.CypherQuery($"MATCH (vest:Vest {{ id:\"{queryDict["id"]}\" }}),(serija:Serija {{ nazivSerije: \"{tag}\" }}) CREATE (vest)-[:ABOUT]->(serija);",queryDict, CypherResultMode.Set);

                  ((IRawGraphClient)client).ExecuteCypher(query);   
           
            }
            }
            return RedirectToPage("/News-Single",new { id = queryDict["id"] });
        }
          public string saveBase64AsImage(string img)
        {
            img=img.Substring(img.IndexOf(',') + 1);
            var imgConverted=Convert.FromBase64String(img);
            
            string imgName=System.Guid.NewGuid().ToString();

            var file = Path.Combine(_environment.ContentRootPath, "wwwroot/images/"+"Library"+"/"+imgName+".jpg");
        
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                fileStream.Write(imgConverted, 0, imgConverted.Length);
                    fileStream.Flush();
                
            }
            return imgName+".jpg";
        }
    }
}
