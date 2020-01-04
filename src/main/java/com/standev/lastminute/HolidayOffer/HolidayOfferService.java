
package com.standev.lastminute.HolidayOffer;

import com.standev.lastminute.User.User;
import com.standev.lastminute.User.UserDAO;
import com.standev.lastminute.User.UserNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;


@Service
public class HolidayOfferService {

    @Autowired
    private HolidayOfferDAO holidayOfferDao;
    @Autowired
    private UserDAO userDAO;


    public Iterable<HolidayOffer> getHolidayOffersByUserId(Integer userId) {
        return holidayOfferDao.findByUserId(userId);
    }

    public HolidayOffer getHolidayOffer(Integer id) {
        return holidayOfferDao
                .findById(id).orElseThrow(() -> new HolidayOfferNotFoundException(id));
    }

    public HolidayOffer createHolidayOffer(HolidayOffer holidayOffer, Integer userId) {
        User user = userDAO.findById(userId)
                .orElseThrow(() -> new UserNotFoundException(userId));

        holidayOffer.setUser(user);
        return holidayOfferDao.save(holidayOffer);
    }


    



}


