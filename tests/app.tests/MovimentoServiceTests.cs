using AttributeExample.Enums;
using AttributeExample.Exceptions;
using AttributeExample.Models;
using AttributeExample.Services;
using FluentAssertions;

namespace AttributeExample.Tests;

public class MovimentoServiceTests
{
  [Fact]
  public void AbrirPorta_DeveAbrirPortaDireitaParaPrimeiroEstagio()
  {
    //Arrange
    Carro carro = new("Carro velho", "Marca de carro velho")
    {
      Portas = [
            new Porta(LadoEnum.Direito) {
                Estado = RotacaoPortaEnum.Fechada
            },
            new Porta(LadoEnum.Esquerdo) {
                Estado = RotacaoPortaEnum.Fechada
            }
        ]
    };

    Carro expected = new("Carro velho", "Marca de carro velho")
    {
      Portas = [
            new Porta(LadoEnum.Direito) {
                Estado = RotacaoPortaEnum.PrimeiroEstagio
            },
            new Porta(LadoEnum.Esquerdo) {
                Estado = RotacaoPortaEnum.Fechada
            }
        ]
    };

    //Act
    MovimentoService.AbrirPorta(carro, LadoEnum.Direito, RotacaoPortaEnum.PrimeiroEstagio);

    //Assert
    carro.Should().BeEquivalentTo(expected);
  }

  [Fact]
  public void AbrirPorta_DeveMoverPortaDireitaParaSegundoEstagio()
  {
    //Arrange
    Carro carro = new("Carro velho", "Marca de carro velho")
    {
      Portas = [
            new Porta(LadoEnum.Direito) {
                Estado = RotacaoPortaEnum.PrimeiroEstagio
            },
            new Porta(LadoEnum.Esquerdo) {
                Estado = RotacaoPortaEnum.Fechada
            }
        ]
    };

    Carro expected = new("Carro velho", "Marca de carro velho")
    {
      Portas = [
            new Porta(LadoEnum.Direito) {
                Estado = RotacaoPortaEnum.SegundoEstagio
            },
            new Porta(LadoEnum.Esquerdo) {
                Estado = RotacaoPortaEnum.Fechada
            }
        ]
    };

    //Act
    MovimentoService.AbrirPorta(carro, LadoEnum.Direito, RotacaoPortaEnum.SegundoEstagio);

    //Assert
    carro.Should().BeEquivalentTo(expected);
  }

  [Fact]
  public void AbrirPorta_AbrirPortaDireitaParaSegundoEstagio_DeveApresentarValidaoDeOperacaoInvalida()
  {
    //Arrange
    Carro carro = new("Carro velho", "Marca de carro velho")
    {
      Portas = [
            new Porta(LadoEnum.Direito) {
                Estado = RotacaoPortaEnum.Fechada
            },
            new Porta(LadoEnum.Esquerdo) {
                Estado = RotacaoPortaEnum.Fechada
            }
        ]
    };

    Carro expected = new("Carro velho", "Marca de carro velho")
    {
      Portas = [
            new Porta(LadoEnum.Direito) {
                Estado = RotacaoPortaEnum.Fechada
            },
            new Porta(LadoEnum.Esquerdo) {
                Estado = RotacaoPortaEnum.Fechada
            }
        ]
    };

    //Act
    var actual = Record.Exception(() =>
      MovimentoService.AbrirPorta(carro, LadoEnum.Direito, RotacaoPortaEnum.SegundoEstagio));

    //Assert
    actual.Should().BeOfType<MovimentoInvalidoException>();
    carro.Should().BeEquivalentTo(expected);
  }
}