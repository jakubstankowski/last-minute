const express = require('express')
const app = express()
const port = process.env.PORT || 3000
const cors = require('cors');
const axios = require('axios');

app.use(cors());

app.get('/', (req, res) => {
    res.send('Welcome to last minute javascript API!')
})


app.get('/api/offers/refresh/r', async (req, res) => {
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

    const offers = await axios.post('https://rpl-api.r.pl/v3/wyszukiwarka/api/wyszukaj', body);
    res.json(offers.data);
});

app.get('/api/offers/refresh/wakacje', async (req, res) => {
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

    const offers = await axios.post('https://www.wakacje.pl/v2/api/offers', body);
    res.json(offers.data);
})


app.listen(port, () => {
    console.log(`Example app listening at http://localhost:${port}`)
})
