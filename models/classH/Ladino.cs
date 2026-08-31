public class Ladino : Heroi {   
    public Ladino(string nome, float vida, int vidaMaxima, float forca, int defesa, float velocidade, int nivel = 1, int xP = 0, float multiplicador = 1.5f) 
                                            : base(nome, vida, vidaMaxima, forca , defesa, velocidade, nivel, xP, multiplicador: multiplicador) {
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