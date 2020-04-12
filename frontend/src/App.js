import React from 'react';
import './App.css';
import Header from "./components/layout/Header";
import HolidayOffers from "./components/holiday-offers/HolidayOffers";
import axios from 'axios';
import HolidayPreferences from "./components/holiday-preferences/HolidayPreferences";

class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            holidayOffers: []
        };
    }

    componentDidMount() {
        axios
            .get('https://my-json-server.typicode.com/jakubstankowski/last-minute/holidayOffers')
            .then(res => this.setState(
                {
                    holidayOffers: res.data
                }))
            .catch((error)=>{
                console.error(error);
            })
    }

    render() {
        return (
            <div className="App">
                <Header/>
                <React.Fragment>
                    <div className="container">
                        <h1 className="text-center">
                            Holiday Preferences
                        </h1>
                        <HolidayPreferences/>
                        <h1 className="text-center">
                            Holiday Offers
                        </h1>
                        <HolidayOffers holidayOffers={this.state.holidayOffers}/>
                    </div>
                </React.Fragment>
            </div>
        );
    }


}

export default App;
