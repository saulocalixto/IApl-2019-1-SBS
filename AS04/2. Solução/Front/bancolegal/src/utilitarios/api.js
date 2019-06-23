const api = "https://localhost:44388/api/"
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

export const deletePeople = (id) =>
fetch(`${api}/pessoa/${id}`, {
    headers,
    method: 'DELETE'
}).then(res => res.json())
    .then(data => data)

export const cadastrarPessoa = (pessoa) =>
    fetch(`${api}/pessoa`, {
        method: 'POST',
        headers,
        body: JSON.stringify(pessoa)
    }).then(res => res.json())
        .then(data => data);

    export const updatePeople = (people) =>
    fetch(`${api}/pessoa`, {
        method: 'PUT',
        headers,
        body: JSON.stringify(people)
    })
    .then(res => res.json())
    .then(data => data);

    export const getCounts = () =>
  fetch(`${api}/conta`, {
    headers,
    method: 'GET'
  }).then(res => res.json())
    .then(data => data)

export const getCount = (id) =>
    fetch(`${api}/conta/${id}`, {
        headers,
        method: 'GET'
    }).then(res => res.json())
        .then(data => data)

export const deleteCount = (id) =>
fetch(`${api}/conta/${id}`, {
    headers,
    method: 'DELETE'
}).then(res => res.json())
    .then(data => data)

export const insertCount = (count) =>
    fetch(`${api}/conta`, {
        method: 'POST',
        headers,
        body: JSON.stringify(count)
    })
    .then(res => res.json())
    .then(data => data);

    export const updateCount = (count) =>
    fetch(`${api}/conta`, {
        method: 'PUT',
        headers,
        body: JSON.stringify(count)
    })
    .then(res => res.json())
    .then(data => data);

    export const insertOperation = (operation) =>
    fetch(`${api}/operacao`, {
        method: 'POST',
        headers,
        body: JSON.stringify(operation)
    })
    .then(res => res.json())
    .then(data => data);

    export const fazerLogin = (login) =>
    fetch(`${api}/login`, {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(login)
    })
    .then(res => res.json())
        .then(data => data);