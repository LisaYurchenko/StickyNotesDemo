namespace StickyNotesDemo
{
    public partial class BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            pictureBoxClose = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxClose).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxClose
            // 
            pictureBoxClose.Image = (Image)resources.GetObject("pictureBoxClose.Image");
            pictureBoxClose.Location = new Point(422, 12);
            pictureBoxClose.Name = "pictureBoxClose";
            pictureBoxClose.Size = new Size(38, 38);
            pictureBoxClose.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxClose.TabIndex = 6;
            pictureBoxClose.TabStop = false;
            pictureBoxClose.Click += pictureBoxClose_Click;
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightYellow;
            ClientSize = new Size(472, 449);
            Controls.Add(pictureBoxClose);
            Name = "BaseForm";
            Text = "BaseForm";
            MouseDown += BaseForm_MouseDown;
            MouseMove += BaseForm_MouseMove;
            MouseUp += BaseForm_MouseUp;
            ((System.ComponentModel.ISupportInitialize)pictureBoxClose).EndInit();
            ResumeLayout(false);
        }

        #endregion
        protected PictureBox pictureBoxClose;
    }
}