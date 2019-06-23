import React, { Component } from 'react'
import * as Map from './Maps'
import { connect } from "react-redux";
import { withRouter } from "react-router-dom";
import { Card, Header } from 'semantic-ui-react'

class Saldo extends Component {

    state = {
        titular: {},
        conta: {}
    }

    componentDidMount = () => {
        this.props.getAllPeoples().then(() => {
            this.props.getAllCounts().then(() => {
                var titular = this.props.pessoas.find(x => x.email === this.props.token.value.email)
                var conta = this.props.counts.find(x => x.id === this.props.token.value.idConta)
                this.setState({ titular, conta })
            })
        });
    }

    render() {
        return (
            <div>
                <Header as='h1'>Saldo</Header>
                {
                    this.props.pessoas.length > 0 && this.props.counts.length > 0 ?
                        <Card fluid={true}>
                            <Card.Content header={'Titular da Conta'} />
                            <Card.Content description={this.state.titular.nome} />
                            <Card.Content header='Saldo Disponível' />
                            <Card.Content description={`R$ ${this.state.conta.saldo},00`} />
                            <Card.Content header='Limite' />
                            <Card.Content description={`R$ ${this.state.conta.limite},00`} />
                            <Card.Content extra>
                                {Date(Date.now()).toLocaleString()}
                            </Card.Content>
                        </Card> :
                        <div> Aguarde</div>
                }
            </div>
        )
    }
}

const mapStateToProps = (store) => {
    const storePessoa = store.pessoaReducer
    const storeCount = store.countReducer
    const storeOperacao = store.operacaoReducer
    const storeSessao = store.sessaoReducer
    return {
        ...storePessoa,
        ...storeCount,
        ...storeOperacao,
        ...storeSessao
    }
}

export default withRouter(connect(mapStateToProps, Map.mapDispatchToProps)(Saldo));