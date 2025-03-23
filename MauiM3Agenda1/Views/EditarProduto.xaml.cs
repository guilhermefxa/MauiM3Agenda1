using MauiM3Agenda1.Models;
namespace MauiM3Agenda1.Views;

public partial class EditarProduto : ContentPage
{
    // Construtor da classe, inicializa os componentes da interface
    public EditarProduto()
    {
        InitializeComponent();
    }

    // M�todo ass�ncrono chamado ao clicar no bot�o da Toolbar
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Obt�m o produto atualmente vinculado ao contexto de dados da p�gina
            Produto produto_anexado = BindingContext as Produto;

            // Cria um novo objeto Produto com os dados atualizados
            Produto p = new Produto
            {
                Id = produto_anexado.Id, // Mant�m o mesmo ID do produto original
                Descricao = txt_descricao.Text, // Atualiza a descri��o com o valor do Entry
                Quantidade = Convert.ToDouble(txt_quantidade.Text), // Converte a quantidade para double
                Preco = Convert.ToDouble(txt_preco.Text) // Converte o pre�o para double
            };

            // Atualiza o produto no banco de dados
            await App.Db.Update(p);

            // Exibe um alerta informando que o registro foi atualizado com sucesso
            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");

            // Retorna para a p�gina anterior
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            // Exibe um alerta caso ocorra um erro
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
