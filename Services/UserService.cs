using Microsoft.EntityFrameworkCore;
using ProjetoGusmaoFinal.Classes;
using ProjetoGusmaoFinal.Data;
using ProjetoGusmaoFinal.Models;

namespace ProjetoGusmaoFinal.Services
{
    public class UserService(CRUDService<Users> Entity, DataContext Context)
    {
        private readonly CRUDService<Users> _entity = Entity;
        private readonly DataContext _context = Context;

        public async Task<ApiResponse<Users>> GetUser(string Email, string Password)
        {
            ApiResponse<Users> Response = new();
            try
            {
                HashResponse ResponseHash = HashService.Crypt(Password);
                Users FoundUser = await _context.Users.FirstOrDefaultAsync(u => Email == u.Email) ?? new();
                Response.Data.Add(FoundUser);
                if (FoundUser.Password != ResponseHash.Hash) {
                    Response.Message = "Senha incorreta, tente novamente.";
                    return Response;
                }
                Response.Success = true;
            }
            catch (Exception Ex)
            {
                Response.Message = Ex.Message;
            }
            return Response;
        }
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
