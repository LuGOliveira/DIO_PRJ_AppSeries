using System;

namespace DIO_PRJ_AppSeries
{
    class Program
    {
        static SerieRepositorio  repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                try
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            ListarSeries();
                            break;
                        case "2":
                            InserirSerie();
                            break;
                        case "3":
                            AtualizarSerie();
                            break;
                        case "4":
                            ExcluirSerie();
                            break;
                        case "5":
                            VisualizarSerie();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();                        
                    }
                }
                catch(ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Opção inválida!");
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            Console.WriteLine("Obrigada!");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if(lista.Count ==0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach( var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1}{2} ", serie.retornaID(), serie.retornaTitulo(), (excluido? " *Excluído*" : ""));
            }
        }

        private static void InserirSerie(){
            Console.WriteLine("Inserir série"); 

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));

            }
            Console.WriteLine("Escolha um genêro: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe um título: ");
            string entradaTitulo = Console.ReadLine().ToUpper();

            Console.WriteLine("Informe o ano de lançamento (AAAA): ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Inclua uma descrição: ");
            string entradaDescricao = Console.ReadLine().ToUpper();

            Serie novaSerie = new Serie(id: repositorio.ProximoID(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo, 
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

        }

         private static void AtualizarSerie(){
            try
            {
                Console.WriteLine("Qual série deseja atualizar?"); 
               
                int idSerie = int.Parse(Console.ReadLine());
                var serie = repositorio.RetornaPorId(idSerie);

                foreach(int i in Enum.GetValues(typeof(Genero))){
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));

                }
                Console.WriteLine("Escolha um genêro: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.WriteLine("Informe um título: ");
                string entradaTitulo = Console.ReadLine().ToUpper();

                Console.WriteLine("Informe o ano de lançamento (AAAA): ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.WriteLine("Inclua uma descrição: ");
                string entradaDescricao = Console.ReadLine().ToUpper();
                
                Serie atualizaSerie = new Serie(id: idSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo, 
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

                repositorio.Atualiza(idSerie, atualizaSerie);
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Série inexistente! Escolha outro código de identificação.");
            }
        }

        private static void ExcluirSerie(){
            try
            {
                Console.WriteLine("Qual série deseja excluir?"); 
                int idSerie = int.Parse(Console.ReadLine());
                var serie = repositorio.RetornaPorId(idSerie);
                Console.WriteLine($"Você confirma a exclusão da série {serie.retornaTitulo()} ?(Y/N)"); 
                if(Console.ReadLine().ToUpper()=="Y")
                {
                    repositorio.Exclui(idSerie);
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Série inexistente! Escolha outro código de identificação.");
            }
        }

        private static void VisualizarSerie(){
            try
            {
                Console.WriteLine("Qual série deseja consultar?"); 
                int idSerie = int.Parse(Console.ReadLine());

                var serie = repositorio.RetornaPorId(idSerie);

                Console.WriteLine(serie); 
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Série inexistente! Escolha outro código de identificação.");
            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO - Séries");
            Console.WriteLine("Informe uma opção:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}