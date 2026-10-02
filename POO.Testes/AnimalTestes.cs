namespace POO.Testes;

[TestClass]
[DoNotParallelize]
public sealed class AnimalTestes
{
    private StringWriter _consoleOutput;
    private TextWriter _originalOutput;

    [TestInitialize]
    public void Setup() // Setup significa Configurar
    {
        _consoleOutput = new StringWriter();
        _originalOutput = Console.Out;
        Console.SetOut(_consoleOutput);
    }

    [TestCleanup] 
    public void Cleanup() // Significa Limpar
    {
        Console.SetOut(_originalOutput);
        _consoleOutput.Dispose();
    }

    // Happy path
    [TestMethod]
    public void QuandoInstanciarCachorro_ComNomeEIdadeCorretos_DeveRetornarObjeto() 
    {
        // Arrange - Arranjo
        string nomeEsperado = "Pipoca";
        int idadeEsperada = 9;

        // Act - Ação
        var animal = new Cachorro(nomeEsperado, idadeEsperada);

        // Assert
        Assert.AreEqual(nomeEsperado, animal.Nome);
        Assert.AreEqual(idadeEsperada, animal.Idade);
    }

    [TestMethod]
    public void QuandoInvocadoComer_Sempre_DeveEscreverMensagemPadraoNoConsole()
    {
        // Arrange - Arranjo
        string nome = "Mimosa";
        var animal = new Vaca(nome, 2);
        string messagemEsperada = $"{nome} está comendo!{Environment.NewLine}"; 
        
        // Act - Ação
        animal.Comer();
        
        // Assert - Afirmação
        Assert.AreEqual(messagemEsperada, _consoleOutput.ToString());
    }

    [TestMethod]
    public void QuandoInvocadoFazerBarulho_NaInstanciaCachorro_DeveFazerAuAu()
    {
        // Arrange
        var nome = "Toto";
        var animal = new Cachorro(nome, 5);
        var mensagemEsperada = $"{nome} fez auau!{Environment.NewLine}";

        // Act
        animal.FazerBarulho();

        // Assert
        Assert.AreEqual(mensagemEsperada, _consoleOutput.ToString());
    }

    [TestMethod]
    public void QuandoInvocadoFazerBarulho_NaInstanciaGato_DeveFazerMiau()
    {
        // Arrange
        var nome = "Garfield";
        var animal = new Gato(nome, 5);
        var mensagemEsperada = $"{nome} fez miau!{Environment.NewLine}";

        // Act
        animal.FazerBarulho();

        // Assert
        Assert.AreEqual(mensagemEsperada, _consoleOutput.ToString());
    }
    
    [TestMethod]
    public void QuandoInvocadoFazerBarulho_NaInstanciaVaca_DeveFazerMu()
    {
        // Arrange
        var nome = "Mimosa";
        var animal = new Vaca(nome, 5);
        var mensagemEsperada = $"{nome} fez mu!{Environment.NewLine}";

        // Act
        animal.FazerBarulho();

        // Assert
        Assert.AreEqual(mensagemEsperada, _consoleOutput.ToString());
    } 
    
    // Unhappy Tests
    [TestMethod]
    public void QuandoInstanciarComNomeVazio_Sempre_DeveLancarArgumentException()
    {
        // Arrange
        string nomeAnimal = string.Empty;
        
        // Act -> Assert
        var excecao = Assert.ThrowsExactly<ArgumentException>(() => new Cachorro(nomeAnimal, 12));
        Assert.Contains("O nome não pode estar vazio ou nulo!", excecao.Message);
    }

    [TestMethod]
    public void QuandoInstanciarComNomeNulo_Sempre_DeveLancarArgumentException()
    {
        // Arrange
        string nomeAnimal = null!;
        
        // Act -> Assert
        var excecao = Assert.ThrowsExactly<ArgumentException>(() => new Cachorro(nomeAnimal, 12));
        Assert.Contains("O nome não pode estar vazio ou nulo!", excecao.Message);
    }
    
    [TestMethod]
    public void QuandoInstanciarComIdadeNegativa_Sempre_DeveLancarArgumentOutOfRangeException()
    {
        // Arrange
        int idade = -1;

        // Act -> Assert
        var excecao = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => new Cachorro("Toto", idade));
        Assert.Contains("A idade do animal não pode ser negativa!", excecao.Message);
    }
}