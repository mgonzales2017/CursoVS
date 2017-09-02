using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoClases
{
    class Program
    {
        static void Main(string[] args)
        {
            Coffee c = new Coffee(10, 30, "tostado");

            while (true)
            {
                c.Drink();
                Console.WriteLine($"Cafe Restante:{c.Quantity}");
                Console.ReadKey();
            }
        }
    }

    abstract class Beverage
    {
        public Beverage()
        {
            Temp = 100;
            Quantity = 100;
        }
        public Beverage(float temp, int quantity)
        {
            Temp = temp;
            Quantity = quantity;
        }

        public float Temp { get; set; }

        public List<string> Components { get; set; }
        
        public virtual int Quantity { get; set; }

        public virtual void Drink()
        {
            Quantity--;
        }
    }

    class Coffee : Beverage
    {
        public Coffee() : base()
        {
            Quantity = 10;
        }

        public Coffee(int quantity, float temp, string roastType)
            : base(temp, quantity)
        {
            RoastType = roastType;
            quantity += quantity;
        }

        public override int Quantity
        {
            get;
            set;
        }

        public virtual string CoffeType { get; set; }
        string RoastType { get; set; }

        public override void Drink()
        {
            Quantity -= 10;
            base.Drink();
            Quantity += 10;
        }
    }

    class Expresso : Coffee
    {
        public int Milk { get; set; }
        public sealed override string CoffeType
        {
            get => base.CoffeType;
            set => base.CoffeType = value;
        }
    }

    class Moka : Coffee
    {
        int chocolate;
    }

    class Tea : Beverage
    {

    }

    class Lipton : Tea
    {

    }

    class Mint : Tea
    {

    }
}
