import * as React from "react";
import axios from 'axios';
import {Link} from "react-router-dom";

class EditHolidayPreferences extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            minPrice: '',
            maxPrice: '',
            website: '',
            country: ''
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    componentDidMount() {
        axios
            .get(`https://my-json-server.typicode.com/jakubstankowski/last-minute/holidayPreferences/${this.props.match.params.id}`)
            .then((response) => {
                this.setState({
                    minPrice: response.data.minPrice,
                    maxPrice: response.data.maxPrice,
                    website: response.data.website,
                    country: response.data.country
                })
            })
            .catch((e) => {
                console.error('error', e);
            })

    }

    handleChange(event) {
        this.setState({
            [event.target.name]: event.target.value
        });
    }

    handleSubmit(event) {
        event.preventDefault();
        axios
            .put(`https://my-json-server.typicode.com/jakubstankowski/last-minute/holidayPreferences/${this.props.match.params.id}`, this.state)
            .then((response) => {
                console.log('response', response);
               /* window.location = '/';*/
            })
            .catch((e) => {
                console.error('error', e);
            })
    }

    render() {
        return (
            <div className="text-center">
                <h3>
                    Edit Holiday Preferences
                </h3>
                <form onSubmit={this.handleSubmit}>
                    <div className="grid-5">
                        <input
                            name="minPrice"
                            type="number"
                            placeholder="Min Price"
                            value={this.state.minPrice}
                            onChange={this.handleChange}/>
                        <input
                            name="maxPrice"
                            type="number"
                            placeholder="Max Price"
                            value={this.state.maxPrice}
                            onChange={this.handleChange}/>
                        <input
                            name="website"
                            type="text"
                            placeholder="Website"
                            value={this.state.website}
                            onChange={this.handleChange}/>
                        <input
                            name="country"
                            type="text"
                            placeholder="Country"
                            value={this.state.country}
                            onChange={this.handleChange}/>
                        <Link to="/">
                            <input
                                type="submit"
                                value="Back"
                                className="btn btn-dark"/>
                        </Link>
                        <input
                            type="submit"
                            value="Save"
                            className="btn btn-primary"/>
                    </div>
                </form>
            </div>
        )
    }
}

export default EditHolidayPreferences;
