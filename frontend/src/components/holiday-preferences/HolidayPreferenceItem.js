import * as React from "react";

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
            <i className="material-icons text-primary mt-1"
               onClick={props.editHolidayPreference.bind(this, props.holidayPreference)}>
                settings
            </i>
        </div>
    )

}


export default HolidayPreferenceItem;
