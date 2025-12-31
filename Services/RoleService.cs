using ProjetoGusmaoFinal.Classes;
using ProjetoGusmaoFinal.Models;

namespace ProjetoGusmaoFinal.Services
{
    public class RoleService(CRUDService<Roles> Entity)
    {
        private readonly CRUDService<Roles> _entity = Entity;

        public async Task<ApiResponse<Roles>> PostRole(Roles Role)
        {
            ApiResponse<Roles> Response = new();
            try
            {

                Roles CreatedRole = await _entity.Post(Role);
                Response.Data.Add(CreatedRole);
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
