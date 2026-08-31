using System;
using System.Collections.Generic;

Console.Clear();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("==========================================================");
Console.WriteLine("             ⚔️  SIMULADOR DE COMBATE RPG  ⚔️             ");
Console.WriteLine("==========================================================");
Console.ResetColor();

// 1. Criação do Herói
Console.Write("Digite o nome do seu Herói: ");
string nomeHeroi = Console.ReadLine();
if (string.IsNullOrWhiteSpace(nomeHeroi)) nomeHeroi = "Arthur";

Console.WriteLine("\nEscolha sua Classe:");
Console.WriteLine("1 - 🛡️  Guerreiro (Mais vida e defesa)");
Console.WriteLine("2 - 🔮  Mago (Alto dano com magia)");
Console.WriteLine("3 - 🗡️  Ladino (Muito veloz)");
Console.Write("Opção: ");
string opcaoClasse = Console.ReadLine();

Heroi heroi = opcaoClasse switch
{
    "2" => new Mago(nomeHeroi, 80, 80, 28, 6, velocidade: 14),
    "3" => new Ladino(nomeHeroi, 90, 90, 24, 8, velocidade: 20),
    _   => new Guerreiro(nomeHeroi, 110, 110, 22, 12, velocidade: 10)
};

Console.WriteLine($"\n✅ Herói {heroi.Nome} criado com sucesso!");
Console.WriteLine("Pressione qualquer tecla para ir ao menu...");
Console.ReadKey();

// 2. Loop Principal
bool jogando = true;
int rodadaArena = 1;

while (jogando && heroi.EstaVivo())
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("==========================================================");
    Console.WriteLine($"   HERÓI: {heroi.Nome} | Nível: {heroi.Nivel} | XP: {heroi.XP}/100 | Vida: {heroi.Vida}/{heroi.VidaMaxima}");
    Console.WriteLine("==========================================================");
    Console.ResetColor();

    Console.WriteLine("1 - ⚔️  Iniciar Combate na Arena");
    Console.WriteLine("2 - 📊 Ver Status do Herói");
    Console.WriteLine("3 - 🧪 Descansar e Curar");
    Console.WriteLine("4 - 🚪 Sair do Jogo");
    Console.Write("\nEscolha uma opção: ");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Clear();
            Console.WriteLine($"=== 🏟️  BATALHA - ARENA ONDA {rodadaArena} ===");

            CombateService combate = new CombateService(heroi);

            // Monstros numerados por sua ordem na lista de combate:
            combate.AdicionarMontro(new Goblin("Goblin 1", 35, 35, 12, 3, velocidade: 16));
            combate.AdicionarMontro(new Goblin("Goblin 2", 35, 35, 12, 3, velocidade: 16));
            combate.AdicionarMontro(new Orc("Orc 1", 60, 60, 18, 6, velocidade: 8));

            if (rodadaArena >= 2)
            {
                combate.AdicionarMontro(new Esqueleto("Esqueleto 1", 45, 45, 15, 5, velocidade: 11));
            }

            combate.IniciarCombate();
            rodadaArena++;

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            break;

        case "2":
            Console.Clear();
            Console.WriteLine("=== 📊 STATUS DETALHADO DO HERÓI ===");
            heroi.MostrarStatus();
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
            break;

        case "3":
            heroi.Curar(30);
            Console.WriteLine($"\n✨ {heroi.Nome} descansou e recuperou vida! Vida atual: {heroi.Vida}/{heroi.VidaMaxima}");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
            break;

        case "4":
            jogando = false;
            Console.WriteLine("\nObrigado por jogar!");
            break;

        default:
            Console.WriteLine("\nOpção inválida! Pressione qualquer tecla...");
            Console.ReadKey();
            break;
    }
}

if (!heroi.EstaVivo())
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\n💀 FIM DE JOGO! Seu herói caiu em combate.");
    Console.ResetColor();
}
