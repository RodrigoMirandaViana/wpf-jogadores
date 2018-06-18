using Atleta.DAO;
using Atleta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Atleta.View
{
    /// <summary>
    /// Lógica interna para formCadastrarAtleta.xaml
    /// </summary>
    public partial class formCadastrarAtleta : Window
    {
        private static Context ctx = Singleton.Instance.Context;
        private Model.Atleta c;
        public formCadastrarAtleta()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ListarAtletas();
        }

        private void ListarAtletas()
        {
            var consulta = ctx.Atletas;
            dgDados.ItemsSource = consulta.ToList();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            c = new Model.Atleta
            {
                Nome = txtNome.Text,
                Posicao = txtPosicao.Text,
                Time = txtTime.Text
            };

            if (AtletaDAO.AdicionarAtleta(c))
            {
                MessageBox.Show("O atleta foi adicionado com sucesso!", "Agenda",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Não é possível adicionar o atleta!", "Agenda",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            c.Nome = txtNome.Text;
            c.Posicao = txtPosicao.Text;
            c.Time = txtTime.Text;
            if (AtletaDAO.RemoverAtleta(c))
            {
                MessageBox.Show("O atleta foi removido com sucesso!", "Atleta",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            // buscar nome
            if (txtNome.Text.Trim().Count() > 0)
            {
                try
                {
                    var consulta = from c in ctx.Atletas
                                   where c.nome.Contains(txtNome.Text)
                                   select c;
                    dgDados.ItemsSource = consulta.ToList();
                }
                catch
                {

                }
            }
            // buscar posição
            if (txtPosicao.Text.Trim().Count() > 0)
            {
                try
                {
                    var consulta = from c in ctx.Atletas
                                   where c.telefone.Contains(txtPosicao.Text)
                                   select c;
                    dgDados.ItemsSource = consulta.ToList();
                }
                catch
                {

                }
            }
            // buscar time
            if (txtTime.Text.Trim().Count() > 0)
            {
                try
                {
                    var consulta = from c in ctx.Atletas
                                   where c.email.Contains(txtTime.Text)
                                   select c;
                    dgDados.ItemsSource = consulta.ToList();
                }
                catch
                {

                }
            }
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            c.Nome = txtNome.Text;
            c.Posicao = txtPosicao.Text;
            c.Time = txtTime.Text;

            if (AtletaDAO.AlterarAtleta(c))
            {
                MessageBox.Show("O atleta foi alterado com sucesso!", "Atleta",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Não é possível alterar o atleta!", "Atleta",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtNome_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

