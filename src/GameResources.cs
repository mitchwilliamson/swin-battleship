using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace Battleship
{
    class GameResources
    {
        public static void LoadFonts()
        {
            SwinGame.LoadFontNamed("ArialLarge", "arial.ttf", 80);
            SwinGame.LoadFontNamed("Courier", "cour.ttf", 14);
            SwinGame.LoadFontNamed("CourierSmall", "cour.ttf", 8);
            SwinGame.LoadFontNamed("Menu", "ffaccess.ttf", 8);
        }

        public static void LoadImages()
        {
            SwinGame.LoadBitmapNamed("Menu", "main_page.jpg");
            SwinGame.LoadBitmapNamed("Discovery", "discover.jpg");
            SwinGame.LoadBitmapNamed("Deploy", "deploy.jpg");

            SwinGame.LoadBitmapNamed("LeftRightButton", "deploy_dir_button_horiz.png");
            SwinGame.LoadBitmapNamed("UpDownButton", "deploy_dir_button_vert.png");
            SwinGame.LoadBitmapNamed("SelectedShip", "deploy_button_hl.png");
            SwinGame.LoadBitmapNamed("PlayButton", "deploy_play_button.png");
            SwinGame.LoadBitmapNamed("RandomButton", "deploy_randomize_button.png");

            for (int i = 0; i < 5; i++)
            {
                SwinGame.LoadBitmapNamed("ShipLR", "ship_deploy_horiz_" + i.ToString() + ".png");
                SwinGame.LoadBitmapNamed("ShipUD", "ship_deploy_vert_" + i.ToString() + ".png");
            }

            SwinGame.LoadBitmapNamed("Explosion", "explosion.png");
            SwinGame.LoadBitmapNamed("Splash", "splash.png");
        }

        public static void LoadSounds()
        {
            SwinGame.LoadSoundEffectNamed("Error", "error.wav");
            SwinGame.LoadSoundEffectNamed("Hit", "hit.wav");
            SwinGame.LoadSoundEffectNamed("Sink", "sink.wav");
            SwinGame.LoadSoundEffectNamed("Siren", "siren.wav");
            SwinGame.LoadSoundEffectNamed("Miss", "watershot.wav");
            SwinGame.LoadSoundEffectNamed("Winner", "winner.wav");
            SwinGame.LoadSoundEffectNamed("Lose", "lose.wav");
        }

        public static void LoadMusic()
        {
            SwinGame.LoadMusicNamed("Background", "horrordrone.mp3");
        }

        public static void Load()
        {
            LoadFonts();
            LoadImages();
            LoadSounds();
            LoadMusic();
        }
    }
}
