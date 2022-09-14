using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProgrammingTechnology : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }

        public ProgrammingTechnology(int id, int languageId, string name) : this()
        {
            Id = id;
            Name = name;
            ProgrammingLanguageId = languageId;
        }

        public ProgrammingTechnology()
        {

        }
    }
}
