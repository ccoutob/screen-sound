// Screen Sound

using Microsoft.Win32;

string mensagem = "Bem vindo ao programa";

//List<string> ListaDeBandas = new List<string>() { "Nectar Gang", "Piramide Perdida", "Bloco 7"};    

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Piramide Perdida", new List<int>() { 10, 4, 6} );
bandasRegistradas.Add("Bloco 7", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagem);

}

void ExibirMenu()
{
    ExibirLogo();   
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 5 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;//É utilizado "!" para informar que a string não deve ser nula, caso remova, verá o aviso
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2:
            ListarBandas();
            break;
        case 3:
            avaliarBanda();
            break;
        case 4:
            ListarMediaDeUmaBanda();
            break;
        case 5:
            Console.WriteLine("Tchau tchau :)");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    exibirTituloDaOpcao("Registro de Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!; //É utilizado "!" para informar que a string não deve ser nula, caso remova, verá o aviso
    bandasRegistradas.Add(nomeDaBanda, new List<int>());//Adicionando banda com o padrão chave-valor, sem devolver uma nota, apenas criando a lista vazia
    Console.Write($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);//Espere 2 mil milesegundos
    Console.Clear();
    ExibirMenu();

}

void ListarBandas()
{
    Console.Clear();
    exibirTituloDaOpcao("Exibindo todas as bandas registradas no Screen Sound");
    
    //for (int i = 0; i < ListaDeBandas.Count; i++)
    //{
        //Console.WriteLine($"Banda: {ListaDeBandas[i]}");
    //}

    foreach(string banda in bandasRegistradas.Keys)//Passando apenas a chave do dicionário (nome das bandas) para ser lida na listagem
    {
        Console.WriteLine($"Banda: {banda}");//ForEach é uma maneira mais simples de imprimir a lista de bandas
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();//Ao digitar qualquer tecla, a próxima ação será executada
    Console.Clear();
    ExibirMenu();
}

void exibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length; //Pegando a quantidade de caracteres do titulo
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*'); //Realocando asteriscos em aspas simples (char) no mesmo tamanho do titulo
    //Imprimindo o titulo com asteriscos
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos);
}

void avaliarBanda()
{
    //digite qual banda deseja avaliar
    // se a banda existir no dicionario >> atribuir uma nota
    // senão, volta ao menu principal

    Console.Clear();
    exibirTituloDaOpcao("Avaliar uma banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine();
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Digite a nota da banda {nomeDaBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);//Adiciona a nota pela banda ja selecionada dentro do dicionário (chave), passando apenas o valor
        Console.WriteLine($"\nA nota {nota} foi dada a banda {nomeDaBanda} com sucesso!");
        Thread.Sleep(3000);
        Console.Clear();
        ExibirMenu();
    }
    else
    {
        Console.WriteLine($"\nA Banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
}

void ListarMediaDeUmaBanda()
{
    //digite qual banda deseja avaliar
    //Se a banda estiver presente, realize a media de notas
    //Se não, volte ao menu principal

    Console.Clear();
    exibirTituloDaOpcao("Media da Banda");
    Console.Write("Digite a banda que deseja ver a média: ");
    var nomeDaBanda = Console.ReadLine();

    if (bandasRegistradas.ContainsKey(nomeDaBanda)!)
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        //Average é usado para buscar valores dentro de um dicionário e realizar sua media
        Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasDaBanda.Average()}.");
        Thread.Sleep(2000);
    }
    else
    {
        Console.WriteLine($"\nA Banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }


    Console.Clear();
    ExibirMenu();
}

ExibirMenu();