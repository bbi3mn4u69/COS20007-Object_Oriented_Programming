using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customprogram;

namespace customprogram
{
    public class Heart : GodownObject
    {
        public Heart(Window win) : base()
        {
            Name = "heart";
            Radius = 24;
            X = SplashKit.Rnd(win.Width - 2 * Radius) + Radius;
            Image = new Bitmap("heart", "C:\\Swinburne SEM2\\OOP\\customprogram\\customprogram\\customprogram\\bin\\Debug\\net7.0\\images\\heart.png");
            Y = 0;
          
        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(Image, X - Radius, Y - Radius);
        }
        public override void Move() 
        {
            Y += 2;
        }
    }
}
