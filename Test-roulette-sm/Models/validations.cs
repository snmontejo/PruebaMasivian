using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_roulette_sm.Models
{
    public class Validations
    {
        public bool validatebetnumber(int number)
            {
            if (number >= 0 & number <= 38)
            {
                return true;
            }else
            {
                return false;
            }
            }

        public bool validatebetmoney(double money)
        {
            if(money>=1 & money <= 10000)
            {
                return true;
            }else
            {
                return false;
            }
        }


    }
}