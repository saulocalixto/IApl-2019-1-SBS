import * as Api from '../utilitarios/api'

export const adicionarPessoa = (pessoa, result) => {
    return {
      type: "ADICIONAR_PESSOA",
      pessoa,
      result
    }
  }
  
  export const fetchAdicionarPessoa = (pessoa) => dispatch => (
    Api.cadastrarPessoa(pessoa).then((result) => {
      dispatch(adicionarPessoa(pessoa, result))
    }, erro => console.log(`Erro na requisição: ${erro}`))
  );

  export const updatePeople = (pessoa, result) => {
    return {
      type: "UPDATE_PEOPLE",
      pessoa,
      result
    }
  }

  export const fetchUpdatePeople = (pessoa, result) => dispatch => (
    Api.updatePeople(pessoa).then((result) => {
      dispatch(updatePeople(pessoa, result))
    }, erro => console.log(`Erro na requisição: ${erro}`))
  );

  export const deletePeople = (id, result) => {
    return {
      type: "DELETE_PEOPLE",
      id, result
    }
  }

  export const fetchDeletePeople = (id) => dispatch => (
    Api.deletePeople(id).then((result) => {
      dispatch(deletePeople(id, result))
    }, erro => console.log(`Erro na requisição: ${erro}`))
  );

  export const fecharAvisoPessoa = () => {
    return {
      type: "FECHAR_AVISO_PESSOA",
    }
  }

  export const fecharAvisoOperacao = () => {
    return {
      type: "FECHAR_AVISO_OPERACAO",
    }
  }

  export const addCount = (count, result) => {
    return {
      type: "ADD_COUNT",
      count,
      result
    }
  }
  
  export const fetchAddCount = (count) => dispatch => (
    Api.insertCount(count).then((result) => {
      dispatch(addCount(count, result))
    }, erro => console.log(`Erro na requisição: ${erro}`))
  );

  export const updateCount = (count, result) => {
    return {
      type: "UPDATE_COUNT",
      count,
      result
    }
  }

  export const fetchUpdateCount = (count) => dispatch => (
    Api.updateCount(count).then((result) => {
      dispatch(updateCount(count, result))
    }, erro => console.log(`Erro na requisição: ${erro}`))
  );

  export const deleteCount = (id, result) => {
    return {
      type: "DELETE_COUNT",
      id, 
      result
    }
  }

  export const fetchDeleteCount = (id) => dispatch => (
    Api.deleteCount(id).then((result) => {
      dispatch(deleteCount(id, result))
    }, erro => console.log(`Erro na requisição: ${erro}`))
  );

  export const getAllCounts = (counts) => {
    return {
      type: "GET_ALL_COUNTS",
      counts
    }
  }
  
  export const fetchGetAllCounts = () => dispatch => (
    Api.getCounts().then((counts) => {
      dispatch(getAllCounts(counts))
    }, erro => console.log(`Erro na requisição: ${erro}`))
  );

  export const addOperation = (operation, result) => {
    return {
      type: "ADD_OPERATION",
      operation,
      result
    }
  }
  
  export const fetchAddOperation = (operation) => dispatch => (
    Api.insertOperation(operation).then((result) => {
      dispatch(addOperation(operation, result))
    }, erro => console.log(`Erro na requisição: ${erro}`))
  );

  export const fecharAvisoCount = () => {
    return {
      type: "FECHAR_AVISO_COUNT",
    }
  }

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

  export const getAllPeoples = (peoples) => {
    return {
      type: "GET_ALL_PEOPLES",
      peoples
    }
  }
  
  export const fetchGetAllPeoples = () => dispatch => (
    Api.consultarPessoas().then((peoples) => {
      dispatch(getAllPeoples(peoples))
    }, erro => console.log(`Erro na requisição: ${erro}`))
  );