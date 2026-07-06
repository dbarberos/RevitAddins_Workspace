[Fact]
public void CalcularCostoTotal_DeberiaRetornarValorCorrecto()
{
    // Arrange
    var mockMuro1 = new Mock<IMuroData>();
    mockMuro1.Setup(m => m.ObtenerAreaMetrica()).Returns(10.0);
    
    var mockMuro2 = new Mock<IMuroData>();
    mockMuro2.Setup(m => m.ObtenerAreaMetrica()).Returns(20.0);

    var calculadora = new CalculadoraCostos();

    // Act
    double resultado = calculadora.CalcularCostoTotal(new[] { mockMuro1.Object, mockMuro2.Object });

    // Assert
    Assert.Equal(465.0, resultado); // (10 * 15.5) + (20 * 15.5)
}
