import { fetchAdicionarPessoa, fetchFazerLogin } from '../actions/index'

export const mapDispatchToProps = (dispatch) => {
    return {
      cadastrePessoa: (pessoa) => dispatch(fetchAdicionarPessoa(pessoa)),
      fazerLogin: (login) => dispatch(fetchFazerLogin(login))
    }
  }