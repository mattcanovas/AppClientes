using System.Globalization;
using AppClientes.Repository;

namespace AppClientes;

class Program
{
    static ClienteRepositorio _repositorio = new();

    static void Main(string[] args)
    {
        var cultura = new CultureInfo("pt-BR");
        Thread.CurrentThread.CurrentCulture = cultura;
        Thread.CurrentThread.CurrentUICulture = cultura;

        _repositorio.LerDadosClientes();
        
        while (true)
        {
            Menu();

            Console.ReadKey();
        }
    }

    static void EscolherOpcao()
    {
        Console.Write("Escolha uma opção: ");
        var opcao = Console.ReadLine();

        switch (int.Parse(opcao))
        {
            case 1:
                {
                    _repositorio.CadastrarCliente();
                    Menu();
                    break;
                }
            case 2:
                {
                    _repositorio.ExibirClientes();
                    Menu();
                    break;
                }
            case 3:
                {
                    _repositorio.EditarCliente();
                    Menu();
                    break;
                }
            case 4:
                {
                    _repositorio.ExcluirCliente();
                    Menu();
                    break;
                }
            case 5:
                {
                    _repositorio.GravarDadosClientes();
                    Environment.Exit(0);
                    break;
                }
            default:
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    break;
                }
        }
    }

    static void Menu()
    {
        Console.Clear();

        Console.WriteLine("Cadastro de Clientes");
        Console.WriteLine("---------------------");
        Console.WriteLine("1 - Cadastrar CLiente");
        Console.WriteLine("2 - Exibir Clientes");
        Console.WriteLine("3 - Editar Cliente");
        Console.WriteLine("4 - Excluir Cliente");
        Console.WriteLine("5 - Sair");
        Console.WriteLine("---------------------");

        EscolherOpcao();
    }
}
