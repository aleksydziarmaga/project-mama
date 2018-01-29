import React, { Component } from 'react'; 
import { BrowserRouter as Router, Route } from 'react-router-dom';
import './App.css'; 
import Board from './Board'; 
import Form from './Form'; 

class App extends Component { 
  render() { 
    return ( 
    	<Router>
        <div>
    	    <Route path='/tasks' component ={Form} />
          <Route path='/board' component={Board}/>
        </div>
      </Router>
      ); 
  } 
} 

export default App; 