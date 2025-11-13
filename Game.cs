using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace MohawkGame2D
{
    public class Game
    {
        new Vector2(500,300), new Vector2(450,600), new Vector2(650,750),
            new Vector2(350,580), new Vector2(300,400), new Vector2(670,750),
            new Vector2(250,620), new Vector2(250,150), new Vector2(200,300),
            new Vector2(200,550)
        };

        Vector2 playerPosition = new Vector2(498, 250);
        Vector2 playerVelocity = new Vector2(3.0f);
        int playerSpeed = 7;

		Vector2 enemyPosition = new Vector2(498, 50);
        Vector2 enemyvelocity = new Vector2(3.0f);
        float enemyspeed = 3.0f;
        float Timeofday = 20;

        public void Setup()
        {
			

            Window.SetTitle("Platform Jumper");
            Window.SetSize(600, 800);

        }
        public void Update()
        {
			playerPosition.Y -= Time.DeltaTime;// move player down 
									   // when timer hits 0 game ends  
            Timeofday -= Time.DeltaTime;
            if (Timeofday <= 0)
			{
				Timeofday = 0; Console.WriteLine("Game Over! times up.");
			}

			// game logic
			UpdateEnemyPosition();
			CheckPlayerPosition();
			CheckCollision();
			Processgravity();




			//drawing 
			Window.ClearBackground(Color.White);
            Text.Color = Color.Red;
            Text.Draw($"{Timeofday}", 300, 300);

            DrawPlatforms();
            DrawPlayer();
            DrawEnemy();

			void processgravity()
			{


			}



			void CheckPlayerPosition()
			{
				playerPosition += playerVelocity;
				playerPosition.X = Math.Clamp(playerPosition.X, 0, 540);
				playerPosition.Y = Math.Clamp(playerPosition.Y, 0, 740);
			}

			void UpdateEnemyPosition()
			{
				Vector2 direction = playerPosition - enemyPosition;
				if (direction != Vector2.Zero)
					direction = Vector2.Normalize(direction);

				enemyPosition += direction * enemyspeed;
			}

			void CheckCollision()
			{
				float distance = Vector2.Distance(playerPosition, enemyPosition);
				if (distance < 30) // close enough to collide
				{
					Console.WriteLine("Game Over! The enemy caught you.");
				}
			}

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
			}
			void playerInput()
                {
                    if (Input.IsKeyboardKeyDown(KeyboardInput.A))
                    {
                        playerVelocity.X = playerSpeed; // Move player left
                    }
                    else if (Input.IsKeyboardKeyDown(KeyboardInput.D))
                    {
                        playerVelocity.X = playerSpeed; // Move player right
                    }
				else if (Input.IsKeyboardKeyDown(KeyboardInput.W))
				{
					playerVelocity.Y = playerSpeed; // make player jump
				}
				else if (Input.IsKeyboardKeyPressed(KeyboardInput.S))
                    {
                    playerVelocity.Y = playerSpeed; // move player down 
				}
                    void UpdateEnemyPosition()
                    {
                        Vector2 direction = Vector2.Normalize(playerPosition - enemyPosition);
                        enemyPosition += direction * enemyspeed;
                    }

                    void CheckPlayerPosition()
                    {// Fixed to update player position
                        // prevent player and enemy from falling off screen 
                        playerPosition += playerVelocity;
                        playerPosition.X = Math.Clamp(playerPosition.X, 0, 775);
                        playerPosition.Y = Math.Clamp(playerPosition.Y, 0, 575);

                    }
                }
                void PreventPlayerfromgoingthroughPlatform()
                {
					foreach (Vector2 platform in platformsPosition)
                        {
					//bool collideX = playerPosition.X + 50 > platform.X && playerPosition.X < platform.X + 100 &&
					//                  bool collideY = playerPosition.Y + 50 > platform.Y && playerPosition.Y < platform.Y + 100 &&


					//if (collideX && collideY) { }
					//	//collision detected dont let player drop through platforms
					//	//moving up 
					//	if (playerVelocity.Y < 0)
					//	{
					//		playerPosition.Y = platform.Y + 12;
					//		playerVelocity.X = 0.0f;
					//	}
					//	//moving down 
					//	else if (playerVelocity.Y > 0)
					//	{
					//		playerPosition.Y = platform.Y + 12;
					//		playerVelocity.X = 0.0f;
					//	}
					//	//moving left 
					//	else if (playerVelocity.X > 0)
					//	{
					//		playerPosition.X = platform.X + 50;
					//		playerVelocity.Y = 0.0f;
					//	}
					//	//moving right

						
							
                    }
                    }
                }
            }
        }