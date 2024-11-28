using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsKyotoDesk.UI
{
    //Manipular Objetos na tela
    public static class ObjectControl
    {
        public static void ButtomDisabled(Button button, params Button[] notEnable)
        {
            button.Enabled=true;
            foreach (var buttonDisabled in notEnable)
            {
                buttonDisabled.Enabled = false;
            }

        }
        public static void TextBoxStringEmpty(params TextBox[] textBoxes)
        {
            foreach (var box in textBoxes)
            {
                box.Text = string.Empty;
            }

        }

        public static void ToggleVisibilityGroupBox(GroupBox mostrar, params GroupBox[] esconder)
        {
            mostrar.Visible = true;
            foreach (GroupBox grp in esconder)
            {
                grp.Visible = false;
            }

        }

        //Validação numérica 
        public static void TextBoxValidNumberKeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite números, backspace e ponto decimal
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Bloqueia mais de um ponto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        public static void TextBoxValidTelefoneTextChanged(object sender, EventArgs e, TextBox textBox)
        {
            // Remove qualquer formatação existente
            string input = new string(textBox.Text.Where(char.IsDigit).ToArray());

            if (input.Length > 11)
            {
                input = input.Substring(0, 11);
            }

            // Aplica o formato "(XX) XXXXX-XXXX"
            if (input.Length > 0)
            {
                if (input.Length <= 2)
                {
                    textBox.Text = $"({input}";
                }
                else if (input.Length <= 7)
                {
                    textBox.Text = $"({input.Substring(0, 2)}) {input.Substring(2)}";
                }
                else
                {
                    textBox.Text = $"({input.Substring(0, 2)}) {input.Substring(2, 5)}-{input.Substring(7)}";
                }

                // Coloca o cursor no final do texto
                textBox.SelectionStart = textBox.Text.Length;
            }
        }
    }

}
