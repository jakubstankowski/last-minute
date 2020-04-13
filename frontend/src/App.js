import React from 'react';
import './App.css';
import Header from "./components/layout/Header";
import HolidayOffers from "./components/holiday-offers/HolidayOffers";
import HolidayPreferences from "./components/holiday-preferences/HolidayPreferences";
import CreateHolidayPreferences from "./components/holiday-preferences/CreateHolidayPreferences";

function App() {
    return (
        <div className="App">
            <Header/>
            <React.Fragment>
                <div className="container">
                    <CreateHolidayPreferences/>
                    <HolidayPreferences/>
                    <HolidayOffers/>
                </div>
            </React.Fragment>
        </div>
    );
}


export default App;
