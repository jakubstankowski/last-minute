import * as React from "react";
import {Link} from "react-router-dom";


function CreateHolidayPreferencesCard() {
    return (
        <div className="card text-center">
            <Link to="/create-preferences">
                <p>
                    Add new preferences
                </p>
                <i className="material-icons md-48 text-center mt-1">
                    add
                </i>
            </Link>
        </div>
    )
}


export default CreateHolidayPreferencesCard;
