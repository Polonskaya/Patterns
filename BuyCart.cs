using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class BuyCart
    {
        private List<Item> items = new List<Item>();
        // В этом методе реализован фассад
        public void EasyOrder()
        {
            double total_cost = 0.0;
            Console.WriteLine("You're buying : ");

            foreach (Item item in items)
            {
                Console.WriteLine("Name : " + item.Name);
                Console.WriteLine("Description : " + item.Description);
                Console.WriteLine("Cost : " + item.Cost);
                total_cost += item.Cost;
            }

            Console.WriteLine("Total : " + total_cost);

            Console.WriteLine("Receiving payments...");

            if (PaymentService.Pay(total_cost))
            {
                Console.WriteLine("Ok!\nMaking items...");

                foreach (Item item in items)
                {
                    Console.WriteLine(item.MakeProcess());
                }

                DeliveryService.Deliver();
            }
            else
            {
                Console.WriteLine("oops. Not enough money...");
            }
        }
        public void AddItem(Item item)
        {
            this.items.Add(item);
        }
    }

}
