using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customprogram
{
    public class Player : GameObject
    {
      
        private int _health, _shield;
     
        public Player(Window win) : base()
        {
            Name = "Player";
            X = 350;
            Y = 350;
            Image = new Bitmap("player", "C:\\Swinburne SEM2\\OOP\\customprogram\\customprogram\\customprogram\\bin\\Debug\\net7.0\\images\\player.png");
            Radius = 20;
            Win = win;
            Health = 10;
            Shield = 10;
        }
        public int Shield 
        {
            get 
            { 
                return _shield; 
            }
            set 
            { 
                _shield = value; 
            }
        }
        public int Health 
        {
            get 
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }
    
        public void HealthBar() 
        {
            int length = 80;
            double healthlenght = (Health / 10F) * length;
            double shieldlenght = (Shield / 10F) * length;
            int xbarpadding = 25;
            int ybarpadding = 30;
            SplashKit.FillRectangle(Color.Black, X - xbarpadding, Y - ybarpadding, length, 5);
            SplashKit.FillRectangle(Color.Red, X - xbarpadding, Y - ybarpadding, healthlenght, 5);
            SplashKit.FillRectangle(Color.Gray, X - xbarpadding, Y - ybarpadding, shieldlenght, 5);

        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(Image, X - Radius, Y - Radius);
            HealthBar();
            
        }
      
        
        public override void Move()
        {
            if (X > Win.Width - Radius)
            {
                X = Win.Width - Radius;
            }
            if (Y > Win.Height - Radius)
            {
                Y = Win.Height - Radius;    
            }
            if (X < Radius)
            {
                X = Radius;
            }
           

        }

    }
}
