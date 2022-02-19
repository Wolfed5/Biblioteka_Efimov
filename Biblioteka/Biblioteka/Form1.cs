using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Biblioteka
{

    public partial class Form1 : Form //страница входа
    {

        List<reader> lister1 = new List<reader>();
        public Form1()
        {
            InitializeComponent();
           
        }

     

        private void button1_Click(object sender, EventArgs e) 
        {
            if (comboBox1.Text=="Читатель") // проверка читателя по списку
            {
                var listo = new List<string>();
                //reader login;
                //login = new reader(textBox1.Text, Convert.ToDateTime(textBox2.Text), Convert.ToInt32(textBox3.Text));
                string login = textBox4.Text+" "+ textBox1.Text+" "+ textBox2.Text+ " " + textBox3.Text;
                string[] log_list = File.ReadAllLines("readers.txt",Encoding.GetEncoding(1251));
                listo.AddRange(log_list);


                for (int i=0;listo.Count>i ;i++)
                {
                    string g1 = listo[i];
                    if (login==g1) 
                    {
                        
                        Form3 frm = new Form3();
                        frm.label4.Text += " "+textBox4.Text;
                        frm.Show();
                    }
                }
                
            }
            if (comboBox1.Text == "Библиотекарь")
            {
                Form2 frm = new Form2();
                frm.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void button2_Click(object sender, EventArgs e) // регистрация читателя
        {
            reader login;
            login = new reader(textBox1.Text, Convert.ToDateTime(textBox2.Text),textBox3.Text);
            lister1.Add(login);
            int bl = login.getBilet();// метод генерации случайного номера билета
            File.AppendAllText("readers.txt", bl +" "+ Convert.ToString(login)+'\n', Encoding.Default);
            label6.Text += " " + bl;
            Form3.ActiveForm.Text += textBox1.Text;
            File.AppendAllText("bilet "+ bl +".txt", "", Encoding.Default);
            File.AppendAllText("bilet " + bl +" return"+ ".txt", "", Encoding.Default);
        }
    }
}
