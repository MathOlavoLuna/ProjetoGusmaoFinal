using ProjetoGusmaoFinal.Classes;
using ProjetoGusmaoFinal.Models;

namespace ProjetoGusmaoFinal.Services
{
    public class NewService(CRUDService<News> Entity)
    {
        private readonly CRUDService<News> _entity = Entity;

        public async Task<ApiResponse<News>> PostNew(News New)
        {
            ApiResponse<News> Response = new();
            try
            {
                News CreatedNew = await _entity.Post(New);
                Response.Data.Add(CreatedNew);
                Response.Success = true;
            }
            catch (Exception Ex)
            {
                Response.Message = Ex.Message;
            }
            return Response;
        }
        public async Task<ApiResponse<News>> GetNews()
        {
            ApiResponse<News> Response = new();
            try
            {
                List<News> AllNews = await _entity.GetAll();
                Response.Data = AllNews;
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
