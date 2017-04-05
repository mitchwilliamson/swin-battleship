using System;
using SwinGameSDK;

namespace Battleship
{
    public class GameMain
    {
        public static void Main()
        {
            SwinGame.OpenGraphicsWindow("Battleship", 800, 600);

            GameResources.Load();
            SwinGame.PlayMusic("Background");

            GameController gameController = new GameController();

            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();


                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0, 0);

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}