public class CombateService {

    private Heroi Heroi { get; set; }
    private List<Monstro> Monstros { get; set; } = new List<Monstro>();

    public CombateService(Heroi heroi) {
        Heroi = heroi;
    }

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
        Console.WriteLine($"\nSua acao, {heroi.Nome}:");
        Console.WriteLine("1. Atacar");
        Console.WriteLine("2. Usar Habilidade Especial");
        Console.Write("Escolha sua acao: ");
        
        if (!int.TryParse(Console.ReadLine(), out int escolha)) {
            Console.WriteLine("Escolha inválida. Tente novamente.");
            return;
        }

        Monstro alvo = EscolherAlvo(monstros);
        if (alvo == null) return;

        switch (escolha) {
            case 1:
                heroi.Atacar(alvo);
                break;
            case 2:
                heroi.UsarHabilidadeEspecial(alvo);
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
        } else {
            monstro.UsarHabilidadeEspecial(Heroi);
        }
    }

    public void MostrarMonstros(List<Monstro> monstros) {
        var monstrosVivos = monstros.Where(m => m.EstaVivo()).ToList();

        Console.WriteLine("\n--- Inimigos em Combate ---");
        for (int i = 0; i < monstrosVivos.Count; i++) {
            var monstro = monstrosVivos[i];
            Console.WriteLine($"[{i + 1}] {monstro.Nome} | Vida: {monstro.Vida}/{monstro.VidaMaxima} | Defesa: {monstro.Defesa}");
        }
        Console.WriteLine("---------------------------");
    }

    public Monstro EscolherAlvo(List<Monstro> monstros) {
        var monstrosVivos = monstros.Where(m => m.EstaVivo()).ToList();

        if (monstrosVivos.Count == 0) {
            Console.WriteLine("Todos os monstros foram derrotados!");
            return null;
        }

        MostrarMonstros(monstros);

        Console.Write("Escolha o número do monstro que deseja atacar: ");
        if (int.TryParse(Console.ReadLine(), out int escolhaM) && escolhaM >= 1 && escolhaM <= monstrosVivos.Count) {
            return monstrosVivos[escolhaM - 1];
        }

        Console.WriteLine("Alvo inválido! Atacando o primeiro disponível...");
        return monstrosVivos[0];
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