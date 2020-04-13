import * as React from "react";
import HolidayOfferItem from "./HolidayOfferItem";
import axios from 'axios';

class HolidayOffers extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            holidayOffers: []
        };
    }

    componentDidMount() {
        axios
            .get('https://my-json-server.typicode.com/jakubstankowski/last-minute/holidayOffers')
            .then((res) => this.setHolidayOffers(res.data))
            .catch((error) => console.error('error:', error));
    }

    setHolidayOffers(data) {
        this.setState({
            holidayOffers: data
        })
    }


    render() {
        return (
            <div>
                <h3 className="text-center">
                    Holiday Offers ({this.state.holidayOffers.length})
                </h3>
                <div className="grid-3">
                    {
                        this.state.holidayOffers.map((offer) =>
                            <HolidayOfferItem key={offer.id} holidayOffer={offer}/>
                        )
                    }
                </div>
            </div>
        )

    }

}

export default HolidayOffers;
