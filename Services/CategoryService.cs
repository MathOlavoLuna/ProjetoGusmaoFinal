using ProjetoGusmaoFinal.Classes;
using ProjetoGusmaoFinal.Models;

namespace ProjetoGusmaoFinal.Services
{
    public class CategoryService
    {
        private readonly CRUDService<Category> _crudService;

        public CategoryService(CRUDService<Category> CrudService)
        {
            _crudService = CrudService;
        }

        public async Task<ApiResponse<Category>> GetAllCategories()
        {
            try
            {
                var Categories = await _crudService.GetAll();

                return new ApiResponse<Category>
                {
                    Success = true,
                    Data = Categories
                };
            }
            catch (Exception Ex)
            {
                return new ApiResponse<Category>
                {
                    Success = false,
                    Message = $"Erro: {Ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<Category>> GetCategoryById(int Id)
        {
            try
            {
                var Category = await _crudService.Get(Id);

                if (Category != null)
                {
                    return new ApiResponse<Category>
                    {
                        Success = true,
                        Data = new List<Category> { Category }
                    };
                }

                return new ApiResponse<Category>
                {
                    Success = false,
                    Message = "Categoria não encontrada."
                };
            }
            catch (Exception Ex)
            {
                return new ApiResponse<Category>
                {
                    Success = false,
                    Message = $"Erro: {Ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<Category>> PostCategory(Category NewCategory)
        {
            try
            {
                var Result = await _crudService.Post(NewCategory);

                return new ApiResponse<Category>
                {
                    Success = true,
                    Message = "Categoria criada com sucesso!",
                    Data = new List<Category> { Result }
                };
            }
            catch (Exception Ex)
            {
                return new ApiResponse<Category>
                {
                    Success = false,
                    Message = $"Erro: {Ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<Category>> UpdateCategory(Category Category)
        {
            try
            {
                var Result = await _crudService.Put(Category);

                return new ApiResponse<Category>
                {
                    Success = true,
                    Message = "Categoria atualizada com sucesso!",
                    Data = new List<Category> { Result }
                };
            }
            catch (Exception Ex)
            {
                return new ApiResponse<Category>
                {
                    Success = false,
                    Message = $"Erro: {Ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<Category>> DeleteCategory(int Id)
        {
            try
            {
                var Category = await _crudService.Get(Id);

                if (Category == null)
                {
                    return new ApiResponse<Category>
                    {
                        Success = false,
                        Message = "Categoria não encontrada."
                    };
                }

                await _crudService.Delete(Category);

                return new ApiResponse<Category>
                {
                    Success = true,
                    Message = "Categoria deletada com sucesso!"
                };
            }
            catch (Exception Ex)
            {
                return new ApiResponse<Category>
                {
                    Success = false,
                    Message = $"Erro: {Ex.Message}"
                };
            }
        }
    }
}