namespace SuficienciaWebII.Services
{
    public class ValidacoesService : IValidacoesService
    {
        // Outro método de validar o model que vem pela [ComandasController] método [post], naquela classe estou validando pelas annotations do proprio
        // MVC, utilizando dataAnnotation, este método não está inutilizado, apenas outra demonstração mais trivial de validação
        //
        // public void ValidarCamposCadastro(CadastroComandaModel model)
        // {
        //     if (model.IdUsuario <= 0)
        //         throw new ValidacaoException("Campo 'IdUsuario' deve ser maior que zero.");
        //
        //     if (string.IsNullOrWhiteSpace(model.NomeUsuario))
        //         throw new ValidacaoException("Campo 'NomeUsuario' deve ser preenchido.");
        //
        //     if (string.IsNullOrWhiteSpace(model.TelefoneUsuario))
        //         throw new ValidacaoException("Campo 'TelefoneUsuario' deve ser preenchido.");
        //
        //     if (model.TelefoneUsuario.Length != 11)
        //         throw new ValidacaoException("Campo 'TelefoneUsuario' deve conter 10 ou 11 digitos (ex: 47940028922 ou 4740028922).");
        //
        //     foreach (var produto in model.Produtos)
        //     {
        //         if (produto.Id <= 0)
        //             throw new ValidacaoException("Campo 'Produtos.Id' deve ser maior que zero.");
        //
        //         if (string.IsNullOrWhiteSpace(produto.Nome))
        //             throw new ValidacaoException("Campo 'Produtos.Nome' deve ser preenchido.");
        //
        //         if (produto.Preco <= 0)
        //             throw new ValidacaoException("Campo 'Produtos.Preco' deve ser maior que zero.");
        //     }
        // }
    }
}