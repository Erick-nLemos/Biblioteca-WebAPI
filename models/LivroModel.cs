namespace FirstAPICSharp.models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        
        // Relação 1 livro para 1 autor
        public AutorModel Autor { get; set; }
    }
}
