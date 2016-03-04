using System.Drawing;

namespace Pong
{
    class Player
    {
        public int score;
        public string name;
        public Paddle paddle;

        public Player(string name, Paddle paddle)
        {
            this.name = name;
            this.paddle = paddle;
        }

        public void AddScore(int num)
        {
            score += num;
        }

        public void DrawScore(Graphics g, float x, float y)
        {
            g.DrawString(score.ToString(), SystemFonts.DefaultFont, Brushes.White, x, y);
        }
    }
}
