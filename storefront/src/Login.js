import ReactDOM from 'react-dom'; 
import React from 'react'; 
import classNames from 'classnames'
import './styles/index.css'; 
import registerServiceWorker from './registerServiceWorker'; 


class Login extends React.Component 
{ 
  render()
  { 
    return 
    ( 
    <div>
      <Header />
      <Form />
    </div>
    ); 
  } 
} 



class Header extends React.Component 
{ 
  render() 
  { 
    return 
    ( 
    <p className="red">Zaloguj się</p>
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
    this.setState
    ({
    show:false
  });
}

remove() 
{
  this.setState
  ({
  show:true
});
}


render() 
{
  return
  (
  <div>
    <form id="form-size">
      <div className="form-group form-group--abs">
        <div className="rel">
          <input type="text" required/>
          <label>login</label>
        </div>
      </div>
      <div className="form-group form-group--abs">
        <div className="rel">
          <input type="password" required/>
          <label>hasło</label>
        </div>
      </div>
      <div className={classNames("form-group form-group--abs", {"input-add":this.state.show})}>
        <div className="rel">
          <input type="password" required/>
          <label>powtórz hasło</label>
        </div>
      </div>
      <div className={classNames("form-group  form-group--abs", {"input-add":this.state.show})}>
        <div className="rel">
          <input type="e-mail" required/>
          <label>e-mail</label>
        </div>
      </div>
      <div className="mt">
        <a className="btn btn-style" onClick={this.remove}>Zaloguj się</a>
        <a className="btn btn-style" onClick={this.add}>Zarejestruj się</a>
      </div>
    </form>
  </div>

  ); 
}
}



export default Login; 