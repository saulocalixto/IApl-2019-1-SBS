
import { combineReducers } from "redux";

export const initialStatePessoa = {
  pessoas: []
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

export default pessoaReducer;