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

        private class OperationBeauty
        {
            public IOperation Operation{ get; set; }
            public string Name { get; set;  }

            public OperationBeauty(IOperation operation)
            {
                Operation = operation;

                var type = Operation.GetType();

                Name = $"{type.Name}.{type.Namespace}";
            }
        }
        
        private CalcLibrary.Calc calc { get; set; }
        public Form1()
        {
            InitializeComponent();
            calc = new CalcLibrary.Calc();
            cbOper.DataSource = calc.Operations;
            cbOper.DisplayMember = "Name";
            var it = cbOper.Items;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lResult.Text = "";


            var oper = cbOper.Text;
            object result = null;
            //var operB //!!! ДОБАВИТЬ Бьютифаер
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
                result = calc.Execute(cbOper.SelectedItem as IOperation, args.ToArray());
            }
            catch (Exception ex)
            {
                lResult.Text = $"Error: {ex.Message}";
                return;
            }

            lResult.Text = $"{result}";
        }

        private void cbOper_SelectedIndexChanged(object sender, EventArgs e)
        {
            var moreArgs = cbOper.SelectedItem is IOperationArgs;
            panTwoArgs.Visible = !moreArgs;
            panMoreArgs.Visible = moreArgs;
        }

        private void cbOper_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            var item = (cbOper.Items[e.Index] as IOperation);
            Brush brush = item is IOperationArgs ? Brushes.Black : Brushes.Red;
            e.Graphics.DrawString(item.Name, e.Font, brush, e.Bounds);
            e.DrawFocusRectangle();
        }
    }
}
