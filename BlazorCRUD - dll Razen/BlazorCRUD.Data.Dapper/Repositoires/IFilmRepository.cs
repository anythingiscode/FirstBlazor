using BlazorCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Data.Dapper.Repositoires
{
    internal interface IFilmRepository
    {
        // Creo las tareas CRUD
        Task<IEnumerable<Film>> GetAllFilms();     //Create
        Task<Film> GetFilmDetails(int id);             //Read
        Task<bool> InsertFilm(Film film);       // ++ insert
        Task<bool> UpdateFilm(Film film);       //Update
        Task<bool> DeleteFilm(int id);          //Delete
    }
}
