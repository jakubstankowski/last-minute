
package com.standev.lastminute.holidayOffer;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;


@Service
public class HolidayOfferService {

    @Autowired
    private HolidayOfferDAO holidayOfferDao;


    public HolidayOffer getHolidayOffer(Integer id){
        return holidayOfferDao.findById(id).orElse(null);
    }



    public void createHolidayOffer(HolidayOffer offer) {
        holidayOfferDao.save(offer);
    }

}


