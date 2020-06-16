using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetDemo.Models;

namespace NetDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        [Route("users")]
        public List<UserData> Users()
        {
            DemoBaseContext context = new DemoBaseContext();
            List<UserData> temps = context.UserData.OrderByDescending(x => x.UserName).Take(10).ToList();

            return temps;
        }

        [HttpPost]
        [Route("login")]
        //[Consumes("application/json")]
        public int Login(UserData user)
        {
            
            string noThese = ");";
            string name = user.UserName;
            string word = user.Password;
            //string email = user.Email;
            for (int i = 0; i < noThese.Length; i++)
            {
                name = name.Replace(noThese[i].ToString(), string.Empty);
                word = word.Replace(noThese[i].ToString(), string.Empty);
                //email = email.Replace(noThese[i].ToString(), string.Empty);
            }
           /* */
            DemoBaseContext context = new DemoBaseContext();
            /*
            List<UserData> datasa = context.UserData
                .Where(x => x.UserName == name)
                .Where(x => x.Password == word)
                .ToList();
            List<UserData> datas = context.UserData.ToList();
            int amount = datas.Where(UserData => UserData.UserName == name)
                .Where(UserData => UserData.Password == word).Count();
                .Where(x => x.Email == email)
             */
            
             
            int amount = context.UserData
                .Where(x => x.UserName == name)
                .Where(x => x.Password == word)
                .ToList()
                .Count();
            return amount;
            /*
            if (amount == 1) return true;
            else return false;
            */
        }

        [HttpPost]
        [Route("signin")]
        public bool Signin(UserData user)
        {
            DemoBaseContext context = new DemoBaseContext();
            bool illegal = false;
            string noThese = ");";
            string name = user.UserName, word = user.Password, emai = user.Email;
            int count = context.UserData.ToList().Count;
            for (int i = 0; i < noThese.Length; i++)
            {

                if (name.Contains(noThese[i]) || word.Contains(noThese[i])
                    || emai.Contains(noThese[i])) illegal = true;
                name = name.Replace(noThese[i].ToString(), string.Empty);
            }



            if (illegal == false && UserExist(name, context) == false)
            {
                context.UserData.Add(user);
            }

            if (illegal || count <= context.UserData.Count()) return false;
            else return true;
        }

        private bool UserExist(string userName, DemoBaseContext context)
        {
            bool exists = false;

            int amount = context.UserData.
                Where(UserData => UserData.UserName == userName).Count();

            if (amount != 0) exists = true;

            return exists;
        }

        [HttpGet]
        [Route("temp")]
        public List<Temperature> temps()
        {
            DemoBaseContext context = new DemoBaseContext();
            List<Temperature> temps = context.Temperature.OrderByDescending(x => x.TimeValue).Take(10).ToList();

            return temps;
        }

        [HttpPost]
        [Route("temp")]
        public int SaveTemps(Temperature data)
        {
            DemoBaseContext context = new DemoBaseContext();
            context.Temperature.Add(data);
            context.SaveChanges();


            int count = context.Temperature.ToList().Count;
            return count;
        }

        [HttpGet]
        [Route("ships")]
        public List<BattleShip> Ships()
        {
            DemoBaseContext context = new DemoBaseContext();
            List<BattleShip> temps = context.BattleShip.OrderByDescending(x => x.TimeValue).Take(10).ToList();

            return temps;
        }

        [HttpPost]
        [Route("ships")]
        public int SaveShips(BattleShip data)
        {
            DemoBaseContext context = new DemoBaseContext();
            List<BattleShip> battleShip = context.BattleShip.Where(x => x.UserId == data.UserId).ToList();
            if (battleShip.Count() == 1)
            {
                battleShip[0].Score = data.Score;
                //context.SaveChanges();

            }
            else
            {
                context.BattleShip.Add(data);
            }

            context.SaveChanges();


            int count = context.BattleShip.ToList().Count;
            return count;
        }
    }
}
