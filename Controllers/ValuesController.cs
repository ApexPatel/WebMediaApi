using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMediaApi.Models;

namespace WebMediaApi.Controllers
{
    public class ValuesController : ApiController
    {
        static List<PersonModel> persons = new List<PersonModel>() 
        { 
            new PersonModel { Id = "1", Name = "ABC" }, 
            new PersonModel { Id = "2", Name = "XYZ" }, 
            new PersonModel { Id = "3", Name = "PQR" } 
        };

        [HttpGet]
        public List<PersonModel> GetAllPersons()
        {
            return persons;
        }       

        public PersonModel GetPerson(string id)
        {
            var vPerson = persons.FirstOrDefault((p) => p.Id == id);
            if (vPerson == null)
            {
                return null;
            }
            return vPerson;
        }       

        [HttpPost]
        // POST api/values
        public void Post([FromBody]string value)
        {            
            PersonModel objPersonModel = JsonConvert.DeserializeObject<PersonModel>(value);

            var i = from c in persons where c.Id.Equals(objPersonModel.Id) select c;          
      
            List<PersonModel> ls =  i.ToList();

            if (ls.Count > 0)            
                //update
                persons.Where(w => w.Id == objPersonModel.Id).ToList().ForEach(p => p.Name = objPersonModel.Name);
            else
                //insert
                persons.Add(objPersonModel);
        }
       
    }
}