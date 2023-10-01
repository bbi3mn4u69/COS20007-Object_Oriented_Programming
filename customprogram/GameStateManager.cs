using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customprogram
{
    public class GameStateManager
    { 
        private IGameState _currentState;
        private static GameStateManager _instance;
        public static GameStateManager Instance()
        {
            if (_instance == null)
                _instance = new GameStateManager();
            return _instance;
        }
        public void SetState(IGameState state)
        {
            _currentState = state;
        }
        public void HandleInput(Window win)
        {
            _currentState.HandleInput(win);
        }

        public void Draw()
        {
            _currentState.Draw();
        }
        public void Update(Window win)
        {
            _currentState.Update(win);
        }
        

    }
}
