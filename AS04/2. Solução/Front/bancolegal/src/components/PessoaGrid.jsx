import React, { Component } from 'react'
import ReactDataGrid from 'react-data-grid';
import * as Map from './Maps'
import { connect } from "react-redux";
import { withRouter } from "react-router-dom";
import { Toolbar } from 'react-data-grid-addons'
import { Header } from "semantic-ui-react";
import { Icon } from 'semantic-ui-react';
import MensagemDeErro from './MensagemDeErro'

class PessoaGrid extends Component {

    state = {
        columns: [
            { key: 'id', name: 'ID', width: 70, editable: false },
            { key: 'nome', name: 'Nome', width: 170, editable: true },
            { key: 'email', name: 'E-mail', width: 170, editable: true },
            { key: 'cpf', name: 'CPF', width: 170, editable: true },
            { key: 'endereco', name: 'Endereço', width: 170, editable: true },
            { key: 'dataNascimento', name: 'Data de nascimento', width: 190, editable: true },
        ]
    }

    componentDidMount = () => {
        this.props.getAllPeoples();
    }

    rowGetter = (i) => {
        return this.props.pessoas[i];
    };

    excluirLinha(column, row) {
        let _this = this;
        if (column.key === 'id') {
            return [
                {
                    icon: <Icon name='remove'></Icon>,
                    callback: () => { _this.props.deletePeople(row.id) }
                },
            ];
        }
    }

    handleGridRowsUpdated = ({ fromRow, toRow, updated }) => {
        var pessoaAlterada = this.props.pessoas[toRow]
        pessoaAlterada[Object.keys(updated)[0]] = updated[Object.keys(updated)[0]]

        this.props.updatePeople(pessoaAlterada).then(() => this.props.getAllPeoples())
    };

    render() {
        return (
            <div>
                <Header as='h1'>Pessoas</Header>
                {
                    this.props.pessoas.length > 0
                        ?
                        <ReactDataGrid
                            enableCellSelect={true}
                            columns={this.state.columns}
                            rowGetter={this.rowGetter}
                            minWidth={this.state.columns.map(x => x.width).reduce((a, b) => a + b, 0)}
                            rowsCount={this.props.pessoas.length}
                            onGridRowsUpdated={this.handleGridRowsUpdated}
                            getCellActions={(column, row) => this.excluirLinha(column, row)}
                            toolbar={<Toolbar onAddRow={() => this.props.history.push("/pessoas/cadastrar")} />}
                        />

                        : <div> Aguarde</div>}
                <MensagemDeErro
                    titulo={'Falha na operação'}
                    mensagem={this.props.message}
                    open={this.props.open}
                    fechar={() => this.props.fecharAvisoPessoa()} />
            </div>
        )
    }
}

const mapStateToProps = (store) => {
    const storePessoa = store.pessoaReducer
    return {
        ...storePessoa
    }
}

export default withRouter(connect(mapStateToProps, Map.mapDispatchToProps)(PessoaGrid));