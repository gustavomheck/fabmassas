using System;
using System.Windows.Input;
using Unisc.Massas.Core.Comandos;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class EntradaEstoqueViewModel : CadastroViewModelBase<Estoque>
    {
        private readonly IEstoqueRepositorio estoqueRepositorio;
        private readonly IProdutoRepositorio produtoRepositorio;

        public EntradaEstoqueViewModel(IEstoqueRepositorio estoqueRepositorio, IProdutoRepositorio produtoRepositorio) 
            : base(estoqueRepositorio, "Entrada de Produto no Estoque")
        {
            this.estoqueRepositorio = estoqueRepositorio;
            this.produtoRepositorio = produtoRepositorio;

            LimparDataValidadeCommand = new DelegateCommand(() => EntidadeSelecionada.DataVencimento = null);
        }

        public Produto[] Produtos { get; set; }
        public ICommand LimparDataValidadeCommand { get; set; }

        protected override void Carregar()
        {
            base.Carregar();

            Produtos = produtoRepositorio.GetAllAsArray();
        }
        
        protected override void Salvar()
        {
            EntidadeSelecionada.QuantDisponivel = EntidadeSelecionada.QuantComprada;
            EntidadeSelecionada.ValorProduto = 
                Convert.ToDecimal(Convert.ToDouble(EntidadeSelecionada.ValorUnidade) * EntidadeSelecionada.QuantComprada);

            base.Salvar();
        }
    }
}
