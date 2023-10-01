using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customprogram
{
    public class BigBoss : GodownObject
    {
        public BigBoss(Window win) : base()
        {
            Name = "bigboss";
            X = SplashKit.Rnd(win.Width - 2 * Radius) + Radius;
            Y = 0;
            Image = new Bitmap("bigboss", "C:\\Swinburne SEM2\\OOP\\customprogram\\customprogram\\customprogram\\bin\\Debug\\net7.0\\images\\boss.png ");
            Radius = 69;
            Health = 3;
        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(Image, X - Radius, Y - Radius);
        }
        public override void Move()
        {
            Y += 0.25;
        }
    }
}
