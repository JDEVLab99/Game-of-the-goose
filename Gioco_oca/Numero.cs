using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gioco_oca
{
    class Numero:Casella
    {
        protected int num;

        public Numero(int num, string msg, string type):base(msg,type)
        {
            set_num(num);
        }

        public void set_num(int n)
        {
            if (n > 0)
                num = n;
        }

        public int get_num()
        {
            return num;
        }
    }
}
