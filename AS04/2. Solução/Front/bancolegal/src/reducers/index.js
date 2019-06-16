
import { combineReducers } from "redux";

export const initialStatePessoa = {
  pessoas: []
};

export const initialStateSessao = {
    token: ''
  };

function pessoaReducer(state = initialStatePessoa, action) {
    let pessoas = []
    switch (action.type) {
        case 'ADICIONAR_PESSOA':
            pessoas = [...state.pessoas, action.pessoa];
            return {
                pessoas,
                ...state,
            };
        default:
            return {
                ...state
            }
    }
}

function sessaoReducer(state = initialStateSessao, action) {
    let token = '';
    switch (action.type) {
        case 'FAZER_LOGIN':
            token = action.token !== undefined ? action.token : '';
            return {
                ...state,
                token,
            };
        default:
            return {
                ...state
            }
    }
}

export default combineReducers( {pessoaReducer, sessaoReducer} );