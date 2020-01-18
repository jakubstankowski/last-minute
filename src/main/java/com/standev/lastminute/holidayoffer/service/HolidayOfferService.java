package com.standev.lastminute.holidayoffer.service;
import com.standev.lastminute.holidayoffer.dao.HolidayOfferDAO;
import com.standev.lastminute.holidayoffer.jpa.HolidayOffer;
import com.standev.lastminute.holidaypreferences.dao.HolidayPreferencesDAO;
import com.standev.lastminute.holidaypreferences.jpa.HolidayPreferences;
import com.standev.lastminute.user.dao.UserDAO;
import com.standev.lastminute.user.jpa.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Optional;


@Service
public class HolidayOfferService {


    @Autowired
    HolidayOfferDAO holidayOfferDAO;
    @Autowired
    HolidayPreferencesDAO holidayPreferencesDAO;
    @Autowired
    UserDAO userDAO;

    public HolidayOffer createHolidayOffer(HolidayOffer holidayOffer, Integer id, Integer userId) {
        HolidayPreferences holidayPreferences = holidayPreferencesDAO.findByIdAndUserId(id, userId).orElse(null);
        holidayOffer.setHolidayPreferences(holidayPreferences);
        return holidayOfferDAO.save(holidayOffer);
    }

}



