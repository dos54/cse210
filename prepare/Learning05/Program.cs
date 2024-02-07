using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new();

        Square square = new("Square red", 12);
        Rectangle rectangle = new("Rectangle blue", 5, 12);
        Cirlce cirlce = new("Circle orange", 3);

        shapes.AddRange(new List<Shape> {square, rectangle, cirlce});

        foreach (Shape shape in shapes) 
        {
            string color = shape.Color;
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}");
        }    
    }


}