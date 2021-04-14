using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
           
                double x1min = double.Parse(textBox1.Text);
                double x2min = double.Parse(textBox6.Text);
                double x1max = double.Parse(textBox2.Text);
                double x2max = double.Parse(textBox5.Text);
                double dx1 = double.Parse(textBox3.Text);
                double dx2 = double.Parse(textBox4.Text);
            

            dataGridView1.ColumnCount = (int)Math.Truncate((x2max - x2min) / dx2) + 1;
            dataGridView1.RowCount = (int)Math.Truncate((x1max - x1min) / dx1) + 1;
           
            for (int i = 0; i<dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (x1min + i * dx1).ToString("0.000");
                dataGridView1.RowHeadersWidth = 80;
             
              

            }
            
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Value = (x2max + i * dx2).ToString("0.000");
                dataGridView1.Columns[i].Width = 60;
                
                
            }

             int cl, rw;
            double x1, x2, y;
            rw = 0;
            x1 = x1max;
            while (x1 <= x1max)
            {
                x2 = x2min;
                cl = 0;
                while (x2 <= x2max)
                {
                    y = Math.Sqrt(56 * x1 + ((x1 + x2 + Math.Sin(x1 * x2)) / 5 - Math.Cos(Math.Pow(x2, 2))));
                    dataGridView1.Rows[rw].Cells[cl].Value = y.ToString("0.000");
                    x2 += dx2;
                    cl++;


                }
                x1 += dx1;
                rw++; 

        

             
            }

            double op;
            dataGridView1.Rows.Add();
            dataGridView1.Columns.Add("suma", "sum");
            for (int i2= 0; i2 <dataGridView1.ColumnCount; i2++)
            {
                op = 0;
                for (int i = 0; i <dataGridView1.RowCount; i++)
                {
                    op += Convert.ToDouble(dataGridView1.Rows[i].Cells[i2].Value);

                }
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[i2].Value = op;
            }
            
            for (int i2 = 0; i2 < dataGridView1.RowCount; i2++)
            {
                op = 0;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    op += Convert.ToDouble(dataGridView1.Rows[i2].Cells[i].Value);

                }
                dataGridView1.Rows[i2].Cells[dataGridView1.ColumnCount - 1].Value = op.ToString("0.000");
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
