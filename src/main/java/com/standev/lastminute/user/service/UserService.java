package com.standev.lastminute.user.service;

import com.standev.lastminute.user.UserNotFoundException;
import com.standev.lastminute.user.dao.UserDAO;
import com.standev.lastminute.user.jpa.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;


@Service
public class UserService {

    @Autowired
    private UserDAO userDao;

    public Iterable<User> getAllUsers() {
        return userDao.findAll();
    }

    public User getUser(Integer id) {
        return userDao.findById(id)
                .orElseThrow(() -> new UserNotFoundException(id));
    }

    public void deleteUser(Integer id) {
        User user = userDao.findById(id)
                .orElseThrow(() -> new UserNotFoundException(id));

        userDao.delete(user);
    }


    public User createUser(User user) {
        return userDao.save(user);
    }

    public User updateUser(Integer id, User newUser) {
        User user = userDao.findById(id)
                .orElseThrow(() -> new UserNotFoundException(id));

        user.setFirstName(newUser.getFirstName());
        user.setLastName(newUser.getLastName());
        user.setEmail(newUser.getEmail());

        return userDao.save(user);
    }


}
