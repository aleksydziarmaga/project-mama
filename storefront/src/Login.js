import React from 'react'; 
import classNames from 'classnames'
import api from './utils/api'

import './styles/index.css'; 
import Background from './background.png';
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
      show: true,
      name: '',
      email: '',
      password: '',
    };
    this.add = this.add.bind(this);
    this.remove = this.remove.bind(this);
    this.handleNameChange = this.handleNameChange.bind(this);
    this.handlePasswordChange = this.handlePasswordChange.bind(this);
    this.handleEmailChange = this.handleEmailChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);

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

handleNameChange (e) {
  this.setState({ name: e.target.value });
}
handleEmailChange (e) {
  this.setState({ email: e.target.value });
}
handlePasswordChange (e) {
  this.setState({ password: e.target.value });
}
handleSubmit (event) {
  event.preventDefault();

  const user = {
    name: this.state.name,
    email: this.state.email,
    password: this.state.password
};

api.addUser(user)
  .then(res => console.log(res))
  .catch(e => console.error(e));
};

render(){ 


return(
<div>
  <form onSubmit={this.handleSubmit} className="form-size">
    <div className="form-group form-group--abs">
      <div className="rel">
        <input name="name" type="text" onChange={this.handleNameChange} required/>
        <label>imię</label>
      </div>
    </div>
    <div className="form-group form-group--abs">
      <div className="rel">
        <input type="password" name="password" onChange={this.handlePasswordChange} required/>
        <label>hasło</label>
      </div>
    </div>
    <div className={classNames("form-group form-group--abs", {"input-add":this.state.show})}>
      <div className="rel">
        <input type="email" name="email" onChange={this.handleEmailChange} required/>
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