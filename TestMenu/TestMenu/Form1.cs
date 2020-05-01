using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.FullRowSelect = true;


            listView1.Columns.Add("Фамилия", 150);
            listView1.Columns.Add("Имя", 150);
            listView1.Columns.Add("Год", 200);

        }

       
        //добавляем строки в ListView
        
        private void add(String surname, String name, String year)
        {
            String[] row = { surname,name,year };
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

  

        //добавить
        private void button1_Click(object sender, EventArgs e)
        {
            add(textBox1.Text, textBox2.Text, textBox3.Text);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";


        }
        //обновить
        private void button2_Click(object sender, EventArgs e)
        {

            listView1.SelectedItems[0].SubItems[0].Text = textBox1.Text;
            listView1.SelectedItems[0].SubItems[1].Text = textBox2.Text;
            listView1.SelectedItems[0].SubItems[2].Text = textBox3.Text;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        //удалить
        private void delete()
        {
            if (MessageBox.Show("Вы действительно хотите удалить?", "Удалить", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }

        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            delete();

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
           

            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location))
                {
                    
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }



        //сохранить

        private void button4_Click(object sender, EventArgs e)
        {
            TextWriter tw = new StreamWriter(@"..\..\Test.txt");
            StringBuilder listViewContent = new StringBuilder();
            for (int item = 0; item < this.listView1.Items.Count; item++)
            {
                for (int subitem = 0;
                   subitem < this.listView1.Columns.Count;
                   subitem++)
                {
                    listViewContent.Append
                    (this.listView1.Items[item].SubItems[subitem].Text);
                    if (subitem < this.listView1.Columns.Count - 1)
                        listViewContent.Append(",");
                }
                tw.WriteLine(listViewContent);
                listViewContent = new StringBuilder();
            }
            tw.Close();
        }

        private void цветТекстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                listView1.ForeColor = dlg.Color;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete();
        }
    }
}
