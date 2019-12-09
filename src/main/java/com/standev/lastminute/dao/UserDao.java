package com.standev.lastminute.dao;

import com.standev.lastminute.entities.User;
import org.springframework.data.repository.CrudRepository;

public interface UserDao extends CrudRepository<User, Integer> {

}
