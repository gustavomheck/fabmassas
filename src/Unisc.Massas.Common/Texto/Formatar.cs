using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Unisc.Massas.Core.Texto
{
    public static class Formatar
    {
        /// <summary>
        /// Formata a string recebida em um Cep.
        /// </summary>
        /// <param name="cep">o número a ser formatado.</param>
        /// <returns>A string formatada em um Cep.</returns>
        public static string Cep(int? cep)
        {
            if (!cep.HasValue) return "";

            var texto = cep.ToString().PadLeft(8, '0');

            texto = texto.PadLeft(8, '0');

            if (texto.Length == 8)
                return $"{texto.Substring(0, 5)}-{texto.Substring(5)}";

            return texto;
        }

        /// <summary>
        /// Formata a string recebida em um CNPJ ou CPF dependendo do tamanho.
        /// </summary>
        /// <param name="cnpjCpf">A string a ser formatada.</param>
        /// <returns>A string formatada em CNPJ ou CPF.</returns>
        public static string CnpjCpf(string cnpjCpf)
        {
            if (String.IsNullOrEmpty(cnpjCpf)) return cnpjCpf ?? "";

            if (cnpjCpf.Length == 14)
                return $"{cnpjCpf.Substring(0, 2)}.{cnpjCpf.Substring(2, 3)}.{cnpjCpf.Substring(5, 3)}/{cnpjCpf.Substring(8, 4)}-{cnpjCpf.Substring(12, 2)}";

            if (cnpjCpf.Length == 11)
                return $"{cnpjCpf.Substring(0, 3)}.{cnpjCpf.Substring(3, 3)}.{cnpjCpf.Substring(6, 3)}-{cnpjCpf.Substring(9, 2)}";

            return cnpjCpf;
        }

        /// <summary>
        /// Formata um número de telefone.
        /// </summary>
        /// <param name="telefone">O número de telefone a formatar.</param>
        /// <returns>O telefone formatado.</returns>
        public static string Telefone(int telefone)
        {
            if (telefone == 0) return "";

            string tel = telefone.ToString();

            if (tel.Length == 8)
                return String.Format("{0}-{1}", tel.Substring(0, 4), tel.Substring(4));

            if (tel.Length == 9)
                return String.Format("{0}-{1}", tel.Substring(0, 5), tel.Substring(4));

            return "";
        }

        public static void MascaraTelefoneKeyUp(TextBox tb, ref KeyEventArgs e)
        {
            if ((e.Key != Key.Back || e.Key != Key.Enter || e.Key != Key.Tab) && tb.Text.Length == 11)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Back && tb.Text.Length == 5)
            {
                tb.Text = tb.Text.Substring(0, 4);
                tb.SelectionStart = 4;
            }
            else if (tb.Text.Length == 4)
            {
                tb.Text += "-";
                tb.SelectionStart = 5;
            }
            else if (tb.Text.Length == 9)
            {
                string aux = tb.Text.Replace("-", "");
                tb.Text = aux.Substring(0, 4) + "-" + aux.Substring(4);
                tb.SelectionStart = 9;
            }
            else if (tb.Text.Length == 10)
            {
                string aux = tb.Text.Replace("-", "");
                tb.Text = aux.Substring(0, 5) + "-" + aux.Substring(5);
                tb.SelectionStart = 10;
            }
        }

        public static void MascaraTelefoneTextChanged(TextBox tb)
        {
            if (!tb.Text.Contains("-"))
            {
                if (tb.Text.Length == 8)
                    tb.Text = tb.Text.Insert(4, "-");
                else if (tb.Text.Length == 9)
                    tb.Text = tb.Text.Insert(5, "-");
            }
        }
    }
}
