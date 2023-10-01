using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace customprogram
{
    public abstract class GodownObject : GameObject
    {
        
        private int _health;
        public GodownObject() : base() { }
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
        public abstract override void Draw();
        public abstract override void Move();
    }
}
