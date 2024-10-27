using FirstAPICSharp.Migrations;

namespace FirstAPICSharp.models
{
    public class ResponseModel<T>
    {
        public T? Dados{get; set;} // O '?' indicar que pode ser nulo
        public string Mensagem { get; set; } = string.Empty;
        public bool Status {  get; set; } = true;
    }
}
