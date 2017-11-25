using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Repositorios
{
    public class EmpresaRepositorio : RepositorioBase<Empresa>, IEmpresaRepositorio
    {
        public override Task<ObservableCollection<Empresa>> GetAllAsNoTrackingAsync()
        {
            return base.GetAllAsNoTrackingAsync();
            return Task.Run(() => 
            {
                return new ObservableCollection<Empresa>()
                {
                    new Empresa()
                    {
                        Id = 1,
                        Bairro = "Santa Cecília",
                        Cep = 94475808,
                        Cnpj = "72247876000148",
                        InscEstadual = "9664394039",
                        Logradouro = "Beco do Aristides",
                        Numero = "910",
                        RazaoSocial = "Mirella e João Telecom ME"
                    },
                    new Empresa()
                    {
                        Id = 2,
                        Bairro = "Pedreira",
                        Cep = 66080500,
                        Cnpj = "54978694000165",
                        InscEstadual = "157705773",
                        Logradouro = "Vila São Judas Tadeu",
                        Numero = "624",
                        RazaoSocial = "Caroline e Betina Entregas Expressas ME"
                    },
                    new Empresa()
                    {
                        Id = 3,
                        Bairro = "Pernambués",
                        Cep = 41100086,
                        Cnpj = "46297426000150",
                        InscEstadual = "88400712",
                        Logradouro = "Rua Lamarão",
                        Numero = "184",
                        RazaoSocial = "Nathan e Sophie Financeira Ltda"
                    },
                    new Empresa()
                    {
                        Id = 4,
                        Bairro = "Parque Santa Madalena",
                        Cep = 03983170,
                        Cnpj = "72662159000182",
                        InscEstadual = "841969100265",
                        Logradouro = "Rua Ubim",
                        Numero = "295",
                        RazaoSocial = "Kaique e Iago Assessoria Jurídica ME"
                    },
                    new Empresa()
                    {
                        Id = 5,
                        Bairro = "Giardino D' Itália",
                        Cep = 13256222,
                        Cnpj = "48125496000156",
                        InscEstadual = "421812062740",
                        Logradouro = "Rua Tito",
                        Numero = "476",
                        RazaoSocial = "Juan e Caio Fotografias Ltda"
                    },
                    new Empresa()
                    {
                        Id = 6,
                        Bairro = "Grajaú",
                        Cep = 36052260,
                        Cnpj = "19421097000134",
                        InscEstadual = "4780563276807",
                        Logradouro = "Travessa João Brun",
                        Numero = "754",
                        RazaoSocial = "Natália e Mariana Entregas Expressas Ltda"
                    },
                    new Empresa()
                    {
                        Id = 7,
                        Bairro = "Tiradentes",
                        Cep = 79042549,
                        Cnpj = "61321906000100",
                        InscEstadual = "280977140",
                        Logradouro = "Travessa Moana",
                        Numero = "623",
                        RazaoSocial = "Diogo e Raul Alimentos Ltda"
                    },
                    new Empresa()
                    {
                        Id = 8,
                        Bairro = "Jardim Batistão",
                        Cep = 79094460,
                        Cnpj = "46146882000107",
                        InscEstadual = "287872246",
                        Logradouro = "Rua Síria",
                        Numero = "279",
                        RazaoSocial = "Felipe e Débora Padaria ME"
                    },
                    new Empresa()
                    {
                        Id = 9,
                        Bairro = "Fradinhos",
                        Cep = 29042650,
                        Cnpj = "72495689000183",
                        InscEstadual = "419220968",
                        Logradouro = "Rua Professora Maria Acciolina Pereira",
                        Numero = "738",
                        RazaoSocial = "Emily e Davi Mudanças ME"
                    },
                };
            });
        }
    }
}
