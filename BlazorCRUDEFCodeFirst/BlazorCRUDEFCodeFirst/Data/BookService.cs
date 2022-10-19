using BlazorCRUDEFCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDEFCodeFirst.Data
{
    public class BookService : IBookService
    {
        private readonly MyBooksContext _context;   //Declaro var
        //Creo constructor de la var
        public BookService(MyBooksContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);      //Buscar en Books en tanto que método async el Id

            _context.Books.Remove(book);

            return await _context.SaveChangesAsync() > 0;   // SaveChangesAsync devuelve un int, que representa las filas afectadas --> si es >0 será que la acción ha tenido éxito
        }

        public async Task<IEnumerable<Book>> GetAllBook()
        {
            return await _context.Books.ToListAsync();      //Devuelve toda la tabla de Books
        }

        public async Task<Book> GetBookDetails(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<bool> InsertBook(Book book)
        {
            _context.Books.Add(book);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveBook(Book book)       // Con esto se puede decidir cuando utilizar insert o Update en funcion de si el Id es >0, ya que si Id>0 será un book que ya existe, sino será insertar uno nuevo
        {
            if (book.BooKId > 0)            
                return await UpdateBook(book);
            else
                return await InsertBook(book);          //Min 24 https://www.youtube.com/watch?v=0zYdUwhursg&list=PLTVK2lirpnSjv-Ieoxj_F35ECC_J1L9ax&index=9&ab_channel=TheCoderCaveesp

        }

        public async Task<bool> UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;  

            return await _context.SaveChangesAsync() > 0;
        }

       

    }
}
