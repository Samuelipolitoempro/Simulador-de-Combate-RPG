public abstract class Personagem {
     public string Nome { get; set; }
     public float Vida { get; set; }
     public int VidaMaxima { get; set; }
     public float Forca { get; set; }
     public int Defesa { get; set; }
     public float Multiplicador { get; set; } = 1.0f;
     public float Velocidade { get; set; }

     public Personagem(string nome, float vida, int vidaMaxima, float forca, int defesa, float velocidade, float multiplicador = 1.0f) {
         Nome = nome;
         Vida = vida;
         VidaMaxima = vidaMaxima;
         Forca = forca;
         Defesa = defesa;
         Velocidade = velocidade;
         Multiplicador = multiplicador;
     }

     public bool EstaVivo() {
        if (Vida > 0) {
            return true;
        }else {
            return false;
        }
    }

    public void Curar(float quantidade) {
        if(quantidade < VidaMaxima) {
            Vida += quantidade;
        }else {
            Vida = VidaMaxima;
        }
    }   

    public abstract void Atacar(Personagem alvo);
    public abstract void UsarHabilidadeEspecial(Personagem alvo);
    public abstract void MostrarStatus();
}