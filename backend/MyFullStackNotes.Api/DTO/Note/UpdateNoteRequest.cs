namespace MyFullStackNotes.Api.DTO.Note
{
    public class UpdateNoteRequest
    {
        public string? NewTitle { get; set; }
        public required string Newdescription { get; set; }
    }
}
