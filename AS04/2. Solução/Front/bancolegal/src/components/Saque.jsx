import React, { Component } from "react";
import { Form, Header, Button } from "semantic-ui-react";
import "react-datepicker/dist/react-datepicker.css";
import { connect } from "react-redux";
import * as Map from './Maps'
import { withRouter } from "react-router-dom";
import MensagemDeErro from './MensagemDeErro'

class Saque extends Component {

    state = {
        titular: {},
        conta: {},
        open: false
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

    sacar = (e) => {

        const target = e.target;
        const valor = target[0].value;
        const contaDestino = this.state.conta.id;
        const contaOrigem = this.state.conta.id;
        const tipo = 0;
        const dataDaOperacao = (new Date()).toISOString()

        var operacao = {
            valor,
            contaDestino,
            tipo,
            dataDaOperacao,
            contaOrigem
        }

        if (this.state.conta.saldo + this.state.conta.limite > valor) {
            this.props.addOperation(operacao).then(() => {
                this.props.history.push("/saldo/")
            })
        } else {
            this.setState({ open: true })
        }
    }

    render() {
        return (
            <div>
                <Header as='h1'>Saque</Header>

                <Header as='h4'>{`Saldo - R$ ${this.state.conta.saldo},00`}</Header>
                <Header as='h4'>{`Disponível para saque - R$ ${(this.state.conta.saldo + this.state.conta.limite)},00`}</Header>

                <Form onSubmit={this.sacar}>
                    <Form.Field>
                        <label>Valor</label>
                        <input type='number' placeholder='Valor para saque' />
                    </Form.Field>
                    <Button type='submit'>Sacar</Button>
                </Form>
                <MensagemDeErro
                    titulo={'Falha na operação'}
                    mensagem={"Valor de saque maior do que o disponível."}
                    open={this.state.open}
                    fechar={() => this.setState({ open: false })} />
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

export default withRouter(connect(mapStateToProps, Map.mapDispatchToProps)(Saque));
