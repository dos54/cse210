using System;

public class Cirlce : Shape 
{
    private double _radius;

    public Cirlce(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}