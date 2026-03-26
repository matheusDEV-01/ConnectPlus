using ConnectPlus.WebAPI.Models;

namespace ConnectPlus.WebAPI.Interfaces;

public interface ITipoDeContatoRepository
{
    void Cadastrar(TipoDeContato tipoDeContato);
    List<TipoDeContato> Listar();
    void Delete(Guid id);
    TipoDeContato BuscarPorId(Guid id);
    void Atualizar(Guid id, TipoDeContato tipoDeContato);
}
