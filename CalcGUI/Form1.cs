using CalcLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcGUI
{
    public partial class Form1 : Form
    {
        private CalcLibrary.Calc calc { get; set; }
        public Form1()
        {
            InitializeComponent();
            calc = new CalcLibrary.Calc();

            //cbOper.Items.AddRange(calc.Operations.Select(o => o.Name).ToArray());

            cbOper.DataSource = calc.Operations;
            cbOper.DisplayMember = "Name";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lResult.Text = "";


            var oper = cbOper.Text;
            object result = null;
            var moreArgs = cbOper.SelectedItem is IOperationArgs;
            var args = new List<object>();

            if (moreArgs)
            {
                var values = tbMore.Text.Split(' ');
                args.AddRange(values);
            }
            else
            {
                var x = tbX.Text;
                var y = tbY.Text;
                args.Add(x);
                args.Add(y);
            }

            try
            {
                result = calc.Execute(oper, args.ToArray());

            }
            catch (Exception ex)
            {
                lResult.Text = $"Error: {ex.Message}";
            }

            lResult.Text = $"{result}";


        }

        private void cbOper_SelectedIndexChanged(object sender, EventArgs e)
        {

            var moreArgs = cbOper.SelectedItem is IOperationArgs;
            panTwoArgs.Visible = !moreArgs;
            panMoreArgs.Visible = moreArgs;
        }
    }
}
