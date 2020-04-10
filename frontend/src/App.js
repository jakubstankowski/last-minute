import React from 'react';
import './App.css';
import Header from "./components/layout/Header";
import HolidayOffers from "./components/HolidayOffers";

class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            holidayOffers: [
                {
                    id: 1,
                    url: '123',
                    price: 1231234,
                    website: 'r.pl',
                    date: '01.01.2001'
                },
                {
                    id: 2,
                    url: 'second url',
                    price: 0,
                    website: 'r.pl',
                    date: '01.01.2001'
                }
            ]
        };
    }

    render() {
        return (
            <div className="App">
                <Header/>
                <React.Fragment>
                    <HolidayOffers holidayOffers={this.state.holidayOffers}/>
                </React.Fragment>
            </div>
        );
    }


}

export default App;
