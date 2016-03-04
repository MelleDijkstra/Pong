using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;

namespace Pong
{
    internal class Game
    {
        public Ball bal;
        private MainScreen window;

        private bool isGameStarted;

        public Player player1;
        public Player player2;

        private readonly Random r;
        private bool crazy;

        public Game(MainScreen window)
        {
            this.window = window;

            r = new Random();

            NewGame();
        }

        public void NewGame()
        {

            player1 = new Player("Player 1", new Paddle(10f, window.ClientSize.Height / 2 - 25, 25, 50));
            player2 = new Player("Player 2", new Paddle(window.ClientSize.Width - 35, window.ClientSize.Height / 2 - 25, 25, 50));

            bal = new Ball(window.ClientSize.Width / 2 - 10, window.ClientSize.Height / 2 - 10, 20);

            isGameStarted = false;

        }

        public void Update()
        {
            bal.Update();

            if (crazy)
            {
                bal.ChangeColor();
                player1.paddle.ChangeColor();
                player2.paddle.ChangeColor();
            }

            if (Keyboard.IsKeyDown(Key.W))
            {
                player1.paddle.y -= 10;
                if (player1.paddle.y < 0)
                {
                    player1.paddle.y = 0;
                }
            }

            if (Keyboard.IsKeyDown(Key.S))
            {
                player1.paddle.y += 10;
                if (player1.paddle.y + player1.paddle.height > window.ClientSize.Height)
                {
                    player1.paddle.y = window.ClientSize.Height - player1.paddle.height;
                }
            }


            // PLAYER 2
            if (Keyboard.IsKeyDown(Key.Up))
            {
                player2.paddle.y -= 10;
                if (player2.paddle.y < 0)
                {
                    player2.paddle.y = 0;
                }
            }

            if (Keyboard.IsKeyDown(Key.Down))
            {
                player2.paddle.y += 10;
                if (player2.paddle.y + player2.paddle.height > window.ClientSize.Height)
                {
                    player2.paddle.y = window.ClientSize.Height - player2.paddle.height;
                }
            }

            if (bal.y <= 0)
            {
                bal.y = 0;
                bal.vy *= -1;
            }

            if (bal.y + bal.size >= window.ClientSize.Height)
            {
                bal.y = window.ClientSize.Height - bal.size;
                bal.vy *= -1;
            }

            if (bal.x < 0)
            {
                player1.AddScore(1);
                if (player1.score == 10)
                {
                    MessageBox.Show(player1.name + " won!");
                    NewGame();
                }
                bal.x = window.ClientSize.Width / 2 - bal.size / 2;
                bal.y = window.ClientSize.Height / 2 - bal.size / 2;
                isGameStarted = false;
                bal.vx = bal.vy = 0;
            }

            if (bal.x + bal.size > window.ClientSize.Width)
            {
                player2.AddScore(1);
                if (player2.score == 10)
                {
                    MessageBox.Show(player2.name + " won!");
                    NewGame();
                }
                bal.x = window.ClientSize.Width / 2 - bal.size / 2;
                bal.y = window.ClientSize.Height / 2 - bal.size / 2;
                isGameStarted = false;
                bal.vx = bal.vy = 0;
            }

            if (player1.paddle.IsColliding(bal))
            {
                bal.vx = Math.Abs(bal.vx) + 1;
            }

            if (player2.paddle.IsColliding(bal))
            {
                bal.vx = -Math.Abs(bal.vx) - 1;
            }

            if (Keyboard.IsKeyDown(Key.Space))
            {
                if (!isGameStarted)
                {
                    isGameStarted = true;
                    bal.vx = (float)(5 * Math.Cos(r.Next(0, 360)));
                    bal.vy = (float)(5 * Math.Sin(r.Next(0, 360)));
                }
            }

            if (Keyboard.IsKeyDown(Key.U))
            {
                crazy = !crazy;
            }
        }

        public void Draw(Graphics g)
        {
            player1.paddle.Draw(g);
            player2.paddle.Draw(g);
            bal.Draw(g);
            player1.DrawScore(g, window.ClientSize.Width / 2 + 20, 20);
            player2.DrawScore(g, window.ClientSize.Width / 2 - 20, 20);
        }

        public static Color GetRandomColor()
        {
            var r = new Random(Environment.TickCount);
            return Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
        }
    }
}