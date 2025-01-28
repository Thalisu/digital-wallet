# Digital Wallet

## Como rodar o projeto:
### Development:

O comando `docker compose -f docker-compose.dev.yml up` iniciará dois containers Docker, um para o banco de dados PostgreSQL e outro com a API na porta 5022.
Após executar o comando, acesse localhost:5022/swagger, onde estarão disponíveis todas as rotas da API.

### Production:

O comando `docker compose up` também iniciará dois containers, porém não haverá o painel de rotas do Swagger, e o acesso será feito pela porta 8080.

## Popular o banco de dados:

### Request
`POST /user/populate`

### Reponse
    HTTP/1.1 200 OK
    Connection: close
    Content-Type: application/json

    [Lista com os usuários criados e seus IDs]

### Os usuários estão presentes aqui:

#### [Users](app/Data/Users.cs)

## Senhas e segredos que precisam ser mudados

#### POSTGRES_PASSWORD
`docker-compose e docker-compose.dev`
<br/>
Ambos `appsettings`, linha 3, coluna 90 a 98.

#### JWT Signing key
Caso queira, você pode gerar uma nova key [aqui](https://tools.onecompiler.com/hmac-sha512)

Ambos `appsettings`, linha 15

## Filtro nas transferências

### Request
`GET /transfer?FrDate=20-03-2024&ToDate=20-05-2024`
    
A data deve estar no formato `dd-MM-yyyy`

### Response

    HTTP/1.1 200 OK
    Connection: close
    Content-Type: application/json

    [As transferencias caso esteja autenticado]


---

### Observação:

Todas as rotas estão disponíveis no ambiente de desenvolvimento no painel Swagger.
