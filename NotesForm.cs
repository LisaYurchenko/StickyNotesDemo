namespace StickyNotesDemo
{
    public partial class NotesForm : Form
    {
        List<string> Items = new List<string>();

        public NotesForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.LightYellow;
            ResizeRedraw = true;
            notesListView.BackColor = Color.LightYellow;
        }
        private Point mouseOffset;
        private bool isMouseDown = false;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, this.ClientSize.Width - 16, this.ClientSize.Height - 16, 16, 16);
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

        private void NotesForm_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y;
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
            var noteListItem = new ListViewItem(new string[] { title, creationDate });
            notesListView.Items.Add(noteListItem);
            Items.Add(title);
            ResizeColumnHeaders();
        }

        private void ResizeColumnHeaders()
        {
            for (int i = 0; i < this.notesListView.Columns.Count - 1; i++)
                this.notesListView.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.notesListView.Columns[this.notesListView.Columns.Count - 1].Width = -2;
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

        private void NotesForm_SizeChanged(object sender, EventArgs e)
        {
            ResizeColumnHeaders();
        }

        private void notesListView_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = notesListView.SelectedItems[0];
            var showWnd = new NoteDetailsForm();
            showWnd.Title = selectedItem.Text;
            showWnd.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            notesListView.Items.Clear();

            foreach (var item in Items)
            {
                if (item.Contains(textBox1.Text))
                {
                    notesListView.Items.Add(item);
                }
            }
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
