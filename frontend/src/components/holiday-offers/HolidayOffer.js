import * as React from "react";
import axios from 'axios';
import {Link} from "react-router-dom";

class HolidayOffer extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            holidayOffer: {}
        };
    }

    componentDidMount() {
        axios
            .get(`https://my-json-server.typicode.com/jakubstankowski/last-minute/holidayOffers/${this.props.match.params.id}`)
            .then((response) => {
                this.setState({
                    holidayOffer: {
                        ...response.data
                    }
                });
            })
            .catch((e) => {
                console.error('error', e);
            })
    }

    render() {
        return (
            <div className="card grid">
                <div>
                    <img alt="image" className="mt-1" src={this.state.holidayOffer.image}/>
                </div>
                <div className="text-center">
                    <h3>
                        {this.state.holidayOffer.country}
                    </h3>
                    <p>
                        Price: {this.state.holidayOffer.price} $
                    </p>
                    <p>
                        Date: {this.state.holidayOffer.date}
                    </p>
                    <p>
                        Website: {this.state.holidayOffer.website}
                    </p>
                    <Link to="/">
                        <a className="btn btn-dark mt-1">
                            Back
                        </a>
                    </Link>
                    <a target="_blank"
                       href={this.state.holidayOffer.url}
                       className="btn btn-primary mt-1">
                        Go to offer
                    </a>
                </div>
            </div>
        )

    }

}

export default HolidayOffer;
