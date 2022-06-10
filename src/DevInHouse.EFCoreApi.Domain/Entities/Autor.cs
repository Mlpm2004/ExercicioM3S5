using DevInHouse.EFCoreApi.Domain.Validations;
using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace DevInHouse.EFCoreApi.Core.Entities
{
    public class Autor : Entity
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        [JsonIgnore]
        public ICollection<Livro> Livros { get; private set; }

        public Autor(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
        public Autor(int id, string nome, string sobrenome)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public ValidationResult Validar()
        {
            AutorValidation? autorValidation = new AutorValidation();
            autorValidation.ValidateAutor();
            ValidationResult? result = autorValidation.Validate(this);

            return result;
        }
    }
}