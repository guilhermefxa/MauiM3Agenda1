using MauiM3Agenda1.Models;
namespace MauiM3Agenda1.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    // Método assíncrono acionado quando o usuário clica no botão da Toolbar.
    // Método assíncrono acionado quando o usuário clica no botão da Toolbar.
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Cria um novo objeto Produto e preenche seus atributos com os valores dos campos de entrada (TextBox).
            Produto p = new Produto
            {
                // Obtém a descrição do produto digitada pelo usuário.
                Descricao = txt_descricao.Text,

                // Converte o valor do campo de quantidade (que é uma string) para um número decimal.
                Quantidade = Convert.ToDouble(txt_quantidade.Text),

                // Converte o valor do campo de preço (que também é uma string) para um número decimal.
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            // Chama o método de inserção no banco de dados de forma assíncrona, aguardando sua conclusão.
            await App.Db.Insert(p);

            // Exibe uma mensagem de sucesso ao usuário informando que o registro foi inserido.
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");
        }
        catch (Exception ex)  // Captura qualquer erro que possa ocorrer durante o processo.
        {
            // Caso ocorra um erro, exibe um alerta com a mensagem de erro para o usuário.
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

}