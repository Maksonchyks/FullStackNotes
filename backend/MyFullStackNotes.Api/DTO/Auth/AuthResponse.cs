namespace MyFullStackNotes.Api.DTO.Auth
{
    public class AuthResponse
    {
        public required string Token { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
    }
}
