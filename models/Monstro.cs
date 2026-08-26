public abstract class Monstro : Personagem {
    public Monstro(string nome, float vida, int vidaMaxima, float forca, int defesa) : base(nome, vida, vidaMaxima, forca, defesa, multiplicador: 1.0f) {
        
    }


    public abstract void Atacar(Personagem alvo);
    public override void MostrarStatus() {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Vida: {Vida}/{VidaMaxima}");
        Console.WriteLine($"Forca: {Forca}");
        Console.WriteLine($"Defesa: {Defesa}");
    }
}