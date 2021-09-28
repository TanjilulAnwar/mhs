import React, { Component } from 'react';
import { variables } from '../Variables.js';
import Table from './Table.jsx';
const axios = require('axios');


export class IP extends Component {
	constructor(props) {
		super(props);
		this.state = {
			IPList: [],
			is_update: false,
			modal_open: false,
			form_inputs: {is_active: true}
		}
	}

	componentDidMount() {
		axios.get(variables.API_URL + 'ipinfo')
			.then(resp => resp.data.success && this.setState({ IPList: resp.data?.message }))
	}

	handleChange = (e)=>{
		const name = e.target.name
		this.setState({form_inputs: {...this.state.form_inputs, [e.target.name]: name==='is_active'?e.target.checked:e.target.value}})
	}

	setUpdateInfo(info) {
		this.setState({is_update: true, modal_open: true, form_inputs: {...info}})
	}

	handleSubmit = ()=>{
		axios.post(variables.API_URL + 'ipinfo/add', this.state.form_inputs)
			.then((resp)=>{
				if(resp.data.success) {
					let new_list = [...this.state.IPList]
					if(this.state.is_update){
						const index = new_list.findIndex(val => val.id === resp.data.message?.id)
						new_list[index] = resp.data?.message
					} else {new_list = [...new_list, resp.data?.message]}
					this.setState({IPList: new_list, modal_open: false})
				}
			})
	}

	render() {
		return (
			<div>
				<button type="button"
					className="btn btn-primary m-2 float-end"
					data-bs-toggle="modal"
					data-bs-target="#ipForm"
					onClick={()=>this.setState({is_update: false, modal_open: true})}
				>
					Add IP
				</button>

				<Table ip_list={this.state.IPList} setUpdateInfo={this.setUpdateInfo.bind(this)}/>

				<div className="modal fade" id="ipForm" tabIndex="-1" aria-hidden="true">
					<div className="modal-dialog modal-lg modal-dialog-centered">
						<div className="modal-content">
							<div className="modal-header">
								<h5 className="modal-title">IP Details</h5>
								<button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
							</div>

							<div className="modal-body">
								<div className="input-group mb-3">
									<span className="input-group-text">IP</span>
									<input type="text" className="form-control" name="name"
										value={this.state.form_inputs.name} onChange={this.handleChange} />
								</div>

								<div className="input-group mb-3">
									<span className="input-group-text">Description</span>
									<input type="text" className="form-control" name="description"
										value={this.state.form_inputs.description} onChange={this.handleChange} />
								</div>

								<div className="input-group mb-3">
									<span className="input-group-text">USER</span>
									<input type="text" className="form-control" name="user"
										value={this.state.form_inputs.user}
										onChange={this.handleChange} />
								</div>
								<div className="input-group mb-3">
									<span className="input-group-text">PASSWORD</span>
									<input type="password" className="form-control" name="password"
										value={this.state.form_inputs.password}
										onChange={this.handleChange} />
								</div>

								<div className="input-group mb-3">
									<div class="form-check form-switch">
										<label class="form-check-label" for="flexSwitchCheckChecked">Active</label>
										<input class="form-check-input" type="checkbox" id="flexSwitchCheckChecked"
											name="is_active"
											checked={this.state.form_inputs.is_active}
											onChange={this.handleChange}
										/>
									</div>
								</div>

								<button type="button"
									className="btn btn-primary float-start"
									onClick={() => this.handleSubmit()}
								>Create
								</button>
							</div>
						</div>
					</div>
				</div>
			</div>
		)
	}
}