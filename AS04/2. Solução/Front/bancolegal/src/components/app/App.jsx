import React from 'react';
import './App.css';
import Menu from '../MenuHeader'
import Login from '../Login'
import CadastrarPessoa from '../CadastrarPessoa'
import Rotas from '../Rotas'
import {
  Container,
  Header
} from 'semantic-ui-react'

function App() {
  return (
    <div className="App">
      <Menu />
      <Container text style={{ marginTop: '7em' }}>
        <Rotas />
    </Container>
    
    </div>
  );
}

export default App;
