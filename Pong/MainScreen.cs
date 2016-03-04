using System;
using System.Windows.Forms;

namespace Pong
{
    public partial class MainScreen : Form
    {
        private readonly Game game;

        public MainScreen()
        {
            InitializeComponent();

            game = new Game(this);
        }

        private void theLoop_Tick(object sender, EventArgs e)
        {
            game.Update();
            Invalidate();
        }

        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);
        }
    }
}