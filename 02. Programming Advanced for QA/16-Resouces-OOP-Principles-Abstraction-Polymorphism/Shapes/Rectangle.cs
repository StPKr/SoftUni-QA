using System;
using Shapes;

internal class Rectangle : IDrawable
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void Draw()
    {
        DrawLine(width, '*', '*');
        for (int i = 1; i < this.height - 1; ++i)
        {
            DrawLine(width, ' ', '*');
        }
        DrawLine(width, '*', '*');
    }
    private void DrawLine(int width, char mid, char end)
    {
        Console.Write(end);
        for (int i = 1; i < width - 1; ++i)
        {
            Console.Write(mid);
        }
        Console.WriteLine(end);
    }
}