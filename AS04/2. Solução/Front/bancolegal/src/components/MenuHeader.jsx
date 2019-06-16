import React from 'react'
import {
  Container,
  Divider,
  Dropdown,
  Grid,
  Header,
  Image,
  List,
  Menu,
  Segment,
} from 'semantic-ui-react'
import icon from '../banco.ico'

const MenuHeader = () => (
  <div>
    <Menu fixed='top' inverted>
      <Container>
        <Menu.Item as='a' header>
          <Image size='mini' src={icon} style={{ marginRight: '1.5em' }} />
          Banco Legal
        </Menu.Item>
        <Menu.Item as='a'>Saldo</Menu.Item>

        <Dropdown item simple text='Ações'>
          <Dropdown.Menu>
            <Dropdown.Item>Listar todos as pessoas</Dropdown.Item>
            <Dropdown.Item>Listar todas as contas</Dropdown.Item>
            <Dropdown.Divider />
            <Dropdown.Header>Movimentações</Dropdown.Header>
            <Dropdown.Item>
              <i className='dropdown icon' />
              <span className='text'>Operações</span>
              <Dropdown.Menu>
                <Dropdown.Item>Saque</Dropdown.Item>
                <Dropdown.Item>Depósito</Dropdown.Item>
                <Dropdown.Item>Transferência</Dropdown.Item>
              </Dropdown.Menu>
            </Dropdown.Item>
            <Dropdown.Item>Sair</Dropdown.Item>
          </Dropdown.Menu>
        </Dropdown>
      </Container>
    </Menu>
  </div>
)

export default MenuHeader