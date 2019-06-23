
import { combineReducers } from "redux";

export const initialStatePessoa = {
    pessoas: [],
    open: false,
    message: ''
};

export const initialStateCount = {
    counts: [],
    message: ''
};

export const initialStateOperation = {
    message: '',
    openOperation: false
};

export const initialStateSessao = {
    token: ''
};

const pessoaReducer = (state = initialStatePessoa, action) => {
    let pessoas = []
    let open = false;
    let message = ''
    switch (action.type) {
        case 'ADICIONAR_PESSOA':
            if (action.result.sucess) {
                pessoas = [...state.pessoas, action.pessoa]
            } else {
                pessoas = [...state.pessoas]
                open = true
                message = action.result.message
            }

            return {
                ...state,
                pessoas,
                open,
                message
            };
        case 'GET_ALL_PEOPLES':
            pessoas = action.peoples.value;
            return {
                ...state,
                pessoas,
            };
        case 'UPDATE_PEOPLE':
            pessoas = state.pessoas.filter(x => x.id !== action.pessoa.id)
            pessoas = [...pessoas, action.pessoa]
            pessoas.sort((a, b) => a.id < b.id ? -1 : a.id > b.id ? 1 : 0)
            return {
                ...state,
                pessoas
            };
        case 'DELETE_PEOPLE':
            if (action.result.sucess) {
                pessoas = state.pessoas.filter(x => x.id !== action.id)
                pessoas.sort((a, b) => a.id < b.id ? -1 : a.id > b.id ? 1 : 0)
            } else {
                pessoas = [...state.pessoas]
                open = true
                message = action.result.message
            }

            return {
                ...state,
                pessoas,
                open,
                message
            };
        case 'FECHAR_AVISO_PESSOA':
            open = false

            return {
                ...state,
                open,
            };
        default:
            return {
                ...state
            }
    }
}

const countReducer = (state = initialStateCount, action) => {
    let counts = []
    let open = false;
    let message = ''
    switch (action.type) {
        case 'ADD_COUNT':
            if (action.result.sucess) {
                counts = [...state.counts, action.count]
            } else {
                counts = [...state.counts]
                open = true
                message = action.result.message
            }

            return {
                ...state,
                counts,
                open,
                message
            };
        case 'GET_ALL_COUNTS':
            if(action.counts.sucess) {
                counts = action.counts.value;
            } else {
                open = true
                message = action.counts.message
            }
            return {
                ...state,
                counts,
                open,
                message
            };
        case 'UPDATE_COUNT':
            counts = state.counts
            if (action.result.sucess) {
                counts = state.counts.filter(x => x.id !== action.count.id)
                counts = [...counts, action.count]
                counts.sort((a, b) => a.id < b.id ? -1 : a.id > b.id ? 1 : 0)
            } else {
                open = true
                message = action.result.message
            }
            return {
                ...state,
                counts,
                open,
                message
            };
        case 'DELETE_COUNT':
            if (action.result.sucess) {
                counts = state.counts.filter(x => x.id !== action.id)
                counts.sort((a, b) => a.id < b.id ? -1 : a.id > b.id ? 1 : 0)
            } else {
                counts = [...state.counts]
                open = true
                message = action.result.message
            }

            return {
                ...state,
                counts,
                open,
                message
            };
        case 'FECHAR_AVISO_COUNT':
            open = false
            return {
                ...state,
                open,
            };
        default:
            return {
                ...state
            }
    }
}

const operationReducer = (state = initialStateOperation, action) => {
    let openOperation = false;
    let message = ''
    switch (action.type) {
        case 'ADD_OPERATION':
            if (!action.result.sucess) {
                openOperation = true
                message = action.result.message
            return {
                ...state,
                openOperation,
                message
            };
        }
        return {
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
            token = action.token;
            return {
                ...state,
                token,
            };
        case 'DESLOGAR':
            token = '';
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

export default combineReducers({ pessoaReducer, sessaoReducer, countReducer, operationReducer });