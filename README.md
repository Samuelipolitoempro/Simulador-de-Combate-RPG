# ⚔️ Simulador de Combate RPG

Um simulador de combate RPG em turnos desenvolvido em **C#** e **.NET**, aplicando conceitos fundamentais de **Programação Orientada a Objetos (POO)** como abstração, herança, encapsulamento e polimorfismo.

---

## 📖 Sobre o Projeto

O projeto simula batalhas táticas entre um herói e grupos de monstros em uma arena de combate via console. O jogador pode escolher entre diferentes classes de heróis, executar ataques normais, usar habilidades especiais e evoluir seu personagem conforme derrota inimigos.

### 🎮 Classes do Jogo

- **Heróis:** `Guerreiro`, `Mago`, `Ladino`
- **Monstros:** `Goblin`, `Orc`, `Esqueleto`

---

## 🚀 O que foi acrescentado na nova atualização (Changelog)

Nesta versão foram implementadas melhorias essenciais de jogabilidade, fluxo de combate e progressão do herói:

### 🥊 1. Sistema Completo de Combate em Turnos (`CombateService`)
- **`IniciarCombate()`**: Gerenciador principal que orquestra as rodadas e turnos até o fim da batalha.
- **`ExecutarTurnoHeroi()`**: Permite ao jogador escolher entre atacar ou usar habilidade especial, além de selecionar o monstro alvo.
- **`ExecutarTurnoMonstro()`**: Monstros agem automaticamente com sorteio aleatório de ações (ataque básico ou habilidade especial).
- **`VerificarFimDeCombate()`**: Validação limpa e centralizada para determinar se o combate acabou (vitória ou derrota).

### 🏆 2. Recompensas e Progressão do Jogador
- **Cálculo de XP por Monstros**: O herói recebe XP multiplicado pela quantidade de monstros enfrentados.
- **Subida de Nível Automática**: Ao atingir 100 de XP, o herói sobe de nível e ganha atributos (Vida Máxima, Força e Defesa).
- **Recompensa de Vitória (Multiplicador de Dano)**: Ao vencer o combate, o herói ganha um item que aumenta seu multiplicador de dano em `+0.2x` (+20%).

### ✨ 3. Habilidades Especiais e Novos Atributos
- Adição do atributo de **`Velocidade`** na classe base `Personagem`.
- Habilidades especiais (`UsarHabilidadeEspecial`) implementadas para todos os monstros (`Goblin`, `Orc`, `Esqueleto`).
- Proteção de estado: vida dos personagens travada em zero para não exibir valores negativos.

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** C#
- **Plataforma:** .NET
- **Paradigma:** Programação Orientada a Objetos (POO)

---

## ▶️ Como Executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/samuelipolito/Simulador-de-Combate-RPG.git
   ```
2. Acesse a pasta do projeto:
   ```bash
   cd "Simulador de Combate RPG"
   ```
3. Execute o projeto com o .NET CLI:
   ```bash
   dotnet run
   ```
