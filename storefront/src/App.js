import React, { Component } from 'react'; 
import './App.css'; 
import Board from './Board'; 
import Form from './Form'; 

class App extends Component { 
  render() { 
    return ( 
    	<div>
    	  {/* <Form /> */}
        <Board />
      </div>
      ); 
  } 
} 

export default App; 