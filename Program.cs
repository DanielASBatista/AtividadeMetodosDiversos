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
                Console.WriteLine("\n==================================================");
                Console.WriteLine("---Digite o número referente à opção desejada: ---");
                Console.WriteLine("1 - Obter por nome");
                Console.WriteLine("2 - Obter funcionarios recentes");
                Console.WriteLine("3 - Obter estatisticas");
                Console.WriteLine("4 - Cadastro de novo funcionário");
                Console.WriteLine("5 - Obter por nome");
                Console.WriteLine("6 - ");
                Console.WriteLine("7 - ");
                Console.WriteLine("8 - Validar Salario Admissao");
                Console.WriteLine("==================================================");
                Console.WriteLine("-----Ou tecle qualquer outro número para sair-----");
                Console.WriteLine("==================================================");

                opcaoEscolhida = int.Parse(Console.ReadLine());
                string mensagem = string.Empty;
                switch (opcaoEscolhida)
                {
                    case 1:
                        ObterPorNome();
                        break;

                    case 2:
                        ObterFuncionariosRecentes();
                        break;

                    case 3:
                        ObterEstatisticas();
                        break;

                    case 4:
                        AdicionarFuncionarioV2();
                        break;
                    case 5:
                        ObterPorNome();
                        break;
                    case 6:
                        ObterFuncionariosRecentes();
                        break;
                    case 7:
                        ObterEstatisticas();
                        break;
                    case 8:
                        ValidarSalarioAdmissao();
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

        //Método com nome ObterPorNome que selecione um funcionário de acordo com o nome digitado e que
        //caso não encontre retorne uma mensagem para o usuário.
        public static void ObterPorNome()
        {
            Console.WriteLine("Digite o nome do funcionario ");
            String nome = Console.ReadLine();
            List<Funcionario> filtrados = lista.Where(f => f.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
            .ToList();

            if (filtrados.Count == 0)
            {
                Console.WriteLine("Funcionário não encontrado, por favor digite o nome de um funcionário já cadastrado.");
            }
            else
            {
                lista = filtrados;
                ExibirLista();
                CriarLista();
            }
        }
        // d) ValidarSalarioAdmissao
        public static void ValidarSalarioAdmissao(){
            for (int i = 0; i < lista.Count; i++){
                if (lista[i].Salario <= 0)
                {
                    Console.WriteLine($"Erro: o funcionário {lista[i].Nome} tem salário inválido (0 ou negativo).");
                    lista.RemoveAt(i);
                    i--; // ajusta índice depois de remover
                }
                else if (lista[i].DataAdmissao < DateTime.Now.Date)
                {
                    Console.WriteLine($"Erro: o funcionário {lista[i].Nome} tem data de admissão inválida ({lista[i].DataAdmissao:dd/MM/yyyy}).");
                    lista.RemoveAt(i);
                    i--;
                }
    }
}

        public static void ObterFuncionariosRecentes()
        {
            List<Funcionario> filtrados = lista.Where(f => f.Id >= 4).OrderByDescending(f => f.Salario).ToList();

            if (filtrados.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário com Id >= 4.");
            }
            else
            {
                lista = filtrados;
                ExibirLista();
                CriarLista();
            }
        }

        public static void ObterEstatisticas()
        {
            Console.WriteLine($"A quantidade de funcionarios é: {lista.Count} funcionarios");
            Console.WriteLine($"Somatório dos salários: R$ {lista.Sum(f => f.Salario):c}");
        }
        public static void AdicionarFuncionarioV2()
        {
            Funcionario f = new Funcionario();
            do
            {
                Console.Write("Digite o nome: ");
                f.Nome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(f.Nome))
                {
                Console.WriteLine("O nome deve ser preenchido.");
                }
            } while (string.IsNullOrWhiteSpace(f.Nome));
            decimal salario;
            do
            {
                Console.Write("Digite o salário: ");
                string entrada = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("O salário não pode ser vazio.");
                    continue;
                }
                if (!decimal.TryParse(entrada, out salario))
                {
                    Console.WriteLine("O valor digitado não é um número válido.");
                    continue;
                }
                if (salario <= 0)
                {
                    Console.WriteLine("O salário deve ser maior que 0.");
                    continue;
                }
                f.Salario = salario;
                break;
            } while (true);
            

            Console.WriteLine("Digite o CPF: ");
            f.CPF = Console.ReadLine();
            Console.WriteLine("Digite a data de admissão: ");
            f.DataAdmissao = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("insira o tipo de contrato:\n1.CLT\n2.Aprendiz");
            f.TipoFuncionario = (TipoFuncionarioEnum)decimal.Parse(Console.ReadLine());
            {
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