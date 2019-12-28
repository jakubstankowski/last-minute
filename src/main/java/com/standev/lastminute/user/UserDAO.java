package com.standev.lastminute.user;

import com.standev.lastminute.user.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.CrudRepository;

public interface UserDAO extends JpaRepository<User, Integer> {

}
