

using System;
using customprogram;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
      
        Window win = new Window("Space War", 800, 640);
        // call the start state at the begining
        GameStateManager.Instance().SetState(new StartState());
        while (!win.CloseRequested) 
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen();

            GameStateManager.Instance().HandleInput(win);
            GameStateManager.Instance().Draw();
            GameStateManager.Instance().Update(win);

            SplashKit.RefreshScreen();  

        }

    }
}