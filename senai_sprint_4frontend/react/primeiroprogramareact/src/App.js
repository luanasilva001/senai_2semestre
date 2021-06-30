import React from 'react';
import './App.css';

//Define uma função DataFormatada que será chamada na renderização dentro do App
function DataFormatada(props){
  return <h2>Horário Atual: {props.date.toLocaleTimeString()}</h2>
}

//Define a classe Clock que será chamada na renderização dentro do App
class Clock extends React.Component{
  constructor(props){
    super(props);
    this.state = {
      //Define o estado date pegando a data/hora atual
      date : new Date()
    };
  }

  //Ciclo de vida que ocorre quando o Clock é inserido na DOM
  //Através da setInterval, o relógio é criado (com um timerID atrelado)
  //Chama a função thick() a cada 1000ms (1s)
  componentDidMount(){
    this.timerID = setInterval (() => {
      this.thick()
    }, 1000);
}

  //Ciclo de vida que ocorre quando o Clock é removido da DOM
  //Quando isso ocorre, a função clearInterval limpa o relógio criado pelo setInterval
  componentWillUnmount(){
    clearInterval(this.timerID);
  }

  //Define no state date a data atual a cada vez que é chamada
  thick(){
    this.setState({
      date : new Date() // = DateTime.Now
    });
  }

  //Pausa do relógio e "matando" o ID do primeiro que foi criado
  pause() {    
    clearInterval(this.timerID)
    console.log(`Relógio ${this.timerID} pausado!`)
  }

  //Retomada do relógio e criando um novo para substituir o anterior
  retomar(){
    this.timerID = setInterval (() => {
      this.thick()
    }, 1000);
    console.log(`Relógio ${this.timerID} retomado!`)
}
  //Renderiza na tela o título
  render(){
    return(
      <div>
        {/*Faz a chamada de dois relógios para mostrar a independência deles */}
        <h1>Relógio</h1>
        <DataFormatada date = {this.state.date}/>
        <button style={{margin : "20px", backgroundColor : "red", color: "white", height : "25px", fontWeight: "600"}} onClick={() => this.pause()}>Pausar {this.timerID}</button>
        <button style={{backgroundColor : "green", color : "white", height : "25px", fontWeight: "600"}} onClick={() => this.retomar()}>Retomar {this.timerID}</button>
      </div>
    );
  } 
}

//Função principal invocada no Index.js
function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Clock />
        <Clock />
      </header>
    </div>
  );
}

//Declara que a função App pode ser usada fora do escopo dela mesma
export default App;
