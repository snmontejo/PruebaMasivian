using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test_roulette_sm.Models;

namespace Test_roulette_sm.Controllers
{
    public class RouletteController : ApiController
    {
        // GET: api/Roulette
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Roulette/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Roulette
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Roulette/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Roulette/5
        public void Delete(int id)
        {
        }

        [Route("Roulette/create")]
        public int create()
        {
            using (RouletteDataContext rou = new RouletteDataContext())
            {
                Roulette roul = new Roulette();
                roul.isOpen = false;
                rou.Roulette.InsertOnSubmit(roul);
                rou.SubmitChanges();

                return roul.id;
            }
        }


        [Route("Roulette/open")]
        public string open(int id)
        {
            using (RouletteDataContext rou = new RouletteDataContext())
            {
                string message = "";
                var roul = rou.Roulette.FirstOrDefault(t => t.id == id);
                if (roul == null)
                {
                    message = "Operacion Denegada";
                }
                else
                {
                    roul.isOpen = true;
                    roul.dateOpen = DateTime.Now;
                    rou.SubmitChanges();

                    message = "Operacion Exitosa";
                }

                return message;
            }
        }

        [Route("Roulette/bet")]
        public string bet(string user, int idroulette, int number, double money)
        {
            string message = "Apuesta denegada";
            Validations validate = new Validations();
            using (RouletteDataContext rou = new RouletteDataContext())
            {
                var roulette = rou.Roulette.FirstOrDefault(t => t.id == idroulette);
                if (roulette != null)
                {
                    if (roulette.isOpen == true)
                    {
                        bool isValidnumber = validate.validatebetnumber(number);
                        bool isValidmoney = validate.validatebetmoney(money);
                        if (isValidnumber == true & isValidmoney == true)
                        {
                            bets b = new bets();
                            b.id_roulette = idroulette;
                            b.user_ = user;
                            b.number = number;
                            b.money = money;
                            rou.bets.InsertOnSubmit(b);
                            rou.SubmitChanges();
                            message = "Apuesta Exitosa";
                        }
                    }
                }
            }

            return message;
        }

        [Route("Roulette/close")]
        public List<bets> close(int idroulette)
        {
            using (RouletteDataContext rou = new RouletteDataContext())
            {
                var roulette = rou.Roulette.FirstOrDefault(t => t.id == idroulette);
                if (roulette != null)
                {
                    if (roulette.isOpen == true)
                    {
                        roulette.isOpen = false;
                        roulette.dateClose = DateTime.Now;
                        rou.SubmitChanges();
                        Random rnd = new Random();
                        var valuewinning = rnd.Next(0, 36);
                        winningNumbers w = new winningNumbers();
                        w.id_roulette = idroulette;
                        w.number = valuewinning;
                        rou.winningNumbers.InsertOnSubmit(w);
                        rou.SubmitChanges();
                    }
                    var bets = rou.bets.Where(t => t.id_roulette == idroulette).ToList();

                    return bets;
                }
                else
                {

                    return null;
                }
            }
        }

        [Route("Roulette/list")]
        public List<Roulette> list()
        {
            using (RouletteDataContext rou = new RouletteDataContext())
            {
                var listRoulette = rou.Roulette.ToList();

                return listRoulette;
            }
        }
    }
}
