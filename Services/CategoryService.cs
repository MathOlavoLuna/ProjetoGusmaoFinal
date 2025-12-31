using ProjetoGusmaoFinal.Classes;
using ProjetoGusmaoFinal.Models;

namespace ProjetoGusmaoFinal.Services
{
    public class CategoryService(CRUDService<Categories> Entity)
    {
        private readonly CRUDService<Categories> _entity = Entity;

        public async Task<ApiResponse<Categories>> PostCategory(Categories Category)
        {
            ApiResponse<Categories> Response = new();
            try
            {
                Categories CreatedCategory = await _entity.Post(Category);
                Response.Data.Add(CreatedCategory);
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
