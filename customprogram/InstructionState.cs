using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace customprogram
{
    public class InstructionState : IGameState
    {
        private Bitmap _instruction;
        public InstructionState() 
        {
            _instruction = new Bitmap("instruction", "C:\\Swinburne SEM2\\OOP\\customprogram\\customprogram\\customprogram\\bin\\Debug\\net7.0\\images\\instruction.png"); 
        }
        public void HandleInput(Window win)
        {
            if (SplashKit.KeyTyped(KeyCode.PKey))
            {
                GameStateManager.Instance().SetState(new StartState());
            }
        }

        public void Draw()
        {
            SplashKit.DrawBitmap(_instruction, 0, 0);
            
        }
        public void Update(Window win) { }
    }
}
