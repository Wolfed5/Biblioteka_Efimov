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
    public partial class Form2 : Form
    {
        List<biblio> lister = new List<biblio>();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //добавление книги
        {
            biblio fin2 = new biblio(textBox1.Text, book_name.Text, avtor.Text, context.Text);
            fin2.addbook(textBox1.Text, book_name.Text, avtor.Text, context.Text);
            if(textBox1.Text.Length>9)
            listBox1.Items.Add(fin2);
            WriteToFile("1.txt", listBox1);

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


            private void button2_Click(object sender, EventArgs e) //удаление книги
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        

        private void Form2_Load(object sender, EventArgs e) // загрузка списка книг
        {
            string[] lines = File.ReadAllLines("1.txt");
            listBox1.Items.AddRange(lines);
            string[] lines2 = File.ReadAllLines("Zapros.txt");
            listBox2.Items.AddRange(lines2);
            string[] lines3 = File.ReadAllLines("Zaivka.txt");
            listBox3.Items.AddRange(lines3);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e) //редактирование книги
        {
            int i = listBox1.SelectedIndex;
            biblio fin2;
            fin2 = new biblio(textBox1.Text,book_name.Text, avtor.Text, context.Text);
            

            listBox1.Items.RemoveAt(i);
            listBox1.Items.Insert(i, fin2);
            WriteToFile("1.txt", listBox1);
        }

        private void button5_Click(object sender, EventArgs e)// выдача книги из списка библиотеки
        {
            int i = listBox2.SelectedIndex;
            string as1;
            string deb1 = listBox2.Items[i].ToString();
            as1 = deb1.Split(' ')[0];
            
            for(int j=0;listBox1.Items.Count>j ;j++)
            {
                if(deb1==as1+" "+listBox1.Items[j].ToString())
                {

                    File.AppendAllText("bilet " + as1 + ".txt", listBox1.Items[j].ToString() + '\n', Encoding.Default);
                    listBox2.Items.RemoveAt(i);
                    listBox1.Items.RemoveAt(j);
                    break;
                }
            }

            WriteToFile("Zapros.txt", listBox2);
            WriteToFile("1.txt", listBox1);
        }

        private void button6_Click(object sender, EventArgs e) //выдача книги новой книги по заявке(сначала нужно добавить эту книгу в список библиотеки, а потом выдать)
        {
            int i = listBox3.SelectedIndex;

            string as1;
            string deb1 = listBox3.Items[i].ToString();
            as1 = deb1.Split(' ')[0];
            
            for (int j = 0; listBox1.Items.Count > j; j++)
            {
                string loc= listBox1.Items[j].ToString();
                loc = loc.Remove(0, loc.IndexOf(' ') + 1);
                if (deb1 == as1 + " " + loc)
                {
                    File.AppendAllText("bilet " + as1 + ".txt", listBox1.Items[j].ToString() + '\n', Encoding.Default);

                    listBox3.Items.RemoveAt(i);
                    listBox1.Items.RemoveAt(j);
                    break;
                }
            }

            WriteToFile("Zaivka.txt", listBox3);
            WriteToFile("1.txt", listBox1);
        }
    }
}
