## Construção de uma Api com funcionalidades de uma Rifa para integração com o Whatsapp 

![Badge em Desenvolvimento](http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge)   

A ideia principal do projeto é construir uma API que receba requisições vindas com dados enviados por um cliente do  Whatsapp, onde essa Api irá salvar esses dados no Banco de Dados utilizando o Entity FrameWork.
O projeto é arquitetado e executado todo em linguagem .NET | C# | ASP.NET CORE.

### Entidade Bilhete de Rifa

 - id: long
 - Nome: string
 - Telefone: string
 - Email: string

### Operações da Api
 - Criar Bilhete
 - Lista Bilhete
 - Atualizar Bilhete
 - Sortear Bilhete

### Comandos para criação do arquivo de migração e conexão com o Banco de Dados (Entity Framework

 - Add Migration Initial -o Migrations
 - Update-Database

### Processo de Integração com o WhatsApp  a ser desenvolvido

 - Foi possível estabelecer a comunicação entre o Whatsapp e a API via o Twilio. Mas devido a taxas extras cobradas pelo Twilio não houve uma forma de adicionar outros números. Dessa forma o único número utilizado foi o número grátis ofertado pelo próprio Twilio.
 - Dessa forma, o objetivo de fazer com que um número de whatsapp se comunica-se com outro número de whatsapp e consulta-se a API criada via número comprado cadastrado ao Twilio, não foi almejado.





<h4 align="center"> 
    :construction:  Projeto em construção  :construction:
</h4>
