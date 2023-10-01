using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customprogram
{
    public interface IGameState
    { 
        public void HandleInput(Window win);
        public void Draw();
        public void Update(Window win); 
    }
}
