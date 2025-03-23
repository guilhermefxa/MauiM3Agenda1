using MauiM3Agenda1.Models;
using System.Collections.ObjectModel;

namespace MauiM3Agenda1.Views;

public partial class ListaProduto : ContentPage
{
    // Lista observ�vel de produtos para exibi��o na interface
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();

    // Construtor da p�gina, inicializa os componentes e define a fonte de dados da ListView
    public ListaProduto()
    {
        InitializeComponent();
        lst_produtos.ItemsSource = lista;
    }

    // M�todo chamado quando a p�gina aparece na tela
    protected async override void OnAppearing()
    {
        try
        {
            lista.Clear(); // Limpa a lista antes de carregar novos dados

            List<Produto> tmp = await App.Db.GetAll(); // Obt�m todos os produtos do banco de dados

            tmp.ForEach(i => lista.Add(i)); // Adiciona os produtos � lista observ�vel
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK"); // Exibe um alerta em caso de erro
        }
    }

    // M�todo chamado ao clicar no bot�o "Adicionar" na Toolbar
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Abre a tela para adicionar um novo produto
            Navigation.PushAsync(new Views.NovoProduto());
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK"); // Exibe um alerta em caso de erro
        }
    }

    // M�todo chamado quando o texto da barra de pesquisa � alterado
    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            string q = e.NewTextValue; // Obt�m o texto digitado
            lista.Clear(); // Limpa a lista antes de exibir os resultados da busca

            List<Produto> tmp = await App.Db.Search(q); // Busca os produtos pelo texto digitado

            tmp.ForEach(i => lista.Add(i)); // Adiciona os produtos encontrados � lista
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK"); // Exibe um alerta em caso de erro
        }
    }

    // M�todo chamado ao clicar no bot�o "Somar" na Toolbar
    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        double soma = lista.Sum(i => i.Total); // Calcula a soma total dos produtos

        string msg = $"O total � {soma:C}"; // Formata a mensagem com o total

        DisplayAlert("Total dos Produtos", msg, "OK"); // Exibe o total dos produtos
    }

    // M�todo chamado ao clicar na op��o "Remover" de um item da lista
    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            MenuItem selecionado = sender as MenuItem; // Obt�m o item selecionado

            Produto p = selecionado.BindingContext as Produto; // Obt�m o produto associado ao item

            bool confirm = await DisplayAlert(
                "Tem Certeza?", $"Remover {p.Descricao}?", "Sim", "N�o"); // Confirma��o antes da remo��o

            if (confirm)
            {
                await App.Db.Delete(p.Id); // Remove o produto do banco de dados
                lista.Remove(p); // Remove o produto da lista
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK"); // Exibe um alerta em caso de erro
        }
    }

    // M�todo chamado ao selecionar um item na lista
    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Produto p = e.SelectedItem as Produto; // Obt�m o produto selecionado

            // Navega para a tela de edi��o do produto e define o contexto de dados
            Navigation.PushAsync(new Views.EditarProduto
            {
                BindingContext = p,
            });
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK"); // Exibe um alerta em caso de erro
        }
    }
}
