using System;

namespace Cadastro_de_Veiculo {
    
    class Moto : Veiculo {

        public int Guidao { get; set; }
        public int Pedal { get; set; }
        public int Marcha { get; set; }

        public Moto(int guidao, int marchas, int pedal) { //esse construtor não está sendo usado, nesse caso não precisaria criá-lo
            Guidao = guidao;
            Marcha = marchas;
            Pedal = pedal;
        }
        public Moto() { } // construtor vazio tbm não precisa criar, por default o c# já possui um construtor  vazio

        public void ExibirVeiculos(Moto moto) {
            Console.WriteLine($"Nº Cadastro {moto.NumeroCadastro} Marca: {moto.Marca} Modelo: {moto.Modelo} Placa {moto.Placa} Motor: {moto.Motor} " +
                 $"Quantidade de Rodas: {moto.Rodas} Guidão: {moto.Guidao} Veículo Alugado: {moto.VeiculoAlugado} " +
                $"Marchas: {moto.Marcha} Pedais: {moto.Pedal}");
        }
    }
}
