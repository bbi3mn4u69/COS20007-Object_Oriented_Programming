using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  
using SplashKitSDK;
using customprogram;

namespace customprogram
{
    public class Enemies : GodownObject
    {
        public Enemies(Window win) : base()
        {
            Name = "enemy";
            Radius = 20;
            X = SplashKit.Rnd(win.Width - 2 * Radius) + Radius;
            Y = 0;
            Image = new Bitmap("Enemies", "C:\\Swinburne SEM2\\OOP\\customprogram\\customprogram\\customprogram\\bin\\Debug\\net7.0\\images\\enemy.png");
            Health = 1;

        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(Image, X - Radius, Y - Radius);
        }
        public override void Move()
        {
            Y += 0.05;
         }

    }

}
