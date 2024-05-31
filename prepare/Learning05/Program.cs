using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var square = new Square("Red", 4);
        var rectangle = new Rectangle("Blue", 5, 3);
        var circle = new Circle("Green", 2);

        var shapes = new List<Shape> { square, rectangle, circle };

        foreach (var shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}