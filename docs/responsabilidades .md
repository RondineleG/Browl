Camada de Apresentação: essa camada é responsável pela interação com o usuário ou outros sistemas externos. Aqui ficam as interfaces gráficas, controladores, rotas e validações de entrada.

Camada de Aplicação: essa camada é responsável por orquestrar as operações do sistema e realizar a lógica de negócio. Aqui ficam os serviços, interfaces de entrada e saída e os DTOs.

Camada de Domínio: essa camada contém as entidades e regras de negócio do sistema. Aqui ficam as interfaces do domínio, entidades, enums e exceções personalizadas.

Camada de Infraestrutura: essa camada é responsável por fornecer a infraestrutura técnica para o sistema, como acesso a banco de dados, serviços externos, cache e logging. Aqui ficam os repositórios, serviços de infraestrutura e as interfaces de infraestrutura.

Camada compartilhada: essa camada contém interfaces e objetos compartilhados entre as outras camadas.



    +--------------------------+
    |     Camada de Apresentação|
    +--------------------------+
    |   Controladores          |
    |   Interfaces de Serviços |
    |   DTOs                   |
    +--------------------------+
                |        
                |        
    +--------------------------+
    |     Camada de Aplicação  |
    +--------------------------+
    |   Serviços               |
    |   Interfaces de entrada  |
    |   Interfaces de saída    |
    |   DTOs                   |
    +--------------------------+
                |        
                |        
    +--------------------------+
    |     Camada de Domínio    |
    +--------------------------+
    |   Entidades              |
    |   Interfaces do Domínio  |
    |   Exceções personalizadas|
    |   Enums                  |
    +--------------------------+
                |        
                |        
    +--------------------------+
    |     Camada de Infraestrut|
    +--------------------------+
    |   Repositórios           |
    |   Serviços de infraestrut|
    |   Interfaces de Infraestr|
    +--------------------------+
                |        
                |        
    +--------------------------+
    |     Camada compartilhada |
    +--------------------------+
    |   Interfaces compartilhad|
    |   Objetos compartilhados |
    +--------------------------+
