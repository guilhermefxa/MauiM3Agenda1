using MauiM3Agenda1.Models;
namespace MauiM3Agenda1.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    // M�todo ass�ncrono acionado quando o usu�rio clica no bot�o da Toolbar.
    // M�todo ass�ncrono acionado quando o usu�rio clica no bot�o da Toolbar.
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Cria um novo objeto Produto e preenche seus atributos com os valores dos campos de entrada (TextBox).
            Produto p = new Produto
            {
                // Obt�m a descri��o do produto digitada pelo usu�rio.
                Descricao = txt_descricao.Text,

                // Converte o valor do campo de quantidade (que � uma string) para um n�mero decimal.
                Quantidade = Convert.ToDouble(txt_quantidade.Text),

                // Converte o valor do campo de pre�o (que tamb�m � uma string) para um n�mero decimal.
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            // Chama o m�todo de inser��o no banco de dados de forma ass�ncrona, aguardando sua conclus�o.
            await App.Db.Insert(p);

            // Exibe uma mensagem de sucesso ao usu�rio informando que o registro foi inserido.
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");
        }
        catch (Exception ex)  // Captura qualquer erro que possa ocorrer durante o processo.
        {
            // Caso ocorra um erro, exibe um alerta com a mensagem de erro para o usu�rio.
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

}