namespace ConnectPlus.WebAPI.DTO;

public class ContatoDTO
{
    public string Nome { get; set; } = null!;
    public string Formadecontato { get; set; } = null!;
    public IFormFile? Imagem { get; set; }
    public string Tipodecontato { get; set; } = null!;
    public Guid IdTipoDeContato { get; set; }
}
