using BlazorCRUD.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Data.Dapper.Repositoires       
{
    public class FilmRepository : IFilmRepository   //Implementamos en el repository las tareas (automaticamente-->clic drcho)
    {
        //Creamos la conexión:
        private string ConnectionString;    //Disponemos de esta variable en appsettings.json, creada al inicio, despues de crear BDD en SQL
       
        //Creamos la estructura necesaria para pasar los datos del .json a la variable
        //1º: Creamos el constructor --> pasamos la var ConnectionString al constructor
        public FilmRepository(string connectionString) { ConnectionString = connectionString; }
        
        //2º: Creamos un método protected SqlConnection de una libreria que si no lo está ya hay que instalar paquete einstanciarla 
        protected SqlConnection dbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public async Task<bool> DeleteFilm(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM Films WHERE Id = @Id";

            var result = await db.ExecuteAsync(sql.ToString(), new {Id = id});

            return result > 0;
        }

        public async Task<Film> GetFilmDetails(int id)
        {
            var db=dbConnection();
            var sql = @"SELECT Id, Title, Director, ReleaseDate 
                        FROM dbo.Films
                        WHERE Id = @Id ";

            return await db.QueryFirstOrDefaultAsync<Film>(sql.ToString(), new {Id = id});
        }

        public async Task<IEnumerable<Film>> GetAllFilms()
        {
           var db=dbConnection();

            var sql = @"SELECT Id, Title, Director, ReleaseDate 
                        FROM dbo.Films";

            return await db.QueryAsync<Film>(sql.ToString(), new { });
        }

        public async Task<bool> InsertFilm(Film film)               //El método es asincrono asi que --> async
        {
            //estructura para insertar film 
            var db = dbConnection();
            //Las instancias SQL las escribo desde SQL que parece ser más sencillo.... y referenciaremos Dapper
            var sql = @"                                
                        INSERT INTO Films (Title, Director, ReleaseDate)
                        VALUES (@Title, @Director, @ReleaseDate) ";

            //Datos para Dapper (que lo acabo de instalar desde BñazorCRUD.Data.Dapper botondrcho/Administrar Paquetes NuGet... --> busqueda general)
            var result = await db.ExecuteAsync(sql.ToString(), new { film.Title, film.Director, film.ReleaseDate });   //Para que sea Asincrono usamos "await"

            //Por ultimo pasamos la var de salida
            return result > 0; //Devolvemos un bool que será: TRUE (>0) si Insert ha tenido exito y sino devolverá FALSE (<0)
        }


        public async Task<bool> UpdateFilm(Film film)
        {
            var db = dbConnection();

            var sql = @"UPDATE Films
                        SET Title = @Title, Director = @Director, ReleaseDate = @ReleaseDate
                        WHERE Id = @Id";

            var result = await db.ExecuteAsync(sql.ToString(), new {film.Title, film.Director, film.ReleaseDate, film.Id });

            return result > 0;
        }
    }
}
