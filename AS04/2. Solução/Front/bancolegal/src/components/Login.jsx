import React from 'react'
import { Button, Form, Grid, Header, Image, Segment, Portal } from 'semantic-ui-react'
import icon from '../banco.ico'
import * as Map from './Maps'
import { connect } from "react-redux";
import { withRouter } from "react-router-dom";

class Login extends React.Component {

    state = { open: false }

    fazerLogin = (e) => {

        const target = e.target;
        const email = target[0].value;
        const senha = target[1].value;

        var login = {
            email,
            senha,
            internacionalizacao : 0
        }

        this.props.fazerLogin(login).then(() => {
            if(this.props.token !== undefined && this.props.token != '' && !this.props.token.mensagem) {
                this.props.history.push("/cadastrarPessoa")
            } else {
                this.setState({open : true})
            }
        });
    }

    render() {
        const { open } = this.state;
        return (
            <Grid textAlign='center' style={{ height: '100vh' }} verticalAlign='middle'>
                <Grid.Column style={{ maxWidth: 450 }}>
                    <Header as='h2' color='teal' textAlign='center'>
                        <Image size='mini' src={icon} style={{ marginRight: '1.5em' }} />
                        Banco Legal
                    </Header>
                <Form size='large'  onSubmit={this.fazerLogin}>
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
                <Portal onClose={() => this.setState({ open: false })} open={open}>
            <Segment
              style={{
                left: '40%',
                position: 'fixed',
                top: '50%',
                zIndex: 1000,
              }}
            >
              <Header>Falha no login</Header>
              <p>{this.props.token.mensagem}</p>

              <Button
                content='Fechar mensagem'
                negative
                onClick={() => this.setState({ open: false })}
              />
            </Segment>
          </Portal>
            </Grid>
        )
    }
}

const mapStateToProps = (store) => {
    const pessoas = store.pessoaReducer.pessoas
    const token = store.sessaoReducer.token
    return {
        pessoas,
        token
    }
  }

  export default withRouter(connect(mapStateToProps, Map.mapDispatchToProps)(Login));