import { fetchAdicionarPessoa } from '../actions/index'

export const mapDispatchToProps = (dispatch) => {
    return {
      cadastrePessoa: (pessoa) => dispatch(fetchAdicionarPessoa(pessoa)),
    }
  }