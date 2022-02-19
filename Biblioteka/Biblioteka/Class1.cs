using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class biblio
    {
        private string cod_book;//код издания
        private string book_name; //название книги
        private string avtor; //автор книги
        private string context; //описание книги
        private biblio book;
        List<biblio> listbooks = new List<biblio>();

        public biblio(string cod_book, string book_name, string avtor, string context)
        {
            this.cod_book = cod_book;
            this.book_name = book_name;
            this.avtor = avtor;
            this.context = context;
        }
        public biblio(string cod_book, string book_name, string avtor)
        {
            this.cod_book = cod_book;
            this.book_name = book_name; 
            this.avtor = avtor;
            this.context = "";
        }

        
        public biblio addbook(string cod_book, string book_name, string avtor, string context) //добавление книги
        {
            book = new biblio(this.cod_book,this.book_name, this.avtor, this.context);
            return book;
        }


        public override string ToString()
        {
            return $"{this.cod_book} {this.book_name} {this.avtor} {this.context}";
        }
    }

    class reader
    {
        private string FIO;
        private DateTime date;//дата рождения
        private string telefon;
        private int bilet;//номер билета читателя
        public reader(string FIO, DateTime date, string telefon)
        {
            this.FIO = FIO;
            this.date = date;
            this.telefon = telefon;
        }

        public int getBilet()//генерация билета читателя
        {
            Random rnd = new Random();
            this.bilet =  rnd.Next(0000, 9999);
            return this.bilet;
        }

        public override string ToString()
        {
            return $"{this.FIO} {this.date.ToString("dd.MM.yyyy")} {this.telefon}";
        }
    }
}
