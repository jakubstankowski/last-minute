package com.standev.lastminute;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.data.jpa.repository.config.EnableJpaAuditing;

@SpringBootApplication
@EnableJpaAuditing
public class LastminuteApplication  {

	public static void main(String[] args) {
		SpringApplication.run(LastminuteApplication.class, args);
	}

}
