package com.standev.lastminute.service;

import com.standev.lastminute.entities.User;
import com.standev.lastminute.dao.UserDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Optional;


@Service
public class UserService {

    @Autowired
    private UserDao userDao;

    public Iterable<User> getAllUsers() {
        return userDao.findAll();
    }

    public User getUser(Integer id){
        return userDao.findById(id).orElse(null);
    }

    public void deleteUser(Integer id) {
        userDao.deleteById(id);
    }


    public User createUser(User user) {
        return userDao.save(user);
    }

    public void updateUser(Integer id, User newUser) {
        userDao.save(newUser);
    }


}
