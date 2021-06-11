using Rahman.ModelBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rahman
{
    public partial class Form1 : Form
    {
        ModelBD.Model1 connect = new ModelBD.Model1();
        public Form1()
        {
            InitializeComponent();
            connect.RARM.Load();
            dataGridView1.DataSource = connect.RARM.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            DialogResult result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                ModelBD.RARM cliadd = new RARM();
                cliadd.Услуга = form.textBox1.Text;
                cliadd.Цена = form.textBox2.Text;
                cliadd.Время = form.textBox3.Text;
                cliadd.Клиент = form.textBox4.Text;
               // cliadd.Price = form.textBox5.Text;

                connect.RARM.Add(cliadd);
                connect.SaveChanges();
                MessageBox.Show("Запись добавлена");


            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 formedit = new Form2();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);

                RARM Clientedit = connect.RARM.Find(id);

                formedit.textBox1.Text = Clientedit.Услуга;
                formedit.textBox2.Text = Clientedit.Цена;
                formedit.textBox3.Text = Clientedit.Время;
                formedit.textBox4.Text = Clientedit.Клиент;
               // formedit.textBox5.Text = Clientedit.Price;


                DialogResult resultedit = formedit.ShowDialog(this);
                if (resultedit == DialogResult.OK)
                {
                    Clientedit.Услуга = formedit.textBox1.Text;
                    Clientedit.Цена = formedit.textBox2.Text;
                    Clientedit.Время = formedit.textBox3.Text;
                    Clientedit.Клиент = formedit.textBox4.Text;
                    //Clientedit.Price = formedit.textBox5.Text;
                    connect.SaveChanges();
                    MessageBox.Show("Запись обновлена");
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == true)
                {
                    RARM Clientdel = connect.RARM.Find(id);
                    connect.RARM.Remove(Clientdel);
                    connect.SaveChanges();
                    string buff = Clientdel.Услуга;
                    MessageBox.Show("запись " + buff + " удалена");
                }
            }
            else
            {
                MessageBox.Show("Запись не выбрана!");
            }
        }
    }
}