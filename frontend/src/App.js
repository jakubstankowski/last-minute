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
                    url: 'https://www.itaka.pl/wycieczki/chorwacja/slonce-i-lawenda,XHRHVAR.html?ofr_id=79c8ab41607f3fddaddcf3d43cbf03140d91af85c7f4673164515f652026b94c&adults=2&childs=0&currency=PLN',
                    price: 1099,
                    website: 'itaka.pl',
                    image:'https://i.content4travel.com/cms/img/u/desktop/seres/xhrhvar_0.jpg',
                    date: '10.10.2020',
                    country: 'Croatia'
                },
                {
                    id: 2,
                    url: 'https://www.itaka.pl/wycieczki/chorwacja/slonce-i-lawenda,XHRHVAR.html?ofr_id=79c8ab41607f3fddaddcf3d43cbf03140d91af85c7f4673164515f652026b94c&adults=2&childs=0&currency=PLN',
                    price: 1099,
                    website: 'itaka.pl',
                    image:'https://i.content4travel.com/cms/img/u/desktop/seres/xhrhvar_0.jpg',
                    date: '10.10.2020',
                    country: 'Croatia'
                },
                {
                    id: 3,
                    url: 'https://www.itaka.pl/wycieczki/chorwacja/slonce-i-lawenda,XHRHVAR.html?ofr_id=79c8ab41607f3fddaddcf3d43cbf03140d91af85c7f4673164515f652026b94c&adults=2&childs=0&currency=PLN',
                    price: 1099,
                    website: 'itaka.pl',
                    image:'https://i.content4travel.com/cms/img/u/desktop/seres/xhrhvar_0.jpg',
                    date: '10.10.2020',
                    country: 'Croatia'
                },
                {
                    id: 4,
                    url: 'https://www.itaka.pl/wycieczki/chorwacja/slonce-i-lawenda,XHRHVAR.html?ofr_id=79c8ab41607f3fddaddcf3d43cbf03140d91af85c7f4673164515f652026b94c&adults=2&childs=0&currency=PLN',
                    price: 1099,
                    website: 'itaka.pl',
                    image:'https://i.content4travel.com/cms/img/u/desktop/seres/xhrhvar_0.jpg',
                    date: '10.10.2020',
                    country: 'Croatia'
                },
                {
                    id: 5,
                    url: 'https://www.itaka.pl/wycieczki/chorwacja/slonce-i-lawenda,XHRHVAR.html?ofr_id=79c8ab41607f3fddaddcf3d43cbf03140d91af85c7f4673164515f652026b94c&adults=2&childs=0&currency=PLN',
                    price: 1099,
                    website: 'itaka.pl',
                    image:'https://i.content4travel.com/cms/img/u/desktop/seres/xhrhvar_0.jpg',
                    date: '10.10.2020',
                    country: 'Croatia'
                },
                {
                    id: 6,
                    url: 'https://www.itaka.pl/wycieczki/chorwacja/slonce-i-lawenda,XHRHVAR.html?ofr_id=79c8ab41607f3fddaddcf3d43cbf03140d91af85c7f4673164515f652026b94c&adults=2&childs=0&currency=PLN',
                    price: 1099,
                    website: 'itaka.pl',
                    image:'https://i.content4travel.com/cms/img/u/desktop/seres/xhrhvar_0.jpg',
                    date: '10.10.2020',
                    country: 'Croatia'
                },
            ]
        };
    }
    render() {
        return (
            <div className="App">
                <Header/>
                <React.Fragment>
                    <div className="container">
                        <HolidayOffers holidayOffers={this.state.holidayOffers}/>
                    </div>
                </React.Fragment>
            </div>
        );
    }


}

export default App;
