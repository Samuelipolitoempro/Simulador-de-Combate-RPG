Heroi heroi = new Guerreiro("Arthur", 0, 100, 25, 10, velocidade: 12);
Monstro goblin = new Goblin("Goblin Ladrão", 40, 40, 12, 3, velocidade: 18);
Monstro orc = new Orc("Orc Guerreiro", 80, 80, 20, 8, velocidade: 8);

Console.WriteLine("--- Status Inicial ---");
heroi.MostrarStatus();
goblin.MostrarStatus();
Console.WriteLine("\n--- Testando Ataque ---");
heroi.Atacar(goblin);
goblin.MostrarStatus(); // Veja se a vida do Goblin diminuiu certo!

heroi.EstaVivo();
goblin.EstaVivo();