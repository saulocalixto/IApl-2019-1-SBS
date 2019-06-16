import * as Api from '../utilitarios/api'

export const adicionarPessoa = (pessoa) => {
    return {
      type: "ADICIONAR_PESSOA",
      pessoa
    }
  }
  
  export const fetchAdicionarPessoa = (pessoa) => dispatch => (
    Api.cadastrarPessoa(pessoa).then(() => {
      dispatch(adicionarPessoa(pessoa))
    }, erro => console.log(`Erro na requisição: ${erro}`))
  );

  export const fazerLogin = (token) => {
    return {
      type: "FAZER_LOGIN",
      token
    }
  }
  
  export const fetchFazerLogin = (login) => dispatch => (
    Api.fazerLogin(login).then((token) => {
      dispatch(fazerLogin(token))
    }, erro => console.log(`Erro na requisição: ${erro}`))
  );