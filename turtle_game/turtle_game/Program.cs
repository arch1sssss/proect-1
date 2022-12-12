using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;
namespace turtle_game
{
    class Program
    {
        static void Main(string[] args)
        {
            int hunger = 1;
            int win = 4;
            bool game_over = false;
            GraphicsWindow.Title = "turtle_game";
            Turtle.PenUp();
            GraphicsWindow.BrushColor = "Gainsboro";
            GraphicsWindow.FillRectangle(0, 0, GraphicsWindow.Width, GraphicsWindow.Height);
            GraphicsWindow.BrushColor = "Black";
            GraphicsWindow.FontSize = 28;
            GraphicsWindow.DrawText(0, 10, $"Сытость {hunger-1}");
            
            GraphicsWindow.BrushColor = "PaleGreen";
            
            var food = Shapes.AddRectangle(10, 10);
            int x = 200, y = 200;
            Shapes.Move(food, x, y);
            Random rand = new Random();
            Turtle.Speed = 3;
            while (true)
            {
                if (game_over)
                {
                    Shapes.HideShape(food);
                    Turtle.Hide();
                    GraphicsWindow.BrushColor = "Gainsboro";
                    GraphicsWindow.FillRectangle(0, 0, GraphicsWindow.Width, GraphicsWindow.Height);
                    GraphicsWindow.BrushColor = "Black";
                    GraphicsWindow.FontSize = 28;
                    GraphicsWindow.DrawText(0, 10, "Вы проиграли");
                }
                else
                {
                    GraphicWindow_KeyDown();
                    Turtle.Move(Turtle.Speed);
                    if (Turtle.X >= x && Turtle.X <= x + 10 && Turtle.Y >= y && Turtle.Y <= y + 10)
                    {
                        if(hunger==win){
                            Shapes.HideShape(food);
                            Turtle.Hide();
                            GraphicsWindow.BrushColor = "Gainsboro";
                            GraphicsWindow.FillRectangle(0, 0, GraphicsWindow.Width, GraphicsWindow.Height);
                            GraphicsWindow.BrushColor = "Black";
                            GraphicsWindow.FontSize = 28;
                            GraphicsWindow.DrawText(0, 10, "Вы выйграли");
                        }
                        else
                        {
hunger += 1;
                            x = rand.Next(0, GraphicsWindow.Width - 10);
                            y = rand.Next(0, GraphicsWindow.Height - 10);
                            Shapes.Move(food, x, y);
                            Turtle.Speed += 1;
                            GraphicsWindow.BrushColor = "Gainsboro";
                            GraphicsWindow.FillRectangle(0, 0, GraphicsWindow.Width, GraphicsWindow.Height);
                            GraphicsWindow.BrushColor = "Black";
                            GraphicsWindow.FontSize = 28;
                            GraphicsWindow.DrawText(0, 10, $"Сытость {hunger-1}");
                            GraphicsWindow.BrushColor = "PaleGreen";
                        }
                    }
                    if (Turtle.X > GraphicsWindow.Width || Turtle.X < 0 || Turtle.Y > GraphicsWindow.Height || Turtle.Y < 0)
                    {
                        game_over = true;
                    }
                }
            }
        }
        private static void GraphicWindow_KeyDown()
        {
            if (GraphicsWindow.LastKey == "Up")
                Turtle.Angle = 0;
            else if (GraphicsWindow.LastKey == "Right")
                Turtle.Angle = 90;
            else if (GraphicsWindow.LastKey == "Down")
                Turtle.Angle = 180;
            else if (GraphicsWindow.LastKey == "Left")
                Turtle.Angle = 270;
        }
    }
}
