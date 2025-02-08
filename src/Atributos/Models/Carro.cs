namespace Atributos.Models
{
  public class Carro(string modelo, string marca)
  {
    public string Modelo { get; set; } = modelo;

    public string Marca { get; set; } = marca;

    public List<Porta> Portas { get; set; } = [
      new Porta(Enums.LadoEnum.Direito),
      new Porta(Enums.LadoEnum.Esquerdo)];
  }
}
