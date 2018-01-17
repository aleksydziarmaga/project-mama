import React from 'react'; 
import classNames from 'classnames'
import Option from 'muicss/lib/react/option';
import Select from 'muicss/lib/react/select';
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


render() 
{
  return(
  <div>
    <form className="form-size">
      <div className="form-group form-group--abs">
        <div className="rel">
          <input type="text" required/>
          <label>imię</label>
        </div>
      </div>
      <div className="form-group form-group--abs">
        <div className="rel">
          <input type="text" required/>
          <label>nazwisko</label>
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
      {/*
      <div className={classNames("form-group  form-group--abs form-group-mb", {"input-add":this.state.show})}>
        <label className="option-label" for="option">kategoria:</label>  
        <Select id="option" name="input" useDefault={true} defaultValue="option2">
          <Option value="option1" label="Option 1" />
          <Option value="option2" label="Option 2" />
          <Option value="option3" label="Option 3" />
          <Option value="option4" label="Option 4" />
        </Select>
      </div>
      */} 
      <div>
        <input type="submit" className="btn-style-prim" onClick={this.remove} value="Zaloguj się"/>
        <input type="submit" className="btn-style-sec" onClick={this.add} value="Zarejestruj się"/>
      </div>
    </form>
  </div>

  ); 
}
}



export default Login; 