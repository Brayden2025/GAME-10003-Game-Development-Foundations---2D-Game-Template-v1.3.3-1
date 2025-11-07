using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {

        /// <summary>
        /// setup runs once before the game loop begins 
        /// </summary>
        /// 
        Vector2[] platformsPosition = {
        new Vector2(), new Vector2(), new Vector2(),
            new Vector2(), new Vector2(), new Vector2(),
            new Vector2(), new Vector2(), new Vector2(),
        };

        Vector2 playerPosition = new Vector2();
        Vector2 playerPosition = new Vector2();
        Vector2 playerVelocity = new Vector2();
        int playerSpeed = 10;

        Vector2 enemyPosition = new Vector2();
        Vector2 enemyvelocity = new Vector2(0, 0);
        float Timeofday = 20;

        public void Setup()
        {
            Window.SetTitle("Platform Jumper");
            Window.SetSize(600, 800);
            Window.TargetFPS = 60; }
        public void Update()
        {
            Window.ClearBackground(Color.White);
            // when timer hits 0 timer restarts 
            Timeofday -= Time.DeltaTime;
            if (Timeofday <= 0)
            {
                Timeofday = 0;

            }
            //draw.circle(4, 4, 4);

            Text.Color = Color.Red;
            Text.Draw($"{Timeofday}", 300, 300);

            DrawPlatforms();
            PlayerMovement();
            UpdateEnemyPosition();
            DrawPlayer();
            DrawEnemy();
            UpdatePlayerPosition();
            CheckCollision();
            PreventPlayerFromGoingThroughPlatforms();

            void DrawPlayer()
            {
                // Draw player
                Draw.FillColor = Color.Blue;
                Draw.Rectangle(playerPosition.X, playerPosition.Y, 60, 60); 
            }
            void DrawEnemy()
            {
                // Draw enemy
                Draw.FillColor = Color.Black;
                Draw.Circle(enemyPosition.X, enemyPosition.Y, 15);
            }
            void DrawPlatforms()
            {
                Draw.FillColor = Color.Green;
                foreach (var position in platformsPosition)
                {
                    Draw.Rectangle(position.X, position.Y, 100, 10);
                }
                void PlayerMovement()
                {
                    if (Input.IsKeyboardKeyDown(KeyboardInput.A))
                    {
                        playerVelocity.X = -playerSpeed; // Move player left
                    }
                    else if (Input.IsKeyboardKeyDown(KeyboardInput.D))
                    {
                        playerVelocity.X = playerSpeed; // Move player right
                    }
                    else if (Input.IsKeyboardKeyDown(KeyboardInput.W))
                    {
                        playerVelocity.Y = -playerSpeed; // Move player up
                    }
                    else if (Input.IsKeyboardKeyDown(KeyboardInput.S))
                    {
                        playerVelocity.Y = playerSpeed; // Move player down
                    }
                    else
                    {
                        playerVelocity = Vector2.Zero; // Stop player movement if no key is pressed
                    }
                }

        };
    };
};