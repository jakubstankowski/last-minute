import * as React from "react";

class HolidayOfferItem extends React.Component {
    render() {
        const { url, date, website } = this.props.holidayOffer;
        return (
            <div className="card">
                <ul>
                    <li>
                        URL: {url}
                    </li>
                    <li>
                        DATE: {date}
                    </li>
                    <li>
                        WEBSITE: {website}
                    </li>
                </ul>
            </div>
        )
    }

}

export default HolidayOfferItem;
