import React from 'react';
import './App.css';
import Header from "./components/layout/Header";
import HolidayOffers from "./components/holiday-offers/HolidayOffers";
import HolidayPreferences from "./components/holiday-preferences/HolidayPreferences";

function App() {
    return (
        <div className="App">
            <Header/>
            <React.Fragment>
                <div className="container">
                    <HolidayPreferences/>
                    <HolidayOffers/>
                </div>
            </React.Fragment>
        </div>
    );
}


export default App;
