using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    enum BaseType
    {
        Canvas, Paper
    }

    // Абстрактный класс фабрики

    abstract class Shop
    {

        public Item PreorderItem(string title, BaseType type)
        {
            Item item = makeItem(title, type);
            return item;
        }
        // Фабричный метод
        protected abstract Item makeItem(string title, BaseType type);
    }

    // Абстрактный базовый класс Продукт

    abstract class Item
    {
        protected string name;
        protected string description;
        protected double cost;

        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public double Cost
        {
            get
            {
                return this.cost;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public virtual string Make()
        {
            return "Item is ready...";
        }
        private string AddFrame()
        {
            Frame frame = new Frame();
            return "\nAdding frame :\n" + frame.Name + ", " + frame.Description;
        }

        // Шаблонный метод
        public string MakeProcess()
        {
            string process = Make();
            process += AddFrame();
            return process;
        }
    }

    #region ConcreteFactories

    class ArtworksShop : Shop
    {
        protected override Item makeItem(string title, BaseType type)
        {
            if (type == BaseType.Canvas)
            {
                return new ArtworksOnCanvas(title);
            }
            else if (type == BaseType.Paper)
            {
                return new ArtworksOnPaper(title);
            }
            else
                return null;
        }
    }

    class PrintsShop : Shop
    {
        protected override Item makeItem(string title, BaseType type)
        {
            if (type == BaseType.Canvas)
            {
                return new PrintsOnCanvas(title);
            }
            else if (type == BaseType.Paper)
            {
                return new PrintsOnPaper(title);
            }
            else
                return null;
        }
    }

    #endregion

    #region ConcreteItems
    class ArtworksOnPaper : Item
    {
        public ArtworksOnPaper(string title)
        {
            name = title;
            description = "Oil on paper";
            cost = 99.9;
        }
        public override string Make()
        {
            return "Artist paint the " + name + " with oil on paper";
        }
    }

    class ArtworksOnCanvas : Item
    {
        public ArtworksOnCanvas(string title)
        {
            name = title;
            description = "Oil on canvas";
            cost = 150.0;
        }
        public override string Make()
        {
            return "Artist paint the " + name + " with oil on canvas";
        }
    }

    class PrintsOnPaper : Item
    {
        public PrintsOnPaper(string title)
        {
            name = title;
            description = "Giclee-Print on paper";
            cost = 9.99;
        }
        public override string Make()
        {
            return name + "had printed on paper";
        }
    }

    class PrintsOnCanvas : Item
    {
        public PrintsOnCanvas(string title)
        {
            name = title;
            description = "Giclee-Print on canvas";
            cost = 50.0;
        }
        public override string Make()
        {
            return name + "had printed on canvas";
        }
    }
    #endregion

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

    static class DeliveryService
    {
        public static void Deliver()
        {
            Console.WriteLine("All items were shipped by DHL post.");
        }
    }

    static class PaymentService
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

    class BuyCart
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
