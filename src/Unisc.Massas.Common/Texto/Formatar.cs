using System;

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
    }
}
