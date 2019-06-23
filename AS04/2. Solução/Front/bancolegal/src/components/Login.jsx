import React from 'react'
import { Button, Form, Grid, Header, Image, Segment } from 'semantic-ui-react'
import icon from '../banco.ico'
import * as Map from './Maps'
import { connect } from "react-redux";
import { withRouter } from "react-router-dom";
import MensagemDeErro from './MensagemDeErro'

class Login extends React.Component {

    state = { open: false }

    fazerLogin = (e) => {

        const target = e.target;
        const email = target[0].value;
        const senha = target[1].value;

        var login = {
            email,
            senha,
            internacionalizacao: 0
        }

        this.props.fazerLogin(login).then(() => {
            if (this.props.token.sucess) {
                this.props.history.push("/saldo")
            } else {
                this.setState({ open: true })
            }
        });
    }

    render() {
        const { open } = this.state;
        return (
            <Grid textAlign='center' style={{ height: '50vh' }} verticalAlign='middle'>
                <Grid.Column style={{ maxWidth: 450 }}>
                    <Header as='h2' color='teal' textAlign='center'>
                        <Image size='mini' src={icon} style={{ marginRight: '1.5em' }} />
                        Banco Legal
                    </Header>
                    <Form size='large' onSubmit={this.fazerLogin}>
                        <Segment stacked>
                            <Form.Input fluid icon='user' iconPosition='left' placeholder='E-mail' />
                            <Form.Input
                                fluid
                                icon='lock'
                                iconPosition='left'
                                placeholder='Senha'
                                type='password'
                            />

                            <Button type='submit' color='teal' fluid size='large'>
                                Login
                        </Button>
                        </Segment>
                    </Form>
                </Grid.Column>
                <MensagemDeErro 
                    titulo={'Falha no login'}
                    mensagem={'Falha ao efetuar o login, verifique email e senha informados.'}
                    open={ open }
                    fechar={() => this.setState({ open:false })}/>
            </Grid>
        )
    }
}

const mapStateToProps = (store) => {
    const token = store.sessaoReducer.token
    return {
        token
    }
}

export default withRouter(connect(mapStateToProps, Map.mapDispatchToProps)(Login));