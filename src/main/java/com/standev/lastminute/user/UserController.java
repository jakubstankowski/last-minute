package com.standev.lastminute.user;

import com.standev.lastminute.holidayOffer.HolidayOffer;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.Arrays;


@RestController
@RequestMapping(value = "/api/users")
public class UserController {

    @Autowired
    private UserService userService;


    @GetMapping()
    public Iterable<User> getAllUsers() {
        return userService.getAllUsers();
    }

    @RequestMapping(method = RequestMethod.POST)
    public String createUser(@RequestBody User user) {

        HolidayOffer holidayOffer = new HolidayOffer();
        holidayOffer.setUrl("itaka.pl/last-minute");
        holidayOffer.setMinPrice(900);
        holidayOffer.setMaxPrice(1200);

        ArrayList<HolidayOffer> newHolidayOffer = new ArrayList<>(Arrays.asList(holidayOffer));
        user.setHolidayOffer(newHolidayOffer);

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
    }


}