import React from 'react';
import './App.css';
import Header from "./components/layout/Header";
import HolidayOffers from "./components/holiday-offers/HolidayOffers";
import HolidayPreferences from "./components/holiday-preferences/HolidayPreferences";
import {BrowserRouter as Router, Route, Link} from "react-router-dom";
import CreateHolidayPreferences from "./components/holiday-preferences/CreateHolidayPreferences";
import EditHolidayPreferences from "./components/holiday-preferences/EditHolidayPreferences";


function App() {
    return (
        <Router>
            <div className="App">
                <Header/>

                    <div className="container">
                        <Route path="/" exact component={HolidayPreferences}/>
                        <Route path="/" exact component={HolidayOffers}/>
                        <Route path="/holiday-preference/create" exact component={CreateHolidayPreferences}/>
                        <Route path="/holiday-preference/edit/:id" exact component={EditHolidayPreferences}/>
                    </div>

            </div>
        </Router>
    );
}


export default App;
