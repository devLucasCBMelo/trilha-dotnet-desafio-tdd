using CalculadoraTDD.Services;

namespace CalculadoraTDDTestes;

public class CalculadoraTests
{
    private CalculadoraImp _calculadora;

    public CalculadoraTests()
    {
        _calculadora = new CalculadoraImp();
    }

    [Fact]
    public void TestSomar1()
    {
        int valor1 = 5;
        int valor2 = 10;

        int resultado = _calculadora.Somar(valor1, valor2);

        Assert.Equal(15, resultado);

    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(4, 6, 10)]
    public void TestSomar2(int val1, int val2, int resultado)
    {
        int resultadoCalculadora = _calculadora.Somar(val1, val2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(1, 2, -1)]
    [InlineData(6, 4, 2)]
    public void TestSubtrair1(int val1, int val2, int resultado)
    {
        int resultadoCalculadora = _calculadora.Subtrair(val1, val2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(6, 4, 24)]
    public void TestMultiplicar1(int val1, int val2, int resultado)
    {
        int resultadoCalculadora = _calculadora.Multiplicar(val1, val2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(4, 2, 2)]
    [InlineData(15, 3, 5)]
    public void TestDividir1(int val1, int val2, int resultado)
    {
        int resultadoCalculadora = _calculadora.Dividir(val1, val2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void TestarDivisaoPorZero()
    {
        Assert.Throws<DivideByZeroException>(
            () => _calculadora.Dividir(3, 0)
        );
    }

    [Fact]
    public void TestarHistory()
    {
        _calculadora.Somar(1, 4);
        _calculadora.Subtrair(5, 1);
        _calculadora.Subtrair(2, 1);

        var lista = _calculadora.historico();

        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);
    }

    [Fact]
    public void TestarHistorico_ComMenosDeTresEntradas()
    {
        // Arrange: Adiciona 2 operações
        _calculadora.Somar(1, 2);
        _calculadora.Subtrair(5, 1);

        // Act: Pega o histórico
        var lista = _calculadora.historico();

        // Assert: Verifica que não foram removidos itens
        Assert.NotEmpty(lista);
        Assert.Equal(2, lista.Count);
    }

    [Fact]
    public void TestarHistorico_ComMaisDeTresEntradas()
    {
        // Arrange: Adiciona 4 operações
        _calculadora.Somar(1, 2);
        _calculadora.Subtrair(5, 1);
        _calculadora.Dividir(10, 2);
        _calculadora.Multiplicar(3, 4);

        // Act: Pega o histórico
        var lista = _calculadora.historico();

        // Assert: Verifica que o histórico contém apenas os 3 últimos itens
        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);
        Assert.Contains("Res: 12", lista); // Multiplicação deve estar presente
        Assert.Contains("Res: 5", lista);  // Divisão deve estar presente
        Assert.Contains("Res: 4", lista);  // Subtração deve estar presente
    }
}