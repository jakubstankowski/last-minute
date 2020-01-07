package com.standev.lastminute.holidaypreferences.web;



import com.standev.lastminute.holidaypreferences.service.HolidayPreferencesService;
import com.standev.lastminute.holidaypreferences.jpa.HolidayPreferences;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping(value = "/api/users")
public class HolidayPreferencesController {


    @Autowired
    private HolidayPreferencesService holidayPreferencesService;


    @PostMapping("/{userId}/holiday-preferences")
    public HolidayPreferences createHolidayPreferences(@RequestBody HolidayPreferences holidayPreferences, @PathVariable("userId") Integer userId) {
        return holidayPreferencesService.createUserHolidayPreferences(holidayPreferences, userId);

    }

    @GetMapping("/{userId}/holiday-preferences")
    public Iterable<HolidayPreferences> getHolidayPreferencesByUser(@PathVariable(value = "userId") Integer userId) {
        return holidayPreferencesService.getHolidayPreferencesByUserId(userId);

    }

   /* @GetMapping()
    public Iterable<User> getAllUsers() {
        return userService.getAllUsers();
    }*/

   /* @GetMapping("/{id}")
    public User getUser(@PathVariable("id") Integer id)  {
        return userService.getUser(id);
    }
*/
  /*  @PostMapping()
    public User createUser(@RequestBody User user) {
        return userService.createUser(user);
    }*/

    /*@DeleteMapping("/{id}")
    public void deleteUser(@PathVariable("id") Integer id)  {
        userService.deleteUser(id);
    }

    @PutMapping("/{id}")
    public User updateUser(@RequestBody User newUser, @PathVariable("id") Integer id) {
        return userService.updateUser(id, newUser);
    }
    */
}
