namespace POO;

static class Program
{
    static void Main(string[] args)
    {
        Animal[] animais =
        [
            new Cachorro("Pipoca", 9),
            new Gato("Pirulito", 2),
            new Vaca("Bertoldis", 5),
            new Cachorro("Denis", 10)
        ];

        foreach (Animal animalAtual in animais)
        {
            animalAtual.Comer();
            animalAtual.FazerBarulho();
        }
    }
}