using System.Text.Json;
using AppClientes.Cadastro;

namespace AppClientes.Repository;

public class ClienteRepositorio
{
    public List<Cliente> clientes = [];

    public void GravarDadosClientes()
    {
        var json = JsonSerializer.Serialize(clientes);

        File.WriteAllText("clientes.txt", json);
    }

    public void LerDadosClientes()
    {
        if (File.Exists("clientes.txt"))
        {
            var dados = File.ReadAllText("clientes.txt");

            var clientesArquivo = JsonSerializer.Deserialize<List<Cliente>>(dados);

            clientes.AddRange(clientesArquivo);
        }
    }

    public void ExcluirCliente()
    {
        Console.Clear();
        Console.Write("Informe o código do cliente: ");
        var codigo = Console.ReadLine();

        var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo), null);
        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado na base de dados! [Enter]");
            Console.ReadKey();
            return;
        }

        ImprimirCliente(cliente);

        clientes.Remove(cliente);

        Console.WriteLine("Cliente removido com sucesso! [Enter]");
        Console.ReadKey();
    }

    public void EditarCliente()
    {
        Console.Clear();
        Console.Write("Informe o código do cliente: ");
        var codigo = Console.ReadLine();

        var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo), null);
        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado na base de dados! [Enter]");
            Console.ReadKey();
            return;
        }

        ImprimirCliente(cliente);

        Console.Write("Nome do cliente: " + cliente.Nome);
        var nome = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Data nascimento: " + cliente.DataNascimento);
        var dataNascimento = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Desconto: " + cliente.Desconto);
        var desconto = decimal.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        cliente.Nome = nome;
        cliente.Desconto = desconto;
        cliente.DataNascimento = dataNascimento;

        Console.WriteLine("Cliente alterado com sucesso! [Enter]");
        ImprimirCliente(cliente);
        Console.ReadKey();
    }

    public void CadastrarCliente()
    {
        Console.Clear();

        Console.WriteLine("Nome do cliente: ");
        var nome = Console.ReadLine();
        Console.WriteLine(Environment.NewLine);

        Console.WriteLine("Data de nascimento: ");
        var dataNascimento = DateOnly.Parse(Console.ReadLine());
        Console.WriteLine(Environment.NewLine);

        Console.WriteLine("Desconto: ");
        var desconto = decimal.Parse(Console.ReadLine());
        Console.WriteLine(Environment.NewLine);

        Cliente cliente = new()
        {
            Id = clientes.Count + 1,
            Nome = nome,
            DataNascimento = dataNascimento,
            Desconto = desconto,
            CadastradoEm = DateTime.Now
        };

        clientes.Add(cliente);

        Console.WriteLine("Cliente cadastrado com sucesso! [Enter]");
        ImprimirCliente(cliente);
        Console.ReadKey();
    }

    public void ImprimirCliente(Cliente cliente)
    {
        Console.WriteLine("ID....................: " + cliente.Id);
        Console.WriteLine("Nome..................: " + cliente.Nome);
        Console.WriteLine("Desconto..............: " + cliente.Desconto);
        Console.WriteLine("Data Nascimento.......: " + cliente.DataNascimento);
        Console.WriteLine("Cadastrado Em.........: " + cliente.CadastradoEm);
        Console.WriteLine("-------------------------------------");
    }

    public void ExibirClientes()
    {
        Console.Clear();
        foreach (var cliente in clientes)
        {
            ImprimirCliente(cliente);
        }

        Console.ReadKey();
    }
}