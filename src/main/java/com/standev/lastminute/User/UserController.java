package com.standev.lastminute.User;
import javassist.NotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;


@RestController
@RequestMapping(value = "/api/users")
public class UserController {

    @Autowired
    private UserService userService;

    @GetMapping()
    public Iterable<User> getAllUsers() {
        return userService.getAllUsers();
    }

    @GetMapping("/{id}")
    public User getUser(@PathVariable("id") Integer id)  {
        return userService.getUser(id);
    }

    @PostMapping()
    public User createUser(@RequestBody User user) {
        return userService.createUser(user);
    }

    @DeleteMapping("/{id}")
    public void deleteUser(@PathVariable("id") Integer id)  {
        userService.deleteUser(id);
    }

    @PutMapping("/{id}")
    public User updateUser(@RequestBody User newUser, @PathVariable("id") Integer id) {
        return userService.updateUser(id, newUser);
    }


}
