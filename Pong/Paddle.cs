using System.Drawing;

namespace Pong
{
    internal class Paddle
    {
        public int width, height;
        public float x, y;
        private Brush color;

        public Paddle(float x, float y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            color = Brushes.White;
        }

        public bool IsColliding(Ball b)
        {
            var isHit = !(b.x + b.size < x ||
                          x + width < b.x ||
                          b.y + b.size < y ||
                          y + height < b.y);

            return isHit;
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(color, new Rectangle((int)x, (int)y, width, height));
        }

        public void ChangeColor()
        {
            color = new SolidBrush(Game.GetRandomColor());
        }
    }
}