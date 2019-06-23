import React from "react";
import { connect } from "react-redux";
import { Route } from "react-router-dom";
import { withRouter } from "react-router-dom";
import Login from './Login'
import CadastrarPessoa from './CadastrarPessoa'
import PessoaGrid from './PessoaGrid'
import CountGrid from './CountGrid'
import InsertCount from './InsertCount'
import Saldo from './Saldo'
import Saque from './Saque'
import Deposito from './Deposito'
import Transferencia from './Transferencia'

const Rotas = props => {

  return (
    <div>
      <Route
        exact
        path="/"
        render={() => (
            <Login />
        )}
      />
      <Route
        exact
        path="/pessoas/cadastrar"
        render={() => {
            return props.token.sucess ? <CadastrarPessoa /> : <Login />
        }}
      />
      <Route
        exact
        path="/pessoas"
        render={() => {
            return props.token.sucess ? <PessoaGrid /> : <Login />
        }}
      />
      <Route
        exact
        path="/counts"
        render={() => {
            return props.token.sucess ? <CountGrid /> : <Login />
        }}
      />
      <Route
        exact
        path="/counts/insert"
        render={() => {
            return props.token.sucess ? <InsertCount /> : <Login />
        }}
      />
      <Route
        exact
        path="/saldo"
        render={() => {
            return props.token.sucess ? <Saldo /> : <Login />
        }}
      />
      <Route
        exact
        path="/operacao/saque"
        render={() => {
            return props.token.sucess ? <Saque /> : <Login />
        }}
      />
      <Route
        exact
        path="/operacao/deposito"
        render={() => {
            return props.token.sucess ? <Deposito /> : <Login />
        }}
      />
      <Route
        exact
        path="/operacao/transferencia"
        render={() => {
            return props.token.sucess ? <Transferencia /> : <Login />
        }}
      />
    </div>
  );
};

const mapStateToProps = (store) => {
    const token = store.sessaoReducer.token
    return {
        token
    }
  }

export default withRouter(connect(mapStateToProps)(Rotas));