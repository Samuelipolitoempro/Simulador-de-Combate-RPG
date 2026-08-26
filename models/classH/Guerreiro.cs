public class Guerreiro : Heroi {   
    public Guerreiro(string nome, float vida, int vidaMaxima, float forca, int defesa, int nivel = 1, int xP = 0, float multiplicador = 1.5f) 
                                            : base(nome, vida, vidaMaxima, forca, defesa, nivel, xP, multiplicador: multiplicador) {
    }

    public override void Atacar(Personagem alvo) {
        float ataque = Forca - alvo.Defesa;
        if (ataque < 0) {
            ataque = 0;
        }
        alvo.Vida -= ataque;
        Console.WriteLine($"{Nome} atacou {alvo.Nome} causando {ataque} de dano!");   
    }   

    public override void UsarHabilidadeEspecial(Personagem alvo) {
        float ataque = Forca * Multiplicador - alvo.Defesa;
        if (ataque < 0) {
            ataque = 0;
        }
        alvo.Vida -= ataque;
        Console.WriteLine($"{Nome} usou sua habilidade especial contra {alvo.Nome} causando {ataque} de dano!");
    }

    public override void MostrarStatus() {
        base.MostrarStatus();
    }
}