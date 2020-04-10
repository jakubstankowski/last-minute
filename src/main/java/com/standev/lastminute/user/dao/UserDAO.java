package com.standev.lastminute.user.dao;

import com.standev.lastminute.user.jpa.User;
import org.springframework.data.jpa.repository.JpaRepository;

public interface UserDAO extends JpaRepository<User, Integer> {

}
