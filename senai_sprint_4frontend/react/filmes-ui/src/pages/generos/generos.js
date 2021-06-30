import { Component } from 'react';

class Generos extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listaGeneros: [],
      titulo: '',
      idGeneroAlterado: 0
    }
  }

  buscarGeneros = () => {
    console.log("API chamada!");

    //Faz a chamada para a API usando o fetch
    fetch('http://localhost:5000/api/generos')

      // O método .json() retorna um objeto JavaScript
      //Define o tipo de dado do retorno
      .then(resposta => resposta.json())

      //e atualiza o state listaGeneros com os dados obtidos
      .then(dados => this.setState({ listaGeneros: dados }))

      //Caso ocorra algum erro, mostra no console do navegador
      .catch(erro => console.log(erro))
  }

  //Atualiza o state título com o valor do input
  atualizaEstadoTitulo = async (event) => {
    //         NomeEstado :  ValorInput  
    await this.setState({ titulo: event.target.value })
    console.log(this.state.titulo)
  }

  //Função responsável por cadastrar um gênero
  cadastrarGenero = (event) => {
    //Ignora o comportamento padrão do navegador
    event.preventDefault();

    //Caso algum Gênero seja selecionado para edição,
    if (this.state.idGeneroAlterado !== 0) {
      //faz a chamada para a API usando fetch e passando o ID do gênero que será atualizado na URL da requisição
      fetch('http://localhost:5000/api/generos/' + this.state.idGeneroAlterado, {
        //Define o método da requisição ( PUT )
        method: 'PUT',

        //Define o corpo da requisição especificando o tipo (JSON)
        //Em outras palavras, converte o state para uma string JSON
        body: JSON.stringify({ nome: this.state.titulo }),

        //Define o cabeçalho da requisição
        headers: {
          "Content-Type": "application/json"
        }
      })

        .then(resposta => {
          //Caso a requisição retorne um status code 204,
          if (resposta.status === 204) {
            console.log(
              //exibe no console do navegador a mensagem 'Gênero x atualizado! onde X é o ID do gênero que foi atualizado
              'Gênero ' + this.state.idGeneroAlterado + ' atualizado!',
              'Seu novo título agora é: ' + this.state.titulo
            )
          }
        })

        //Então, atualiza a lista de gêneros
        //sem o usuário precisar executar outra ação
        .then(this.buscarGeneros)

        //Faz a chamada para a função limparCampos()
        .then(this.limparCampos);

    } else {
      //Cadastro

      //Faz a chamada para a API usando fetch
      fetch('http://localhost:5000/api/generos', {
        //Define o método da requisição (POST)
        method: 'POST',

        //Define o corpo da requisição especificando o tipo (JSON)
        //Em outras palavras, converte o state para uma string JSON
        body: JSON.stringify({ nome: this.state.titulo }),

        //Define o cabeçalho da requisição
        headers: {
          "Content-Type": "application/json"
        }
      })

        //Exibe no console do navegador a mensagem "Gênero cadastrado!"
        .then(console.log('Gênero cadastrado!'))

        //Caso ocorra algum erro, exibe a mensagem no console do navegador
        .catch(erro => console.log(erro))

        //Então, atualiza a lista de gêneros
        //sem o usuário precisar executar outra ação
        .then(this.buscarGeneros)

        //Faz a chamada para a função limparCampos()
        .then(this.limparCampos)
    }
  }

  //Chama a função buscarGeneros() assim que o componente é renderizado
  componentDidMount() {
    this.buscarGeneros();
  }

  //Recebe um gênero da lista
  buscarGeneroPorId = (genero) => {
    this.setState({
      //Atualiza o state idGeneroAlterado com o valor do ID do Gênero recbido
      idGeneroAlterado: genero.idGenero,
      //e o state título com o valor do título gênero recebio
      titulo: genero.nome
    }, () => {
      console.log(
        //Exibe no console do navegador o valor do ID do Gênero recebido
        'O Gênero ' + genero.idGenero + ' foi selecionado, ',
        //e o valor do state idGeneroAlterado
        'agora o valor do state idGeneroAlterado é: ' + this.state.idGeneroAlterado,
        //e o valor do state titulo
        'e o valor do state título é: ' + this.state.titulo
      );
    });
  };

  //função responsável por excluir um gênero
  excluirGenero = (genero) => {
    //exibe no console do navegaor o ID do Gênero recebido
    console.log('O Gênero ' + genero.idGenero + ' foi selecionado!')

    //Faz a chamada para a API usando fetch passando o ID do Gênero recebido na URL da requisiçãp
    fetch('http://localhost:5000/api/generos/' + genero.idGenero, {
      //Define o método da requisição ( DELETE )
      method: 'DELETE'
    })

      //Caso a requisição retorne um status code 204,
      .then(resposta => {
        if (resposta.status === 204) {
          //Exibe no console do navegador a mensagem 'Gênero X excluído!' onde x é o ID do Gênero excluído
          console.log('Gênero ' + genero.idGenero + ' excluído!')
        }
      })
      //caso ocorra algum erro, exibe exte erro no console do navegador
      .catch(erro => console.log(erro))

      //Então, atualiza a lista de gêneros
      //sem o usuário precisar executar outra ação
      .then(this.buscarGeneros)
  }

  //Reseta os states título e idGeneroAlterado
  limparCampos = () => {
    this.setState({
      titulo: '',
      idGeneroAlterado: 0
    });
    //Exibe no console do navegador a mensagem 'Os states foram resetados!'
    console.log('Os states foram resetados!')
  }

  render() {
    return (
      <div>
        <main>
          <section>
            {/* lista de gêneros */}
            <h2>Lista de gêneros</h2>
            <table>
              <thead>
                <tr>
                  <th>#</th>
                  <th>Título do gênero</th>
                  <th>Ações</th>
                </tr>
              </thead>

              <tbody>
                {
                  this.state.listaGeneros.map((genero) => {
                    return (
                      <tr key={genero.idGenero}>
                        <td>{genero.idGenero}</td>
                        <td>{genero.nome}</td>

                        {/* Faz a chamada da função buscarGeneroPorId passando o Gênero selecionado */}
                        <td><button onClick={() => this.buscarGeneroPorId(genero)}>Editar</button></td>
                        <td><button onClick={() => this.excluirGenero(genero)}>Excluir</button></td>
                      </tr>
                    )
                  })
                }
              </tbody>
            </table>
          </section>

          <section>
            {/* Cadastro de gêneros */}
            <h2>Cadastro de Gêneros</h2>

            {/* Formulário de cadastro de gêneros */}
            <form onSubmit={this.cadastrarGenero}>
              <div>
                <input
                  type="text"
                  value={this.state.titulo}
                  onChange={this.atualizaEstadoTitulo}
                  placeholder="Título do Gênero" />

                {/* <button type="submit">Cadastrar</button> */}

                {/* Estrutura do IF Ternário */}
                {/* condição ? faça algo, caso seja verdadeiro : faça algo, caso seja falso */}
                {/* Altera o botão de acordo com a operação ( edição ou cadastro ) usando IF Ternário */}

                {/* {
                  this.state.idGeneroAlterado === 0 ?
                    <button type="submit">Cadastrar</button> :
                    <button type="submit">Atualizar</button>
                } */}

                {/* Uma outra forma, com IF Ternário e disabled ao mesmo tempo */}
                {
                  <button type="submit" disabled={this.state.titulo === '' ? 'none' : ''}>
                    {
                      this.state.idGeneroAlterado === 0 ?
                        'Cadastrar' : 'Atualizar'
                    }
                  </button>
                }

                <button type="button" onClick={this.limparCampos}>Cancelar</button>
              </div>
            </form>

            {/* Caso algum gênero tenha sido selecionado para edição, exibe a mensagem de feedback ao usuário */}
            {
              this.state.idGeneroAlterado !== 0 &&
              <div>
                <p>O gênero {this.state.idGeneroAlterado} está sendo editado!</p>
                <p>Clique em Cancelar caso queira cancelar a operação de editar um novo gênero.</p>
              </div>
            }
          </section>
        </main>
      </div>
    )
  }
}

export default Generos;