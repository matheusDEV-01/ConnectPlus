using ConnectPlus.WebAPI.Models;

namespace ConnectPlus.WebAPI.Interfaces;

public interface IContatoRepository
{
    void Cadastrar(Contato NovoContato);
    List<Contato> Listar();
    void Delete(Guid id);
    Contato BuscarPorId(Guid id);
    void Atualizar(Guid id, Contato contato);
}
