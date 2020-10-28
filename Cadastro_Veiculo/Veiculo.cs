using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cadastro_de_Veiculo {
    public class Veiculo : IVeiculo {
        public int NumeroCadastro { get; set; }
        public int TpVeiculo { get; set; }
        public int Rodas { get; set; }
        public string Motor { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public bool VeiculoAlugado { get; set; }

        private List<Veiculo> Veiculos = new List<Veiculo>();

        const string OPCAOEDITAREEXCLUIR = "Nº Cadastro Veículo: ";
        const string PLACAFORADOPADRAO = "Placa fora do Padrão Exigido.";
        const string EXIGEPLACA = "Informe uma Placa Válida";
        const string PLACAEXISTEPARAOUTROVEICULO = "Placa já Existe para outro Veículo.";
        const string VEICNAOENCONTRADO = "Número de Cadastro do Veículo não Encotrado";
        const string ALUGAOUDEVOLVE = "SIM";
        const string VEICULOALUGADO = "Veículo já esta alugado!";
        const string DEVOLVEVEICULO = "Veiculo não esta alugado!";
        const string EXCLUSAOVEICULOALUGADO = "Veículo Alugado não pode ser Excluído";
        const string SUCESSOVEICULOALUGADO = "Veículo Alugado com Sucesso!";
        const string SUCESSODEVOLVEVEICULO = "Veículo Devolvido com Sucesso!";
        const string SUCESSOREMOVEVEICULO = "Veículo Removido com Sucesso!";
        
        public Veiculo(int tpVeiculo, int numeroCadastro, string marca, string modelo, string placa, string motor, int rodas, bool veiculoAlugado) {
            TpVeiculo = tpVeiculo;
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
            Motor = motor;
            Rodas = rodas;
            NumeroCadastro = numeroCadastro;
            VeiculoAlugado = veiculoAlugado;
        }
        public Veiculo() { }

        public void AlugarVeiculo(Veiculo editVeic) {
            if (editVeic.VeiculoAlugado)
                Console.WriteLine(VEICULOALUGADO);
            else
                editVeic.VeiculoAlugado = true;
                Console.WriteLine(SUCESSOVEICULOALUGADO);
        }
        public void DevolveVeiculoAlugado(Veiculo editVeic) {
            if (!editVeic.VeiculoAlugado)
                Console.WriteLine(DEVOLVEVEICULO);
            else
                editVeic.VeiculoAlugado = false;
                Console.WriteLine(SUCESSODEVOLVEVEICULO);
        }
        public void VeiculoAlugadoNaoPodeSerExcluido(Veiculo numberCadastro) {
            if (numberCadastro.VeiculoAlugado) {
                Console.WriteLine(EXCLUSAOVEICULOALUGADO);
            } else {
                Veiculos.Remove(numberCadastro);
                Console.WriteLine(SUCESSOREMOVEVEICULO);
            }
        }
        public void CadastrarVeiculo(int tpVeiculo) {
            Random random = new Random();
            int numeroCadastro = random.Next(1, 101);

            Console.WriteLine("Nº Cadastro do Veículo: {0}", numeroCadastro);

            Console.Write("Modelo: ");
            string modelo = Console.ReadLine();
            var modeloIni = char.ToUpper(modelo[0]) + modelo.Substring(1);

            Console.Write("Marca: ");
            string marca = Console.ReadLine();
            var marcaIni = char.ToUpper(marca[0]) + marca.Substring(1);

            Console.Write("Potência Motor: ");
            string motor = Console.ReadLine();

            Console.Write("Nº Roda: ");
            int.TryParse(Console.ReadLine(), out int roda);

            int contPlaca = 0;
            string placa = "";
            do {
                Console.Write("Placa: ");
                placa = Console.ReadLine().ToUpper();

                if (placa.Length > 0) {
                    if (!veirificaPlacaExisteOutroVeiculo(placa)) {
                        var resultPadraoPlaca = ValidarPadraoPlaca(placa);
                        if (resultPadraoPlaca) {
                            contPlaca++;
                        } else {
                            Console.WriteLine(PLACAFORADOPADRAO);
                        }
                    }
                } else {
                    Console.WriteLine(EXIGEPLACA);
                }
            } while (contPlaca == 0);

            bool veiculoAlugado = false;

            if (tpVeiculo == 1) {
                Console.Write("Nº Porta: ");
                int.TryParse(Console.ReadLine(), out int porta);

                Console.Write("Nº ParaBrisa: ");
                int.TryParse(Console.ReadLine(), out int paraBrisa);

                Console.Write("Nº Porta Mala: ");
                int.TryParse(Console.ReadLine(), out int portaMala);

                var novoVeiculo = new Carro();
                novoVeiculo.TpVeiculo = tpVeiculo;
                novoVeiculo.Placa = placa;
                novoVeiculo.Marca = marcaIni;
                novoVeiculo.Modelo = modeloIni;
                novoVeiculo.Motor = motor;
                novoVeiculo.Rodas = roda;
                novoVeiculo.VeiculoAlugado = veiculoAlugado;
                novoVeiculo.Porta = porta;
                novoVeiculo.PortaMalas = portaMala;
                novoVeiculo.ParaBrisa = paraBrisa;
                novoVeiculo.NumeroCadastro = numeroCadastro;
                Veiculos.Add(novoVeiculo);

            } else {
                Console.Write("Nº Guidão: ");
                int.TryParse(Console.ReadLine(), out int guidao);

                Console.Write("Nº Marcha: ");
                int.TryParse(Console.ReadLine(), out int marcha);

                Console.Write("Nº Pedal: ");
                int.TryParse(Console.ReadLine(), out int pedal);

                var novoVeiculo = new Moto();
                novoVeiculo.TpVeiculo = tpVeiculo;
                novoVeiculo.Placa = placa;
                novoVeiculo.Marca = marcaIni;
                novoVeiculo.Modelo = modeloIni;
                novoVeiculo.Motor = motor;
                novoVeiculo.Guidao = guidao;
                novoVeiculo.VeiculoAlugado = veiculoAlugado;
                novoVeiculo.Pedal = pedal;
                novoVeiculo.Marcha = marcha;
                novoVeiculo.Rodas = roda;
                novoVeiculo.NumeroCadastro = numeroCadastro;
                Veiculos.Add(novoVeiculo);
            }
        }
        public bool veirificaPlacaExisteOutroVeiculo(string placa) {
            foreach (var verifPlaca in Veiculos) {
                if (placa == verifPlaca.Placa) {
                    Console.WriteLine(PLACAEXISTEPARAOUTROVEICULO);
                    return true;
                }
            }
            return false;
        }
        private static bool ValidarPadraoPlaca(string placa) {
            if (string.IsNullOrWhiteSpace(placa)) 
                { return false; }

            if (placa.Length > 8) 
                { return false; }

            placa = placa.Replace("-", "").Trim();

            if (char.IsLetter(placa, 4)) {
                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(placa);
            } else {
                var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return padraoNormal.IsMatch(placa);
            }
        }
        public void EditarVeiculo() {
            Console.Write(OPCAOEDITAREEXCLUIR);
            int numberEditar = int.Parse(Console.ReadLine());
            foreach (var editVeic in Veiculos) {
                if (numberEditar == editVeic.NumeroCadastro) {
                    EditVeiculo(editVeic);
                    break;
                }
            }
            Console.WriteLine(VEICNAOENCONTRADO);
        }
        public void EditVeiculo(Veiculo editVeic) {
            bool validaCampoInt;

            Console.WriteLine("Nº Cadastro do Veículo: {0}", editVeic.NumeroCadastro);

            Console.WriteLine("Modelo Atual: {0}", editVeic.Modelo);
            Console.Write("Novo Modelo: ");
            string modelo = Console.ReadLine();
            if (modelo.Length != 0 && modelo != editVeic.Modelo) {
                var novoModelo = char.ToUpper(modelo[0]) + modelo.Substring(1);
                editVeic.Modelo = novoModelo;
            }

            Console.WriteLine("Modelo Atual: {0}", editVeic.Marca);
            Console.Write("Nova Marca: ");
            string marca = Console.ReadLine();
            if (marca.Length != 0 && marca != editVeic.Marca) {
                var novoMarca = char.ToUpper(marca[0]) + marca.Substring(1);
                editVeic.Marca = novoMarca;
            }

            Console.WriteLine("Potência do Motor Atual: {0}", editVeic.Motor);
            Console.Write("Nova Potência de Motor: ");
            string motor = Console.ReadLine();
            if (motor.Length != 0 && motor != editVeic.Motor) {
                editVeic.Motor = motor;
            }

            Console.WriteLine("Nº Roda Atual: {0}", editVeic.Rodas);
            Console.Write("Novo Nº Roda: ");
            validaCampoInt = int.TryParse(Console.ReadLine(), out int roda);
            if (validaCampoInt) {
                if (roda != editVeic.Rodas) {
                    editVeic.Rodas = roda;
                }
            }

            int contPlaca = 0;
            string placa = "";
            do {
                Console.Write("Placa: ");
                placa = Console.ReadLine().ToUpper();
                if (placa.Length != 0 && placa != editVeic.Placa) {
                    if (!veirificaPlacaExisteOutroVeiculo(placa)) {
                        var resultPadraoPlaca = ValidarPadraoPlaca(placa);
                        if (resultPadraoPlaca) {
                            editVeic.Placa = placa;
                            contPlaca++;
                        } else {
                            Console.WriteLine(PLACAFORADOPADRAO);
                        }
                    }
                } else {
                    contPlaca++;
                }
            } while (contPlaca == 0);

            Console.WriteLine("Veículo Alugado: {0}", editVeic.TpVeiculo);
            Console.Write("Deseja Alugar o Veículo (Sim ou Não): ");
            string OPCAOALUGA = Console.ReadLine().ToUpper();

            if (OPCAOALUGA == ALUGAOUDEVOLVE) {
                AlugarVeiculo(editVeic);
            }

            Console.Write("Deseja Desalugar o Veículo (Sim ou Não): ");
            string OPCAODEVOLVE = Console.ReadLine().ToUpper();
            if (OPCAODEVOLVE == ALUGAOUDEVOLVE) {
                DevolveVeiculoAlugado(editVeic);
            }

            if (editVeic.TpVeiculo == 1) {
                var carro = editVeic as Carro;

                Console.WriteLine("Nº de Portas Atual: {0}", carro.Porta);
                Console.Write("Novo Nº de Portas: ");
                validaCampoInt = int.TryParse(Console.ReadLine(), out int portas);
                if (validaCampoInt) {
                    if (portas != carro.Porta) {
                        carro.Porta = portas;
                    }
                }

                Console.WriteLine("Nº de Porta Malas Atual: {0}", carro.PortaMalas);
                Console.Write("Novo Nº de Porta Malas: ");
                validaCampoInt = int.TryParse(Console.ReadLine(), out int portaMalas);
                if (validaCampoInt) {
                    if (portaMalas != carro.PortaMalas) {
                        carro.PortaMalas = portaMalas;
                    }
                }

                Console.WriteLine("Nº de Parabrisas Atual: {0}", carro.ParaBrisa);
                Console.Write("Novo Nº de Parabrisas: ");
                validaCampoInt = int.TryParse(Console.ReadLine(), out int parabrisas);
                if (validaCampoInt) {
                    if (parabrisas != carro.ParaBrisa) {
                        carro.ParaBrisa = parabrisas;
                    }
                }
            } else {
                var moto = editVeic as Moto;

                Console.WriteLine("Nº Guidão Atual: {0}", moto.Guidao);
                Console.Write("Novo Guidão: ");
                validaCampoInt = int.TryParse(Console.ReadLine(), out int guidao);
                if (validaCampoInt) {
                    if (guidao != moto.Guidao) {
                        moto.Guidao = guidao;
                    }
                }

                Console.WriteLine("Nº Marchas: {0}", moto.Marcha);
                Console.Write("Nº Marchas: ");
                validaCampoInt = int.TryParse(Console.ReadLine(), out int marchas);
                if (validaCampoInt) {
                    if (marchas != moto.Marcha) {
                        moto.Marcha = marchas;
                    }
                }

                Console.WriteLine("Nº Pedais: {0}", moto.Pedal);
                Console.Write("Nº Pedais: ");
                validaCampoInt = int.TryParse(Console.ReadLine(), out int pedais);
                if (validaCampoInt) {
                    if (pedais != moto.Pedal) {
                        moto.Pedal = pedais;
                    }
                }
            }
        }
        public void ExcluirVeiculo() {
            Console.Write(OPCAOEDITAREEXCLUIR);
            int numberExcluir = int.Parse(Console.ReadLine());

            foreach (var veiculo in Veiculos) {
                if (veiculo.NumeroCadastro == numberExcluir) {
                    VeiculoAlugadoNaoPodeSerExcluido(veiculo);
                    break;
                }
            }
            Console.WriteLine(VEICNAOENCONTRADO);
        }
        public List<Veiculo> ListarVeiculos() {
            return Veiculos;
        }
        public Veiculo ListarVeiculoPorPlaca(string placa) {
            foreach (var veiculo in Veiculos) {
                if (veiculo.Placa == placa) {
                    return veiculo;
                }
            }
            return null;
        }
        public List<Veiculo> ListarVeiculosPorMarcaEModelo(string marca, string modelo) {
            List<Veiculo> listaMarcaEModelo = new List<Veiculo>();
            foreach (var veiculo in Veiculos) {
                if (veiculo.Marca == marca
                    && veiculo.Modelo == modelo) {
                    listaMarcaEModelo.Add(veiculo);
                }
            }
            return listaMarcaEModelo;
        }
    }
}
