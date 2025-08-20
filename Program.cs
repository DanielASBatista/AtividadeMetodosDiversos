using System;
using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;

namespace MyApp
{
    internal class Program
    {
        static List<Funcionario> lista = new List<Funcionario>();
        static void Main(string[] args)
        {
            CriarLista();
            ObterPorId();
        }

        public static void ObterPorId(){
            lista = lista.FindAll(x => x.Id == 2);
            ExibirLista();            
        }
        public static void CriarLista()
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.CPF = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.CPF = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.CPF = "135792468";
            f3.DataAdmissao = DateTime.Parse("01/11/2003");
            f3.Salario = 70.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.CPF = "246813579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.CPF = "246813579";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Roger Guedes";
            f6.CPF = "246813579";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f6);
        }

        public static void ExibirLista(){
            string dados = "";
            for (int i = 0; i < lista.Count; i++){
                dados +="=====================================\n";
                dados += String.Format("Id: {0}\n", lista[i].Id);
                dados += String.Format("Nome: {0}\n ",lista[i].Nome);
                dados += String.Format("CPF: {0}\n",lista [i].CPF);
                dados += String.Format("Admissão: {0:dd/MM/yyyy}\n", lista[i].DataAdmissao);
                dados += String.Format("Salario: {0:c2}\n", lista[i].Salario);
                dados += String.Format("Tipo:{0}\n", lista[i].TipoFuncionario);
                dados +="=====================================\n";
            }
            Console.WriteLine(dados);
        }
    }
}