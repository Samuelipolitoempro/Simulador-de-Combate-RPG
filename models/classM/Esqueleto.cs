public class Esqueleto : Monstro {
    public Esqueleto(string nome, float vida, int vidaMaxima, float forca, int defesa) : base(nome, vida, vidaMaxima, forca, defesa) {
        
    }

    public override void Atacar(Personagem alvo) {
        float ataque = Forca - alvo.Defesa;
        if (ataque < 0) {
            ataque = 0;
        }
        alvo.Vida -= ataque;
        Console.WriteLine($"{Nome} atacou {alvo.Nome} causando {ataque} de dano!");   
    }   

    public override void MostrarStatus() {
        base.MostrarStatus();
    }
}