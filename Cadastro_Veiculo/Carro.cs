using System;

namespace Cadastro_de_Veiculo {
    class Carro : Veiculo {
        public int Porta { get; set; }
        public int ParaBrisa { get; set; }
        public int PortaMalas { get; set; }
        public Carro(int porta, int portamalas, int parabrisa) {
            Porta = porta;
            PortaMalas = portamalas;
            ParaBrisa = parabrisa;
        }
        public Carro() { }

        public void ExibirVeiculos(Carro carro) {
            Console.WriteLine($"Nº Cadastro {carro.NumeroCadastro} Marca: {carro.Marca} Modelo: {carro.Modelo} Placa {carro.Placa} Motor: {carro.Motor} " +
                 $"Nª Rodas: {carro.Rodas} Portas: {carro.Porta} Veículo Alugado: {carro.VeiculoAlugado} " +
                $"Nª Porta Malas: {carro.PortaMalas} Nº Parabrisas: {carro.ParaBrisa}");
        }

    }
}
