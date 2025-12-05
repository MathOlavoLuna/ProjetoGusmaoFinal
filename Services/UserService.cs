using ProjetoGusmaoFinal.Classes;
using ProjetoGusmaoFinal.Data;
using ProjetoGusmaoFinal.Models;

namespace ProjetoGusmaoFinal.Services
{
    public class UserService(CRUDService<Users> Entity)
    {
        private readonly CRUDService<Users> _entity = Entity;

        public async Task<ApiResponse<Users>> PostUser(Users User)
        {
            ApiResponse<Users> Response = new();
            try
            {

                Users CreatedUser = await _entity.Post(User);
                Response.Data.Add(CreatedUser);
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
