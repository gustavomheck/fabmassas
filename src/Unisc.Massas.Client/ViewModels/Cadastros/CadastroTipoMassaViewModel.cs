using MaterialDesignThemes.Wpf;
using System;
using System.Windows.Input;
using Unisc.Massas.Client.Views;
using Unisc.Massas.Core;
using Unisc.Massas.Core.Comandos;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class CadastroTipoMassaViewModel : CadastroViewModelBase<TipoMassa>
    {
        private readonly IFormaRepositorio formaRepositorio;
        private readonly IMaquinaRepositorio maquinaRepositorio;

        public CadastroTipoMassaViewModel(ITipoMassaRepositorio tipoMassaRepositorio,
                                          IFormaRepositorio formaRepositorio,
                                          IMaquinaRepositorio maquinaRepositorio)
            : base(tipoMassaRepositorio, "Cadastro de Tipo de Massa")
        {
            this.formaRepositorio = formaRepositorio;
            this.maquinaRepositorio = maquinaRepositorio;

            CadastrarFormaCommand = new DelegateCommand(CadastrarForma);
            CadastrarMaquinaCommand = new DelegateCommand(CadastrarMaquina);

            Carregar();
        }

        private async void CadastrarForma()
        {
            var viewModel = new ModalViewModelBase<Forma>();
            var view = new AdicionarFormaView()
            {
                DataContext = viewModel
            };
            var result = (bool?)(await DialogHost.Show(view, "RootDialog"));

            if (result.HasValue && result.Value && formaRepositorio.Insert(viewModel.EntidadeSelecionada, out string msgErro))
            {
                Formas = formaRepositorio.GetAllAsArray();
                EntidadeSelecionada.Forma = viewModel.EntidadeSelecionada;
            }
        }

        private async void CadastrarMaquina()
        {
            var viewModel = new ModalViewModelBase<Maquina>();
            var view = new AdicionarMaquinaView()
            {
                DataContext = viewModel
            };
            var result = (bool?)(await DialogHost.Show(view, "RootDialog"));

            if (result.HasValue && result.Value && maquinaRepositorio.Insert(viewModel.EntidadeSelecionada, out string msgErro))
            {
                Maquinas = maquinaRepositorio.GetAllAsArray();
                EntidadeSelecionada.Maquina = viewModel.EntidadeSelecionada;
            }
        }

        public Forma[] Formas { get; set; }
        public Maquina[] Maquinas { get; set; }
        public ICommand CadastrarFormaCommand { get; set; }
        public ICommand CadastrarMaquinaCommand { get; set; }

        protected override void Carregar()
        {
            base.Carregar();

            ApplicationHelper.ExecuteAction(new Action(
                () =>
                {
                    Formas = formaRepositorio.GetAllAsArray();
                    Maquinas = maquinaRepositorio.GetAllAsArray();
                }));
        }
    }
}
