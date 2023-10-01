using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace customprogram
{
    public class BackGround : GameObject
    {
        public BackGround() : base()
        {
            Name = "background";
            Image = new Bitmap("background", "C:\\Swinburne SEM2\\OOP\\customprogram\\customprogram\\customprogram\\bin\\Debug\\net7.0\\images\\background.jpg");
            X = 0;
            Y = 0;
        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(Image, X, Y);
        }
        public override void Move() { }
    }
}
