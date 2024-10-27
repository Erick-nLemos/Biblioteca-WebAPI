using System.Text.Json.Serialization;

namespace FirstAPICSharp.models
{
    public class AutorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName {  get; set; }


        // Relação 1 autor para N livros
        [JsonIgnore]
        public ICollection<LivroModel> Livros { get; set; }
    }
}
