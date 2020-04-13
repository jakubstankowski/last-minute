import * as React from "react";
function HolidayPreferenceItem(props) {
    const {id, minPrice, maxPrice, website, country} = props.holidayPreference;

    return (
        <div className="card">
            <ul>
                <li>
                    ID: {id}
                </li>
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
        </div>
    )

}



export default HolidayPreferenceItem;
