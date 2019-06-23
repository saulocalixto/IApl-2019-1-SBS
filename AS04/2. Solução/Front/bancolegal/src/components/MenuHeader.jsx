import React from 'react'
import {
  Container,
  Dropdown,
  Image,
  Menu
} from 'semantic-ui-react'
import icon from '../banco.ico'
import { connect } from "react-redux";
import { withRouter } from "react-router-dom";

const MenuHeader = (props) => (
  <div>
    <Menu fixed='top' inverted>
      <Container>
        <Menu.Item as='a' header>
          <Image size='mini' src={icon} style={{ marginRight: '1.5em' }} />
          Banco Legal
        </Menu.Item>
        <Menu.Item onClick={() => props.history.push("/saldo/")}>Saldo</Menu.Item>

        <Dropdown item simple text='Ações'>
          <Dropdown.Menu>
            <Dropdown.Item onClick={() => props.history.push("/pessoas/")}>Listar todos as pessoas</Dropdown.Item>
            <Dropdown.Item onClick={() => props.history.push("/counts/")}>Listar todas as contas</Dropdown.Item>
            <Dropdown.Divider />
            <Dropdown.Header>Movimentações</Dropdown.Header>
            <Dropdown.Item>
              <i className='dropdown icon' />
              <span className='text'>Operações</span>
              <Dropdown.Menu>
                <Dropdown.Item onClick={() => props.history.push("/operacao/saque/")}>Saque</Dropdown.Item>
                <Dropdown.Item onClick={() => props.history.push("/operacao/deposito/")}>Depósito</Dropdown.Item>
                <Dropdown.Item onClick={() => props.history.push("/operacao/transferencia/")}>Transferência</Dropdown.Item>
              </Dropdown.Menu>
            </Dropdown.Item>
            <Dropdown.Item onClick={() => props.history.push("/")}>Sair</Dropdown.Item>
          </Dropdown.Menu>
        </Dropdown>
      </Container>
    </Menu>
  </div>
)

export default withRouter(connect()(MenuHeader));