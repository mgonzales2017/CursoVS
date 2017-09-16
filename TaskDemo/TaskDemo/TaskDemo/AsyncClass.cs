using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo
{
    class AsyncClass
    {
        private  int Suma(int a, int b) {

            return a + b;
        }

        public  Task<int> SumaAsync(int a, int b)
        {
            return Task.Run(() => Suma(a, b));
        }
    }
}
