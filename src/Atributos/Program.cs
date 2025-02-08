// Carro carro = new("Carro velho", "Marca de carro velho");
// Console.WriteLine($"Estado atual: {JsonSerializer.Serialize(
//     carro,
//     new JsonSerializerOptions { WriteIndented = true })}");

using Atributos.Services;

CarroManager manager = new();
manager.PrintarEstadoAtual();

manager.AbrirPorta(Atributos.Enums.LadoEnum.Direito, Atributos.Enums.RotacaoPortaEnum.PrimeiroEstagio);
manager.PrintarEstadoAtual();

manager.AbrirPorta(Atributos.Enums.LadoEnum.Direito, Atributos.Enums.RotacaoPortaEnum.SegundoEstagio);
manager.PrintarEstadoAtual();

