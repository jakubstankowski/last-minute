import * as React from "react";
import axios from 'axios';
import HolidayPreferenceItem from "./HolidayPreferenceItem";

class HolidayPreferences extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            holidayPreferences: []
        };
    }

    componentDidMount() {
        axios
            .get('https://my-json-server.typicode.com/jakubstankowski/last-minute/holidayPreferences')
            .then((res) => this.setHolidayPreferences(res.data))
            .catch((error) => console.error('error:', error));
    }

    setHolidayPreferences(data) {
        this.setState({
            holidayPreferences: data
        })
    }

    render() {
        return (
            <div>
                <h3 className="text-center">
                    Holiday Preferences ({this.state.holidayPreferences.length}/4)
                </h3>
                <div className="grid-4">
                    {
                        this.state.holidayPreferences.map((preference) =>
                            <HolidayPreferenceItem key={preference.id} holidayPreference={preference}/>
                        )
                    }
                </div>
            </div>
        )
    }

}

export default HolidayPreferences;
