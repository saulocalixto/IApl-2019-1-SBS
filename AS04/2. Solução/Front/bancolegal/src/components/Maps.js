import { fetchAdicionarPessoa,
   fetchFazerLogin,
   fetchGetAllPeoples,
   fetchUpdatePeople,
   fetchDeletePeople,
   fecharAvisoPessoa,
  fetchAddCount,
  fetchDeleteCount,
  fecharAvisoCount,
  fetchUpdateCount,
  fetchGetAllCounts,
  fetchAddOperation,
  fecharAvisoOperacao } from '../actions/index'

export const mapDispatchToProps = (dispatch) => {
    return {
      cadastrePessoa: (pessoa) => dispatch(fetchAdicionarPessoa(pessoa)),
      fazerLogin: (login) => dispatch(fetchFazerLogin(login)),
      getAllPeoples: () => dispatch(fetchGetAllPeoples()),
      updatePeople: (pessoa) => dispatch(fetchUpdatePeople(pessoa)),
      deletePeople: (id) => dispatch(fetchDeletePeople(id)),
      fecharAvisoPessoa: () => dispatch(fecharAvisoPessoa()),
      addCount: (count) => dispatch(fetchAddCount(count)),
      getAllCounts: () => dispatch(fetchGetAllCounts()),
      updateCount: (count) => dispatch(fetchUpdateCount(count)),
      deleteCount: (id) => dispatch(fetchDeleteCount(id)),
      fecharAvisoCount: () => dispatch(fecharAvisoCount()),
      addOperation:(operation) => dispatch(fetchAddOperation(operation)),
      fecharAvisoOperacao: () => dispatch(fecharAvisoOperacao()),
    }
  }