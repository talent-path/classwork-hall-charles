using System;
using System.Collections.Generic;
using System.Linq;

namespace WidgetCrud
{
    public class InMemWidgetDao
    {
        List<Widget> _allWidgets = new List<Widget>
        {
            new Widget { Id = 1, Name="Lumber", Category="Building", Price=12.00m},
            new Widget { Id = 2, Name="Bricks", Category="Building", Price=20.00m},
            new Widget { Id = 3, Name="Shoes", Category="Clothing", Price=4.00m},
            new Widget { Id = 4, Name="Hats", Category="Clothing", Price=2.00m},
            new Widget { Id = 5, Name="Pants", Category="Clothing", Price=1.00m},
        };

        int id = 5;

        public InMemWidgetDao()
        {
        }

        public int AddWidget(Widget toAdd)
        {

            id++;
            toAdd.Id = id;

            Console.WriteLine("Enter a name for the widget.");
            toAdd.Name = Console.ReadLine();

            Console.WriteLine("Enter a category for the widget.");
            toAdd.Category = Console.ReadLine();

            Console.WriteLine("Enter a price for the widget.");
            toAdd.Price = decimal.Parse(Console.ReadLine());

            _allWidgets.Add(toAdd);

            return id;
        }

        public void RemoveWidgetById(int id)
        {
            _allWidgets.RemoveAll(x => x.Id == id);
        }

        public void UpdateWidget(Widget updated)
        {
            Console.WriteLine("Enter the widget Id to update.");
            updated.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a name for the widget.");
            updated.Name = Console.ReadLine();

            Console.WriteLine("Enter a category for the widget.");
            updated.Category = Console.ReadLine();

            Console.WriteLine("Enter a price for the widget.");
            updated.Price = decimal.Parse(Console.ReadLine());

            foreach (Widget widget in _allWidgets)
            {
                if(widget.Id == updated.Id)
                {
                    widget.Name = updated.Name;
                    widget.Category = updated.Category;
                    widget.Price = updated.Price;
                }
            }
        }

        public Widget GetWidgetById(int id)
        {
            var toReturn = _allWidgets.Where(x => x.Id == id).SingleOrDefault();

            return toReturn;
        }

        public IEnumerable<Widget> GetWidgetsByCategory(string category)
        {
            var toReturn = _allWidgets
                .Where(x => x.Category == category);

            return toReturn;
        }

        public IEnumerable<Widget> GetAllWidgetsForPage(int pageSize, int pageNumber)
        {
            //assuming each page is pageSize wide, return the pageNumberth page of widgets
            //order by name?
            var allWidgetsOrdered = _allWidgets.OrderBy(x => x.Name);

            IEnumerable<Widget> toReturn = allWidgetsOrdered.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return toReturn;
        }
    }
}
