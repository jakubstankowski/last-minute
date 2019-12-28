package com.standev.lastminute.User;

import javassist.NotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;


@Service
public class UserService {

    @Autowired
    private UserDAO userDao;

    public Iterable<User> getAllUsers() {
        return userDao.findAll();
    }

    public User getUser(Integer id) throws NotFoundException {
        return userDao.findById(id)
                .orElseThrow(() -> new NotFoundException("User with id: " + id + " not found!"));
    }

    public void deleteUser(Integer id) throws NotFoundException {
        User user = userDao.findById(id)
                .orElseThrow(() -> new NotFoundException("User with id: " + id + " not found!"));

        userDao.delete(user);
    }


    public void createUser(User user) {
        userDao.save(user);
    }

    public User updateUser(Integer id, User newUser) throws NotFoundException {
        User user = userDao.findById(id)
                .orElseThrow(() -> new NotFoundException("User with id: " + id + " not found!"));

        user.setFirstName(newUser.getFirstName());
        user.setLastName(newUser.getLastName());
        user.setEmail(newUser.getEmail());

        return userDao.save(user);
    }


}
