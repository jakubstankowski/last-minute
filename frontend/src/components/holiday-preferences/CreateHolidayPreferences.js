import * as React from "react";
import {Link} from "react-router-dom";


class CreateHolidayPreferences extends React.Component {

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


    handleChange(event) {
        this.setState({
            [event.target.name]: event.target.value
        });
    }

    handleSubmit(event) {
        event.preventDefault();
        if (this.props.holidayPreferencesLength < 4) {
             this.props.addHolidayPreferences(this.state);
         }
         this.setState({
             minPrice: '',
             maxPrice: '',
             website: '',
             country: ''
         });
        /*window.location = '/';*/
    }

    render() {
        return (
            <div className="text-center">
                <h3>
                    Create Holiday Preferences
                </h3>
                <form onSubmit={this.handleSubmit}>
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
                </form>
            </div>
        )
    }
}

export default CreateHolidayPreferences;
