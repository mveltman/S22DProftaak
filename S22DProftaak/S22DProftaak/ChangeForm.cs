using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S22DProftaak
{
    public partial class ChangeForm : Form
    {
        public Action.Action Act;
        public DateTime Time;
        public string desc;
        public Action.Action ChangedItem()
        {
            Act.ChangeInfo(desc, Time);
            return Act;
        }

        public ChangeForm(Action.Action act)
        {
            InitializeComponent();
            Act = act;
            richTextBox1.Text = Act.Note;
        }
        public bool GetChange()
        {

            return true;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Time = dateTimePicker1.Value;
            desc = richTextBox1.Text;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
