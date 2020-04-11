import * as React from "react";
import HolidayOfferItem from "./HolidayOfferItem";
import PropTypes from 'prop-types';


class HolidayOffers extends React.Component {
    render() {
        return (
            <div className="grid-3">
                {
                    this.props.holidayOffers.map((offer) =>
                        <HolidayOfferItem key={offer.id} holidayOffer={offer}/>
                    )
                }
            </div>
        )
    }

}

HolidayOffers.propTypes = {
    holidayOffers: PropTypes.array.isRequired,
};


export default HolidayOffers;
