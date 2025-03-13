using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppTranslater
{
    public partial class ErrorForm: Form
    {
        public string error;
        public ErrorForm(string errorText)
        {
            InitializeComponent();
            error = errorText;
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            labelError.Text = error;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
