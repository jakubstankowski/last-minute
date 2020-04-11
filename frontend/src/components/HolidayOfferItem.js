import * as React from "react";
import './HolidayOfferItem.css';


class HolidayOfferItem extends React.Component {
    render() {
        const {url, date, website, image, price, country} = this.props.holidayOffer;
        return (
            <div className="card">
                <div className="image">
                    <img src={image}/>
                </div>
                <div className="country_and_price">
                    <p className="text-light">
                        {country}
                    </p>
                    <p className="text-light">
                        {date}
                    </p>
                    <p className="text-light">
                        {price} $
                    </p>
                </div>
                <div className="button text-center">
                    <button className="btn btn-primary btn-sm my-1">
                        Details
                    </button>
                </div>
            </div>
        )
    }

}

export default HolidayOfferItem;
