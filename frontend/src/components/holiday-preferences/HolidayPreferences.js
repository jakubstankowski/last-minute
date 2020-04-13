import * as React from "react";
import axios from 'axios';
import HolidayPreferenceItem from "./HolidayPreferenceItem";
import CreateHolidayPreferences from "./CreateHolidayPreferences";

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

    /*addHolidayPreferences preference =>  {
        console.log(preference);
        const newPreference = {
            id: 5,
            ...preference
        };

        console.log('prefe', this.state.holidayPreferences);
       /!* this.setState({
            holidayPreferences: [...this.state.holidayPreferences, newPreference]
        });*!/


        /!* axios
             .post('https://my-json-server.typicode.com/jakubstankowski/last-minute/holidayPreferences', preference)
             .then((res) => console.log(res))
             .catch(error => console.error('error', error));*!/
    }
*/

    addHolidayPreferences = preference => {
       /* console.log(preference);
        const newPreference = {
            id: 5,
            ...preference
        };*/

        console.log('prefe', this.state.holidayPreferences);
        axios
            .post('https://my-json-server.typicode.com/jakubstankowski/last-minute/holidayPreferences', preference)
            .then((res) => console.log(res.data))
            .catch(error => console.error('error', error));

       /* this.setState({
            holidayPreferences: [...this.state.holidayPreferences, newPreference]
        });*/
    };

    render() {
        return (
            <div>
                <CreateHolidayPreferences
                    addHolidayPreferences={this.addHolidayPreferences}
                    holidayPreferencesLength={this.state.holidayPreferences.length}/>
                <h3 className="text-center">
                    Holiday Preferences ({this.state.holidayPreferences.length}/4)
                </h3>
                <div className="grid-4">
                    {
                        this.state.holidayPreferences.map((preference) =>
                            <HolidayPreferenceItem
                                key={preference.id}
                                holidayPreference={preference}/>
                        )
                    }
                </div>
            </div>
        )
    }

}

export default HolidayPreferences;
