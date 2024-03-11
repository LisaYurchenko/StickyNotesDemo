using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickyNotesDemo
{
    public partial class NoteDetailsForm : Form
    {
        public string Title { get; set; }
        public string Content
        {
            get; set;
        }
        public NoteDetailsForm()
        {
            InitializeComponent();
        }

        private void NoteDetailsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Title = titleTextBox.Text;
            Content = contentTextEdit.Text;
        }
    }
}
