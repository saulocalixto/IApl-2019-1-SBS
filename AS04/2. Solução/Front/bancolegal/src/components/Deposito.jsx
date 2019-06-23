import React, { Component } from "react";
import { Form, Header, Button } from "semantic-ui-react";
import "react-datepicker/dist/react-datepicker.css";
import { connect } from "react-redux";
import * as Map from './Maps'
import { withRouter } from "react-router-dom";

class Deposito extends Component {

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

    depositar = (e) => {

        const target = e.target;
        const valor = target[0].value;
        const contaDestino = this.state.conta.id;
        const contaOrigem = this.state.conta.id;
        const tipo = 2;
        const dataDaOperacao = (new Date()).toISOString()

        var operacao = {
            valor,
            contaDestino,
            tipo,
            dataDaOperacao,
            contaOrigem
        }

        this.props.addOperation(operacao).then(() => {
            this.props.history.push("/saldo/")
        })
    }

    render() {
        return (
            <div>
                <Header as='h1'>Depósito</Header>

                <Header as='h3'>{`Saldo - R$ ${this.state.conta.saldo},00`}</Header>

                <Form onSubmit={this.depositar}>                    
                    <Form.Field>
                        <label>Valor</label>
                        <input type='number' placeholder='Valor de depósito' />
                    </Form.Field>
                    <Button type='submit'>Depositar</Button>
                </Form>
            </div>)
    }
};

const mapStateToProps = (store) => {
    const storePessoa = store.pessoaReducer
    const storeCount = store.countReducer
    const storeSessao = store.sessaoReducer
    return {
        ...storePessoa,
        ...storeCount,
        ...storeSessao
    }
}

export default withRouter(connect(mapStateToProps, Map.mapDispatchToProps)(Deposito));
