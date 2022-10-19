using BlazorCRUD.Model;

namespace BlazorCRUD.UI.Interfaces
{
    // Esta es la interface que va ha hacer de nexo extre Blasor y el servidor
    public interface IFilmsService
    {
        Task<IEnumerable<Film>> GetAllFilms();
        Task<Film> GetDetails(int id);
        Task<bool> DeleteFilm(int id);
        Task<bool> SaveFilm(Film film);


    }
}
