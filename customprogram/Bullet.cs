using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customprogram
{
    public abstract class Bullet : GameObject
    {
        public Bullet() { }
        public abstract bool OnScreen();
        public override abstract void Draw();
        public override abstract void Move();
    }
}
