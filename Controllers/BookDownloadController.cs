using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoGusmaoFinal.Services;

namespace ProjetoGusmaoFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookDownloadController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookDownloadController(BookService BookService)
        {
            _bookService = BookService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadPdf(int Id)
        {
            try
            {
                var Response = await _bookService.GetBookWithPdf(Id);

                if (!Response.Success || Response.Data == null || Response.Data.Count == 0)
                {
                    return NotFound("Livro não encontrado.");
                }

                var Book = Response.Data[0];

                if (Book.PdfFile == null || Book.PdfFile.Length == 0)
                {
                    return NotFound("PDF não encontrado para este livro.");
                }

                return File(Book.PdfFile, "application/pdf", Book.PdfFileName ?? "livro.pdf");
            }
            catch (Exception Ex)
            {
                return StatusCode(500, $"Erro ao baixar PDF: {Ex.Message}");
            }
        }
    }
}