using System;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro_de_Veiculo {
    class Program {

        public static void MenuPrincipal() {
        
            Console.Clear();
            Console.WriteLine("Sistema de Veículo");
            Console.WriteLine("1 - Cadastre Novo Carro");
            Console.WriteLine("2 - Cadastre Nova Moto");
            Console.WriteLine("3 - Editar Veículo");
            Console.WriteLine("4 - Excluir Veículo");
            Console.WriteLine("5 - Listar todos os Veículos");
            Console.WriteLine("6 - Listar Veículos por Placa");
            Console.WriteLine("7 - Listar Veículos por Marca e Modelo");
            Console.WriteLine("0 - Sair");
        }

        private static void LimparExibirMenu() {

            Console.ReadLine();
            MenuPrincipal();
        }

        const string NENHUMVEICULO = "Não há Veículos Cadastrados";

        static void Main(string[] args) {
        
            var veiculo = new Veiculo();
            
            // essas duas variáveis não estão sendo utilizadas
            // (usar o sonarLint para verificar essas questões)
            var placaEncontrada = new Veiculo();
            var veiculos = new List<Veiculo>();

            const string OPCAOESCOLHA = "Escolha uma Opção: ";
            const string PLACANAOENCONTRADA = "Placa não encontrada para nenhum veículo!";
            const string OPINV = "Opção inválida!!";
            string placa = string.Empty;
            string marca = string.Empty;
            string modelo = string.Empty;
            string modeloOficial = string.Empty;
            string marcaOficial = string.Empty;
            int opcao = 0;
            int tpVeiculo = 0;

            do {
                MenuPrincipal();
                Console.Write(OPCAOESCOLHA);
                opcao = int.Parse(Console.ReadLine());

                switch (opcao) {
                    case 0:
                        break;

                    case 1:
                        tpVeiculo = 1; // usar os enums ou constantes
                        veiculo.CadastrarVeiculo(tpVeiculo);
                        LimparExibirMenu();
                        break;
                    
                    case 2:
                        tpVeiculo = 2;
                        veiculo.CadastrarVeiculo(tpVeiculo);
                        LimparExibirMenu();
                        break;
                    
                    case 3:
                        veiculo.EditarVeiculo();
                        LimparExibirMenu();
                        break;
                    
                    case 4:
                        veiculo.ExcluirVeiculo();
                        LimparExibirMenu();
                        break;
                    
                    case 5:
                        veiculos = veiculo.ListarVeiculos();
                        VisualizarTodosVeiculos(veiculos);
                        LimparExibirMenu();
                        break;
                    
                    case 6:

                        placa = SolicitaPlaca(placa);
                        placaEncontrada = veiculo.ListarVeiculoPorPlaca(placa);
                        
                        if (placaEncontrada == null) {
                            Console.WriteLine(PLACANAOENCONTRADA);
                        } 
                        else {
                            VisualizarVeiculos(placaEncontrada);
                        }
                        
                        LimparExibirMenu();
                        break;
                    
                    case 7:
                        
                        marcaOficial = SolicitaMarca(marca);
                        modeloOficial = SolicitaModelo(modelo);
                        veiculos = veiculo.ListarVeiculosPorMarcaEModelo(marcaOficial, modeloOficial);
                        
                        VisualizarTodosVeiculos(veiculos);
                        LimparExibirMenu();
                        break;

                    default:
                        Console.WriteLine(OPINV);
                        LimparExibirMenu();
                        break;
                }
            } while (opcao != 0);
        }

        public static string SolicitaPlaca(string placa) {

            Console.Write("Placa do Veículo que Deseja Listar: ");
            placa = Console.ReadLine().ToUpper();
            return placa;
        }

        public static string SolicitaModelo(string modelo) {

            Console.Write("Modelo Veículo: ");
            modelo = Console.ReadLine();

            var modeloOficial = char.ToUpper(modelo[0]) + modelo.Substring(1);
            return modeloOficial;
        }

        public static string SolicitaMarca(string marca) {

            Console.Write("Marca Veículo: ");
            marca = Console.ReadLine();

            var marcaOficial = char.ToUpper(marca[0]) + marca.Substring(1);
            return marcaOficial;
        }

        public static void VisualizarVeiculos(Veiculo placaEncontrada) {

            if (placaEncontrada.TpVeiculo == 1) {
                var carro = placaEncontrada as Carro;
                carro.ExibirVeiculos(carro);
            } 
            else {
                var moto = placaEncontrada as Moto;
                moto.ExibirVeiculos(moto);
            }
        }
        private static void VisualizarTodosVeiculos(List<Veiculo> veiculos) {

            if (veiculos.Count > 0) {
                
                var orderNumeroCadastro = veiculos.OrderBy(veic => veic.NumeroCadastro);
                foreach (Veiculo veiculo in orderNumeroCadastro) {

                    if (veiculo.TpVeiculo == 1) {
                        var carro = veiculo as Carro;
                        carro.ExibirVeiculos(carro);
                    } else {
                        var moto = veiculo as Moto;
                        moto.ExibirVeiculos(moto);
                    }
                }

                Console.WriteLine();
                Console.WriteLine($"Total de Veiculos: {veiculos.Count}");
            } 
            else {
                Console.WriteLine(NENHUMVEICULO);
            }
        }
    }
}
