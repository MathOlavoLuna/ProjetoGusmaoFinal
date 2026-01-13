using ProjetoGusmaoFinal.Classes;
using ProjetoGusmaoFinal.Models;

namespace ProjetoGusmaoFinal.Services
{
    public class PublisherService
    {
        private readonly CRUDService<Publisher> _crudService;

        public PublisherService(CRUDService<Publisher> CrudService)
        {
            _crudService = CrudService;
        }

        public async Task<ApiResponse<Publisher>> GetAllPublishers()
        {
            try
            {
                var Publishers = await _crudService.GetAll();

                return new ApiResponse<Publisher>
                {
                    Success = true,
                    Data = Publishers
                };
            }
            catch (Exception Ex)
            {
                return new ApiResponse<Publisher>
                {
                    Success = false,
                    Message = $"Erro: {Ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<Publisher>> GetPublisherById(int Id)
        {
            try
            {
                var Publisher = await _crudService.Get(Id);

                if (Publisher != null)
                {
                    return new ApiResponse<Publisher>
                    {
                        Success = true,
                        Data = new List<Publisher> { Publisher }
                    };
                }

                return new ApiResponse<Publisher>
                {
                    Success = false,
                    Message = "Autor/Editora não encontrado."
                };
            }
            catch (Exception Ex)
            {
                return new ApiResponse<Publisher>
                {
                    Success = false,
                    Message = $"Erro: {Ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<Publisher>> PostPublisher(Publisher NewPublisher)
        {
            try
            {
                var Result = await _crudService.Post(NewPublisher);

                return new ApiResponse<Publisher>
                {
                    Success = true,
                    Message = "Autor/Editora criado com sucesso!",
                    Data = new List<Publisher> { Result }
                };
            }
            catch (Exception Ex)
            {
                return new ApiResponse<Publisher>
                {
                    Success = false,
                    Message = $"Erro: {Ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<Publisher>> UpdatePublisher(Publisher Publisher)
        {
            try
            {
                var Result = await _crudService.Put(Publisher);

                return new ApiResponse<Publisher>
                {
                    Success = true,
                    Message = "Autor/Editora atualizado com sucesso!",
                    Data = new List<Publisher> { Result }
                };
            }
            catch (Exception Ex)
            {
                return new ApiResponse<Publisher>
                {
                    Success = false,
                    Message = $"Erro: {Ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<Publisher>> DeletePublisher(int Id)
        {
            try
            {
                var Publisher = await _crudService.Get(Id);

                if (Publisher == null)
                {
                    return new ApiResponse<Publisher>
                    {
                        Success = false,
                        Message = "Autor/Editora não encontrado."
                    };
                }

                await _crudService.Delete(Publisher);

                return new ApiResponse<Publisher>
                {
                    Success = true,
                    Message = "Autor/Editora deletado com sucesso!"
                };
            }
            catch (Exception Ex)
            {
                return new ApiResponse<Publisher>
                {
                    Success = false,
                    Message = $"Erro: {Ex.Message}"
                };
            }
        }
    }
}