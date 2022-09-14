using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProgrammingLanguage : Entity
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<ProgrammingTechnology> ProgrammingTechnologies { get; set; }

        public ProgrammingLanguage(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }

        public ProgrammingLanguage()
        {
            ProgrammingTechnologies = new HashSet<ProgrammingTechnology>();
        }
    }
}
