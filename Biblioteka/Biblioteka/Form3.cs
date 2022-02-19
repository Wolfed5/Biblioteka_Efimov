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


namespace Biblioteka
{
    public partial class Form3 : Form //интерфейс читателя
    {
        List<string> lister = new List<string>();
        List<string> listing = new List<string>();
        List<string> listingz = new List<string>();
        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string as1, as2, as3, as4,as5;
            // biblio ser;
            listBox2.Items.Clear();
            lister.Clear();
            if (comboBox1.Text == "по названию")
            {
                
                for (int i = 0; listBox1.Items.Count > i; i++)
                {
                    string deb1 = listBox1.Items[i].ToString();

                    as1 = deb1.Split(' ')[0];
                    as2 = deb1.Split(' ')[1];
                    as3 = deb1.Split(' ')[2];
                    as4 = deb1.Split(' ')[3];

                    if (textBox4.Text == as2|| textBox4.Text == as2+" "+as3 || textBox4.Text == as2 + " " + as3 + " " + as4 )
                    {
                     //   ser = new biblio(as1, as2, as4);
                        lister.Add(deb1);
                    }
                }
              
            }
            else if (comboBox1.Text == "по автору")
            {
                for (int i = 0; listBox1.Items.Count > i; i++)
                {
                    string deb1 = listBox1.Items[i].ToString();

                    as1 = deb1.Split(' ')[0];
                    as2 = deb1.Split(' ')[1];
                    as3 = deb1.Split(' ')[2];
                    as4 = deb1.Split(' ')[3];

                    if (textBox4.Text == as3 || textBox4.Text == as4)
                    {
                       // ser = new biblio(as1, as2, as4);
                        lister.Add(deb1);
                    }
                }           
            }
         
            foreach (string emp in lister)
            {
                
                listBox2.Items.Add(emp);
            }
            


        }

        private void WriteToFile(string path, ListBox listBox)
        {
            using (var sw = new StreamWriter(new FileStream(path, FileMode.Create)))
            {
                if (listBox != null)
                {
                    foreach (var item in listBox.Items) // в таком же порядке
                    {
                        sw.WriteLine(item.ToString());
                    }
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)// загрузка списка книг и книг в наличии у читателя по билету
        {

            label4.Text += " " + textBox4.Text;
            string sel = label4.Text.Split(' ')[1];
            string[] lines = File.ReadAllLines("1.txt");
            string[] lines2 = File.ReadAllLines("bilet "+sel+".txt");
            string[] lines3 = File.ReadAllLines("bilet " + sel + " return" + ".txt");
            listBox1.Items.AddRange(lines);
            listBox3.Items.AddRange(lines2);
            listBox4.Items.AddRange(lines3);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)//запрос на получение книги из списка библиотеки
        {
            string deb2 = label4.Text;
            string sel = deb2.Split(' ')[1];
            int i = listBox1.SelectedIndex;
            string post = listBox1.Items[i].ToString(); //
            listing.Add(sel + " " + post);
          //  WriteToFile("Zapros.txt", Convert.ToL(listing));
            File.WriteAllLines("Zapros.txt", listing);
            var list = File.ReadLines("Zapros.txt").ToList();

        }

        private void button2_Click(object sender, EventArgs e)// возврат книги
        {

            int i = listBox3.SelectedIndex;
            string post = listBox3.Items[i].ToString();
            post= post.Remove(0, post.IndexOf(' ') + 1);
            string deb2 = label4.Text;
            string as1 = deb2.Split(' ')[1];
            listBox1.Items.Add(post); //список книг библиотеки
            listBox4.Items.Add(post); //список возвращенных книг данным читателем
            listBox3.Items.RemoveAt(i);
            WriteToFile("bilet " + as1 + ".txt", listBox3);
            WriteToFile("1.txt", listBox1);
            WriteToFile("bilet " + as1 +" return"+  ".txt", listBox4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string deb2 = label4.Text;
            string as1 = deb2.Split(' ')[1];
            listingz.Add(as1 +" "+book_name.Text+" "+avtor.Text+" "+context.Text);
            //  WriteToFile("Zapros.txt", Convert.ToL(listing));
            File.WriteAllLines("Zaivka.txt", listingz);
            var list = File.ReadLines("Zaivka.txt").ToList();
        }
    }
}
