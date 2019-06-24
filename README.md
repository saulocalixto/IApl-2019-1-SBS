# IApl-2019-1-SBS
Trabalho para a disciplina de Integração de Aplicações do Bacharelado em Engenharia de Software do INF-UFG. Consiste na implementação de um serviço bancário fictício.

O sistema desenvolvido possui uma API REST que pode ser acessada em:

```
http://bancolegal.azurewebsites.net/api/
```

A página web de exemplo implementando as chamadas da api pode ser acessado em:

```
https://sitebancolegal.azurewebsites.net/
```

## Login (/login)

Para realizar todas as outras chamadas listadas, é necessário realizar um Login na plataforma. Utilizando o endpoint abaixo, a API retornará um token **que deverá ser usado para validar as demais requisições.**

Salientamos que a requisição de **/login** retorna um "Token" **que deve ser passado no Header de qualquer requisição abaixo listada**.

### Endpoints

* Realizar Login: POST/api/login

### Exemplo de Body

```json
{
    "email": "saulo@gmail.com",
    "senha": "1234admin",
    "internacionalizacao" : "0"
}
```
O objeto passado precisa ter um email e senha válidos para retornar o token. A internacionalização indica a linguagem do sistema, sendo:
- 0 : PT-BR
- 1 : EN
- 2 : FR

## Conta (/conta)

### Endpoints

* Consultar Todos: GET /api/conta
* Consultar: GET /api/conta/{id}
* Cadastrar: POST /api/conta
* Atualizar: PUT /api/conta
* Apagar: DELETE /api/conta/{id}

### Header - Exemplo de Token

```
Token: '459c1d6c-d3e1-4daa-b0e3-bfbdb1f310ad'
```

### Exemplo de Body

```json
{
    "titular": 1,
    "agencia": 854,
    "numero": 12345678,
    "senha": "1234admin",
    "saldo": 100000,
    "limite": 755555,
    "ativo": true,
    "id": 1
}
```

## Operação (/operacao)

### Endpoints

* Consultar Todos: GET /api/operacao
* Consultar: GET /api/operacao/{id}
* Cadastrar: POST /api/operacao
* Atualizar: PUT /api/operacao
* Apagar: DELETE /api/operacao/{id}

### Header - Exemplo de Token

```
Token: '459c1d6c-d3e1-4daa-b0e3-bfbdb1f310ad'
```

### Exemplo de Body

```json
{
    "tipo": 1,
    "valor": 500,
    "dataDaOperacao": "2019-01-01T00:00:00",
    "contaOrigem": 1,
    "contaDestino": 2,
    "id": 1
}
```

## Pessoa (/pessoa)

### Endpoints

* Consultar Todos: GET /api/pessoa
* Consultar: GET /api/pessoa/{id}
* Cadastrar: POST /api/pessoa
* Atualizar: PUT /api/pessoa
* Apagar: DELETE /api/pessoa/{id}

### Header - Exemplo de Token

```
Token: '459c1d6c-d3e1-4daa-b0e3-bfbdb1f310ad'
```

### Exemplo de Body

```json
{
    "nome": "Nome Completo",
    "cpf": "12345678900",
    "email" : "email@gmail.com"
    "dataNascimento": "1990-09-18T00:00:00",
    "endereco": "Rua X n 123",
    "id": 1
}
```

## Operação (/operacao)

### Endpoints

* Consultar Todos: GET /api/operacao
* Consultar: GET /api/operacao/{id}
* Cadastrar: POST /api/operacao

### Header - Exemplo de Token

```
Token: '459c1d6c-d3e1-4daa-b0e3-bfbdb1f310ad'
```

### Exemplo de Body

```json
{
    "tipo": 1,
    "valor": 500,
    "dataDaOperacao": "2019-01-01T00:00:00",
    "contaOrigem": 1,
    "contaDestino": 2,
    "id": 1
}
```
Valores válidos para tipo:
- 0 : Saque
- 1 : Transferência
- 2 : Depósito

## Considerações Finas

* Toda requisição do tipo *Post* e *Put* necessitam **obrigatoriamente** de um objeto em seu *Body*
* Nunca se esquecer do token de acesso em todas as requisições
* Você é livre para usar a api
