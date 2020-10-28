using System.Collections.Generic;

namespace Cadastro_de_Veiculo {
    public interface IVeiculo {
        public void CadastrarVeiculo(int tpVeiculo);
        public void EditarVeiculo();
        public void ExcluirVeiculo();
        public List<Veiculo> ListarVeiculos();
        public Veiculo ListarVeiculoPorPlaca(string placa);
        public List<Veiculo> ListarVeiculosPorMarcaEModelo(string marca, string modelo);
    }
}
