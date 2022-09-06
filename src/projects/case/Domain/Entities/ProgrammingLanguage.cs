using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProgrammingLanguage : Entity
    {
        public string Name { get; set; } = null!;

        public ProgrammingLanguage(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ProgrammingLanguage()
        {

        }
    }
}
