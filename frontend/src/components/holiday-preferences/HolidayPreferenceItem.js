import * as React from "react";
import {Link} from "react-router-dom";

function HolidayPreferenceItem(props) {
    const {id, minPrice, maxPrice, website, country} = props.holidayPreference;
    return (
        <div className="card">
            <ul>
                <li>
                    Minimum Price: {minPrice}
                </li>
                <li>
                    Maximum Price: {maxPrice}
                </li>
                <li>
                    Website: {website}
                </li>
                <li>
                    Country: {country}
                </li>
            </ul>
            <i className="material-icons text-primary mt-1"
               onClick={props.deleteHolidayPreference.bind(this, id)}>
                delete
            </i>
            <Link to={`/holiday-preference/edit/${id}`}>
                <i className="material-icons text-primary mt-1"
                   onClick={props.editHolidayPreference.bind(this, props.holidayPreference)}>
                    settings
                </i>
            </Link>
        </div>
    )

}


export default HolidayPreferenceItem;
