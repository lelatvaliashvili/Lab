namespace LibraryBookService.Models.Response
{
    public class ErrorResponse
    {
        public List<ErrorDetails> Errors { get; set; } = new List<ErrorDetails>();
    }
}
