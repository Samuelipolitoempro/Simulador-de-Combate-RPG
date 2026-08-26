public abstract class Heroi : Personagem {

    public int Nivel { get; set; } = 1;
    public int XP { get; set; } = 0;
    public Heroi(string nome, float vida, int vidaMaxima, float forca, int defesa, int nivel = 1, int xP = 0, float multiplicador = 1.5f) 
                                        : base(nome, vida, vidaMaxima, forca, defesa, multiplicador: multiplicador) {
        Nivel = nivel;
        XP = xP;
    }

    public void GanharXP(int quantidade) {
        XP += quantidade;

        while (XP >= 100)
        {
            XP -= 100;
            SubirNivel();
        }
    }

    public void SubirNivel() {
        Nivel++;
        VidaMaxima += 10;
        Vida = VidaMaxima;
        Forca += 2;
        Defesa += 2;

        Console.WriteLine($"{Nome} subiu para o nível {Nivel}!");
    }

    public abstract void Atacar(Personagem alvo);
    public abstract void UsarHabilidadeEspecial(Personagem alvo);

    public override void MostrarStatus() {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Vida: {Vida}/{VidaMaxima}");
        Console.WriteLine($"Forca: {Forca}");
        Console.WriteLine($"Defesa: {Defesa}");
        Console.WriteLine($"Nível: {Nivel}");
        Console.WriteLine($"XP: {XP}/100");
    }
    
}