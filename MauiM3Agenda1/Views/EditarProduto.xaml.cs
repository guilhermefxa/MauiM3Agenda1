using MauiM3Agenda1.Models;
namespace MauiM3Agenda1.Views;

public partial class EditarProduto : ContentPage
{
    // Construtor da classe, inicializa os componentes da interface
    public EditarProduto()
    {
        InitializeComponent();
    }

    // Método assíncrono chamado ao clicar no botão da Toolbar
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Obtém o produto atualmente vinculado ao contexto de dados da página
            Produto produto_anexado = BindingContext as Produto;

            // Cria um novo objeto Produto com os dados atualizados
            Produto p = new Produto
            {
                Id = produto_anexado.Id, // Mantém o mesmo ID do produto original
                Descricao = txt_descricao.Text, // Atualiza a descrição com o valor do Entry
                Quantidade = Convert.ToDouble(txt_quantidade.Text), // Converte a quantidade para double
                Preco = Convert.ToDouble(txt_preco.Text) // Converte o preço para double
            };

            // Atualiza o produto no banco de dados
            await App.Db.Update(p);

            // Exibe um alerta informando que o registro foi atualizado com sucesso
            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");

            // Retorna para a página anterior
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            // Exibe um alerta caso ocorra um erro
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
