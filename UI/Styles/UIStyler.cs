using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsKyotoDesk.UI.Styles
{

    public static class UIStyler
    {
        //Bloquear a Edição no DataGridView
        public static void ConfigDataGridView(params DataGridView[] dataGridViews)
        {
            foreach (var dataGridView in dataGridViews)
            {
                dataGridView.ReadOnly = true; // Bloqueia edição
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Seleciona a linha inteira
                dataGridView.AllowUserToAddRows = false; // Remove linha vazia no final
                dataGridView.AllowUserToDeleteRows = false; // Impede exclusão de linhas
                dataGridView.AllowUserToOrderColumns = false; // Impede mover colunas
                dataGridView.AllowUserToResizeColumns = false; // Impede redimensionamento
                dataGridView.AllowUserToResizeRows = false; // Impede redimensionamento de linhas
                ApplyStyleDataGridView(dataGridView);
            }
            
        }

        //estilização para o DataGridView
        public static void ApplyStyleDataGridView(DataGridView dgv)
        {
            // Estilo Geral do DataGridView
            dgv.BackgroundColor = Color.White; // Cor de fundo mais limpa
            dgv.BorderStyle = BorderStyle.None; // Remove bordas padrão
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245); // Cor das linhas alternadas
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204); // Cor de fundo ao selecionar
            dgv.DefaultCellStyle.SelectionForeColor = Color.White; // Cor da fonte ao selecionar
            dgv.DefaultCellStyle.BackColor = Color.White; // Cor de fundo da célula
            dgv.DefaultCellStyle.ForeColor = Color.Black; // Cor da fonte
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9); // Fonte moderna e limpa
            dgv.DefaultCellStyle.Padding = new Padding(10); // Espaçamento interno nas células

            // Estilo do Cabeçalho
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204); // Azul suave para o cabeçalho
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.ColumnHeadersHeight = 45; // Aumenta a altura do cabeçalho para uma aparência mais elegante

            // Estilo das Linhas
            dgv.RowTemplate.Height = 45; // Linhas com altura personalizada para um layout mais espaçado
            dgv.RowTemplate.DividerHeight = 1; // Espaçamento entre as linhas
            dgv.RowHeadersVisible = false; // Remove o cabeçalho das linhas
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204); // Cor de fundo ao selecionar linha
            dgv.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            dgv.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9);

            // Ajuste do tamanho das colunas
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajuste automático das colunas
            dgv.AutoResizeColumns(); // Redimensiona as colunas de acordo com o conteúdo
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Ajuste automático de altura das linhas
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing; // Desabilita o redimensionamento da coluna de cabeçalho

            // Adiciona uma sombra suave nas células para dar um efeito de profundidade
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            //dgv.DefaultCellStyle.BorderColor = Color.FromArgb(220, 220, 220); // Cor da borda suave

            // Habilitar a rolagem automática de linha
            dgv.ScrollBars = ScrollBars.Vertical;

            // Desabilitar a edição direta nas células
            dgv.ReadOnly = true;
        }

        //Estilizar os TextBox
        public static void ApplyStyleTextBox(params System.Windows.Forms.TextBox[] TextBoxes)
        {
            foreach (var textBox in TextBoxes)
            {
                // Estilo Geral do TextBox
                textBox.BackColor = Color.White; // Fundo branco para simplicidade
                textBox.ForeColor = Color.FromArgb(50, 50, 50); // Texto em cinza escuro
                textBox.BorderStyle = BorderStyle.FixedSingle; // Bordas finas e discretas
                textBox.Font = new Font("Segoe UI", 16); // Fonte moderna e legível
                textBox.Padding = new Padding(5); // Espaçamento interno para conforto visual

                // Evento para estilizar o foco
                textBox.Enter += (s, e) =>
                {
                    textBox.BackColor = Color.FromArgb(240, 248, 255); // Fundo azul claro ao focar
                    textBox.ForeColor = Color.Black; // Texto em preto ao focar
                    textBox.BorderStyle = BorderStyle.Fixed3D; // Realça as bordas ao focar
                };

                // Evento para voltar ao estilo original ao perder o foco
                textBox.Leave += (s, e) =>
                {
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Color.FromArgb(50, 50, 50);
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                };
            }
        }

        public static void ApplyStyleButton(params System.Windows.Forms.Button[] buttons)
        {
            foreach (var button in buttons)
            {
                // Estilo Geral do Botão
                button.BackColor = Color.White; // Fundo branco
                button.ForeColor = Color.Black; // Texto preto
                button.FlatStyle = FlatStyle.Flat; // Remove o relevo padrão
                button.FlatAppearance.BorderSize = 2; // Define a espessura da borda
                button.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#33334C"); // Cor da borda
                button.Font = new Font("Segoe UI", 10, FontStyle.Regular); // Fonte moderna e legível

                // Evento para estilizar o foco
                button.MouseEnter += (s, e) =>
                {
                    button.BackColor = Color.FromArgb(240, 248, 255); // Fundo azul claro ao passar o mouse
                    button.ForeColor = Color.Black; // Texto permanece preto
                };

                // Evento para voltar ao estilo original ao remover o foco
                button.MouseLeave += (s, e) =>
                {
                    button.BackColor = Color.White;
                    button.ForeColor = Color.Black;
                };
            }
        }


    }
}
