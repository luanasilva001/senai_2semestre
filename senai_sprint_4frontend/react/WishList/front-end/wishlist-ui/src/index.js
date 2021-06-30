import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import Home from './pages/home/home';
import { Route, BrowserRouter as Router, Switch } from 'react-router-dom';

import desejos from './pages/desejos/desejos';
import cadDesejos from './pages/cadDesejos/cadDesejos';
import reportWebVitals from './reportWebVitals';

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} /> {/* Home */}
        <Route path="/listadesejos" component={desejos} /> {/* Desejos */}
        <Route path="/caddesejos" component={cadDesejos} /> {/* Cadastrar
        {/* <Redirect to="/notFound" component={notFound} /> Redireciona para Not Found */}
      </Switch>
    </div>
  </Router>
)


ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();