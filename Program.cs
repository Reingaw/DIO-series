using System;

namespace DIO.series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();
            while(userOption.ToUpper() != "X")
            {
                switch(userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        RemoveSerie();
                        break;
                    case "5":
                        ViewSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListSeries()
        {
            Console.WriteLine("Listar séries");

            var list = repository.ListSeries();

            if(list.Count == 0)
            {
                Console.WriteLine("Nenhuma séries cadastrada.");
                return;
            }

            foreach(var serie in list)
            {
                var isRemoved = serie.returnRemoved();

                Console.WriteLine(
                    $"#ID {serie.returnId()}: - {serie.returnTitle()} - {(isRemoved ? "Excluido" : "")}"
                );
            }
        }

        private static void InsertSerie()
        {
            Console.WriteLine("Inserir nova série");

            Serie newSerie = GetSerieInfo();

            repository.InsertSerie(newSerie);
        }

        private static void UpdateSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int serieIndex = int.Parse(Console.ReadLine());

            Serie updatedSerie = GetSerieInfo();

            repository.UpdateSerie(serieIndex, updatedSerie);
        }

        private static void RemoveSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int serieIndex = int.Parse(Console.ReadLine());

            repository.RemoveSerie(serieIndex);
        }

        private static void ViewSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int serieIndex = int.Parse(Console.ReadLine());

            var serie = repository.ReturnSerieById(serieIndex);

            Console.WriteLine(serie);
        }

        private static Serie GetSerieInfo()
        {
            foreach(int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genre), i)}");
            }
            Console.WriteLine();
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entryGenre = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite o Titulo da Série: ");
            string entryTitle = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entryYear = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite a Descrição da Série: ");
            string entryDescription = Console.ReadLine();

            Serie serieInfo = new Serie( id: repository.NextId(),
                                        genre: (Genre)entryGenre,
                                        title: entryTitle,
                                        year: entryYear,
                                        description: entryDescription);

            return serieInfo;
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return userOption;
        }
    }
}