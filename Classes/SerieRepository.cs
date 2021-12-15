using System;
using System.Collections.Generic;
using DIO.series.Interfaces;

namespace DIO.series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> serieList = new List<Serie>();

        public void UpdateSerie(int id, Serie entity)
        {
            serieList[id] = entity;
        }

        public void RemoveSerie(int id)
        {
            serieList[id].Remove();
        }

        public void InsertSerie(Serie entity)
        {
            serieList.Add(entity);
        }

        public Serie ReturnSerieById(int id)
        {
            return serieList[id];
        }

        public List<Serie> ListSeries()
        {
            return serieList;
        }

        public int NextId()
        {
            return serieList.Count;
        }
    }
}