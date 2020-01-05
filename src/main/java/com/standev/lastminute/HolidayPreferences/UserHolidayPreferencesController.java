package com.standev.lastminute.HolidayPreferences;



import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping(value = "/api/users")
public class UserHolidayPreferencesController {


    @Autowired
    private UserHolidayPreferencesService userHolidayPreferencesService;


    @PostMapping("/{userId}/holiday-preferences")
    public UserHolidayPreferences createUserHolidayPreferences(@RequestBody UserHolidayPreferences userHolidayPreferences, @PathVariable("userId") Integer userId) {
        return userHolidayPreferencesService.createUserHolidayPreferences(userHolidayPreferences, userId);

    }

    @GetMapping("/{userId}/holiday-preferences")
    public Iterable<UserHolidayPreferences> getUserHolidayPreferencesByUser(@PathVariable(value = "userId") Integer userId) {
        return userHolidayPreferencesService.getUserHolidayPreferencesByUserId(userId);

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
