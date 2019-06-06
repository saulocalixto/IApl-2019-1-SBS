# IApl-2019-1-SBS
Trabalho para a disciplina de Integração de Aplicações do Bacharelado em Engenharia de Software do INF-UFG. Consiste na implementação de um serviço bancário fictício.

## API

O sistema desenvolvido possui uma API REST que pode ser acessada em:

```
http://bancolegal.azurewebsites.net/api/
```

### Conta (/conta)

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

### Operação (/operacao)

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

### Pessoa (/pessoa)

```json
{
    "nome": "Nome Completo",
    "cpf": "12345678900",
    "dataNascimento": "1990-09-18T00:00:00",
    "endereco": "Rua X n 123",
    "id": 1
}
```
