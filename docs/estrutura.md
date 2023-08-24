OnePiece
├── OnePiece.Application # Camada de Aplicação
│ ├── Interfaces # Interfaces para entrada e saída da camada de Aplicação
│ ├── Services # Implementações dos serviços da camada de Aplicação
│ ├── DTOs # Objetos de transferência de dados para a camada de Aplicação
│ └── Mappings # Mapeamentos entre DTOs e entidades

├── OnePiece.Domain # Camada de Domínio
│ ├── Entities # Entidades do domínio
│ ├── Interfaces # Interfaces do domínio
│ └── Services # Serviços do domínio

├── OnePiece.Infrastructure # Camada de Infraestrutura
│ ├── Data # Repositórios e implementações do acesso a dados
│ ├── Interfaces # Interfaces de Infraestrutura
│ ├── Services # Serviços de Infraestrutura
│ └── Persistence # Configuração e inicialização do banco de dados

├── OnePiece.Tests # Testes unitários

├── OnePiece.API # Camada de Apresentação
│ ├── Controllers # Controladores da API
│ ├── DTOs # Objetos de transferência de dados para a API
│ ├── Mappings # Mapeamentos entre DTOs e entidades
│ └── Startup.cs # Configurações iniciais da API

└── OnePiece.Shared # Camada compartilhada
├── Exceptions # Exceções personalizadas
├── Interfaces # Interfaces compartilhadas
└── Utils # Utilitários compartilhados


           +-----------------------+
           |    OnePiece.API       |
           +-----------------------+
                       |
                       | depende de
                       |
           +-----------------------+
           | OnePiece.Application  |
           +-----------------------+
                       |
                       | depende de
                       |
           +-----------------------+
           |  OnePiece.Domain      |
           +-----------------------+
                       |
                       | depende de
                       |
           +-----------------------+
           | OnePiece.Infrastructure|
           +-----------------------+
                       |
                       | usa
                       |
           +-----------------------+
           |    OnePiece.Shared    |
           +-----------------------+
