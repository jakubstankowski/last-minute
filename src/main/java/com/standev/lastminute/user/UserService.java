package com.standev.lastminute.user;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;


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


    public void createUser(User user) {
        userDao.save(user);
    }

    public void updateUser(Integer id, User newUser) {
        userDao.save(newUser);
    }


}
