import '../cadDesejos/cadDesejos.css';
import img from "../cadDesejos/imgs/image-removebg-preview.png"
import img2 from "../cadDesejos/imgs/Creative thinking-bro (1).png"
import { Route, Switch, Link } from 'react-router-dom';
import Home from '../home/home';
import desejos from '../desejos/desejos';
import { Component } from 'react';

class CadDesejos extends Component {
    constructor(props) {
        super(props);
        this.state = {
            descricao: '',
            idUsuario: 0
        }
    }

    salvarDescricao = async (event) => {
        await this.setState({ descricao: event.target.value })
        console.log(this.state.descricao)
    }

    salvarId = async (event) => {
        await this.setState({ idUsuario: event.target.value })
        console.log(this.state.idUsuario)
    }

    limparCampos = () => {
        this.setState({
            descricao: '',
            idUsuario: 1
        })

        console.log("Valores limpos com sucesso!")
    }

    cadastrarDesejo = (event) => {

        event.preventDefault();

        fetch('http://localhost:5000/api/listadesejo', {
            method: 'POST',

            body: JSON.stringify({ Descricaodesejo: this.state.descricao, IdUsuario: this.state.idUsuario }),

            headers: {
                "Content-Type": "application/json"
            }
        })

            .then(console.log('Desejo cadastrado!'))

            .catch(erro => console.log(erro))

        // .then(this.limparCampos)
    }

    render() {
        return (
            <div>
                <title>Cadastro de desejos</title>
                <meta charSet="utf-8" />
                <meta name="viewport" content="width=devide-width,initial-scale=1, shrink-to-fit=no" />


                <header>
                    <div className="menu-cad">
                        <div className="menu-voltar">
                            <div className="menu-imagem">
                                <img src={img} alt="Seta voltar" />
                            </div>
                            <Link className="menu-voltar-texto" to="/">Voltar</Link>
                        </div>

                        <div className="menu-listar">
                            <Link to="/listadesejos">Listar meus desejos</Link>
                        </div>
                    </div>

                    <Switch>
                        <Route exact path="/" component={Home} /> {/* Home */}
                        <Route path="/listadesejos" component={desejos} /> {/* Desejos */}
                    </Switch>
                </header>

                <div className="cadastro">
                    <div className="cadastro-formulario">
                        <p className="titulo-cadastro">Cadastro de desejos</p>
                        <form className="formulario" onSubmit={this.cadastrarDesejo}>
                            <input className="input-id"
                                type="number"
                                value={this.state.idUsuario}
                                onChange={this.salvarId}
                                placeholder="Digite o seu ID"
                            />
                            <input className="input-nome"
                                type="text"
                                value={this.state.descricao}
                                onChange={this.salvarDescricao}
                                placeholder="Escreva aqui o seu desejo"
                            />
                            <button className="botao" type="submit">Enviar</button>
                        </form>
                    </div>

                    <div className="menu-imagem-lado">
                        <img src={img2} alt="Personagem segurando lista na mão" />
                    </div>
                </div>
                <footer className="footer">
                    <p>SENAI INFORMÁTICA</p>
                </footer>
            </div>
        )
    }
}

export default CadDesejos;