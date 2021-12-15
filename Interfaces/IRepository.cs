using System;
using System.Collections.Generic;

namespace DIO.series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> ListSeries();
        T ReturnSerieById(int id);
        void InsertSerie(T entity);
        void RemoveSerie(int id);
        void UpdateSerie(int id, T entity);
        int NextId();
    }
}