using System;
using System.Threading;

namespace MohawkGame2D
{
    public class Game

    {   // Player variables
        Vector2[] cloudpositions = [new Vector2(20, 50), new Vector2(100, 200), new Vector2(250, 300)];
        Vector2[] platformpositons = [new Vector2(500, 300), new Vector2(450, 600), new Vector2(650, 750), new Vector2(200, 550)];


        public void setup()

            {
            Window.SetTitle("platformjumper");
            Window.SetSize(800, 600);
            Window.TargetFPS = 60;

            // initialize all game objects 

            for (int i = 0; i < Clouds.length; i * *)
                {
                Clouds[i] = new Clouds();
                Clouds[i].setup(Cloudposition[i]);

            }
            for (int i = 0; 0; i < Platform.length; i * *) ;
        {
                Platform[i] = new Platform();
                Platform[i].position = platformposition[i];
                Platform[i].size = Platformsize[i];
                Platform[i].setup();

                    }
            player = new player();
            player.setup();

                }
        }
                }
