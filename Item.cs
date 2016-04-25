using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public abstract class Item
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
}
