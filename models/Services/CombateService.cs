public class CombateService {

    private Heroi Heroi { get; set; }
    private List<Monstro> Monstros { get; set; } = new List<Monstro>();
    

    public void AdicionarMontro(Monstro monstro) {
        Monstros.Add(monstro);
        Console.WriteLine($"Monstro {monstro.Nome} adicionado à lista de monstros.");
        Console.WriteLine("----------------------------------------------------------");
    }

    public List<Personagem> DeterminarOrdemTurno(Heroi heroi, List<Monstro> monstros) {
    var random = new Random();
    var todos = new List<Personagem> { heroi };
    todos.AddRange(monstros);
    return todos.OrderByDescending(_ => random.Next(1, 20)).ToList();
    }

    public void IniciarCombate()
    {
        Console.WriteLine("Iniciando combate...");
        Console.WriteLine("----------------------------------------------------------");
        while (!VerificarFimDeCombate()) {
            Console.Write("Ação do herói: ");
            ExecutarTurnoHeroi(Heroi, Monstros);
            if (VerificarFimDeCombate()) {
                break;
            }
            
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Ação dos monstros:");
            foreach (var monstro in Monstros) {
                if (monstro.EstaVivo()) {
                    ExecutarTurnoMonstro(monstro);

                    if (!Heroi.EstaVivo()) {
                    break;
                    }
                }
            }
            Console.WriteLine("----------------------------------------------------------");
        }
        FinalizarCombate();
    }

    public void ExecutarTurnoHeroi(Heroi heroi, List<Monstro> monstros) {
        Console.WriteLine($"Sua acao, {heroi.Nome}:");
        Console.WriteLine("1. Atacar");
        Console.WriteLine("2. Usar Habilidade Especial");
        int escolha = int.Parse(Console.ReadLine());

        switch (escolha) {
        case 1:
                EscolherAlvo(monstros);
                heroi.Atacar(EscolherAlvo(monstros));
        break;
        case 2:
                EscolherAlvo(monstros);
                heroi.UsarHabilidadeEspecial(EscolherAlvo(monstros));
        break;
        default:
                Console.WriteLine("Escolha inválida. Tente novamente.");
        break;
        }
        
    }

    public void ExecutarTurnoMonstro(Monstro monstro) {
        Random random = new Random();
        double sorteio = random.NextDouble();

        if (sorteio < 0.5) {
            monstro.Atacar(Heroi);
        }else {
            monstro.UsarHabilidadeEspecial(Heroi);
        }
    }
    public void MostrarMonstros(List<Monstro> monstros) {
        var monstrosVivos = monstros.Where(m => m.EstaVivo()).ToList();

        Console.WriteLine("Monstros disponíveis:");
        int contador = 1;
        foreach (var monstro in monstrosVivos) {
        Console.WriteLine($"{contador} -");
        monstro.MostrarStatus();
        contador++;
        }
    }

    public Monstro EscolherAlvo(List<Monstro> monstros) {
        MostrarMonstros(monstros);
        if(monstros.Count == 0) {
            Console.WriteLine("Todos os monstros foram derrotados!");
            return null;
        } else {
            Console.WriteLine("Escolha o número do monstro que deseja atacar:");
            int escolhaM = int.Parse(Console.ReadLine());
            return monstros[escolhaM - 1];
        }

    }

    public bool VerificarFimDeCombate() {

        return !Heroi.EstaVivo() || Monstros.All(m => !m.EstaVivo());
    }
    public void FinalizarCombate() {
        if (Heroi.EstaVivo()) {
            Console.WriteLine("🏆 Vitória!");

            int quantidadeMonstros = Monstros.Count;
            int xpPorMonstro = 50;
            int xpTotal = quantidadeMonstros * xpPorMonstro;

            Heroi.GanharXP(xpTotal);
            Heroi.AumentarMultiplicadorDano(0.2f);
        }else {
            Console.WriteLine("☠️ Derrota! O herói foi derrotado.");
        }
    }
}