#Bem vindo ao meu projeto#

- O Projeto foi realizado para um CRUD de clientes e seus endereços, o intuito é realizar o cadastro de ambos
- A arquitetura utilizada foi a de microserviços com uma API gatway intermediando o consumo (Aqui foi utiizado o OCELOT)

  #Ferramentas utilizadas#
  - .NET 6
  - SqlServer 2019
  - EntityFramework
  - AutoMapper
  - AutoFac

  #Informações para startar o projeto#

  - Para inicializar o projeto clone o repositório em sua máquina, ou baixe o arquivo .zip
  - Ao instalar o projeto certifique-se de alterar a string de conexão no appsetings.json do projeto cliente e tambem do projeto endereço
  - Lembrando que deve ser uma string de conexão do SqlServer, caso tenha outro banco deve realizar a alteração do projeto para lhe atender;
  - Após trocar a string de conexão realize os passos para migração das entidades no banco de dados
  - Vá até o terminal de sua preferência e caminhe até a pasta do projeto (no Visual studio fica em: Ferramentas > linha de comando > powershell do desenvolvedor) 
  - para realizar a criação do modelo de migração utilize o comando "dotnet ef migrations add <NOME_DA_SUA_MIGRACAO>"
  - Vale lembrar que o nome da sua migração não pode estar igual aos nomes de migração já criados;
  - Após criar com sucesso sua migração vamos fazer o update dessa migração para o banco de dados, aqui rodamos o comando: dotnet ef database update
  - Assim seu banco deve estar criado, repita o processo para o projeto de cliente e o projeto de endereço.
 
  - Após os passo acima abra o projeto no Visua studio e clique em iniciar, sua API estará rodando.

- Observações
- O Serviço de clientes roda nas portas: https://localhost:44503 e http://localhost:44502
- O Serviço de endereços roda nas portas: https://localhost:44501 e http://localhost:44500
- O Serviço da API Gatway roda na porta: https://localhost:5001

- O FrontEnd roda consumindo a API Gateway, porém ambos os Swaggers estão de pé para realizar testes
