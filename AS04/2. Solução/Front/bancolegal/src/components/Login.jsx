import React from 'react'
import { Button, Form, Grid, Header, Image, Message, Segment } from 'semantic-ui-react'
import icon from '../banco.ico'

const Login = () => (
  <Grid textAlign='center' style={{ height: '100vh' }} verticalAlign='middle'>
    <Grid.Column style={{ maxWidth: 450 }}>
      <Header as='h2' color='teal' textAlign='center'>
      <Image size='mini' src={icon} style={{ marginRight: '1.5em' }} />
        Banco Legal
      </Header>
      <Form size='large'>
        <Segment stacked>
          <Form.Input fluid icon='user' iconPosition='left' placeholder='E-mail' />
          <Form.Input
            fluid
            icon='lock'
            iconPosition='left'
            placeholder='Senha'
            type='password'
          />

          <Button color='teal' fluid size='large'>
            Login
          </Button>
        </Segment>
      </Form>
      <Message>
        Primeiro acesso? <a href='#'>Cadastre-se</a>
      </Message>
    </Grid.Column>
  </Grid>
)

export default Login