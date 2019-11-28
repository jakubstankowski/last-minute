package com.standev.lastminute.controller;

import com.standev.lastminute.model.Offer;
import com.standev.lastminute.model.User;
import com.standev.lastminute.service.OfferService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class OfferController {

    @Autowired
    private OfferService offerService;


    @RequestMapping(method = RequestMethod.GET, value = "/offers")
    public List<Offer> getAllOffers() {
        return offerService.getAllOffers();
    }

    @RequestMapping(method = RequestMethod.GET, value = "/offer/{id}")
    public Offer getOffer(@PathVariable String id) {
        return offerService.getOffer(id);
    }

    @RequestMapping(method = RequestMethod.POST, value = "/offers")
    public void addOffer(@RequestBody Offer offer) {
        offerService.addOffer(offer);
    }

    @RequestMapping(method = RequestMethod.PUT, value = "/offer/{id}")
    public void updateOffer(@RequestBody Offer offer, @PathVariable String id) {
        offerService.updateOffer(id, offer);
    }

    @RequestMapping(method = RequestMethod.DELETE, value = "/offer/{id}")
    public void updateOffer(@PathVariable String id) {
        offerService.deleteOffer(id);
    }


}
