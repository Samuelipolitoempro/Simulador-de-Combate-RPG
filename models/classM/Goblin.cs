public class Goblin : Monstro {
    public Goblin(string nome, float vida, int vidaMaxima, float forca, int defesa, float velocidade) : base(nome, vida, vidaMaxima, forca, defesa, velocidade) {
        
    }

    public override void Atacar(Personagem alvo) {
        float ataque = Forca - alvo.Defesa;
        if (ataque < 0) {
            ataque = 0;
        }
        alvo.Vida -= ataque;
        if(alvo.Vida < 0) {
            alvo.Vida = 0;
        }
        Console.WriteLine($"{Nome} atacou {alvo.Nome} causando {ataque} de dano!");   
    }   

    public override void UsarHabilidadeEspecial(Personagem alvo) {
        float ataque = Forca * Multiplicador - alvo.Defesa;
        if (ataque < 0) {
            ataque = 0;
        }
        alvo.Vida -= ataque;
        if(alvo.Vida < 0) {
            alvo.Vida = 0;
        }
        Console.WriteLine($"{Nome} usou sua habilidade especial contra {alvo.Nome} causando {ataque} de dano!");
    }
    public override void MostrarStatus() {
        base.MostrarStatus();
    }
}