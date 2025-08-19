using System;
using System.Collections.Generic;
using ConsoleTables;

namespace A2NickDamor
{
    internal class Program
    {
        static List<Shape> shapes = new List<Shape>();

        static void Main(string[] args)
        {
  
            shapes.Add(new Circle(3.5, 0.8));
            shapes.Add(new Triangle(3, 4, 5, 0.7));
            shapes.Add(new Rectangle(4, 6, 0.9));
            shapes.Add(new Square(5, 0.5));

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Nick Damor - Student ID: 991781470");
                Console.WriteLine(" Shape Manager Menu ");
                Console.WriteLine("1. Add Shape");
                Console.WriteLine("2. Edit Shape");
                Console.WriteLine("3. Delete Shape");
                Console.WriteLine("4. View Shapes");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": ShowAddMenu(); break;
                    case "2": ShowEditMenu(); break;
                    case "3": ShowDeleteMenu(); break;
                    case "4": ViewShapes(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("Invalid input. Press Enter...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void ShowAddMenu()
        {
            Console.Clear();
            Console.WriteLine("Add Shape:");
            Console.WriteLine("1. Circle");
            Console.WriteLine("2. Triangle");
            Console.WriteLine("3. Rectangle");
            Console.WriteLine("4. Square");
            Console.WriteLine("5. Back");
            Console.Write("Select a shape to add: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1": AddCircle(); break;
                case "2": AddTriangle(); break;
                case "3": AddRectangle(); break;
                case "4": AddSquare(); break;
            }

            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }

        static double GetDoubleInput(string prompt)
        {
            double val;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out val))
            {
                Console.Write("Invalid input. Try again: ");
            }
            return val;
        }

        static double GetOpacityInput()
        {
            double opacity;
            do
            {
                opacity = GetDoubleInput("Enter opacity (0 to 1): ");
                if (opacity < 0 || opacity > 1)
                {
                    Console.WriteLine("Opacity must be between 0 and 1.");
                }
            }
            while (opacity < 0 || opacity > 1);
            return opacity;
        }

        static void AddCircle()
        {
            double radius = GetDoubleInput("Enter radius: ");
            double opacity = GetOpacityInput();
            shapes.Add(new Circle(radius, opacity));
            Console.WriteLine("Circle added!");
        }

        static void AddTriangle()
        {
            double a = GetDoubleInput("Enter side A: ");
            double b = GetDoubleInput("Enter side B: ");
            double c = GetDoubleInput("Enter side C: ");
            double opacity = GetOpacityInput();
            shapes.Add(new Triangle(a, b, c, opacity));
            Console.WriteLine("Triangle added!");
        }

        static void AddRectangle()
        {
            double length = GetDoubleInput("Enter length: ");
            double width = GetDoubleInput("Enter width: ");
            double opacity = GetOpacityInput();
            shapes.Add(new Rectangle(length, width, opacity));
            Console.WriteLine("Rectangle added!");
        }

        static void AddSquare()
        {
            double side = GetDoubleInput("Enter side: ");
            double opacity = GetOpacityInput();
            shapes.Add(new Square(side, opacity));
            Console.WriteLine("Square added!");
        }

        static void ViewShapes()
        {
            Console.Clear();
            Console.WriteLine(" All Shapes ");

            if (shapes.Count == 0)
            {
                Console.WriteLine("No shapes to display.");
            }
            else
            {
                var table = new ConsoleTable("ID", "Type", "Opacity (%)", "Area", "Perimeter");

                foreach (var shape in shapes)
                {
                    table.AddRow(
                        shape.ShapeId,
                        shape.ShapeType,
                        (shape.Opacity * 100).ToString("F2"),
                        shape.Area().ToString("F2"),
                        shape.Perimeter().ToString("F2")
                    );
                }

                table.Write();
            }

            Console.WriteLine("\nPress Enter to return to the main menu...");
            Console.ReadLine();
        }

        static void ShowEditMenu()
        {
            Console.Clear();
            Console.WriteLine("Edit Shape:");
            Console.WriteLine("1. Circle");
            Console.WriteLine("2. Triangle");
            Console.WriteLine("3. Rectangle");
            Console.WriteLine("4. Square");
            Console.WriteLine("5. Back");
            Console.Write("Select a shape to edit: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1": EditShape("Circle"); break;
                case "2": EditShape("Triangle"); break;
                case "3": EditShape("Rectangle"); break;
                case "4": EditShape("Square"); break;
            }

            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }

        static void ShowDeleteMenu()
        {
            Console.Clear();
            Console.WriteLine("Delete Shape:");
            Console.WriteLine("1. Circle");
            Console.WriteLine("2. Triangle");
            Console.WriteLine("3. Rectangle");
            Console.WriteLine("4. Square");
            Console.WriteLine("5. Back");
            Console.Write("Select a shape to delete: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1": DeleteShape("Circle"); break;
                case "2": DeleteShape("Triangle"); break;
                case "3": DeleteShape("Rectangle"); break;
                case "4": DeleteShape("Square"); break;
            }

            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }

        static void EditShape(string shapeType)
        {
            bool found = false;
            foreach (var shape in shapes)
            {
                if (shape.ShapeType.ToString() == shapeType)
                {
                    Console.WriteLine("ID: " + shape.ShapeId + ", Opacity: " + shape.Opacity);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No shapes of this type to edit.");
                return;
            }

            int id = (int)GetDoubleInput("Enter ID to edit: ");

            foreach (var shape in shapes)
            {
                if (shape.ShapeId == id && shape.ShapeType.ToString() == shapeType)
                {
                    if (shapeType == "Circle")
                    {
                        Circle c = (Circle)shape;
                        c.Radius = GetDoubleInput("Enter new radius: ");
                        c.Opacity = GetOpacityInput();
                    }
                    else if (shapeType == "Triangle")
                    {
                        Triangle t = (Triangle)shape;
                        t.A = GetDoubleInput("Enter new side A: ");
                        t.B = GetDoubleInput("Enter new side B: ");
                        t.C = GetDoubleInput("Enter new side C: ");
                        t.Opacity = GetOpacityInput();
                    }
                    else if (shapeType == "Rectangle")
                    {
                        Rectangle r = (Rectangle)shape;
                        r.Length = GetDoubleInput("Enter new length: ");
                        r.Width = GetDoubleInput("Enter new width: ");
                        r.Opacity = GetOpacityInput();
                    }
                    else if (shapeType == "Square")
                    {
                        Square s = (Square)shape;
                        double side = GetDoubleInput("Enter new side: ");
                        s.Length = side;
                        s.Width = side;
                        s.Opacity = GetOpacityInput();
                    }

                    Console.WriteLine("Shape updated successfully.");
                    return;
                }
            }

            Console.WriteLine("Shape not found.");
        }

        static void DeleteShape(string shapeType)
        {
            bool found = false;
            foreach (var shape in shapes)
            {
                if (shape.ShapeType.ToString() == shapeType)
                {
                    Console.WriteLine("ID: " + shape.ShapeId + ", Opacity: " + shape.Opacity);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No shapes of this type to delete.");
                return;
            }

            int id = (int)GetDoubleInput("Enter ID to delete: ");

            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i].ShapeId == id && shapes[i].ShapeType.ToString() == shapeType)
                {
                    shapes.RemoveAt(i);
                    Console.WriteLine("Shape deleted successfully.");
                    return;
                }
            }

            Console.WriteLine("Shape not found.");
        }
    }
}
