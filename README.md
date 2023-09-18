### Clean Architecture
 
- Camada de Domínio:
    1. Lógica de negócios
    2. Independente

- Camada de Aplicação:
    1. Serviços
    2. Interfaces
    3. Coordena a lógica de negócios
    4. Recebe solicitações da camada de Apresentação e chama os serviços necessários

- Camada de Infraestrutura: 
    1. Injenções de depêndencia
    2. Acesso ao banco de dados
    3. Autenticação e serviços de e-mail

- Camada de Apresentação:
    1. Interação com o usuário

## Novas Tarefas

- criar o docker file
- criar o template de tarefas
