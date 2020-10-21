const express = require('express');
const path = require('path');
const compression = require('compression');
const bodyParser = require("body-parser");
const cors = require('cors');
const axios = require('axios');


const PORT = 8080;
const HOST = '0.0.0.0';

const app = express();

app.use(compression());
app.use(cors());

app.get('/api/r', (req, res) => {
    const body = {
        "Konfiguracja": {"LiczbaPokoi": "1", "Wiek": ["1990-09-23", "1990-09-23"]},
        "Sortowanie": {
            "CzyPoDacie": false,
            "CzyPoCenie": true,
            "CzyPoOcenach": false,
            "CzyPoPolecanych": false,
            "CzyDesc": false
        },
        "CzyCenaZaWszystkich": false,
        "CzyGrupowac": true,
        "Promocje": ["last-minute"],
        "TypyTransportu": ["air", "bus"],
        "PokazywaneLotniska": "SAME",
        "Paginacja": {"Przeczytane": "0", "IloscDoPobrania": "18"},
        "CzyImprezaWeekendowa": false
    };

    let results = [];
    axios.post('https://rpl-api.r.pl/v3/wyszukiwarka/api/wyszukaj', body)
        .then((res) => {
            results = res.data;
        })

    setTimeout(() => {
        res.json(results);
    }, 1000);

});

app.get('/api/wakacje', (req, res) => {
    const body = [{
        "method": "search.tripsSearch", "params": {
            "brand": "WAK",
            "limit": 10,
            "priceHistory": 1,
            "imageSizes": ["570,428"],
            "flatArray": true,
            "multiSearch": true,
            "withHotelRate": 1,
            "withPromoOffer": 1,
            "recommendationVersion": "noTUI",
            "type": "tours",
            "firstMinuteTui": false,
            "countryId": ["37", "33", "99", "74", "65", "16"],
            "regionId": [],
            "cityId": [],
            "hotelId": [],
            "roundTripId": [],
            "cruiseId": [],
            "searchType": "lastminute",
            "offersAttributes": [],
            "alternative": {"countryId": [], "regionId": [], "cityId": []},
            "query": {
                "campTypes": [],
                "qsVersion": 0,
                "qsVersionLast": 0,
                "tab": false,
                "candy": false,
                "pok": null,
                "flush": false,
                "tourOpAndCode": null,
                "obj_code": null,
                "obj_type": null,
                "catalog": null,
                "roomType": null,
                "test": null,
                "year": null,
                "month": null,
                "rangeDate": null,
                "withoutLast": 0,
                "category": false,
                "not-attribute": false,
                "pageNumber": 1,
                "departureDate": "2020-10-20",
                "arrivalDate": "2022-05-01",
                "departure": null,
                "type": [1],
                "duration": {"min": 7, "max": 28},
                "minPrice": null,
                "maxPrice": null,
                "service": [],
                "firstminute": null,
                "attribute": [],
                "promotion": [],
                "tourId": null,
                "search": null,
                "minCategory": null,
                "maxCategory": 50,
                "sort": 13,
                "order": 1,
                "rank": null,
                "withoutTours": [],
                "withoutCountry": [],
                "withoutTrips": [],
                "rooms": [{"adult": 2, "kid": 0, "ages": [], "inf": null}],
                "offerCode": null
            }
        }
    }];

    let results = [];

    axios.post('https://www.wakacje.pl/v2/api/offers', body)
        .then((res) => {
            results = res.data;
        })
        .catch((e) => {
            console.log('error: ', e);
        })

    setTimeout(() => {
        res.json(results);
    }, 1000);
})


app.listen(PORT, HOST);
console.log(`Running on http://${HOST}:${PORT}`);
