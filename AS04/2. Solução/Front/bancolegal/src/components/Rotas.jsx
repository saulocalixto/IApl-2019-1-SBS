import React, { Component } from "react";
import { connect } from "react-redux";
import { Route } from "react-router-dom";
import { withRouter } from "react-router-dom";
import Login from './Login'
import CadastrarPessoa from './CadastrarPessoa'

const Rotas = props => {
  const { classes } = props;

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
        path="/cadastrarPessoa"
        render={() => {
            return props.token !== undefined && props.token != '' && !props.token.mensagem ? <CadastrarPessoa /> : <Login />
        }}
      />
    </div>
  );
};

const mapStateToProps = (store) => {
    const pessoas = store.pessoaReducer.pessoas
    const token = store.sessaoReducer.token
    return {
        pessoas,
        token
    }
  }

export default withRouter(connect(mapStateToProps)(Rotas));