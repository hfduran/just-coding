Você foi contratado pelo Tribunal Superior Eleitoral para desenvolver um sistema de coleta e totalização de votos em uma eleição. O sistema deverá permitir a entrada de dados de forma manual (digitando-se um a um os votos) ou de forma automatica pela transmissão criptografada de dados via redes privadas de dados. A saída deverá se dar também de diferentes formas, i.e., por meio de uma página Web com gráficos, armazenando-se em um banco de dados confiável e através de uma interface REST para consulta por outras máquinas. Portanto, optou-se pelo padrão MVC para embasar a arquitetura do sistema.

No entanto, para fins de validação da ideia do sistema, você deverá implementar apenas uma versão preliminar simplificada do sistema com um único controlador (que lê votos da entrada padrão) e uma única visão (que imprime a totalização de votos na saída padrão).

Ou seja, o Modelo será uma estrutura de dados para armazenar o número de votos de cada candidato a presidente, senador, deputado federal e deputado estadual.

O controlador será simplesmente um laço que, a cada iteração, recebe os votos de um eleitor. Cada eleitor vota em 1 único candidato de cada um dos 4 tipos de cargo, ou seja, vota em 4 candidatos. Não será necessário implementar a validação dos votos, ou seja, não é necessário verificar se o usuário digitou o número de um candidato inválido.

A visão conterá um método que, consultando o modelo, irá imprimir uma tabela com todos os votos realizados até o momento, ordenada por tipo de cargo. Dentro de cada cargo, os candidatos devem aparecer em ordem do mais votado para o menos votado. A cada novo voto, o modelo deverá informar à visão que seu estado foi modificado.

Implemente o sistema acima utilizando o padrão MVC. Lembre-se de seguir as boas práticas de programação orientada a objetos. Em particular, capriche nos nomes de variáveis, classes e métodos e evite métodos longos.

Um possível exemplo de como poderia ser a entrada de dados é o seguinte:

--------------Digite os seus votos------------

(use 0 para voto em branco e -1 para voto nulo)

    Voto para Presidente: 93

    Voto para Senador: 241

    Voto para Deputado Federal: 2525

    Voto para Deputado Estadual: 0

--------------Tabela de Votos-------------

Presidente:

    93    1

Senador:

    241    1

Deputado Federal:

    2525    1

Deputado Estadual:

    0    1

--------------Digite os seus votos------------

(use 0 para voto em branco e -1 para voto nulo)

    Voto para Presidente: 93

    Voto para Senador: 241

    Voto para Deputado Federal: -1

    Voto para Deputado Estadual: 42000

--------------Tabela de Votos-------------

Presidente:

    93    2

Senador:

    241    2

Deputado Federal:

    2525    1

    -1    1

Deputado Estadual:

    0    1

    42000    1

--------------Digite os seus votos------------

(use 0 para voto em branco e -1 para voto nulo)

    Voto para Presidente: 82

    Voto para Senador: 241

    Voto para Deputado Federal: 2525

    Voto para Deputado Estadual: 42000

--------------Tabela de Votos-------------

Presidente:

    93    2

    82    1

Senador:

    241    3

Deputado Federal:

    2525    2

    -1    1

Deputado Estadual:

    42000    2

    0    1
