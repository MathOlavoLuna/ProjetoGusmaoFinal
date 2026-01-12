using Microsoft.EntityFrameworkCore;
using ProjetoGusmaoFinal.Classes;
using ProjetoGusmaoFinal.Data;
using ProjetoGusmaoFinal.Models;

namespace ProjetoGusmaoFinal.Services
{
    public class RegistrationService(CRUDService<Registrations> Entity, DataContext Context)
    {
        private readonly CRUDService<Registrations> _entity = Entity;
        private readonly DataContext _context = Context;

        public async Task<ApiResponse<Registrations>> PostRegistration(Registrations Registration)
        {
            ApiResponse<Registrations> Response = new();
            try
            {
                Registrations CreatedRegistration = await _entity.Post(Registration);
                Response.Data.Add(CreatedRegistration);
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
