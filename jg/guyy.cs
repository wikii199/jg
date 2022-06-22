using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jg
{
    class guy
    {
        public string Name;
        public int Cash;

        public void info()
        {
            Console.WriteLine(Name + " ma " + Cash + " hajsu. ");

        }
        public int dajhajs(int cashAmount)
        {
            if (cashAmount <= 0)
            {
                Console.WriteLine(Name + " mowi" + cashAmount + "jest chujowa kwota");
                return 0;
            }
            if (cashAmount > Cash)
            {
                Console.WriteLine(Name + "mowi: " + " nie mam hajsu na tyle kurwo" + cashAmount);
                return 0;

            }
            Cash -= cashAmount;
            return cashAmount;
        }
        public void dawajhajshuju(int amout)
        {
            if (amout <= 0)
            {
                Console.WriteLine(Name + "mowi" + amout + " to za malo chuju");

            }
            else
            {
                Cash += amout;

            }
        }

    }

}
