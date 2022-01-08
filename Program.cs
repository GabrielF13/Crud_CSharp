using System;


namespace DIO.Series
{
	class program
	{
		static SerieRepositorio repositorio = new SerieRepositorio();
		static void Main(string[]args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
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
					case "c":
						Console.Clear();
						break;
					
					default:
						throw new ArgumentOutOfRangeException();

				}

					opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por usar nossos servoços");
			Console.ReadLine();
		}

		private static void ListarSeries()
		{
			Console.WriteLine("Listar Séries");
			var lista = repositorio.Lista();
			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma Série Cadastrada");
				return;
			}
			foreach (var serie in lista)
			{
				var excluido = serie.retornaExluido();
				Console.WriteLine("#ID {0} : - {1} {2} ", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
			}
		}

		private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova serie");
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine("Digite o Genero ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite o titulo ");
			string entradaTitulo = Console.ReadLine();

			Console.WriteLine("Digite o o ano da serie ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite a descricao ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
				repositorio.Insere(novaSerie);
			
		}


		private static void AtualizarSerie()
		{
			Console.Write("Digite o id da serie");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine("Digite o  genero entre as opçõesa acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite o titulo: ");
			string entradaTitulo = Console.ReadLine();

			Console.WriteLine("Digite o o ano da serie ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite a descricao ");
			string entradaDescricao = Console.ReadLine();

			Serie atulizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
			repositorio.Atualiza(indiceSerie, atulizaSerie);
			
		}

		private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indeceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indeceSerie);
		}

		private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}
		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Dio series ao seu dispor");
			Console.WriteLine("Informe a opção desejada");

			Console.WriteLine("1- Listar série");
			Console.WriteLine("2- Inserir série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("c- Limpar Tela");
			Console.WriteLine("x- Sair");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;



		}
	}
}
