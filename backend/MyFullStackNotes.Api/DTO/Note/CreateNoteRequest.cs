namespace MyFullStackNotes.Api.DTO.Note
{
    public class CreateNoteRequest
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required Guid UserId { get; set; }
    }
}
