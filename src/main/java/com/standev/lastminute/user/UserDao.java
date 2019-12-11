package com.standev.lastminute.user;

import com.standev.lastminute.user.User;
import org.springframework.data.repository.CrudRepository;

public interface UserDao extends CrudRepository<User, Integer> {

}
