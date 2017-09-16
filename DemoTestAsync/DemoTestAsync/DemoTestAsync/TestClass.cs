using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DemoTestAsync
{
    class TestClass
    {
        public void BlockMethod()
        {
            Thread.Sleep(10000);
            MessageBox.Show("Esto detiene todo");
        }

        public async void NonBlockableMethod()
        {
            await Task.Delay(10000);
            MessageBox.Show("No bloquea");
        }

        public Task NonBlockableMethodAsync()
        {
            return Task.Run(() => NonBlockableMethod());
        }
    }
}
