

package com.standev.lastminute.holidayOffer;


import com.standev.lastminute.user.UserDAO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping(value = "/api/users")
public class HolidayOfferController {


    @Autowired
    private HolidayOfferService holidayOfferService;
    @Autowired
    private HolidayOfferDAO holidayOfferDao;

    @Autowired
    private UserDAO userDao;

    @GetMapping("/{userId}/holiday-offers/{id}")
    public HolidayOffer getHolidayOffer(@PathVariable("id") Integer id) {
        return holidayOfferService.getHolidayOffer(id);
    }

    @PostMapping("/{userId}/holiday-offers")
    public String createHolidayOffer(@RequestBody HolidayOffer holidayOffer, @PathVariable("userId") Integer userId) {
        userDao.findById(userId).map(user ->{
            holidayOffer.setUser(user);
           return  holidayOfferDao.save(holidayOffer);
       });

        holidayOfferDao.save(holidayOffer);


        return "Success create new holiday offer!";
    }

}
