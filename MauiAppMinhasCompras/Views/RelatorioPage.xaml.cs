using MauiAppMinhasCompras.Models;
using System.Linq;

namespace MauiAppMinhasCompras.Views
{
    public partial class RelatorioPage : ContentPage
    {
        public RelatorioPage()
        {
            InitializeComponent();
            CarregarRelatorio();
        }

        // Método para carregar o relatório
        private async void CarregarRelatorio()
        {
            try
            {
                // Obtém todos os produtos do banco
                var produtos = await App.Db.GetAll();

                // Agrupa os produtos por categoria e calcula o total gasto em cada categoria
                var relatorio = produtos
                    .GroupBy(p => p.Categoria)
                    .Select(g => new
                    {
                        Categoria = g.Key,
                        TotalGasto = g.Sum(p => p.Preco * p.Quantidade)
                    })
                    .ToList();

                // Exibe os dados no ListView
                RelatorioListView.ItemsSource = relatorio;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
