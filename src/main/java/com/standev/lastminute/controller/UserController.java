package com.standev.lastminute.controller;
import com.standev.lastminute.model.User;
import com.standev.lastminute.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class UserController {

    @Autowired
    private UserService userService;


    @RequestMapping(method = RequestMethod.GET, value = "/users")
    public List<User> getAllUsers() {
       return userService.getAllUsers();
    }

    @RequestMapping(method = RequestMethod.GET, value = "/user/{id}")
    public User getUser(@PathVariable String id){
        return userService.getUser(id);
    }

    @RequestMapping(method = RequestMethod.POST, value = "/users")
    public void  addUser(@RequestBody User user){
        userService.addUser(user);
    }

    @RequestMapping(method = RequestMethod.PUT, value="/user/{id}")
    public void updateUser(@RequestBody User user, @PathVariable String id){
        userService.updateUser(id, user);
    }

    @RequestMapping(method = RequestMethod.DELETE, value="/user/{id}")
    public void updateUser(@PathVariable String id){
        userService.deleteUser(id);
    }


}
