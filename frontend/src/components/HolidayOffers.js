import * as React from "react";

class HolidayOffers extends React.Component {
    render() {
        return (
            <div>
                {
                    this.props.holidayOffers.map((val) =>
                        <div key={val.id}>
                            <p>URL: {val.url} website: {val.website} date: {val.date}</p>
                        </div>
                    )
                }
            </div>
        )
    }

}

export default HolidayOffers;
