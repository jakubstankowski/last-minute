package com.standev.lastminute.User;

import javassist.NotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.Map;


@RestController
@RequestMapping(value = "/api/users")
public class UserController {

    @Autowired
    private UserService userService;

    @GetMapping()
    public Iterable<User> getAllUsers() {
        return userService.getAllUsers();
    }

    @PostMapping()
    public ResponseEntity<User> createUser(@RequestBody User user) {
        userService.createUser(user);
        return ResponseEntity.ok(user);
    }

    @GetMapping("/user/{id}")
    public ResponseEntity<User> getUser(@PathVariable("id") Integer id) throws NotFoundException {
        User user = userService.getUser(id);
        return ResponseEntity.ok(user);
    }

    @DeleteMapping("/user/{id}")
    public ResponseEntity<User> deleteUser(@PathVariable("id") Integer id) throws NotFoundException {
        userService.deleteUser(id);
        return ResponseEntity.ok().build();
    }

    @PutMapping("/user/{id}")
    public ResponseEntity<User> updateUser(@RequestBody User user, @PathVariable("id") Integer id) throws NotFoundException{
        User updateUser = userService.updateUser(id, user);
        return ResponseEntity.ok(updateUser);
    }


}
