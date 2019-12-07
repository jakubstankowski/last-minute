package com.standev.lastminute.repository;

import com.standev.lastminute.model.User;
import org.springframework.data.repository.CrudRepository;

public interface UserRepository  extends CrudRepository<User, String> {


}
