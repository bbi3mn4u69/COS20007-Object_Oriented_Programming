using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customprogram
{
    public class PlayerBullet : Bullet
    {
        public PlayerBullet(Window win, double x, double y) : base()
        {
            Name = "playerbullet";
            X = x;
            Y = y;
            Image = new Bitmap("playerbullet", "C:\\Swinburne SEM2\\OOP\\customprogram\\customprogram\\customprogram\\bin\\Debug\\net7.0\\images\\bullet.png");
            Radius = 12;
            Win = win;
        }
        // check if bullet onscreen or not
        
        public override bool OnScreen() 
        {
            int right, left, top, bottom;

            right = Win.Width + Radius;
            bottom = Win.Height + Radius;
            left = - Radius;
            top = - Radius;

            if (X > left && X < right && Y > top && Y < bottom) 
            {
                return true;
            }
            return false;
        }

        public override void Draw()
        {
            SplashKit.DrawBitmap(Image, X - Radius, Y - Radius);

        }
        public override void Move()
        {
            Y -= 1;
        }
    }

}
