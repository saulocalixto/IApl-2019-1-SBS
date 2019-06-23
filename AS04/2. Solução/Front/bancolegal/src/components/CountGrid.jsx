import React, { Component } from 'react'
import ReactDataGrid from 'react-data-grid';
import * as Map from './Maps'
import { connect } from "react-redux";
import { withRouter } from "react-router-dom";
import { Toolbar } from 'react-data-grid-addons'
import { Header } from "semantic-ui-react";
import { Icon } from 'semantic-ui-react';
import MensagemDeErro from './MensagemDeErro'

class CountGrid extends Component {

    state = {
        columns: [
            { key: 'id', name: 'ID', width: 70, editable: false },
            { key: 'titular', name: 'Titular', width: 170, editable: false },
            { key: 'agencia', name: 'Agencia', width: 150, editable: false },
            { key: 'numero', name: 'Conta', width: 150, editable: false },
            { key: 'saldo', name: 'Saldo', width: 150, editable: true },
            { key: 'limite', name: 'Limite', width: 120, editable: true },
        ],
        rows: []
    }

    componentDidMount = () => {
        this.setRows()
    }

    setRows = () => {
        this.props.getAllCounts().then(() => {
            if(this.props.pessoas.length === 0) {
                this.props.getAllPeoples().then(() => {
                    let rows = this.mountRow()
                    this.setState({ rows })
                })
            } else {
                let rows = this.mountRow()
                this.setState({ rows })
            }
            
        })
    }

    mountRow = () => {
        return this.props.counts.map(x => {
            let nomeTitular = this.props.pessoas.find(pessoa => pessoa.id === x.titular).nome
            let titular = `${x.titular} - ${nomeTitular}`
            return { id: x.id, titular, agencia: x.agencia, numero: x.numero, saldo: x.saldo, limite: x.limite }
        })
    }

    rowGetter = (i) => {
        return this.state.rows[i];
    };

    excluirLinha(column, row) {
        let _this = this;
        if (column.key === 'id') {
            return [
                {
                    icon: <Icon name='remove'></Icon>,
                    callback: () => {
                        _this.props.deleteCount(row.id).then(() => {
                            this.setRows()
                        })

                    }
                },
            ];
        }
    }

    handleGridRowsUpdated = ({ fromRow, toRow, updated }) => {
        var countUpdated = this.props.counts[toRow]

        countUpdated[Object.keys(updated)[0]] = updated[Object.keys(updated)[0]]

        this.props.updateCount(countUpdated).then(() => this.setRows())
    };

    render() {
        return (
            <div>
                <Header as='h1'>Contas</Header>
                {
                    this.state.rows.length > 0
                        ?
                        <ReactDataGrid
                            enableCellSelect={true}
                            columns={this.state.columns}
                            rowGetter={this.rowGetter}
                            rowsCount={this.state.rows.length}
                            minWidth={this.state.columns.map(x => x.width).reduce((a,b) => a + b, 0)}
                            onGridRowsUpdated={this.handleGridRowsUpdated}
                            getCellActions={(column, row) => this.excluirLinha(column, row)}
                            toolbar={<Toolbar onAddRow={() => this.props.history.push("/counts/insert")} />}
                        />

                        : <div> Aguarde</div>}
                <MensagemDeErro
                    titulo={'Falha na operação'}
                    mensagem={this.props.message}
                    open={this.props.open}
                    fechar={() => this.props.fecharAvisoCount()} />
            </div>
        )
    }
}

const mapStateToProps = (store) => {
    const storeCount = store.countReducer
    const pessoas = store.pessoaReducer.pessoas
    return {
        ...storeCount,
        pessoas
    }
}

export default withRouter(connect(mapStateToProps, Map.mapDispatchToProps)(CountGrid));