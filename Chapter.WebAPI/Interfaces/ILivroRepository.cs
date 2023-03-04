using Chapter.WebAPI.Models;

namespace Chapter.WebAPI.Interfaces
{
    public interface ILivroRepository
    {
        List<Livro> Ler();

        void Cadastrar(Livro usuario);

        void Atualizar(int id, Livro usuario);

        void Deletar(int id);

        Livro BuscarPorId(int id);

        Livro BuscarPorTitulo(string titulo);
    }
}
