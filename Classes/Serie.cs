using System;

namespace DIO.series
{
    public class Serie : BaseEntity
    {
        private Genre Genre { get; set; } 
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Removed { get; set; }

        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Removed = false;
        }
        public override string ToString()
        {
            string returned = "";
            returned += "Gênero: " + this.Genre + Environment.NewLine;
            returned += "Título: " + this.Title + Environment.NewLine;
            returned += "Descrição: " + this.Description + Environment.NewLine;
            returned += "Ano de Ínicio: " + this.Year + Environment.NewLine;
            returned += "Excluído: " + this.Removed;

            return returned;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }

        public bool returnRemoved()
        {
            return this.Removed;
        }

        public void Remove() 
        {
            this.Removed = true;
        }
    }
}