# Sim City AI

## Autoria

- António Rodrigues, 22202884
- Rafael José, 22202078

## Divisão

- António Rodrigues:
  - Veículos
  - Agentes fixos do ambiente

- Rafael José:
  - Peões
    - Árvore de comportamento (*Behavior Tree*)
    - Efeito de alcoolismo (*Chaos*)
    - *Pathfinding*
    - Passadeiras
  - *Game Manager*
    - Definições dos peões
    - Definições de *chaos*
  - Relatório
    - Introdução
  - *Context*
    - Efeito de piscar (*Blink effect*)

## Introdução

Este projeto centra-se no desenvolvimento de um modelo de tráfego urbano com uma temática alienigena, no *Unity* que simula de forma realista a interação entre diferentes agentes, veículos e peões, num ambiente citadino. Para modelar o comportamento dos agentes, utilizamos o TheKiwiCoder - *behavior tree* [[1]](https://www.youtube.com/watch?v=SgrG6uAZDHE)[[2]](https://www.thekiwicoder.com/behaviour-tree), um package que permite a criação de árvores de comportamento através da interface do *Unity*. Esta interface usa *nodes* para definir comportamentos, que incluem ações, composições e decoradores, necessitando de programação em C# para executar comportamentos específicos conforme necessário, os comportamentos de cada agente são explicados na secção [metadologia](#metadologia). Complementando esse comportamento, os agentes utilizam *pathfinding* baseado na *navmesh* do *Unity* para navegar no ambiente urbano, calculando rotas eficientes que evitam obstáculos e respeitam as regras de trânsito, semáforos, sinais stop e passadeiras, para uma movimentação mais fluida e realista. Contudo, um elemento do projeto é a capacidade de introduzir um modo 'caos', no qual um agente pode deixar de obedecer às regras de trânsito, aumentando a probabilidade de comportamentos imprevisíveis e caóticos, o que pode resultar em acidentes dentro da simulação.

O ambiente urbano simulado inclui componentes essenciais como passeios, estradas, passadeiras, sinais stop, veículos e peões. A cidade é composta por vários destinos, acessíveis através de uma rede integrada de estradas para veículos e passeios para peões. Todos os elementos são desenhados para influenciar realisticamente o movimento e o comportamento dos agentes.

A pesquisa para este projeto incluiu uma revisão de estudos e trabalhos recentes sobre simulação de tráfego em cidades, com foco em modelagem baseada em agentes e o uso de técnicas de inteligência artificial para a gestão de tráfego. As fontes consultadas, através de plataformas como o Google Scholar, forneceram uma base sólida para a seleção das tecnologias implementadas e ajudaram a moldar as técnicas utilizadas para atingir os objetivos do projeto, incluindo o desenvolvimento de cenários de caos controlado para testar a resiliência da simulação.

## Estado da Arte

## Metadologia

A implementação deste trabalho foi feito em 3D, utilizando o *game engine* Unity. A simulação é feita numa cidade com ruas, estradas, passeios e passadeiras.

### Peões

Os peões são gerados aleatoriamente no inicio da simulação, sendo possível definir o número máximo de agentes a serem gerados (*Game manager - numberOfPedestrians*), num tempo aleatório entre 0 e um intervalo máximo de tempo definido pelo utilizador (*Game manager - maxDestinyTimePedestrians*). Têm um comportamento definido por uma árvore de comportamento (*Behavior Tree - Pedestrian Tree*), a qual tem 3 estados principais: normal (ou sóbrio), bêbado e em acidente.

![Árvore de comportamento dos peões](./Images/PedestrianBehaviorTree.png)

Os peões em estado normal têm um destino aleatório e tentam chegar até ele, todos eles com uma velocidade diferente, respeitando as regras de trânsito, no qual vão permanecer num tempo aleatório entre 0 e um intervalo máximo de tempo definido pelo utilizador (*Game manager - maxDestinyTimePedestrians*) até voltarem a sair de lá para outro destino aleatório.

![Sequência de comportamento normal dos peões](./Images/NormalPedestrianSequencer.png)

Cada vez que um peão sai do seu destino há uma probabilidade de sair de lá bêbado. Quando um peão está bêbado, o seu comportamento muda, passando a andar de forma mais errática e a ignorar as regras de trânsito, com uma velocidade aleatória, que pode ser mais baixa do que o seu mínimo no estado normal ou mais alta do que o máximo no seu estado normal. A probabilidade de um peão sair bêbado do seu destino é definida pelo utilizador (*Game manager - chaosChance*). E dura um tempo aleatório entre 0 e um intervalo máximo de tempo definido (*Game manager - maxChaosTime*), o peão volta ao estado normal. Durante este estado o peão está ainda a piscar para indicar que está bêbado, entre a sua cor original e a cor vermelha, a velocidade deste efeito é definida pelo utilizador (*Game manager - blinkSpeed*).

![Sequência de comportamento bêbado dos peões](./Images/DrunkPedestrianSequencer.png)

Quando um peão está em acidente, este fica parado no local do acidente durante um tempo aleatório entre 0 e um intervalo máximo de tempo definido pelo utilizador (*Game manager - maxAccidentTime*), após o qual acabar volta ao estado normal. Este estado é ativado quando um peão colide com um veículo. Durante este estado o peão está a piscar para indicar que está em acidente, entre a sua cor original e a cor vermelha, a velocidade deste efeito é definida pelo utilizador (*Game manager - blinkSpeed*).

![Sequência de comportamento em acidente dos peões](./Images/AccidentPedestrianSequencer.png)

### *Game Manager*

O *Game Manager* é o objeto que controla o estado, antes e durante, da simulação. É aqui que permite que a simulação seja personalizada, permitindo ao utilizador definir tudo o que é passível de ser definido. E esses parâmetros são:

- Peões (*Pedestrians*)
  - ***numberOfPedestrians***: número máximo de peões a serem gerados no inicio da simulação,
  - ***:pedestriansSpawnPoints***: possíveis pontos de *spawn* e destino dos peões,
  - ***:maxDestinyTimePedestrians***: intervalo máximo de tempo para um peão ser gerado ou estar parado num destino,

![Parâmetros dos peões](./Images/GameManagerPedestrians.png)

- Caos (*Chaos*)
  - ***chaosChance***: probabilidade de um agente começar a comportar-se de forma errática,
  - ***maxChaosTime***: intervalo máximo de tempo máximo para um agente estar em estado de caos,
  - ***blinkSpeed***: velocidade do efeito de piscar de um agente em estado de caos,

![Parâmetros de caos](./Images/GameManagerChaos.png)

- Acidente (*Accident*)
  - ***maxAccidentTime***: intervalo máximo de tempo para um agente estar em estado de acidente,

![Parâmetros de acidente](./Images/GameManagerAccident.png)

## Resultados e discussão

## Conclusões

## Referências

- [1] TheKiwiCoder. (2021, July 16). Free behaviour Tree editor for Unity. YouTube. https://www.youtube.com/watch?v=SgrG6uAZDHE 
- [2] TheKiwiCoder. (2021, July 16). Behaviour Tree. https://www.thekiwicoder.com/behaviour-tree 