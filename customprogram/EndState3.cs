using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace customprogram
{
    public class EndState3 : IGameState
    {
        // if enemy reached base
        private Bitmap _end_background;
        private string _endng1;
        private string _endng2;
        public EndState3() 
        {
            _endng1 = "THE BASE IS DESTROYED BECAUSE TOO MUCH ENEMY THERE";
            _endng2 = "BETTER LUCK NEXT TIME";
            _end_background = new Bitmap("end", "C:\\Swinburne SEM2\\OOP\\customprogram\\customprogram\\customprogram\\bin\\Debug\\net7.0\\images\\back.jpg");

        }
        public void HandleInput(Window win)
        {
            if (SplashKit.KeyDown(KeyCode.RKey))
            {
                GameStateManager.Instance().SetState(new SpaceWar(win));
            }
 
        }
        public void Draw()
        {
            SplashKit.DrawBitmap(_end_background, 0, 0);
            SplashKit.DrawTextOnBitmap(_end_background, _endng1, Color.Red, "Normal Font", 28, 250, 200);
            SplashKit.DrawTextOnBitmap(_end_background, _endng2, Color.Red, "Normal Font", 28, 250, 250);
        }
        public void Update(Window win) { }
    }
}
