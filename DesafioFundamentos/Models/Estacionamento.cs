namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            veiculos.Add(Console.ReadLine().ToString().ToUpper());
        }

        public void RemoverVeiculo()
        {
            int horas = 0;
            string horasString = String.Empty;
            bool condicao = true;
            
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToString().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                while (condicao)
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    horasString = Console.ReadLine().ToString();
                    
                    /// Verifica se o usuario digitou somente numeros para horas.
                    if (int.TryParse(horasString, out int value))
                    {
                        horas = Convert.ToInt32(horasString);
                        condicao = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro. Por favor digite apenas números");
                        condicao = true;
                    }
                }
                
                // Realiza o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                decimal valorTotal = this.precoInicial + this.precoPorHora * horas; 

                // Remove a placa digitada da lista de veículos
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
