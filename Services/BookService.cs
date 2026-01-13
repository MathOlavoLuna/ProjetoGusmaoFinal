// Services/BookService.cs
using Microsoft.EntityFrameworkCore;
using ProjetoGusmaoFinal.Classes;
using ProjetoGusmaoFinal.Data;
using ProjetoGusmaoFinal.Models;

namespace ProjetoGusmaoFinal.Services
{
    public class BookService
    {
        private readonly CRUDService<Books> _crudService;
        private readonly DataContext _context;

        public BookService(CRUDService<Books> CrudService, DataContext Context)
        {
            _crudService = CrudService;
            _context = Context;
        }

        public async Task<ApiResponse<Books>> PostBook(Books NewBook)
        {
            try
            {
                Console.WriteLine($"BookService.PostBook - Recebido livro: {NewBook.Name}");
                Console.WriteLine($"PDF File size: {NewBook.PdfFile?.Length ?? 0} bytes");

                _context.Books.Add(NewBook);

                Console.WriteLine("Chamando SaveChangesAsync...");
                int RowsAffected = await _context.SaveChangesAsync();
                Console.WriteLine($"Rows affected: {RowsAffected}");

                if (RowsAffected > 0)
                {
                    Console.WriteLine($"✓ Livro ID {NewBook.Id} salvo com sucesso!");
                    return new ApiResponse<Books>
                    {
                        Success = true,
                        Message = "Livro criado com sucesso!",
                        Data = new List<Books> { NewBook }
                    };
                }

                return new ApiResponse<Books>
                {
                    Success = false,
                    Message = "Erro ao criar livro."
                };
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"✗ ERRO no BookService.PostBook:");
                Console.WriteLine($"Message: {Ex.Message}");
                Console.WriteLine($"Stack: {Ex.StackTrace}");

                return new ApiResponse<Books>
                {
                    Success = false,
                    Message = $"Erro: {Ex.Message}"
                };
            }
        }

        // GET SEM o PDF (para listagem - mais rápido)
        public async Task<ApiResponse<Books>> GetAllBooks()
        {
            try
            {
                var Books = await _context.Books
                    .Select(b => new Books
                    {
                        Id = b.Id,
                        Name = b.Name,
                        Description = b.Description,
                        PdfFileName = b.PdfFileName,
                        PdfFileSize = b.PdfFileSize,
                        CoverImageUrl = b.CoverImageUrl,
                        AmazonUrl = b.AmazonUrl,
                        ISBN = b.ISBN,
                        CreatedAt = b.CreatedAt,
                        PublisherId = b.PublisherId,
                        Publisher = b.Publisher,
                        BookCategories = b.BookCategories
                        // NÃO INCLUIR PdfFile aqui!
                    })
                    .Include(b => b.Publisher)
                    .Include(b => b.BookCategories)
                        .ThenInclude(bc => bc.Category)
                    .OrderByDescending(b => b.CreatedAt)
                    .ToListAsync();

                return new ApiResponse<Books>
                {
                    Success = true,
                    Data = Books
                };
            }
            catch (Exception Ex)
            {
                return new ApiResponse<Books>
                {
                    Success = false,
                    Message = $"Erro: {Ex.Message}"
                };
            }
        }

        // GET COM o PDF (para download)
        public async Task<ApiResponse<Books>> GetBookWithPdf(int Id)
        {
            try
            {
                var Book = await _context.Books
                    .Include(b => b.Publisher)
                    .Include(b => b.BookCategories)
                        .ThenInclude(bc => bc.Category)
                    .FirstOrDefaultAsync(b => b.Id == Id);

                if (Book != null)
                {
                    return new ApiResponse<Books>
                    {
                        Success = true,
                        Data = new List<Books> { Book }
                    };
                }

                return new ApiResponse<Books>
                {
                    Success = false,
                    Message = "Livro não encontrado."
                };
            }
            catch (Exception Ex)
            {
                return new ApiResponse<Books>
                {
                    Success = false,
                    Message = $"Erro: {Ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<Books>> GetBookById(int Id)
        {
            try
            {
                var Book = await _context.Books
                    .Select(b => new Books
                    {
                        Id = b.Id,
                        Name = b.Name,
                        Description = b.Description,
                        PdfFileName = b.PdfFileName,
                        PdfFileSize = b.PdfFileSize,
                        CoverImageUrl = b.CoverImageUrl,
                        AmazonUrl = b.AmazonUrl,
                        ISBN = b.ISBN,
                        CreatedAt = b.CreatedAt,
                        PublisherId = b.PublisherId,
                        Publisher = b.Publisher,
                        BookCategories = b.BookCategories
                    })
                    .Include(b => b.Publisher)
                    .Include(b => b.BookCategories)
                        .ThenInclude(bc => bc.Category)
                    .FirstOrDefaultAsync(b => b.Id == Id);

                if (Book != null)
                {
                    return new ApiResponse<Books>
                    {
                        Success = true,
                        Data = new List<Books> { Book }
                    };
                }

                return new ApiResponse<Books>
                {
                    Success = false,
                    Message = "Livro não encontrado."
                };
            }
            catch (Exception Ex)
            {
                return new ApiResponse<Books>
                {
                    Success = false,
                    Message = $"Erro: {Ex.Message}"
                };
            }
        }
    }
}