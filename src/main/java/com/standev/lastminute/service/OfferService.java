package com.standev.lastminute.service;

import com.standev.lastminute.model.Offer;
import com.standev.lastminute.model.User;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

@Service
public class OfferService {
    private List<Offer> offers = new ArrayList<>(Arrays.asList(
            new Offer("1", "www.itaka.pl", 1200, 900),
            new Offer("2", "www.rainbow.pl", 1500, 1000)
    ));


    public List<Offer> getAllOffers() {
        return offers;
    }

    public Offer getOffer(String id) {
        return offers.stream()
                .filter(u -> u.getId().equals(id))
                .findFirst()
                .get();
    }


    public void addOffer(Offer offer) {
        offers.add(offer);
    }

    public void updateOffer(String id, Offer offer) {
        for (int i = 0; i < offers.size(); i++) {
            Offer o = offers.get(i);
            if (o.getId().equals(id)) {
                offers.set(i, offer);
                return;
            }
        }
    }

    public void deleteOffer(String id) {
        for (int i = 0; i < offers.size(); i++) {
            Offer o = offers.get(i);
            if (o.getId().equals(id)) {
                offers.remove(o);
                return;
            }
        }

    }


}
