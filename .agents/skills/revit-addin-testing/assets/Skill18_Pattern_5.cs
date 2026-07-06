// Ejemplo de prueba de integración (requiere ejecución In-Process)
[Fact]
public void CrearMuro_CuandoSePasanDatosValidos_DeberiaCrearElementoEnBD()
{
    // Usando una clase base o Fixture que provee el Documento de prueba
    Document doc = Fixture.Document; 

    using (Transaction t = new Transaction(doc, "Test Muro"))
    {
        t.Start();
        
        // Act
        Wall nuevoMuro = Wall.Create(doc, curvaTest, levelId, false);
        
        // Assert
        Assert.NotNull(nuevoMuro);
        Assert.True(nuevoMuro.Id.IntegerValue > 0);
        
        t.RollBack(); // IMPORTANTE: Se deshace la transacción para dejar el modelo limpio para el siguiente test
    }
}
