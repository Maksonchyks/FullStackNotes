using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFullStackNotes.Domain.Entities
{
    public class Note
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public Guid UserId { get; private set; }
        public User? User { get; private set; }
        public Note(string title, string? description, Guid userId)
        {
            Title = title;
            Description = description;
            UserId = userId;
        }

        public void ChangeTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Заголовок не може бути порожнім.", nameof(newTitle));

            Title = newTitle;
        }
        public void ChangeDescription(string? newDescription)
        {
            Description = newDescription; 
        }
    }
}
