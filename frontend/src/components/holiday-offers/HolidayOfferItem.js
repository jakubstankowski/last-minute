import * as React from "react";
import './HolidayOfferItem.css';
import PropTypes from "prop-types";
function HolidayOfferItem(props) {
    const {id, date, image, price, country} = props.holidayOffer;

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
                    Details ID: {id}
                </button>
            </div>
        </div>
    )

}

HolidayOfferItem.propTypes = {
    holidayOffer: PropTypes.object.isRequired,
};



export default HolidayOfferItem;
