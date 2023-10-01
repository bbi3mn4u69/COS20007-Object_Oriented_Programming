using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customprogram
{
    public class StartState : IGameState
    {
        private Bitmap _startbackground;
        private string _startoption1;
        private string _startoption2;
       
        public StartState() 
        {
            _startbackground = new Bitmap("startbackground", "C:\\Swinburne SEM2\\OOP\\customprogram\\customprogram\\customprogram\\bin\\Debug\\net7.0\\images\\startbackground.png");
            _startoption1 = "New Game(Press S)";
            _startoption2 = "Instruction(Press I)";
        }
 
        public void HandleInput(Window win) 
        {
            if (SplashKit.KeyTyped(KeyCode.SKey))
            {
               GameStateManager.Instance().SetState(new SpaceWar(win));
            }
            if (SplashKit.KeyTyped(KeyCode.IKey))
            {
                GameStateManager.Instance().SetState(new InstructionState());
            }
        }
        
        public void Draw() 
        {
            SplashKit.DrawBitmap(_startbackground, 0, 0);
            SplashKit.DrawTextOnBitmap(_startbackground, _startoption1, Color.Red, "Normal Font", 300, 350, 360);
            SplashKit.DrawTextOnBitmap(_startbackground, _startoption2, Color.Red, "Normal Font", 300, 350, 400);
        }
        public void Update(Window win) { }
        
    }
}
