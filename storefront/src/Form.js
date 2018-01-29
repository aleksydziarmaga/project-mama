import React, { Component } from 'react'; 
import './App.css'; 
import Option from 'muicss/lib/react/option';
import Select from 'muicss/lib/react/select';
import './styles/index.css'; 
import Background from './background.png';
import api from './utils/api'

var sectionStyle = {
	width: "100%",
	height: "100vh",
	backgroundImage: `url(${Background})`
};


class Form extends Component { 
	constructor(props) {
		super(props);
		this.state = {
			name: '',
			description: ''
		}

		this.handleSubmit = this.handleSubmit.bind(this);
		this.handleNameChange = this.handleNameChange.bind(this);
		this.handleDescChange = this.handleDescChange.bind(this);
		
	}

	handleSubmit(e) {
		e.preventDefault()

		const task = this.state;
		task.author_id = 2;
		api.addTask(task)
			.then(res => console.log(res))
			.catch(err => console.error(err));
	}
	handleNameChange(e) {
		this.setState({
			name: e.target.value
		})
	}
	handleDescChange(e) {
		this.setState({
			description: e.target.value
		})
	}
	render() { 
		return ( 
			<div>
				<section style={ sectionStyle }>
					<div className="logo">
						<span className="red">M</span>
						<span className="grey">A</span>
						<span className="red">M</span>
						<span className="grey">A</span>
					</div>
					<div className="form-task">
						<form onSubmit={this.handleSubmit}>
							<div className="form-group form-group--abs">
								<div className="rel">
									<input type="text" required onChange={this.handleNameChange}/>
									<label>Temat</label>
								</div>
							</div>
							<div className="form-group">
								<textarea onChange={this.handleDescChange} className="text-field" name="comment"></textarea>
							</div>
							{/*
							<div className="form-group  form-group--abs">
							<label className="option-label" for="option">Kategoria:</label>  
							<Select id="option" name="input" useDefault={true} defaultValue="option2">
								<Option value="option1" label="Option 1" />
								<Option value="option2" label="Option 2" />
								<Option value="option3" label="Option 3" />
								<Option value="option4" label="Option 4" />
							</Select>
							</div>
							*/}
							<input type="submit" className="btn-style-prim btn-pos"value="Wyślij"/>
						</form>
						</div>
					</section>
				</div>
			); 
		} 
} 

export default Form; 