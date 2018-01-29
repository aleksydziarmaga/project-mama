import React from 'react'; 
import classNames from 'classnames'

import './styles/index.css'; 
import Background from './background.png';
import axios from 'axios';
var sectionStyle = {
width: "100%",
minHeight: "100vh",
backgroundImage: `url(${Background})`
};



class Login extends React.Component 
{ 
  render()
  { 
    return( 
    <div>
      <section style={ sectionStyle } className="section">
        <div className="logo">
          <span className="red">M</span>
          <span className="grey">A</span>
          <span className="red">M</span>
          <span className="grey">A</span>
        </div>
        <div className="block">
          <Header />
          <Form />
        </div>
      </section>
    </div>

    ); 
  } 
} 

class Header extends React.Component 
{ 
  render() 
  { 
    return( 
    <div className="red">Zaloguj się</div>
    ); 
  } 
} 

class Form extends React.Component 
{ 
  constructor(props) 
  {
    super(props);
    this.state = 
    {
      show: true
    };
    this.add = this.add.bind(this);
    this.remove = this.remove.bind(this);
  }

  add() 
  {
    this.setState({
    show:false
  });
}

remove() 
{
  this.setState({
  show:true
});
}



state = {
  name: '',
  email: '',
  password: ''
}

handleChange = event => {
  this.setState({ name: event.target.value });
  this.setState({ email: event.target.value });
  this.setState({ password: event.target.value });
}

  handleSubmit = event => {
    event.preventDefault();

const user = {
  name: this.state.name,
  email: this.state.email,
  password: this.state.password
};

axios.post('http://localhost:56364/api/Registration', { user })
  .then(res => {
  console.log(res);
  console.log(res.data);
  })
};

render(){ 


return(
<div>
  <form onSubmit={this.handleSubmit} className="form-size">
    <div className="form-group form-group--abs">
      <div className="rel">
        <input name="name"   type="text" onChange={this.handleChange} required/>
        <label>imię</label>
      </div>
    </div>
    <div className="form-group form-group--abs">
      <div className="rel">
        <input type="text"   name="password" onChange={this.handleChange} required/>
        <label>hasło</label>
      </div>
    </div>
    <div className={classNames("form-group form-group--abs", {"input-add":this.state.show})}>
      <div className="rel">
        <input type="text" name="email" onChange={this.handleChange} required/>
        <label>e-mail</label>
      </div>
    </div>
    <div>
      <input type="submit" className="btn-style-prim" onClick={this.remove} value="Zaloguj się"/>
      <input type="submit" className="btn-style-sec"  onClick={this.add} value="Zarejetruj się"/>
    </div>
  </form>
</div>

); 
}
}



export default Login; 