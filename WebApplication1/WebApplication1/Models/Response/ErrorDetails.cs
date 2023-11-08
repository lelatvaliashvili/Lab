using System.Text.Json;

namespace LibraryBookService.Models.Response
{
    public class ErrorDetails
    {
        public string? FieldName { get; set; }

        public string? Message { get; set; }
    }
}
