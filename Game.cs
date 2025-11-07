using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace MohawkGame2D
{
    public class Game
    {

        /// <summary>
        /// setup runs once before the game loop begins 
        /// </summary>

        Vector2[] platformsPosition = {
        new Vector2(500,300), new Vector2(450,600), new Vector2(650,750),
            new Vector2(350,580), new Vector2(300,400), new Vector2(670,750),
            new Vector2(250,620), new Vector2(250,150), new Vector2(200,300),
            new Vector2(200,550)
        };

        Vector2 playerPosition = new Vector2(498, 250);
        Vector2 playerVelocity = new Vector2(0,0);
        int playerSpeed = 7;

        Vector2 enemyPosition = new Vector2(498,50);
        Vector2 enemyvelocity = new Vector2(0,0);
        float enemyspeed = 3.0f;
        float Timeofday = 20;

        public void Setup()
        {
            Window.SetTitle("Platform Jumper");
            Window.SetSize(600, 800);
            Window.TargetFPS = 60;
        }
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

            DrawPlatforms(); DrawPlayer(); DrawEnemy(); 
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
                    void UpdateEnemyPosition()
                    {
                        Vector2 direction = Vector2.Normalize(playerPosition - enemyPosition);
                        enemyPosition += direction * enemyspeed;
                    }

                    void CheckPlayerPosition()
                    {// Fixed to update player position
                        playerPosition += playerVelocity;
                        // prevent player and enemy from falling off screen 
                        playerPosition += playerVelocity;
                        playerPosition.X = Math.Clamp(playerPosition.X, 0, 775);
                        playerPosition.Y = Math.Clamp(playerPosition.Y, 0, 575);

                    }
                }
                void CheckCollision()
                {
                    float distance = Vector2.Distance(playerPosition, enemyPosition);
                    if (enemyPosition == playerPosition)
                    {
                        // end game code
                        Console.WriteLine("game over you have failed");

                    }


                }
                void PreventPlayerfromgoingthroughPlatform()
                {
                    foreach (var platform in platformsPosition)
                    {
                        if (playerPosition.X + 50 > platform.X && playerPosition.X < platform.X + 100 &&
                               playerPosition.Y + 50 > platform.Y && playerPosition.Y < platform.Y + 10)
                        {
                            //collision detected dont let player walk through platforms
                            //jumping up 
                            if (playerVelocity.Y < 0)
                            {
                                playerPosition.Y = platform.Y + 12;
                                playerVelocity.X = 0;
                            }
                            //moving down 
                            else if (playerVelocity.Y > 0)
                            {
                                playerPosition.Y = platform.Y + 12;
                                playerVelocity.X = 0;
                            }
                            //moving left 
                            else if (playerVelocity.X > 0)
                            {
                                playerPosition.X = platform.X + 50;
                                playerVelocity.Y = 0;
                            }
                            //moving right 
                        }
                        else if (playerVelocity.X > 0)
                        {
                            playerPosition.X = platform.X - 50;
                            playerVelocity.X = 0;
                        }
                    }
                    void gameCheckCollision()
                    {
                        float enemyposition = Vector2.Distance(playerPosition, enemyPosition);
                        if (enemyPosition == playerPosition)

                            // End game logic
                            Console.WriteLine("Game Over! The enemy has caught you.");

                    }
                    ;

                }
            }
        }

}   } 