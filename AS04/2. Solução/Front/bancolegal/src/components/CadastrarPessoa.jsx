import React, { Fragment } from "react";
import { Field, reduxForm } from "redux-form";
import { Form, Header, Button } from "semantic-ui-react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { connect } from "react-redux";
import * as Map from './Maps'
import { withRouter } from "react-router-dom";

class CadastrarPessoa extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            startDate: new Date()
        };
        this.trocaData = this.trocaData.bind(this);
    }

    trocaData(date) {
        this.setState({
            startDate: date
        });
    }

    enviarPessoa = (e) => {

        const target = e.target;
        const email = target[0].value;
        const nome = target[1].value;
        const cpf = target[2].value;
        const endereco = target[3].value;
        const dataNascimento = this.state.startDate.toISOString();

        var pessoa = {
            email,
            nome,
            cpf,
            endereco,
            dataNascimento
        }

        this.props.cadastrePessoa(pessoa);
    }

    render() {
        return (
            <div>
                <Header as='h1'>Cadastro de Pessoa</Header>

                <Form onSubmit={this.enviarPessoa}>
                    <Form.Field>
                        <label>E-Mail</label>
                        <input placeholder='E-mail' name='email'/>
                    </Form.Field>
                    <Form.Field>
                        <label>Nome</label>
                        <input placeholder='Nome' />
                    </Form.Field>
                    <Form.Field >
                        <label>CPF</label>
                        <input type='number' maxLength={11} placeholder='CPF' name='cpf'/>
                    </Form.Field>
                    <Form.Field>
                        <label>Endereço</label>
                        <input placeholder='Endereço' name='endereco'/>
                    </Form.Field>
                    <Form.Field>
                        <label>Data de Nascimento</label>
                        <DatePicker
                            dateFormat='dd/MM/yyyy'
                            selected={this.state.startDate}
                            onChange={this.trocaData}
                        />
                    </Form.Field>
                    <Button type='submit'>Cadastrar</Button>
                </Form>
            </div>)
    }
};

const mapStateToProps = (store) => {
    const pessoas = store.pessoas
    return {
        pessoas
    }
  }

export default withRouter(connect(mapStateToProps, Map.mapDispatchToProps)(CadastrarPessoa));
