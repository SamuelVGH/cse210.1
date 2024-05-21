using System;
using System.Globalization;

public class Fraction
{
    private int topOfFraction;
    private int bottomOfFraction;

    public Fraction()
    {
        topOfFraction= 1;
        bottomOfFraction= 1; 
    }
    public Fraction(int number)
    {
        topOfFraction= number;
        bottomOfFraction= 1; 
    }

    public Fraction (int top , int bottom)
    {
        topOfFraction= top;
        bottomOfFraction= bottom; 
    }

    public string GetFractionString()
    {
        string message= $"{topOfFraction}/{bottomOfFraction}";
        return message;
    }

    public double GetFractionInDecimal()
    {
        return (double)topOfFraction / (double)bottomOfFraction;
    }
}