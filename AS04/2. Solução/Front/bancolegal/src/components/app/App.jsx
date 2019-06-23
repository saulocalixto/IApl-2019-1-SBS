import React from 'react';
import './App.css';
import Menu from '../MenuHeader'
import Rotas from '../Rotas'
import { Container } from 'semantic-ui-react'

const App = () => {
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
