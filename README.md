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
  - *Context*
    - Efeito de piscar (*Blink effect*)

## Introdução

## Estado da Arte

## Metadologia

A implementação deste trabalho foi feito em 3D, utilizando o *game engine* Unity. A simulação é feita numa cidade com ruas, estradas, passeios e passadeiras.

### Peões

Os peões são gerados aleatoriamente no inicio da simulação, sendo possível definir o número máximo de agentes a serem gerados (*Game manager - numberOfPedestrians*), num tempo aleatório entre 0 e um intervalo máximo de tempo definido pelo utilizador (*Game manager - maxDestinyTimePedestrians*). Têm um comportamento definido por uma árvore de comportamento (*Behavior Tree - Pedestrian Tree*), a qual tem 3 estados principais: normal (ou sóbrio), bêbado e em acidente.

Os peões em estado normal têm um destino aleatório e tentam chegar até ele, evitando colisões com outros peões e veículos e respeitando as regras de trânsito, no qual vão permanecer num tempo aleatório entre 0 e um intervalo máximo de tempo definido pelo utilizador (*Game manager - maxDestinyTimePedestrians*) até voltarem a sair de lá para outro destino aleatório.

[PLACEHOLDER PARA IMAGEM DA ARVORE DE COMPORTAMENTO EM ESTADO NORMAL]

Cada vez que um peão sai do seu destino há uma probabilidade de sair de lá bêbado. Quando um peão está bêbado, o seu comportamento muda, passando a andar de forma mais errática e a ignorar as regras de trânsito. A probabilidade de um peão sair bêbado do seu destino é definida pelo utilizador (*Game manager - chaosChance*). E com um tempo aleatório entre 0 e um intervalo máximo de tempo definido (*Game manager - maxChaosTime*), o peão volta ao estado normal. Durante este estado o peão está ainda a piscar para indicar que está bêbado, entre a sua cor original e a cor vermelha, a velocidade deste efeito é definida pelo utilizador (*Game manager - blinkSpeed*).

[PLACEHOLDER PARA IMAGEM DA ARVORE DE COMPORTAMENTO EM ESTADO BÊBADO]

Quando um peão está em acidente, este fica parado no local do acidente durante um tempo aleatório entre 0 e um intervalo máximo de tempo definido pelo utilizador (*Game manager - maxAccidentTime*), após o qual acabar volta ao estado normal. Este estado é ativado quando um peão colide com um veículo. Durante este estado o peão está a piscar para indicar que está em acidente, entre a sua cor original e a cor vermelha, a velocidade deste efeito é definida pelo utilizador (*Game manager - blinkSpeed*).

[PLACEHOLDER PARA IMAGEM DA ARVORE DE COMPORTAMENTO EM ESTADO ACIDENTE]

### *Game Manager*

O *Game Manager* é o objeto que controla o estado, antes e durante, da simulação. É aqui que permite que a simulação seja personalizada, permitindo ao utilizador definir tudo o que é passível de ser definido. E esses parâmetros são:

- Peões (*Pedestrians*)
  - ***numberOfPedestrians***: número máximo de peões a serem gerados no inicio da simulação,
  - ***:pedestriansSpawnPoints***: possíveis pontos de *spawn* e destino dos peões,
  - ***:maxDestinyTimePedestrians***: intervalo máximo de tempo para um peão ser gerado ou estar parado num destino,

[PLACEHOLDER PARA IMAGEM DOS PARÂMETROS DOS PEÕES]

- Caos (*Chaos*)
  - ***chaosChance***: probabilidade de um agente começar a comportar-se de forma errática,
  - ***maxChaosTime***: intervalo máximo de tempo máximo para um agente estar em estado de caos,
  - ***blinkSpeed***: velocidade do efeito de piscar de um agente em estado de caos,

[PLACEHOLDER PARA IMAGEM DOS PARÂMETROS DOS PEÕES]

- Acidente (*Accident*)
  - ***maxAccidentTime***: intervalo máximo de tempo para um agente estar em estado de acidente,

[PLACEHOLDER PARA IMAGEM DOS PARÂMETROS DOS PEÕES]

## Resultados e discussão

## Conclusões

## Referências
