import React, { Component } from 'react'
import { Button, Header, Segment, Portal } from 'semantic-ui-react'
import { connect } from "react-redux";
import { withRouter } from "react-router-dom";


class MensagemDeErro extends Component {

    render() {
        return (
            <Portal onClose={() => this.props.fechar()} open={this.props.open}>
                <Segment
                    style={{
                        left: '40%',
                        position: 'fixed',
                        top: '50%',
                        zIndex: 1000,
                    }}
                >
                    <Header>{this.props.titulo}</Header>
                    <p>{this.props.mensagem}</p>

                    <Button
                        content='Fechar mensagem'
                        negative
                        onClick={() => this.props.fechar()}
                    />
                </Segment>
            </Portal>
        )
    }
}

export default withRouter(connect()(MensagemDeErro));