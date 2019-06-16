const api = "http://bancolegal.azurewebsites.net/api"
const headers = { 
    'Token': '459c1d6c-d3e1-4daa-b0e3-bfbdb1f310ad',
    'Content-Type': 'application/json'
 };

export const consultarPessoas = () =>
  fetch(`${api}/pessoa`, {
    headers,
    method: 'GET'
  }).then(res => res.json())
    .then(data => data)

export const consultarPessoa = (id) =>
    fetch(`${api}/pessoa/${id}`, {
        headers,
        method: 'GET'
    }).then(res => res.json())
        .then(data => data)

export const cadastrarPessoa = (pessoa) =>
    fetch(`${api}/pessoa`, {
        method: 'POST',
        headers,
        body: JSON.stringify(pessoa)
    })
    .then(res => { res.json() });

    export const fazerLogin = (login) =>
    fetch(`${api}/login`, {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(login)
    })
    .then(res => res.json())
        .then(data => data);