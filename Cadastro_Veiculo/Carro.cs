using System;

namespace Cadastro_de_Veiculo {

    class Carro : Veiculo {

        public int Porta { get; set; } // é interessante deixar uma linha de espaço entre namespace, classe e métodos
        public int ParaBrisa { get; set; }
        public int PortaMalas { get; set; }

        public Carro(int porta, int portamalas, int parabrisa) { //esse construtor não está sendo usado, nesse caso não precisaria criá-lo
            Porta = porta;
            PortaMalas = portamalas;
            ParaBrisa = parabrisa;
        }
        
        public Carro() { } // construtor vazio tbm não precisa criar, por default o c# já possui um construtor  vazio

        public void ExibirVeiculos(Carro carro) {
            Console.WriteLine($"Nº Cadastro {carro.NumeroCadastro} Marca: {carro.Marca} Modelo: {carro.Modelo} Placa {carro.Placa} Motor: {carro.Motor} " +
                 $"Nª Rodas: {carro.Rodas} Portas: {carro.Porta} Veículo Alugado: {carro.VeiculoAlugado} " +
                $"Nª Porta Malas: {carro.PortaMalas} Nº Parabrisas: {carro.ParaBrisa}");
        }
    }
}
