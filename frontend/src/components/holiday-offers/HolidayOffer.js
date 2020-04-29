import * as React from "react";
import axios from 'axios';

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
                console.log('response:', response);
                this.setState({
                    holidayOffer: {
                        ...response.data
                    }
                });
                console.log('holiday offer', this.state.holidayOffer)
            })
            .catch((e) => {
                console.error('error', e);
            })
    }

    render() {
        return (
            <div className="grid card">
             <h3 className="text-center">
                 {this.state.holidayOffer.country}
                 <img className="mt-1" src={this.state.holidayOffer.image}/>
             </h3>
            </div>
        )

    }

}

export default HolidayOffer;
