import * as React from "react";

class CreateHolidayPreferences extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            value: ''

        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        this.setState({value: event.target.value});
    }

    handleSubmit(event) {
        alert('Podano następujące imię: ' + this.state.value);
        event.preventDefault();
    }


    render() {
        return (
            <div>
                <h3 className="text-center">
                    Create Holiday Preferences
                </h3>
                <div>
                    <form onSubmit={this.handleSubmit}>
                        <div className="grid-5">
                            <input
                                type="number"
                                placeholder="Min Price"
                                value={this.state.value}
                                onChange={this.handleChange}/>
                            <input
                                type="number"
                                placeholder="Max Price"
                                value={this.state.value}
                                onChange={this.handleChange}/>
                            <input
                                type="number"
                                placeholder="Max Price"
                                value={this.state.value}
                                onChange={this.handleChange}/>
                            <input
                                type="number"
                                placeholder="Max Price"
                                value={this.state.value}
                                onChange={this.handleChange}/>
                            <input type="submit" value="Wyślij"/>

                        </div>

                        {/*<input type="submit" value="Wyślij"/>
                        <label>
                            Imię:
                            <input type="text" value={this.state.value} onChange={this.handleChange}/>
                        </label>
                        <input type="submit" value="Wyślij"/>*/}
                    </form>
                </div>
            </div>
        )
    }
}

export default CreateHolidayPreferences;
