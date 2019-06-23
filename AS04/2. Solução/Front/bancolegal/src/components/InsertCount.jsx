import React, { Component } from "react";
import { Form, Header, Button } from "semantic-ui-react";
import "react-datepicker/dist/react-datepicker.css";
import { connect } from "react-redux";
import * as Map from './Maps'
import { withRouter } from "react-router-dom";

class InsertCount extends Component {

    cadastrarConta = (e) => {

        const target = e.target;
        const titular = target[0].value;
        const agencia = target[1].value;
        const numero = target[2].value;
        const senha = target[3].value;
        const saldo = target[4].value;
        const limite = target[5].value;

        var count = {
            titular,
            agencia,
            numero,
            senha,
            saldo,
            limite
        }

        this.props.addCount(count).then(() => {
            this.props.history.push("/counts/")
        })
    }

    render() {
        return (
            <div>
                <Header as='h1'>Cadastro de Conta</Header>

                <Form onSubmit={this.cadastrarConta}>                    
                <Form.Field label="Titular" control="select">
                    {
                        this.props.pessoas.map(x => 
                            <option value={x.id}>{`${x.id} - ${x.nome}`}</option>
                        )
                    }
                </Form.Field>

                    <Form.Field>
                        <label>Agencia</label>
                        <input type='number' placeholder='Agencia' />
                    </Form.Field>
                    <Form.Field >
                        <label>Conta</label>
                        <input type='number' maxLength={11} placeholder='Numeo Conta' name='numero'/>
                    </Form.Field>
                    <Form.Field>
                        <label>Senha</label>
                        <input type='password' placeholder='Senha' name='senha'/>
                    </Form.Field>
                    <Form.Field >
                        <label>Saldo</label>
                        <input type='number' maxLength={11} placeholder='Saldo' name='saldo'/>
                    </Form.Field>
                    <Form.Field >
                        <label>Limite</label>
                        <input type='number' maxLength={11} placeholder='Limite' name='limite'/>
                    </Form.Field>
                    <Button type='submit'>Cadastrar</Button>
                </Form>
            </div>)
    }
};

const mapStateToProps = (store) => {
    const storeCount = store.countReducer
    const pessoas = store.pessoaReducer.pessoas
    return {
        ...storeCount,
        pessoas
    }
}

export default withRouter(connect(mapStateToProps, Map.mapDispatchToProps)(InsertCount));
