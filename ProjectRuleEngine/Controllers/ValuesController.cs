using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using ProjectRuleEngine.Models;

namespace ProjectRuleEngine.Controllers
{
    public class ValuesController : ApiController
    {
        private MyDbContext _context;
        public ValuesController()
        {
            _context = new MyDbContext();
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public List<UpdatedData> Post([FromBody]List<ReceivedData> DataStream)
        {

            var violatedData = new List<UpdatedData>();

            foreach (var data in DataStream)
            {
                //To process the incoming Stream
                UpdatedData datareceived = new UpdatedData(data);
                datareceived.Process(data);

                //To save the incoming Stream in a Database
                _context.UpdatedDatas.Add(datareceived);
                _context.SaveChanges();

                //If signal has violated a rule then show that signal to User
                if (datareceived.CorrectSignal == false)
                {
                    violatedData.Add(datareceived);
                }
            }
            return violatedData;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}