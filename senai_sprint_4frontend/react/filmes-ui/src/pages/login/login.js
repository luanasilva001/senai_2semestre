import React, { Component } from 'react';
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import axios from 'axios';

class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      senha: '',
      erroMensagem: '',
      isLoading: false
    }
  };

  //Função que faz a chamada para a API para realizar o login
  efetuaLogin = (event) => {
    console.log('logar')
    //Ignora o comportamento do navegador (recarregar a página, porr exemplo)
    event.preventDefault();

    //remove a frase de erro do state erroMensagem e define que a requisição está em andamento
    this.setState({ erroMensagem: '', isLoading: true })

    //Define a URL no corpo da requisição
    axios.post('http://localhost:5000/api/usuarios/login', {
      email: this.state.email,
      senha: this.state.senha
    })

      .then(console.log('estou logado'))

      //verifica o retorno da requisição
      .then(resposta => {
        //caso o status code seja 200,
        if (resposta.status === 200) {
          //salva o valor do token no localStorage
          localStorage.setItem('usuario-login', resposta.data.token)
          //exibe o valor no console do navegador
          // console.log('meu token é: ' + resposta.data.token)
          //e define que a requisição terminou
          this.setState({ isLoading: false })

          //define a variável base64 que vai receber o payload do token
          // let base64 = localStorage.getItem('usuario-login').split('.')[1];
          // //exibe no console o valor presente na variável base64
          // console.log(base64);
          // //exibe no console o valor decodificado de base64 para string
          // console.log(window.atob(base64));
          // //exibe no console o valor convertido da string para JSON apenas do tipo de usuário
          // console.log(JSON.parse(window.atob(base64)).role);

          //Exibe no console os dados do token convertido para objeto
          // console.log(parseJwt());
          // //exibe no console apenas o tipo de usuário logado
          // console.log(parseJwt());

          //verifica se o tipo de usuário logado é Administrador
          //se for, redireciona para a página Gêneros
          if (parseJwt().role === "1") {
            //Exibe no console do navegador um bool informando se o usuário está logado ou nao
            // console.log(usuarioAutenticado());
            this.props.history.push('/generos');
          } else {
            this.props.history.push('/');
          }
        }
      })

      //caso haja um erro,
      .catch(() => {
        //define o valor do state erroMensagem com uma mensagem personalizada e que a requisição terminou
        this.setState({ erroMensagem: 'E-mail ou senha inválidos! Tente novamente.', isLoading: false })
      })
  }

  //função genérica que atualiza o state de acordo com o input e pode ser reutilizada em vários inputs
  atualizaStateCampo = (campo) => {
    this.setState({ [campo.target.name]: campo.target.value })
  }

  render() {
    return (
      <div>
        <main>
          <section>
            <p>Bem vindo(a)! <br /> Faça login para acessar sua conta.</p>

            {/* Faz a chamaa para a função de login quando o botão é pressionado */}
            <form onSubmit={this.efetuaLogin}>
              <input
                //email
                type="text"
                name="email"
                //define que o input email recebe o valor do state email
                value={this.state.email}
                //faz a chamada para a função que atualiza o state, conforme o usuário altera o valor do input
                onChange={this.atualizaStateCampo}
                placeholder="username"
              />

              <input
                //senha
                type="password"
                name="senha"
                //define que o input senha recebe o valor do state email
                value={this.state.senha}
                //faz a chamada para a função que atualiza o state, conforme o usuário altera o valor do input
                onChange={this.atualizaStateCampo}
                placeholder="password"
              />

              {/* exibe a mensgaem de erro ao tentar logar com credenciais inválidas */}
              <p style={{ color: 'red' }}>{this.state.erroMensagem}</p>

              {/* verifica se a requisição está em andamento
               se estiver, desabilita o click do botão 
              */}

              {
                //caso o isLoading seja true, renderiza o botão desabilitado com o texto 'Loading...'
                this.state.isLoading === true &&
                <button type="submit" disabled>Loading...</button>
              }

              {
                //caso seja false, renderiza o botão habilitado com o texto 'Login'
                this.state.isLoading === false &&
                <button
                  type="submit"
                  disabled={this.state.email === '' || this.state.senha === '' ? 'none' : ''}
                >
                  Login
                </button>
              }


              {/* <button type="submit">
                Login
              </button> */}
            </form>
          </section>
        </main>
      </div>
    )
  }
};

export default Login;