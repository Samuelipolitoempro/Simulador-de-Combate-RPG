public abstract class Monstro : Personagem {
    public Monstro(string nome, float vida, int vidaMaxima, float forca, int defesa, float velocidade) : base(nome, vida, vidaMaxima, forca, defesa, velocidade, multiplicador: 1.0f) {
        
    }

    public override void MostrarStatus() {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Vida: {Vida}/{VidaMaxima}");
        Console.WriteLine($"Forca: {Forca}");
        Console.WriteLine($"Defesa: {Defesa}");
        Console.WriteLine($"Velocidade: {Velocidade}");
        Console.WriteLine($"---------------------------------");
    }
}