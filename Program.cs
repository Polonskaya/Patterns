using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public enum BaseType
    {
        Canvas, Paper
    }

    class Frame
    {
        private string name;
        private double cost;
        private string description;
        public  Frame()
        {
            this.name = "Casual Frame";
            this.cost = 0.0;
            this.description = "Standart Free Frame";
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
        }
    }

    // Вспомогательрные классы для реализации фассада

    public static class DeliveryService
    {
        public static void Deliver()
        {
            Console.WriteLine("All items were shipped by DHL post.");
        }
    }

    public static class PaymentService
    {
        static double balance = 200.0;
        public static bool Pay(double cost)
        {
            if (balance - cost >= 0)
            {
                balance -= cost;
                return true;
            }
            else
                return false;

        }
    }

    class MainAgent
    {
        static void Main()
        {
            BuyCart buycart = new BuyCart();
            Shop artwork_shop = new ArtworksShop();
            Shop prints_shop = new PrintsShop();
            buycart.AddItem(artwork_shop.PreorderItem("Claude Monet - Self Portrait", BaseType.Canvas));
            buycart.AddItem(prints_shop.PreorderItem("Leonardo da Vinchi - Mona Lisa", BaseType.Paper));
            buycart.EasyOrder();
        }
    }
}
