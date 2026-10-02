namespace POO;

public abstract class Animal
{
    public string Nome { get; private set; }
    public int Idade { get; private set; }

    protected Animal(string nome, int idade)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome não pode estar vazio ou nulo!", nameof(nome));
        
        if (int.IsNegative(idade))
            throw new ArgumentOutOfRangeException(nameof(idade), "A idade do animal não pode ser negativa!");
        
        Nome = nome;
        Idade = idade;
    }
    
    public void Comer()
    {
        Console.WriteLine($"{Nome} está comendo!"); // Interpolação
    }

    public virtual void FazerBarulho()
    {
        Console.WriteLine($"{Nome} fez barulho!");
    }
}