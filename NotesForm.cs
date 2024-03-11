namespace StickyNotesDemo
{
    public partial class NotesForm : Form
    {
        private Point mouseOffset;
        private bool isMouseDown = false;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, this.ClientSize.Width - 16, this.ClientSize.Height - 16, 16, 16);
        }

        public NotesForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.LightYellow;
            this.ResizeRedraw = true;
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
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            NoteDetailsForm noteDetailsForm = new NoteDetailsForm();
            noteDetailsForm.ShowDialog();

            var title = noteDetailsForm.Title;
            var content = noteDetailsForm.Content;
            var creationDate = noteDetailsForm.CreationDate.ToString();

            notesListView.View = View.Details;
            notesListView.Columns.Add("colTitle");
            notesListView.Columns.Add("colDateTime");
            var noteListItem = new ListViewItem(new string[] { title, creationDate });
            notesListView.Items.Add(noteListItem);
        }

        private void NotesForm_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight -
                SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void NotesForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void NotesForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void pictureBoxAdd_Click(object sender, EventArgs e)
        {
            NoteDetailsForm noteDetailsForm = new NoteDetailsForm();
            noteDetailsForm.ShowDialog();

            var title = noteDetailsForm.Title;
            var content = noteDetailsForm.Content;
            var creationDate = noteDetailsForm.CreationDate.ToString();

            notesListView.View = View.Details;
            notesListView.Columns.Add("colTitle");
            notesListView.Columns.Add("colDateTime");
            var noteListItem = new ListViewItem(new string[] { title, creationDate });
            notesListView.Items.Add(noteListItem);
        }

        private void pictureBoxAdd_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxAdd.BackColor = Color.LightGray;
        }

        private void pictureBoxAdd_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAdd.BackColor = Color.Transparent;
        }

        private void pictureBoxMore_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
