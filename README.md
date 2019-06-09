# IApl-2019-1-SBS
Trabalho para a disciplina de Integração de Aplicações do Bacharelado em Engenharia de Software do INF-UFG. Consiste na implementação de um serviço bancário fictício.

O sistema desenvolvido possui uma API REST que pode ser acessada em:

```
http://bancolegal.azurewebsites.net/api/
```

## Login (/login)

Para realizar todas as outras chamadas listadas, é necessário realizar um Login na plataforma. Utilizando o endpoint abaixo, a API retornará um token que deverá ser usado para validar a requisição.

O token obtido deverá ser fornecido no body da requisição com dois parâmetros, 'token' e 'objeto'. Este último parâmetro deverá conter o objeto referente à requisição em chamadas do tipo POST e PUT. Em qualquer outra requisição, fornecer uma string vazia ("") é suficiente.

```json
{
    "objeto": "",
    "token": "91ba471b-82dc-4637-86d7-f5096ac826a7"
}
```

### Endpoints

* Realizar Login: GET /api/login

### Objeto de Exemplo

```json
{
    "IdConta": 1,
    "Senha": "123456"
}
```

## Conta (/conta)

### Endpoints

* Consultar Todos: GET /api/conta
* Consultar: GET /api/conta/1
* Cadastrar: POST /api/conta/1
* Atualizar: PUT /api/conta/1
* Apagar: DELETE /api/conta/1

### Objeto de Exemplo

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
* Consultar: GET /api/operacao/1
* Cadastrar: POST /api/operacao/1
* Atualizar: PUT /api/operacao/1
* Apagar: DELETE /api/operacao/1

### Objeto de Exemplo

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
* Consultar: GET /api/pessoa/1
* Cadastrar: POST /api/pessoa/1
* Atualizar: PUT /api/pessoa/1
* Apagar: DELETE /api/pessoa/1

### Objeto de Exemplo

```json
{
    "nome": "Nome Completo",
    "cpf": "12345678900",
    "dataNascimento": "1990-09-18T00:00:00",
    "endereco": "Rua X n 123",
    "id": 1
}
```
