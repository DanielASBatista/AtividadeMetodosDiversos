//Daniel Alves - RM:251376
//Hernan Rodrigo - RM:251169

using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;

namespace MenuSeletorDeMetodos
{
    internal class Program
    {
        static List<Funcionario> lista = new List<Funcionario>();
        static void Main(string[] args)
        {
            FuncaoSeletoraDeMetodos();
        }

        public static void FuncaoSeletoraDeMetodos()
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
                Console.WriteLine("5 - Cadastro com validação de nome");
                Console.WriteLine("6 - Obter por tipo de contratação");
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
                        ValidarNome();
                        break;
                    case 6:
                        ObterPorTipo();
                        break;
                    default:
                        Console.WriteLine("Saindo do sistema....");
                        break;
                }
            } while (opcaoEscolhida >= 1 && opcaoEscolhida <= 6);
            Console.WriteLine("==================================================");
            Console.WriteLine("* Obrigado por utilizar o sistema e volte sempre *");
            Console.WriteLine("==================================================");
        }

        //Método com nome ObterPorNome que selecione um funcionário de acordo com o nome digitado e que
        //caso não encontre retorne uma mensagem para o usuário. Ele reconhece entradas parciais e não diferencia maiúsculas de minúsculas.
        public static void ObterPorNome()
        {
            Console.WriteLine("Digite o nome do funcionário: ");
            string nome = Console.ReadLine();

            List<Funcionario> filtrados = lista
            .Where(f => f.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (filtrados.Count == 0)
        {
            Console.WriteLine("Funcionário não encontrado. Por favor, digite um nome já cadastrado (ou parte dele).");
        }
        else
        {
            lista = filtrados;
            ExibirLista();
            CriarLista();
        }
        }
        //Método com nome ObterFuncionariosRecentes que selecione todos os funcionários com Id maior ou igual a 4 e ordene por salário decrescente.
        //Caso não encontre retorne uma mensagem para o usuário.
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

        //Método com nome AdicionarFuncionarioV2 que adicione um novo funcionário na lista, porém com as seguintes validações:
        //Nome não pode ser vazio ou nulo.
        //Salário deve ser maior que 0.
        //Data de admissão não pode ser uma data passada.
        //Caso alguma das validações falhe, deve ser exibida uma mensagem para o usuário e o funcionário não deve ser adicionado.
        //Caso todas as validações passem, o funcionário deve ser adicionado e a lista exibida.        
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

            do
            {
                Console.WriteLine("Digite a data de admissão: ");
                string entrada = Console.ReadLine();

            if (!DateTime.TryParse(entrada, out DateTime dataAdmissao))
            {
                Console.WriteLine("Entrada inválida! Digite a data no formato correto (ex: dd/MM/aaaa).");
                continue; 
            }

            if (dataAdmissao < DateTime.Today)
            {
                Console.WriteLine("Data de admissão inválida, não é possível contratar no passado.");
                continue;
            }

            f.DataAdmissao = dataAdmissao; 
            break;

            } while (true);

            Console.WriteLine("insira o tipo de contrato:\n1.CLT\n2.Aprendiz");
            f.TipoFuncionario = (TipoFuncionarioEnum)decimal.Parse(Console.ReadLine());
            {
                lista.Add(f);
                ExibirLista();
            }
        }
        //Método com nome ValidarNome que valide se o nome do funcionário possui pelo menos dois caracteres.
        //Caso o nome seja inválido, deve ser exibida uma mensagem para o usuário e o nome não deve ser atribuído ao funcionário.
        //Caso o nome seja válido, o nome deve ser atribuído ao funcionário e uma mensagem de sucesso exibida.
        public static void ValidarNome()
        {
            Funcionario f = new Funcionario();

            do
            {
                Console.Write("Digite o nome: ");
                string nome2C = Console.ReadLine();

                if (nome2C.Length < 2)
                {
                    Console.WriteLine("O nome deve ter pelo menos dois caracteres.");
                    continue;
                }
                else Console.WriteLine($"Nome {nome2C} válido.");


                f.Nome = nome2C;
                break;
            } while (true);
        }
        //Método com nome ObterPorTipo que selecione os funcionários de acordo com o tipo de contratação (CLT ou Aprendiz) digitado pelo usuário.
        //Caso não encontre retorne uma mensagem para o usuário.    

        public static void ObterPorTipo()
        {
            Console.WriteLine("Digite o tipo de contratação (1 para CLT, 2 para Aprendiz): ");
            string entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out int tipoInt) || (tipoInt != 1 && tipoInt != 2))
            {
                Console.WriteLine("Tipo de contratação inválido. Por favor, digite 1 para CLT ou 2 para Aprendiz.");
                return;
            }

            TipoFuncionarioEnum tipoSelecionado = (TipoFuncionarioEnum)tipoInt;

            List<Funcionario> filtrados = lista.Where(f => f.TipoFuncionario == tipoSelecionado).ToList();

            if (filtrados.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário encontrado para o tipo de contratação selecionado.");
            }
            else
            {
                lista = filtrados;
                ExibirLista();
                CriarLista();
            }
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