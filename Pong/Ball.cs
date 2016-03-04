using System.Drawing;

namespace Pong
{
    internal class Ball
    {
        public int size;
        public Brush color = Brushes.Tomato;
        public float x, y, vx, vy;

        public Ball(float x, float y, int size)
        {
            this.x = x;
            this.y = y;
            this.size = size;
        }

        public void Update()
        {
            x += vx;
            y += vy;
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(color, new Rectangle((int)x, (int)y, size, size));
        }

        public void ChangeColor()
        {
            color = new SolidBrush(Game.GetRandomColor());
        }
    }
}