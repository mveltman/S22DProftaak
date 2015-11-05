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
        public Action.Action ChangedItem()
        {
            Act.ChangeInfo(richTextBox1.Text, dateTimePicker1.Value);
            return Act;
        }

        public ChangeForm(Action.Action act)
        {
            InitializeComponent();
            Act = act;
        }
        public bool GetChange()
        {

            return true;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
