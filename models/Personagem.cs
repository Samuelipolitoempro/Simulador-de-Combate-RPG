public abstract class Personagem {
     public string Nome { get; set; }
     public float Vida { get; set; }
     public int VidaMaxima { get; set; }
     public float Forca { get; set; }
     public int Defesa { get; set; }
     public float Multiplicador { get; set; }

     public Personagem(string nome, float vida, int vidaMaxima, float forca, int defesa, float multiplicador = 1.5f) {
         Nome = nome;
         Vida = vida;
         VidaMaxima = vidaMaxima;
         Forca = forca;
         Defesa = defesa;
         Multiplicador = multiplicador;
     }

     public void ReceberDano(float dano) {
         if(dano > Vida){
            Vida = 0;
        }else{
            Vida -= dano;
        }
     }

     public bool EstarVivo() {
        if (Vida > 0) {
            Console.WriteLine("Sim, você está vivo!");
            return true;
        }else {
            Console.WriteLine("Você está morto!");
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