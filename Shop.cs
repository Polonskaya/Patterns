using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    // Абстрактный класс фабрики

    public abstract class Shop
    {

        public Item PreorderItem(string title, BaseType type)
        {
            Item item = makeItem(title, type);
            return item;
        }
        // Фабричный метод
        protected abstract Item makeItem(string title, BaseType type);
    }
    #region ConcreteFactories

    public class ArtworksShop : Shop
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

    public class PrintsShop : Shop
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
}
