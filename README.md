# Sim City AI

## Autoria

- António Rodrigues, 22202884
- Rafael José, 22202078

## Divisão

- António Rodrigues:
  - Carros
    - Árvore de comportamento (*Behavior Tree*)
    - Efeito de alcoolismo (*Chaos*)
    - *Pathfinding*
  - Peões
    - Sistema de troca de cor
  - Agentes fixos do ambiente
    - Semáforos
    - Sinais de Stop
    - Estradas
    - Destinos
  - *Game Manager*
    - Definições dos carros
    - Gerador de carros
    - Contador de carros
    - Métodos para UI
  - *UI*
    - Botões
    - Texto
  - Câmera
    - Câmera com movimentação de teclado para a build
  - Relatório
    - Metodologia
      - Carros
      - Estradas
      - Destinos
      - Semáforos
      - Sinais Stop

- Rafael José:
  - Peões
    - Árvore de comportamento (*Behavior Tree*)
    - Efeito de alcoolismo (*Chaos*)
    - *Pathfinding*
  - Agentes fixos do ambiente
    - Passadeiras
    - Passeios
  - *Game Manager*
    - Definições dos peões
    - Definições de *chaos*
    - Definições de acidente
    - Gerador de peões
    - Contador de peões
  - Relatório
    - Introdução
    - Estado da Arte
    - Metodologia
      - Peões
      - *Game Manager*
    - Resultados e discussão
    - Conclusões
  - *Context*
    - Efeito de piscar (*Blink effect*)
  - Limpeza e organização do projeto

## Introdução

Este projeto centra-se no desenvolvimento de um modelo de tráfego urbano com uma temática alienigena, no *Unity* que simula de forma realista a interação entre diferentes agentes, carros e peões, num ambiente citadino. Para modelar o comportamento dos agentes, utilizamos o TheKiwiCoder - *behavior tree* [[1]](https://www.youtube.com/watch?v=SgrG6uAZDHE)[[2]](https://www.thekiwicoder.com/behaviour-tree), um package que permite a criação de árvores de comportamento através da interface do *Unity*. Esta interface usa *nodes* para definir comportamentos, que incluem ações, composições e decoradores, necessitando de programação em C# para executar comportamentos específicos conforme necessário, os comportamentos de cada agente são explicados na secção [metadologia](#metadologia). Complementando esse comportamento, os agentes utilizam *pathfinding* baseado na *navmesh* do *Unity* para navegar no ambiente urbano, calculando rotas eficientes que evitam obstáculos e respeitam as regras de trânsito, semáforos, sinais stop e passadeiras, para uma movimentação mais fluida e realista. Contudo, um elemento do projeto é a capacidade de introduzir um modo 'caos', no qual um agente pode deixar de obedecer às regras de trânsito, aumentando a probabilidade de comportamentos imprevisíveis e caóticos, o que pode resultar em acidentes dentro da simulação.

O ambiente urbano simulado inclui componentes essenciais como passeios, estradas, passadeiras, sinais stop, carros e peões. A cidade é composta por vários destinos, acessíveis através de uma rede integrada de estradas para carros e passeios para peões. Todos os elementos são desenhados para influenciar realisticamente o movimento e o comportamento dos agentes.

A pesquisa para este projeto incluiu uma revisão de estudos e trabalhos recentes sobre simulação de tráfego em cidades, com foco em modelagem baseada em agentes e o uso de técnicas de inteligência artificial para a gestão de tráfego. As fontes consultadas, através de plataformas como o Google Scholar, forneceram uma base sólida para a seleção das tecnologias implementadas e ajudaram a moldar as técnicas utilizadas para atingir os objetivos do projeto, incluindo o desenvolvimento de cenários de caos controlado para testar a resiliência da simulação.

## Estado da Arte

Nesta secção, iremos apresentar uma pequena pesquisa feita sobre este tipo de simulações, com recurso a trabalhos semelhante, descrevendo-os e comparando-os com o nosso trabalho.

### *The Action Point Angle of Sight: A Traffic Generation Method for Driving Simulation, as a Small Step to Safe, Sustainable and Smart Cities*

Este trabalho aborda o desenvolvimento de um gerador de tráfego para simulações de condução, denominado "*Action Point Angle of Sight*" (APAS), que visa aprimorar a autenticidade das simulações de tráfego usadas para testar carros autónomos e melhorar a segurança rodoviária. Este método é projetado para integrar-se com simuladores de condução modernos, oferecendo uma abordagem mais naturalista e precisa para a geração de tráfego em ambientes urbanos.

A principal inovação do APAS é a sua capacidade de simular interações baseadas em física entre carros, infraestruturas e condições ambientais variáveis, como o clima. Utiliza modelos avançados que permitem a simulação de comportamentos de tráfego realistas, como a observância das regras de trânsito e a reação a fatores estocásticos, como carros aleatórios e variações de velocidade. Ao contrário de simuladores tradicionais que frequentemente reciclam tecnologias antigas e apresentam limitações na representação de fluxos de tráfego mistos e caóticos, o APAS foi desenvolvido para superar essas barreiras, oferecendo uma ferramenta robusta e versátil para o estudo e planeamento de tráfego urbano. [[3]](https://www.researchgate.net/publication/371605221_The_Action_Point_Angle_of_Sight_A_Traffic_Generation_Method_for_Driving_Simulation_as_a_Small_Step_to_Safe_Sustainable_and_Smart_Cities)

#### **Comparação com o nosso projeto**

- **Abordagem de Simulação de Tráfego:**
  - Ambos os projetos visam aprimorar as simulações de tráfego, mas o nosso projeto foca a criação de um ambiente urbano com múltiplos tipos de agentes, utilizando behavior trees para modelar uma gama variada de comportamentos de tráfego, incluindo a interação entre carros e peões. Por outro lado, o APAS desenvolve um método específico que melhora a geração de fluxos de tráfego mistos e realistas, focando-se na precisão dos movimentos e nas respostas dos carros autonomos em condições variadas de tráfego.
- **Integração de Comportamentos Realistas:**
  - O nosso projeto implementa uma abordagem para simular comportamentos de tráfego e interações entre agentes, destacando-se na modelação de cenários urbanos dinâmicos. O APAS, por sua vez, concentra-se na utilização de uma nova fórmula teórica para simular de forma eficaz os comportamentos de carros em resposta a variáveis estocásticas, como carros aleatórios e variações de velocidade, visando uma simulação que se aproxima das condições reais de condução.

### *Creating an Interactive Urban Traffic System for the Simulation of Different Traffic Scenarios*

Este trabalho explora a criação de um sistema de tráfego urbano interativo utilizando a realidade virtual (VR) para simular diferentes cenários de tráfego numa cidade modelo da Europa Central. Utilizando *engine* Unity, os autores desenvolveram um ambiente virtual imersivo que permite aos utilizadores experimentar condições de tráfego dinâmicas de forma visual e interativa. O foco do sistema é proporcionar uma plataforma que possa visualizar e simular a complexa interação entre peões, transporte individual e público.

A principal inovação apresentada é o uso de um sistema de tráfego modular e personalizável dentro do Unity, que reage ao comportamento individual dos utilizadores, incluindo a movimentação do avatar. Isto é crucial para evitar acidentes ou congestionamentos de tráfego irremediáveis. Esta ferramenta elimina a necessidade de software de terceiros, tornando-a uma opção valiosa para desenvolvedores que procuram implementar sistemas de tráfego em ambientes virtuais imersivos. 

A metodologia aplicada baseia-se nas capacidades atuais do Unity, permitindo a criação de objetos 3D. O sistema de tráfego emprega uma rede de waypoints, onde os carros seguem rotas predeterminadas, interagindo com semáforos e outros elementos do tráfego conforme programado. Este sistema também permite ajustes em tempo real dos parâmetros de tráfego para refletir mudanças no cenário simulado. [[4]](https://www.mdpi.com/2076-3417/13/10/6020)

#### **Comparação com o nosso projeto**

- **Flexibilidade e Parametrização:**
  - Ambos os projetos oferecem sistemas de tráfego onde os parâmetros podem ser ajustados pelos utilizadores para modificar cenários de tráfego, destacando-se pela capacidade de responderem a ajustes definidos pelo utilizador para refletir diferentes condições urbanas.
- **Interação e Realismo no Tráfego:**
  - O nosso projeto e o sistema descrito no artigo investem em criar simulações que capturam interações realistas entre os componentes do tráfego. Ambos utilizam técnicas para gerir e simular o movimento de carros e o comportamento dos agentes em ambientes urbanos com o objetivo de aumentar o realismo da simulação.

### *Project Westdrive: Unity City With Self-Driving Cars and Pedestrians for Virtual Reality Studies*

Este estudo introduz o projeto "*Westdrive*", uma cidade virtual desenvolvida no Unity para estudos em realidade virtual, focada em navegação espacial e aspetos éticos de decisões em ambientes urbanos. A cidade virtual de *Westdrive* abrange uma área de 230 hectares e inclui até 150 carros autónomos e 655 pedestres ativos e passivos, além de milhares de elementos naturais para criar um ambiente dinâmico e realista.

O projeto é open-source e modular, construído para ser facilmente adaptável às necessidades variadas de experimentos científicos. Oferece uma ferramenta chamada "*City AI toolkit*" que permite aos utilizadores criar avatares e personalizar carros sem necessidade de conhecimento prévio em programação, facilitando o uso de suas funcionalidades integradas no *engine* Unity.

A estrutura do projeto permite uma implementação simples de ambientes complexos, onde todos os componentes podem ser usados independentemente. A simulação envolve elementos estáticos, como edifícios e árvores, e dinâmicos, como carros e pedestres que se movem de acordo com scripts programáveis. A interação dos objetos é controlada por um conjunto de ferramentas que administram os percursos, os carros e os comportamentos dos pedestres dentro da simulação. [[5]](https://www.frontiersin.org/articles/10.3389/fict.2020.00001/full)

#### **Comparação com o nosso projeto**

- **Modularidade e Personalização:**
  - O nosso projeto permite a personalização de cenários de tráfego e comportamentos de agentes, o que é semelhante ao *Westdrive*. No entanto, o *Westdrive* destaca-se pela sua estrutura altamente modular e scriptável, que facilita a adaptação às necessidades específicas de diferentes estudos de pesquisa, oferecendo um toolkit que permite aos usuários modificar avatares e carros sem programação direta.
- **Facilidade de Implementação e Adaptação:**
  - O Westdrive oferece uma plataforma que minimiza as barreiras técnicas para a configuração de experimentos, integrando todas as funções principais na interface gráfica do Unity e permitindo modificações sem codificação direta. O nosso projeto, embora possa exigir um conhecimento técnico mais profundo para personalizações e ajustes, oferece uma flexibilidade para adaptar o comportamento do tráfego conforme necessário.

## Metadologia

A implementação deste trabalho foi feito em 3D, utilizando o *game engine* Unity. A simulação é feita numa cidade com ruas, estradas, passeios e passadeiras.

### Peões

Os peões são gerados aleatoriamente no inicio da simulação, sendo possível definir o número máximo de agentes a serem gerados (*Game manager - numberOfPedestrians*), num tempo aleatório entre 0 e um intervalo máximo de tempo definido pelo utilizador (*Game manager - maxDestinyTimePedestrians*). Têm um comportamento definido por uma árvore de comportamento (*Behavior Tree - Pedestrian Tree*), a qual tem 3 estados principais: normal (ou sóbrio), bêbado e em acidente.

![Árvore de comportamento dos peões](./Images/PedestrianBehaviorTree.png)

Os peões em estado normal têm um destino aleatório e tentam chegar até ele, todos eles com uma velocidade diferente, respeitando as regras de trânsito, no qual vão permanecer num tempo aleatório entre 0 e um intervalo máximo de tempo definido pelo utilizador (*Game manager - maxDestinyTimePedestrians*) até voltarem a sair de lá para outro destino aleatório.

![Sequência de comportamento normal dos peões](./Images/NormalPedestrianSequencer.png)

Cada vez que um peão sai do seu destino há uma probabilidade de sair de lá bêbado. Quando um peão está bêbado, o seu comportamento muda, passando a andar de forma mais errática e a ignorar as regras de trânsito, com uma velocidade aleatória, que pode ser mais baixa do que o seu mínimo no estado normal ou mais alta do que o máximo no seu estado normal. A probabilidade de um peão sair bêbado do seu destino é definida pelo utilizador (*Game manager - chaosChance*). E dura um tempo aleatório entre 0 e um intervalo máximo de tempo definido (*Game manager - maxChaosTime*), o peão volta ao estado normal. Durante este estado o peão está ainda a piscar para indicar que está bêbado, entre a sua cor original e a cor vermelha, a velocidade deste efeito é definida pelo utilizador (*Game manager - blinkSpeed*).

![Sequência de comportamento bêbado dos peões](./Images/DrunkPedestrianSequencer.png)

Quando um peão está em acidente, este fica parado no local do acidente durante um tempo aleatório entre 0 e um intervalo máximo de tempo definido pelo utilizador (*Game manager - maxAccidentTime*), após o qual acabar volta ao estado normal. Este estado é ativado quando um peão colide com um carro. Durante este estado o peão está a piscar para indicar que está em acidente, entre a sua cor original e a cor vermelha, a velocidade deste efeito é definida pelo utilizador (*Game manager - blinkSpeed*).

![Sequência de comportamento em acidente dos peões](./Images/AccidentPedestrianSequencer.png)

Os peões são representados pelo modelo de um alien. Este modelo muda de cor sempre que é gerado.
![Modelo peões](./Images/ModelPeao.png)


### Carros

Os carros são gerados aleatoriamente no inicio da simulação, sendo possível definir o número máximo de agentes a serem gerados (*Game manager - numberOfCars*), estes são gerados instantaneamente nas localizações iniciais, se houver mais que um para ser gerado nessa localização, há um atraso de tempo definido pelo utilizador até o próximo carro ser gerado nessa localização (*Game manager - timerForCarToSpawn*). Têm um comportamento definido por uma árvore de comportamento (*Behavior Tree - Car*), a qual tem 3 estados principais: normal (ou sóbrio), bêbado e em acidente.

![Árvore de comportamento dos carros](./Images/CarBehaviorTree.png)

Os carros em estado normal têm um destino aleatório e tentam chegar até ele, cada prefab de carro tem uma velocidade diferente, respeitando as regras de trânsito, verificam se há peões no caminho, se têm um sinal de stop à frente ou um semáforo. Estas verificações são feita com *RayCast's*. Nesses casos o carro trava e fica parado uns segundo no node *Wait*. Quando chegam ao seu destino, recebem um novo destino, desaparecem uns segundos e voltam a aparecer.

![Sequência de comportamento normal dos carros](./Images/CarMovingSequence.png)
![Sequência de verificação de colisões](./Images/CollisionCheckSequence.png)

Enquanto o carro navega a cidade, tem uma chance baixa de ficar bêbado e ignorar as regras de trânsito. Não parando em sinais de stop, semáforos ou passadeiras para os peões passarem. Durante este estado o carro está a piscar para indicar que está bêbado, entre a sua cor original e a cor vermelha, a velocidade deste efeito é definida pelo utilizador (*Game manager - blinkSpeed*).
Este node retorna sucesso se o carro estiver bêbado, passando a frente as verificações por semáforos e peões.

![Sequência de comportamento bêbado dos carros](./Images/CardNodeDrunk.png)

Os carros quando estão em acidente têm um comportamento muito parecido ao de quando estão bêbados, mas para além de passar as verificações a frente, também reduz a velocidade deles para 0.

![Sequência de comportamento em acidente dos carros](./Images/CarNodeAccident.png)

#### Tipos de carros

O colisor quadrado na parte da frente de cada carro é o detetor de peões, os peões como são mais pequenos que os carros, por vezes andavam entre os *RayCast's* dos carros e o carro atropelava-os. A solução foi usar um collider que enquanto tiver peões não avança.

O carro roxo tem uma velocidade baixa de 4.
![Carro roxo](./Images/PurpleCar.png)

O carro cinzento tem uma velocidade média de 6.
![Carro cinzento](./Images/BlueCar.png)

O carro rosa tem uma velocidade alta de 8.
![Carro rosa](./Images/PinkCar.png)

### Destinos

Os carros têm sempre o mesmo tipo de destino, a garagem duma casa.
Os peões têm como destino a porta da casa ou o jardim nos pontos vermelhos assinalados.

![Casa](./Images/Destiny.png)
![Jardim](./Images/Garden.png)

### Semáforos

Os semáforos são agentes fixos do ambiente que trocam entre dois estados, verde e vermelho.
Quando está vermelho, ativa um colisor por baixo dele que os carros detetam durante a sua verificações de colisões.
Quando está verde, desliga esse colisor.

![Colisor semáforo](./Images/CollidersTrafficLight.png)

### Sinal Stop

Os sinais de stop são agentes fixos do ambiente. Têm um colider ao lado deles que é verificado pelo carro.
O carro ao verificar esta colisão, guarda que já colidiu com este sinal de stop, e não volta a parar em sinais de stop, assim que passa pelo collider do sinal de stop e sai, volta a colidir com sinais de stop.

![Colisor sinal stop](./Images/CollidersStopSign.png)

### Estradas

As estradas em que os carros andam são separadas por peças. Estas peças são compostas por planos pretos para o chão, NavMeshLinks e um colisor para divir as faixas.
Os NavMeshLink são colocados nas pontas das peças para unir as peças das estradas e garantir uma circulação de uma só direção, estão representados por vermelhor e verde.
Os colisores das faixas garantem que os carros andam apenas num faixa, permitindo haver duas faixas na mesma peça com direções opostas, este colisores são transparentes.

![Composição de uma peça de estrada](./Images/CollidersRoad.png)
![Navmesh depois do colisor para as faixas](./Images/RoadFinalNavMesh.png)

### *Game Manager*

O *Game Manager* é o objeto que controla o estado, antes e durante, da simulação. É aqui que permite que a simulação seja personalizada, permitindo ao utilizador definir tudo o que é passível de ser definido. E esses parâmetros são:

- Peões (*Pedestrians*)
  - ***pedestrianPrefab***: *prefab* do peão,
  - ***numberOfPedestrians***: número máximo de peões a serem gerados no inicio da simulação,
  - ***pedestriansSpawnPoints***: possíveis pontos de *spawn* e destino dos peões,
  - ***maxDestinyTimePedestrians***: intervalo máximo de tempo para um peão ser gerado ou estar parado num destino.

![Parâmetros dos peões](./Images/GameManagerPedestrians.png)

- Carros (*Cars*)
  - ***carPrefabs***: *prefabs* dos carros,
  - ***numberOfCars***: número máximo de carros a serem gerados no inicio da simulação,
  - ***carSpawnPoints***: possíveis pontos de *spawn* e destino dos carros,
  - ***timeForCarToSpawn***: intervalo de tempo entre a geração de carros no mesmo ponto.

![Parâmetros dos carros](./Images/GameManagerCars.png)

- Caos (*Chaos*)
  - ***chaosChance***: probabilidade de um agente começar a comportar-se de forma errática,
  - ***maxChaosTime***: intervalo máximo de tempo máximo para um agente estar em estado de caos,
  - ***blinkSpeed***: velocidade do efeito de piscar de um agente em estado de caos.

![Parâmetros de caos](./Images/GameManagerChaos.png)

- Acidente (*Accident*)
  - ***maxAccidentTime***: intervalo máximo de tempo para um agente estar em estado de acidente.

![Parâmetros de acidente](./Images/GameManagerAccident.png)

- UI
  - ***carsText***: *text* que mostra o número de carros ativos,
  - ***pedestriansText***: *text* que mostra o número de peões ativos.

![UI](./Images/GameManagerUI.png)

## Resultados e discussão

### Resultados

A simulação que realizámos demonstrou comportamentos alinhados com as expectativas programadas e revelou algumas dinâmicas emergentes interessantes. Como esperado, os carros e peões cumpriram as regras de trânsito, com carros a parar em semáforos, sinais stop e passadeiras quando há peões a atravessar, e peões a utilizarem os passeios e passadeiras destinadas para eles. Esta fidelidade nas ações dos agentes valida o uso das *behavior trees* e *pathfinding* na modelação do comportamento dos agentes.

Inesperadamente, observámos comportamentos emergentes não explicitamente programados, como os peões a desviarem-se autonomamente uns dos outros, e os carros com tendência de se desviar dos peões antes de efetivamente parar para eles atravessarem nas passadeiras. Este comportamento emergente, é resultado do sistema de *pathfinding* baseado em *navmesh*, sugere que o modelo pode efetivamente processar e adaptar-se a complexidades não antecipadas do ambiente simulado, garantindo uma navegação mais realista e fluida.

Quanto ao modo 'caos', os carros e peões consistentemente ignoraram as regras de trânsito, os carros ignorando sinais stop e semáforos, e os peões atravessando a estrada sem respeitar as passadeiras. Este comportamento imprevisível resultou em acidentes frequentes, enquanto o modo estava ativo, mesmo que com baixa probabilidade deste ser ativo, com carros a colidirem uns com os outros e com peões, e peões a serem atropelados por carros. Este cenário de caos controlado permitiu-nos testar a resiliência da simulação e avaliar a capacidade dos agentes de lidar com situações de tráfego extremas.

### Discussão

A análise dos resultados da simulação demonstra uma relação direta entre as configurações definidas no GameManager e o comportamento dos agentes. As *behavior trees* e o *pathfinding* mostraram-se eficazes, com os agentes a cumprir as regras de trânsito em condições normais e a exibir comportamentos emergentes, como os peões a desviarem-se uns dos outros e os carros a reduzirem a velocidade antes de parar nas passadeiras. Estes comportamentos emergentes confirmam que o sistema de *pathfinding* baseado em navmesh está a adaptar efetivamente as trajetórias para evitar colisões, garantindo uma movimentação realista e segura dos agentes.

O modo 'caos' revelou-se uma ferramenta valiosa para testar a resiliência da simulação e avaliar a capacidade dos agentes de lidar com situações extremas de tráfego. Os acidentes frequentes observados durante o modo 'caos' destacam a importância de considerar cenários de tráfego imprevisíveis e caóticos na modelação de ambientes urbanos, e a necessidade de implementar estratégias de segurança e prevenção de acidentes para proteger os agentes e garantir a segurança do tráfego.

Os comportamentos inesperados, como a evasão autónoma, reforçam a importância de ajustes contínuos nas behavior trees e nas configurações de pathfinding, com o objetivo de melhorar o realismo e a resposta dos agentes nas simulações.

## Conclusões

O desenvolvimento deste projeto permitiu-nos explorar e implementar técnicas de simulação de tráfego urbano, incluindo *behavior trees*, *pathfinding* e cenários de caos controlado. A simulação resultante demonstrou a eficácia dessas técnicas na modelação de comportamentos realistas de carros e peões, com agentes a cumprir as regras de trânsito, a evitar colisões e a adaptar-se a cenários de tráfego.

Os resultados confirmaram que o modelo é capaz de replicar as regras de trânsito e comportamentos esperados, enquanto revela comportamentos emergentes como a capacidade dos peões de desviar-se autonomamente e dos carros de ajustar suas trajetórias antes de parar nas passadeiras. No entanto, a simulação também revelou a importância de considerar cenários de tráfego extremos, como o modo 'caos', para testar a resiliência da simulação e avaliar a capacidade dos agentes de lidar com situações imprevisíveis.

Esta simulação está alinhada com a pesquisa que realizámos sobre a aplicação de técnicas de IA na gestão de tráfego urbano, e destaca a importância de considerar cenários de tráfego variados e complexos para garantir a segurança e eficiência do tráfego. O modelo desenvolvido neste projeto pode ser adaptado e expandido para incluir mais agentes, cenários e comportamentos, com o objetivo de criar simulações mais realistas e abrangentes de tráfego urbano.

## Referências

- [1] TheKiwiCoder. (2021, July 16). Free behaviour Tree editor for Unity. YouTube. https://www.youtube.com/watch?v=SgrG6uAZDHE 
- [2] TheKiwiCoder. (2021, July 16). Behaviour Tree. https://www.thekiwicoder.com/behaviour-tree 
- [3] Do, S., Kemanji, K., Vinh, M., & Tuan, V. (2023, June). The Action Point Angle of Sight: A Traffic Generation Method for Driving Simulation, as a Small Step to Safe, Sustainable and Smart Cities. ResearchGate. https://www.researchgate.net/publication/371605221_The_Action_Point_Angle_of_Sight_A_Traffic_Generation_Method_for_Driving_Simulation_as_a_Small_Step_to_Safe_Sustainable_and_Smart_Cities 
- [4] Weißmann, M., Edler, D., Keil, J., & Dickmann, F. (2023, May 13). Creating an interactive urban traffic system for the simulation of different traffic scenarios. MDPI. https://www.mdpi.com/2076-3417/13/10/6020 
- [5] Nezami, F. N., Wächter, M. A., Pipa, G., & König, P. (2020, January 9). Project westdrive: Unity City with self-driving cars and pedestrians for virtual reality studies. Frontiers. https://www.frontiersin.org/articles/10.3389/fict.2020.00001/full 
- [6] Yuloskov, A., Bahrami, M., Mazzara, M., & Kotorov, I. (2022, June). Traffic light algorithms in Smart Cities: Simulation and analysis. ResearchGate. https://www.researchgate.net/publication/361845379_Traffic_Light_Algorithms_in_Smart_Cities_Simulation_and_Analysis 
- [7] Unity. NavMeshAgent.CompleteOffMeshLink. Docs Unity 3D. https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.CompleteOffMeshLink.html
