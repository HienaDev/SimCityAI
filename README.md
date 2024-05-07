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
    - Estado da Arte
    - Metodologia
      - Peões
      - *Game Manager*
    - Resultados e discussão
  - *Context*
    - Efeito de piscar (*Blink effect*)

## Introdução

Este projeto centra-se no desenvolvimento de um modelo de tráfego urbano com uma temática alienigena, no *Unity* que simula de forma realista a interação entre diferentes agentes, veículos e peões, num ambiente citadino. Para modelar o comportamento dos agentes, utilizamos o TheKiwiCoder - *behavior tree* [[1]](https://www.youtube.com/watch?v=SgrG6uAZDHE)[[2]](https://www.thekiwicoder.com/behaviour-tree), um package que permite a criação de árvores de comportamento através da interface do *Unity*. Esta interface usa *nodes* para definir comportamentos, que incluem ações, composições e decoradores, necessitando de programação em C# para executar comportamentos específicos conforme necessário, os comportamentos de cada agente são explicados na secção [metadologia](#metadologia). Complementando esse comportamento, os agentes utilizam *pathfinding* baseado na *navmesh* do *Unity* para navegar no ambiente urbano, calculando rotas eficientes que evitam obstáculos e respeitam as regras de trânsito, semáforos, sinais stop e passadeiras, para uma movimentação mais fluida e realista. Contudo, um elemento do projeto é a capacidade de introduzir um modo 'caos', no qual um agente pode deixar de obedecer às regras de trânsito, aumentando a probabilidade de comportamentos imprevisíveis e caóticos, o que pode resultar em acidentes dentro da simulação.

O ambiente urbano simulado inclui componentes essenciais como passeios, estradas, passadeiras, sinais stop, veículos e peões. A cidade é composta por vários destinos, acessíveis através de uma rede integrada de estradas para veículos e passeios para peões. Todos os elementos são desenhados para influenciar realisticamente o movimento e o comportamento dos agentes.

A pesquisa para este projeto incluiu uma revisão de estudos e trabalhos recentes sobre simulação de tráfego em cidades, com foco em modelagem baseada em agentes e o uso de técnicas de inteligência artificial para a gestão de tráfego. As fontes consultadas, através de plataformas como o Google Scholar, forneceram uma base sólida para a seleção das tecnologias implementadas e ajudaram a moldar as técnicas utilizadas para atingir os objetivos do projeto, incluindo o desenvolvimento de cenários de caos controlado para testar a resiliência da simulação.

## Estado da Arte

Nesta secção, iremos apresentar uma pequena pesquisa feita sobre este tipo de simulações, com recurso a trabalhos semelhante, descrevendo-os e comparando-os com o nosso trabalho.

### *The Action Point Angle of Sight: A Traffic Generation Method for Driving Simulation, as a Small Step to Safe, Sustainable and Smart Cities*

Este trabalho aborda o desenvolvimento de um gerador de tráfego para simulações de condução, denominado "*Action Point Angle of Sight*" (APAS), que visa aprimorar a autenticidade das simulações de tráfego usadas para testar veículos autónomos e melhorar a segurança rodoviária. Este método é projetado para integrar-se com simuladores de condução modernos, oferecendo uma abordagem mais naturalista e precisa para a geração de tráfego em ambientes urbanos.

A principal inovação do APAS é a sua capacidade de simular interações baseadas em física entre veículos, infraestruturas e condições ambientais variáveis, como o clima. Utiliza modelos avançados que permitem a simulação de comportamentos de tráfego realistas, como a observância das regras de trânsito e a reação a fatores estocásticos, como veículos aleatórios e variações de velocidade. Ao contrário de simuladores tradicionais que frequentemente reciclam tecnologias antigas e apresentam limitações na representação de fluxos de tráfego mistos e caóticos, o APAS foi desenvolvido para superar essas barreiras, oferecendo uma ferramenta robusta e versátil para o estudo e planeamento de tráfego urbano. [[3]](https://www.researchgate.net/publication/371605221_The_Action_Point_Angle_of_Sight_A_Traffic_Generation_Method_for_Driving_Simulation_as_a_Small_Step_to_Safe_Sustainable_and_Smart_Cities)

#### **Comparação com o nosso projeto**

- **Abordagem de Simulação de Tráfego:**
  - Ambos os projetos visam aprimorar as simulações de tráfego, mas o nosso projeto foca a criação de um ambiente urbano com múltiplos tipos de agentes, utilizando behavior trees para modelar uma gama variada de comportamentos de tráfego, incluindo a interação entre veículos e peões. Por outro lado, o APAS desenvolve um método específico que melhora a geração de fluxos de tráfego mistos e realistas, focando-se na precisão dos movimentos e nas respostas dos veículos autonomos em condições variadas de tráfego.
- **Integração de Comportamentos Realistas:**
  - O nosso projeto implementa uma abordagem para simular comportamentos de tráfego e interações entre agentes, destacando-se na modelação de cenários urbanos dinâmicos. O APAS, por sua vez, concentra-se na utilização de uma nova fórmula teórica para simular de forma eficaz os comportamentos de veículos em resposta a variáveis estocásticas, como veículos aleatórios e variações de velocidade, visando uma simulação que se aproxima das condições reais de condução.

### *Creating an Interactive Urban Traffic System for the Simulation of Different Traffic Scenarios*

Este trabalho explora a criação de um sistema de tráfego urbano interativo utilizando a realidade virtual (VR) para simular diferentes cenários de tráfego numa cidade modelo da Europa Central. Utilizando *engine* Unity, os autores desenvolveram um ambiente virtual imersivo que permite aos utilizadores experimentar condições de tráfego dinâmicas de forma visual e interativa. O foco do sistema é proporcionar uma plataforma que possa visualizar e simular a complexa interação entre peões, transporte individual e público.

A principal inovação apresentada é o uso de um sistema de tráfego modular e personalizável dentro do Unity, que reage ao comportamento individual dos utilizadores, incluindo a movimentação do avatar. Isto é crucial para evitar acidentes ou congestionamentos de tráfego irremediáveis. Esta ferramenta elimina a necessidade de software de terceiros, tornando-a uma opção valiosa para desenvolvedores que procuram implementar sistemas de tráfego em ambientes virtuais imersivos. 

A metodologia aplicada baseia-se nas capacidades atuais do Unity, permitindo a criação de objetos 3D. O sistema de tráfego emprega uma rede de waypoints, onde os veículos seguem rotas predeterminadas, interagindo com semáforos e outros elementos do tráfego conforme programado. Este sistema também permite ajustes em tempo real dos parâmetros de tráfego para refletir mudanças no cenário simulado. [[4]](https://www.mdpi.com/2076-3417/13/10/6020)

#### **Comparação com o nosso projeto**

- **Flexibilidade e Parametrização:**
  - Ambos os projetos oferecem sistemas de tráfego onde os parâmetros podem ser ajustados pelos utilizadores para modificar cenários de tráfego, destacando-se pela capacidade de responderem a ajustes definidos pelo utilizador para refletir diferentes condições urbanas.
- **Interação e Realismo no Tráfego:**
  - O nosso projeto e o sistema descrito no artigo investem em criar simulações que capturam interações realistas entre os componentes do tráfego. Ambos utilizam técnicas para gerir e simular o movimento de veículos e o comportamento dos agentes em ambientes urbanos com o objetivo de aumentar o realismo da simulação.

### *Project Westdrive: Unity City With Self-Driving Cars and Pedestrians for Virtual Reality Studies*

Este estudo introduz o projeto "*Westdrive*", uma cidade virtual desenvolvida no Unity para estudos em realidade virtual, focada em navegação espacial e aspetos éticos de decisões em ambientes urbanos. A cidade virtual de *Westdrive* abrange uma área de 230 hectares e inclui até 150 veículos autónomos e 655 pedestres ativos e passivos, além de milhares de elementos naturais para criar um ambiente dinâmico e realista.

O projeto é open-source e modular, construído para ser facilmente adaptável às necessidades variadas de experimentos científicos. Oferece uma ferramenta chamada "*City AI toolkit*" que permite aos utilizadores criar avatares e personalizar veículos sem necessidade de conhecimento prévio em programação, facilitando o uso de suas funcionalidades integradas no *engine* Unity.

A estrutura do projeto permite uma implementação simples de ambientes complexos, onde todos os componentes podem ser usados independentemente. A simulação envolve elementos estáticos, como edifícios e árvores, e dinâmicos, como veículos e pedestres que se movem de acordo com scripts programáveis. A interação dos objetos é controlada por um conjunto de ferramentas que administram os percursos, os veículos e os comportamentos dos pedestres dentro da simulação. [[5]](https://www.frontiersin.org/articles/10.3389/fict.2020.00001/full)

#### **Comparação com o nosso projeto**

- **Modularidade e Personalização:**
  - O nosso projeto permite a personalização de cenários de tráfego e comportamentos de agentes, o que é semelhante ao *Westdrive*. No entanto, o *Westdrive* destaca-se pela sua estrutura altamente modular e scriptável, que facilita a adaptação às necessidades específicas de diferentes estudos de pesquisa, oferecendo um toolkit que permite aos usuários modificar avatares e veículos sem programação direta.
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

### Resultados

A simulação que realizámos demonstrou comportamentos alinhados com as expectativas programadas e revelou algumas dinâmicas emergentes interessantes. Como esperado, os veículos e peões cumpriram as regras de trânsito, com veículos a parar em semáforos, sinais stop e passadeiras quando há peões a atravessar, e peões a utilizarem os passeios e passadeiras destinadas para eles. Esta fidelidade nas ações dos agentes valida o uso das *behavior trees* e *pathfinding* na modelação do comportamento dos agentes.

Inesperadamente, observámos comportamentos emergentes não explicitamente programados, como os peões a desviarem-se autonomamente uns dos outros, e os veículos com tendência de se desviar dos peões antes de efetivamente parar para eles atravessarem nas passadeiras. Este comportamento emergente, é resultado do sistema de *pathfinding* baseado em *navmesh*, sugere que o modelo pode efetivamente processar e adaptar-se a complexidades não antecipadas do ambiente simulado, garantindo uma navegação mais realista e fluida.

Quanto ao modo 'caos', os veículos e peões consistentemente ignoraram as regras de trânsito, os veículos ignorando sinais stop e semáforos, e os peões atravessando a estrada sem respeitar as passadeiras. Este comportamento imprevisível resultou em acidentes frequentes, enquanto o modo estava ativo, mesmo que com baixa probabilidade deste ser ativo, com veículos a colidirem uns com os outros e com peões, e peões a serem atropelados por veículos. Este cenário de caos controlado permitiu-nos testar a resiliência da simulação e avaliar a capacidade dos agentes de lidar com situações de tráfego extremas.

## Conclusões

## Referências

- [1] TheKiwiCoder. (2021, July 16). Free behaviour Tree editor for Unity. YouTube. https://www.youtube.com/watch?v=SgrG6uAZDHE 
- [2] TheKiwiCoder. (2021, July 16). Behaviour Tree. https://www.thekiwicoder.com/behaviour-tree 
- [3] Do, S., Kemanji, K., Vinh, M., & Tuan, V. (2023, June). The Action Point Angle of Sight: A Traffic Generation Method for Driving Simulation, as a Small Step to Safe, Sustainable and Smart Cities. ResearchGate. https://www.researchgate.net/publication/371605221_The_Action_Point_Angle_of_Sight_A_Traffic_Generation_Method_for_Driving_Simulation_as_a_Small_Step_to_Safe_Sustainable_and_Smart_Cities 
- [4] Weißmann, M., Edler, D., Keil, J., & Dickmann, F. (2023, May 13). Creating an interactive urban traffic system for the simulation of different traffic scenarios. MDPI. https://www.mdpi.com/2076-3417/13/10/6020 
- [5] Nezami, F. N., Wächter, M. A., Pipa, G., & König, P. (2020, January 9). Project westdrive: Unity City with self-driving cars and pedestrians for virtual reality studies. Frontiers. https://www.frontiersin.org/articles/10.3389/fict.2020.00001/full 
- [6] Yuloskov, A., Bahrami, M., Mazzara, M., & Kotorov, I. (2022, June). Traffic light algorithms in Smart Cities: Simulation and analysis. ResearchGate. https://www.researchgate.net/publication/361845379_Traffic_Light_Algorithms_in_Smart_Cities_Simulation_and_Analysis 