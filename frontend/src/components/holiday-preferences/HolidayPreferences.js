import * as React from "react";
import axios from 'axios';
import HolidayPreferenceItem from "./HolidayPreferenceItem";
import {v4 as uuidv4} from 'uuid';
import CreateHolidayPreferencesCard from "./CreateHolidayPreferencesCard";

class HolidayPreferences extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            holidayPreferences: [],
            edit: {
                status: false,
                holidayPreference: {}
            }
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

    addHolidayPreferences = preference => {
        axios
            .post('https://my-json-server.typicode.com/jakubstankowski/last-minute/holidayPreferences', preference)
            .then(res => {
                res.data.id = uuidv4();
                this.setState({
                    holidayPreferences: [...this.state.holidayPreferences, res.data]
                });
            })
            .catch(error => console.error('error', error));
    };

    deleteHolidayPreference = id => {
        let confirm = window.confirm("Do you want to delete this item");
        if (confirm) {
            axios.delete(`https://my-json-server.typicode.com/jakubstankowski/last-minute/holidayPreferences/${id}`)
                .then(res =>
                    this.setState({
                        holidayPreferences: [...this.state.holidayPreferences.filter(preference => preference.id !== id)]
                    })
                );
        }

    };

    editHolidayPreference = preference => {
        this.setState({
            editing: true
        });
        window.scroll(0, 0);
    };

    render() {
        return (
            <div>
                <h3 className="text-center">
                    Holiday Preferences ({this.state.holidayPreferences.length}/4)
                </h3>
                <div className="grid">
                    <CreateHolidayPreferencesCard/>
                    {
                        this.state.holidayPreferences.map((preference) =>
                            <HolidayPreferenceItem
                                editHolidayPreference={this.editHolidayPreference}
                                deleteHolidayPreference={this.deleteHolidayPreference}
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
