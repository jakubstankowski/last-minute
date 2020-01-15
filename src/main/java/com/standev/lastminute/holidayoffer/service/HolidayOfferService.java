package com.standev.lastminute.holidayoffer.service;

;
import com.standev.lastminute.holidayoffer.dao.HolidayOfferDAO;
import com.standev.lastminute.holidayoffer.jpa.HolidayOffer;
import com.standev.lastminute.holidaypreferences.dao.HolidayPreferencesDAO;
import com.standev.lastminute.holidaypreferences.jpa.HolidayPreferences;
import com.standev.lastminute.user.dao.UserDAO;
import com.standev.lastminute.user.jpa.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;


@Service
public class HolidayOfferService {


    @Autowired
    HolidayOfferDAO holidayOfferDAO;
    HolidayPreferencesDAO holidayPreferencesDAO;
    UserDAO userDAO;

    public HolidayOffer createHolidayOffer(HolidayOffer holidayOffer, Integer id, Integer userId) {
        User user = userDAO.findById(userId).orElse(null);
        HolidayPreferences holidayPreferences = holidayPreferencesDAO.findById(id).orElse(null);
        holidayPreferences.setUser(user);
        holidayOffer.setHolidayPreferences(holidayPreferences);
        return holidayOfferDAO.save(holidayOffer);
    }

}



