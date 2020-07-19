namespace Snake
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.SnakeHead = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.Gaming = new System.Windows.Forms.Timer(this.components);
            this.InfoLabel = new System.Windows.Forms.Label();
            this.Death = new System.Windows.Forms.Timer(this.components);
            this.StateLabel = new System.Windows.Forms.Label();
            this.PauseLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.SnakeHead});
            this.shapeContainer1.Size = new System.Drawing.Size(284, 261);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // SnakeHead
            // 
            this.SnakeHead.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SnakeHead.BackColor = System.Drawing.Color.Black;
            this.SnakeHead.BorderWidth = 5;
            this.SnakeHead.Cursor = System.Windows.Forms.Cursors.Default;
            this.SnakeHead.Enabled = false;
            this.SnakeHead.FillColor = System.Drawing.Color.Black;
            this.SnakeHead.FillGradientColor = System.Drawing.Color.Black;
            this.SnakeHead.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Central;
            this.SnakeHead.Location = new System.Drawing.Point(134, 118);
            this.SnakeHead.Name = "SnakeHead";
            this.SnakeHead.SelectionColor = System.Drawing.Color.Black;
            this.SnakeHead.Size = new System.Drawing.Size(10, 10);
            // 
            // Gaming
            // 
            this.Gaming.Enabled = true;
            this.Gaming.Interval = 50;
            this.Gaming.Tick += new System.EventHandler(this.Gaming_Tick);
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.InfoLabel.Enabled = false;
            this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.InfoLabel.Location = new System.Drawing.Point(9, 9);
            this.InfoLabel.Margin = new System.Windows.Forms.Padding(0);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(101, 26);
            this.InfoLabel.TabIndex = 1;
            this.InfoLabel.Text = "InfoLabel";
            // 
            // Death
            // 
            this.Death.Enabled = true;
            this.Death.Interval = 50;
            this.Death.Tick += new System.EventHandler(this.Death_Tick);
            // 
            // StateLabel
            // 
            this.StateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StateLabel.AutoSize = true;
            this.StateLabel.BackColor = System.Drawing.Color.Transparent;
            this.StateLabel.Enabled = false;
            this.StateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.StateLabel.Location = new System.Drawing.Point(9, 200);
            this.StateLabel.Margin = new System.Windows.Forms.Padding(0);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(116, 26);
            this.StateLabel.TabIndex = 2;
            this.StateLabel.Text = "StateLabel";
            // 
            // PauseLabel
            // 
            this.PauseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PauseLabel.AutoSize = true;
            this.PauseLabel.BackColor = System.Drawing.Color.Transparent;
            this.PauseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F);
            this.PauseLabel.Location = new System.Drawing.Point(187, 9);
            this.PauseLabel.Margin = new System.Windows.Forms.Padding(0);
            this.PauseLabel.Name = "PauseLabel";
            this.PauseLabel.Size = new System.Drawing.Size(88, 26);
            this.PauseLabel.TabIndex = 3;
            this.PauseLabel.Text = "PAUSE";
            this.PauseLabel.Visible = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.PauseLabel);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.shapeContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Snake";
            this.Load += new System.EventHandler(this.Game_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Game_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape SnakeHead;
        private System.Windows.Forms.Timer Gaming;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Timer Death;
        private System.Windows.Forms.Label StateLabel;
        private System.Windows.Forms.Label PauseLabel;
    }
}