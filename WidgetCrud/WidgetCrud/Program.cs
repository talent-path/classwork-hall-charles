using System;
using System.Collections.Generic;

namespace WidgetCrud
{
    class Program
    {
        static InMemWidgetDao dao = new InMemWidgetDao();


        static void Main(string[] args)
        {

            bool done = false;

            while (!done)
            {
                int choice = PrintMainMenu();
                int id;
                string category;
                int pageSize;
                int pageNum;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine();
                        AddWidget();
                        break;
                    case 2:
                        Console.WriteLine("Enter id to remove.");
                        id = int.Parse(Console.ReadLine());
                        RemoveWidgetById(id);
                        break;
                    case 3:
                        UpdateWidget();
                        break;
                    case 4:
                        Console.WriteLine("Enter id to get.");
                        id = int.Parse(Console.ReadLine());
                        GetWidgetById(id);
                        break;
                    case 5:
                        Console.WriteLine("Enter category to get.");
                        category = Console.ReadLine();
                        GetWidgetsByCat(category);
                        break;
                    case 6:
                        Console.WriteLine("Enter page size.");
                        pageSize = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter page number.");
                        pageNum = int.Parse(Console.ReadLine());
                        GetWidgetsByPage(pageSize, pageNum);
                        break;
                    case 7:
                        done = true;
                        break;

                }
            }
        }

        private static void RemoveWidgetById(int id)
        {
            dao.RemoveWidgetById(id);
            Console.WriteLine("Widget with id " + id + " removed.");
            Console.WriteLine();
        }

        private static void AddWidget()
        {
            Widget widget = new Widget();
            Console.WriteLine("Widget created with id " + dao.AddWidget(widget) + ".");
            Console.WriteLine();
        }

        private static void UpdateWidget()
        {
            Widget widget = new Widget();
            dao.UpdateWidget(widget);
            Console.WriteLine("Widget updated.");
            Console.WriteLine();
        }

        private static void GetWidgetById(int id)
        {
            Widget widget = dao.GetWidgetById(id);
            Console.WriteLine("Name: " + widget.Name + " Category: " + widget.Category + " Price: " + widget.Price);
            Console.WriteLine();
        }

        private static void GetWidgetsByCat(string category)
        {
            IEnumerable<Widget> widgets = dao.GetWidgetsByCategory(category);

            foreach(Widget widget in widgets)
            {
                Console.WriteLine("Name: " + widget.Name + " Category: " + widget.Category + " Price: " + widget.Price);
            }
            Console.WriteLine();
        }

        private static void GetWidgetsByPage(int pageSize, int pageNum)
        {
            IEnumerable<Widget> widgets = dao.GetAllWidgetsForPage(pageSize, pageNum);

            foreach (Widget widget in widgets)
            {
                Console.WriteLine("Name: " + widget.Name + " Category: " + widget.Category + " Price: " + widget.Price);
            }
            //Apple, Brick, Hat, Lumber, Pants, Shoes
            Console.WriteLine("Results for page number " + pageNum + " with pages of size " + pageSize);
            Console.WriteLine();

        }

        private static int PrintMainMenu()
        {
            Console.WriteLine("Enter number to perform operation.");
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Remove");
            Console.WriteLine("3 - Update");
            Console.WriteLine("4 - Get By Id");
            Console.WriteLine("5 - Get By Category");
            Console.WriteLine("6 - Get By Page");
            Console.WriteLine("7 - Exit");
            Console.WriteLine("-------------------");

            return int.Parse(Console.ReadLine());
        }
    }
}