namespace Pong
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.theLoop = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // theLoop
            // 
            this.theLoop.Enabled = true;
            this.theLoop.Interval = 10;
            this.theLoop.Tick += new System.EventHandler(this.theLoop_Tick);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(583, 444);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainScreen";
            this.Text = "Pong";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainScreen_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer theLoop;
    }
}

