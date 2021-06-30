import { Component } from 'react';

import './App.css';

class Github extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listaRepositorios: [],
      nomeRepositorio: ''
    }
  }

  buscarRepositorios = (e) => {
    e.preventDefault();

    console.log("API chamada...");

    fetch('https://api.github.com/users/' + this.state.nomeRepositorio + '/repos')

      .then(resposta => resposta.json())

      .then(dados => this.setState({ listaRepositorios: dados }))

      .catch(erro => console.log(erro))
  }

  atualizarNome = async (nome) => {
    await this.setState({ nomeRepositorio: nome.target.value })
    console.log(this.state.nomeRepositorio)
  }

  render() {
    return (
      <div>
        <main>
          <section>
            <h2>Buscador</h2>
            <form onSubmit={this.buscarRepositorios}>
              <div>
                <input
                  type="text"
                  value={this.state.nomeRepositorio}
                  onChange={this.atualizarNome}
                  placeholder="Usuário do GitHub" />
                <button type="submit" onClick={this.buscarRepositorios}> Localizar </button>
              </div>
            </form>
          </section>

          <section>
            <h2>Lista de repositórios de {this.state.nomeRepositorio}</h2>
            <table>
              <thead>
                <tr>
                  <th>#</th>
                  <th>Nome</th>
                  <th>Descrição</th>
                  <th>Data de criação</th>
                  <th>Tamanho</th>
                </tr>
              </thead>

              <tbody>
                {
                  this.state.listaRepositorios.map((repositorios) => {
                    return (
                      <tr key={repositorios.id}>
                        <td>{repositorios.id}</td>
                        <td>{repositorios.name}</td>
                        <td>{repositorios.description}</td>
                        <td>{repositorios.created_at}</td>
                        <td>{repositorios.size}</td>
                      </tr>
                    )
                  })
                }
              </tbody>
            </table>
          </section>
        </main>
      </div >
    )
  }
}

export default Github;
