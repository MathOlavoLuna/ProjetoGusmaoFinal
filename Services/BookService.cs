using ProjetoGusmaoFinal.Classes;
using ProjetoGusmaoFinal.Models;

namespace ProjetoGusmaoFinal.Services
{
    public class BookService(CRUDService<Books> Entity)
    {
        private readonly CRUDService<Books> _entity = Entity;

        public async Task<ApiResponse<Books>> PostBook(Books Book)
        {
            ApiResponse<Books> Response = new();
            try
            {
                Books CreatedBook = await _entity.Post(Book);
                Response.Data.Add(CreatedBook);
                Response.Success = true;
            }
            catch (Exception Ex)
            {
                Response.Message = Ex.Message;
            }
            return Response;
        }
    }
}
