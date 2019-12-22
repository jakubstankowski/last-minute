

package com.standev.lastminute.holidayOffer;


import com.standev.lastminute.user.User;
import com.standev.lastminute.user.UserDao;
import com.standev.lastminute.user.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.Arrays;

@RestController
@RequestMapping(value = "/api/users")
public class HolidayOfferController {


    @Autowired
    private HolidayOfferService holidayOfferService;
    @Autowired
    private HolidayOfferDao holidayOfferDao;

    @Autowired
    private UserDao userDao;


  /*  @RequestMapping(method = RequestMethod.GET, value = "/{userId}/holiday-offers")
    public Iterable<HolidayOffer> getAllHolidayOffers(@PathVariable("userId") Integer userId) {
        return holidayOfferService.getAllHolidayOffers(userId);
    }*/

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


   /* @RequestMapping(method = RequestMethod.DELETE, value = "/{userId}/holiday-offers/{id}")
    public void deleteHolidayOffer(@PathVariable("id") Integer id) {
        holidayOfferService.deleteHolidayOffer(id);
    }*/

  /*  @RequestMapping(method = RequestMethod.POST, value = "/{userId}/holiday-offers")
    public String createHolidayOffer(@RequestBody HolidayOffer holidayOffer, @PathVariable("userId") Integer userId) {
        User user = new User(userId, "", "", "");
        holidayOffer.setUser(user);
        holidayOfferService.createHolidayOffer(holidayOffer);

        return "Success create new holiday offer!";
    }*/


/*   @RequestMapping(method = RequestMethod.POST)
    public String createUser(@RequestBody User user) {
        userService.createUser(user);
        return "Success create new user!";
    }

    @RequestMapping(method = RequestMethod.GET, value = "/user/{id}")
    public User getUser(@PathVariable("id") Integer id) {
        return userService.getUser(id);
    }

    @RequestMapping(method = RequestMethod.DELETE, value = "/user/{id}")
    public String deleteUser(@PathVariable("id") Integer id) {
        userService.deleteUser(id);
        return "Success delete user!";
    }

    @RequestMapping(method = RequestMethod.PUT, value = "/user/{id}")
    public String updateUser(@RequestBody User user, @PathVariable("id") Integer id) {
        userService.updateUser(id, user);
        return "Success update user!";
    }*//*



}
*/
