using System;
using System.IO.Pipes;
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
            //ObterPorId();
            //ObterPorIdDigitado();
            //AdicionarFuncionario();
            //ObterPorSalario();
            ExemplosListasColecoes();
        }

        public static void ExemplosListasColecoes()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("****** Exemplos - Aula 03 Listas e Coleções ******");
            Console.WriteLine("==================================================");
            CriarLista();
            int opcaoEscolhida = 0;
            do
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("---Digite o número referente a opção desejada: ---");
                Console.WriteLine("1 - Obter Por Id");
                Console.WriteLine("2 - Adicionar funcionario");
                Console.WriteLine("3 - Obter por Id digitado");
                Console.WriteLine("4 - Obter por Salario digitado");
                Console.WriteLine("==================================================");
                Console.WriteLine("-----Ou tecle qualquer outro número para sair-----");
                Console.WriteLine("==================================================");
            
                opcaoEscolhida = int.Parse(Console.ReadLine());
                string mensagem = string.Empty;
                switch (opcaoEscolhida)
                {
                case 1:
                    ObterPorId();
                break;

                case 2:
                    AdicionarFuncionarioV2();
                break;

                case 3:
                    ObterPorIdDigitado();
                break;

                case 4:
                    ObterPorSalario();
                break;
                default:
                Console.WriteLine("Saindo do sistema....");
                break;
            }
        } while (opcaoEscolhida >= 1 && opcaoEscolhida <= 10);
            Console.WriteLine("==================================================");
            Console.WriteLine("* Obrigado por utilizar o sistema e volte sempre *");
            Console.WriteLine("==================================================");
} 
        public static void AdicionarFuncionarioV2(){
            Funcionario f = new Funcionario();

            Console.WriteLine("Digite o nome: ");
            f.Nome = Console.ReadLine();
            Console.WriteLine("Digite o salário: ");
            f.Salario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Digite o CPF: ");
            f.CPF = Console.ReadLine();
            Console.WriteLine("Digite a data de admissão: ");
            f.DataAdmissao = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("insira o tipo de contrato:\n1.CLT\n2.Aprendiz");
            f.TipoFuncionario = (TipoFuncionarioEnum)decimal.Parse(Console.ReadLine()); 

            if (string.IsNullOrEmpty(f.Nome)){
                Console.WriteLine("O nome deve ser preenchido");
                return;
            }

            else if (f.Salario == 0){
                Console.WriteLine("Valor do salário não pode ser 0");
                return;
            }

            else{
                lista.Add(f);
                ExibirLista();
            }
}
        public static void ObterPorIdDigitado(){
            Console.WriteLine("Digite o Id: ");
            int id = int.Parse(Console.ReadLine());
            Funcionario fbusca = lista.Find(x => x.Id == id);

            if (fbusca == null){
                Console.WriteLine("Não encontrado");
            }
            else
                Console.WriteLine($"Funcionario encontrado: {fbusca.Nome}");
        }

        public static void ObterPorSalario(){
            Console.WriteLine("Digite o valor minimo");
            decimal Salario = decimal.Parse(Console.ReadLine());
            lista = lista.FindAll(x => x.Salario == Salario);
            ExibirLista();

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