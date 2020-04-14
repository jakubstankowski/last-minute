import * as React from "react";
import './HolidayOfferItem.css';
import PropTypes from "prop-types";
function HolidayOfferItem(props) {
    const {id, date, image, price, country} = props.holidayOffer;

    return (
        <div className="card">
            <img src={image}/>
            <div>
                <p className="text-light">
                  Country:  {country}
                </p>
                <p className="text-light">
                    Date: {date}
                </p>
                <p className="text-light">
                    Price: {price} $
                </p>
            </div>
        </div>
    )

}

HolidayOfferItem.propTypes = {
    holidayOffer: PropTypes.object.isRequired,
};



export default HolidayOfferItem;
