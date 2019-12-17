/*

package com.standev.lastminute.holidayOffer;

import com.standev.lastminute.user.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;


@Service
public class HolidayOfferService {

    @Autowired
    private HolidayOfferDao holidayOfferDao;

    public Iterable<HolidayOffer> getAllHolidayOffers(Integer userId) {
        System.out.println("GET ALL HOLIDAY OFFERS!@##!@ userrr id:: "+userId);
        return holidayOfferDao.findByUserId(userId);
    }

    public HolidayOffer getHolidayOffer(Integer id){
        return holidayOfferDao.findById(id).orElse(null);
    }

    public void deleteHolidayOffer(Integer id) {
        holidayOfferDao.deleteById(id);
    }


    public void createHolidayOffer(HolidayOffer offer) {

        System.out.println("before saving!@!@#@!# "+offer.getId());
        holidayOfferDao.save(offer);
        System.out.println("FIND BY USER ID:  "+holidayOfferDao.findByUserId(2));


    }

    public void updateHolidayOffer(Integer id, HolidayOffer newOffer) {
        holidayOfferDao.save(newOffer);
    }


}

*/
