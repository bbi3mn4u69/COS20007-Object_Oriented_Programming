using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customprogram
{
    public class CollisionDetector
    {
        public bool CheckCollision(GameObject obj1, GameObject obj2)
        {
            return SplashKit.BitmapCollision(obj1.Image, obj1.X - obj1.Radius, obj1.Y - obj1.Radius, obj2.Image, obj2.X - obj2.Radius, obj2.Y - obj2.Radius);
        }
    }
}
