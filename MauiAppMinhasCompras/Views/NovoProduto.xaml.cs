using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Verifica se todos os campos estão preenchidos
            if (string.IsNullOrEmpty(txt_descricao.Text) ||
                string.IsNullOrEmpty(txt_quantidade.Text) ||
                string.IsNullOrEmpty(txt_preco.Text) ||
                txt_categoria.SelectedItem == null)
            {
                await DisplayAlert("Erro", "Todos os campos devem ser preenchidos", "OK");
                return;
            }

            // Criação do novo produto com os dados inseridos
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text),
                Categoria = txt_categoria.SelectedItem.ToString() // Captura a categoria selecionada
            };

            // Insere o produto no banco de dados
            await App.Db.Insert(p);

            // Exibe mensagem de sucesso
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");

            // Volta para a tela anterior
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            // Exibe mensagem de erro caso algum problema ocorra
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
