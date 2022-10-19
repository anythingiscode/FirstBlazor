using BlazorCRUD.Data.Dapper.Repositoires;
using BlazorCRUD.Model;
using BlazorCRUD.UI.Data;
using BlazorCRUD.UI.Interfaces;

namespace BlazorCRUD.UI.Services
{
    public class FilmService : IFilmsService        //Esta clase es un nexo entre Blasor y nuestra capa de acceso a datos
    {
        private readonly SqlConfiguration _configuration;
        private FilmRepository _filmRepository;        //Ref a la interface

        //Constructor
        public FilmService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _filmRepository = new FilmRepository(configuration.ConnectionString);
        }

        public Task<bool> DeleteFilm(int id)
        {
            return _filmRepository.DeleteFilm(id);
        }

        public Task<IEnumerable<Film>> GetAllFilms()
        {
            return _filmRepository.GetAllFilms();
        }

        public Task<Film> GetDetails(int id)
        {
            return _filmRepository.GetFilmDetails(id);
        }

        public Task<bool> SaveFilm(Film film)
        {
            if (film.Id == 0)   
                return _filmRepository.InsertFilm(film);
            else                    // definimos que pasa cuando al modificar un registro lo guardamos (despues de la opcion "edit")
            {
                return _filmRepository.UpdateFilm(film);
            }  
        }
    }
}
