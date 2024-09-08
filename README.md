## PROJETO RIFA FÁCIL

![Badge em Desenvolvimento](http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge)   

A ideia principal do projeto é construir uma API de uma Rifa que receba requisições vindas com dados enviados por um rifador responsável pela criação e manipulação da rifa ou de um cliente que está comprando rifas, onde essa Api irá salvar esses dados no Banco de Dados utilizando o Entity FrameWork. O projeto é arquitetado e executado todo em linguagem .NET | C# | ASP.NET CORE.


### Entidade Bilhete de Rifa

 - id: long
 - Nome: string
 - Telefone: string
 - Email: string

### Entidade Rifador
 - Nome: string
 - Telefone: string
 - Email: string
 - Senha: string

### Entidade Rifa
 - Premio: string
 - DataSorteio: DateTime
 - ValorBilhete: float
 - Status: string

### Entidade Afiliado
 - Nome: string
 - Email: string
 - Telefone: string


### Serviços
- Atualizar Bilhete
- Atualizar Rifador
- Atualizar Rifa
- Cadastrar Afiliado
- Cadastrar Rifa
- Consultar Bilhete
- Comprar Bilhete
- Consultar Rifador
- Consultar Rifa
- Criar Conta
- Excluir Bilhete
- Excluir Rifador
- Excluir Rifa
- Sortear Bilhete
- Vender Bilhete

### Comandos para criação do arquivo de migração e conexão com o Banco de Dados (Entity Framework)

 - Add Migration Initial -o Migrations
 - Update-Database



<h4 align="center"> 
    :construction:  Projeto em construção  :construction:
</h4>
