import { Component } from 'react';
import '../desejos/desejos.css';
import { Route, Switch, Link } from 'react-router-dom';
import Home from '../home/home';
import cadDesejos from '../cadDesejos/cadDesejos';
import img from "../cadDesejos/imgs/image-removebg-preview.png"
import img2 from "../desejos/imgs/Checklist-pana.png"

class Desejos extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaDesejos: []
        }
    }

    buscarDesejos = (event) => {
        console.log('A API tá lascada!')

        fetch('http://localhost:5000/api/listadesejo')

            .then(resposta => resposta.json())

            .then(dados => this.setState({ listaDesejos: dados }))
    }

    componentDidMount() {
        this.buscarDesejos();
    }

    render() {
        return (
            <div className="div-mae">
                <header>
                    <div className="menu-cad">
                        <div className="menu-voltar">
                            <div className="menu-imagem">
                                <img src={img} alt="Seta voltar" />
                            </div>

                            <a className="menu-voltar-texto" href="/caddesejos">Voltar</a>
                        </div>

                        <div className="menu-listar">
                            <Link to="/">HOME</Link>
                        </div>
                    </div>

                    <Switch>
                        <Route exact path="/" component={Home} />
                        <Route path="/caddesejos" component={cadDesejos} />
                    </Switch>
                </header>


                <main>
                    <h3 className="titulo">Lista de Desejos</h3>
                    <div className="todos-desejos">
                        <div className="desejos">
                            <table>
                                <thead>
                                    <tr>
                                        {/* <th>#</th>
                                    <th>IdUsuario</th> */}
                                        <th style={{ color: "#db944d", alignItems: "flex-end" }}>Descrição</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {
                                        this.state.listaDesejos.map((desejo) => {
                                            return (
                                                <tr key={desejo.idDesejo}>
                                                    {/* <td>{desejo.idDesejo}</td>
                                                <td>{desejo.idUsuario}</td> */}
                                                    <td>{desejo.descricaodesejo}</td>
                                                </tr>
                                            )
                                        })
                                    }
                                </tbody>
                            </table>
                        </div>
                        <div className="desejos-img">
                            <img src={img2} alt="Personagem segurando uma lista" />
                        </div>
                    </div>
                </main>
                <footer className="footer">
                    <p>SENAI INFORMÁTICA</p>
                </footer>
            </div>
        )
    }

    // render() {
    //     return (
    //         // <head>
    //         //     <title>Listar desejos</title>
    //         //     <meta charSet="utf-8" />
    //         //     <meta name="viewport" content="width=devide-width,initial-scale=1, shrink-to-fit=no" />
    //         // </head>

    //         <div className="tudo">
    //             <header>
    //                 <div className="menu-cad">
    //                     <div className="menu-voltar">
    //                         <div className="menu-imagem">
    //                             <img src={img} alt="Seta voltar" />
    //                         </div>

    //                         <a className="menu-voltar-texto" href="/caddesejos">Voltar</a>
    //                     </div>

    //                     <div className="menu-listar">
    //                         <Link to="/">HOME</Link>
    //                     </div>
    //                 </div>

    //                 <Switch>
    //                     <Route exact path="/" component={Home} />
    //                     <Route path="/caddesejos" component={cadDesejos} />
    //                 </Switch>
    //             </header>
    //             <main>

    //                 {/* listar desejos */}
    //                 <h2>Lista de desejos</h2>
    //                 <div className="todos-desejos">
    //                     <div className="desejos">
    //                         {
    //                             this.state.listaDesejos.map((desejo) => {
    //                                 return (
    //                                     <table>
    //                                         <thead>
    //                                             <tr>
    //                                                 <th>#</th>
    //                                                 <th>IdUsuario</th>
    //                                                 <th>Descrição</th>
    //                                             </tr>
    //                                         </thead>
    //                                         <tbody>
    //                                             {
    //                                                 this.state.listaDesejos.map((desejo) => {
    //                                                     return (
    //                                                         <tr key={desejo.idDesejo}>
    //                                                             <td>{desejo.idDesejo}</td>
    //                                                             <td>{desejo.idUsuario}</td>
    //                                                             <td>{desejo.descricaodesejo}</td>
    //                                                         </tr>
    //                                                     )
    //                                                 })
    //                                             }
    //                                         </tbody>
    //                                     </table>

    //                                 )
    //                             })
    //                         }
    //                         <form>
    //                             <div>
    //                                 <button type="submit" onClick={() => this.buscarDesejos()}>Enviar</button>
    //                             </div>
    //                         </form>
    //                     </div>
    //                     <div className="desejos-img">
    //                         <img src={img2} alt="Personagem segurando uma lista" />
    //                     </div>
    //                 </div>
    //             </main>
    //         </div>
    //     )
    // }
}

export default Desejos;