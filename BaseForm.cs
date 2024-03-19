namespace StickyNotesDemo
{
    public partial class BaseForm : Form
    {
        private Point _mouseOffset;
        private bool _isMouseDown = false;

        public BaseForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.LightYellow;
            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, this.ClientSize.Width - 16, this.ClientSize.Height - 16, 16, 16);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x20000;
                return cp;
            }
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int HTBOTTOMRIGHT = 17;

            if (m.Msg == WM_NCHITTEST)
            {
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                pos = this.PointToClient(pos);
                if (pos.X >= this.ClientSize.Width - 16 && pos.Y >= this.ClientSize.Height - 16)
                {
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void BaseForm_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y;
                _mouseOffset = new Point(xOffset, yOffset);
                _isMouseDown = true;
            }
        }

        private void BaseForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(_mouseOffset.X, _mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void BaseForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isMouseDown = false;
            }
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
