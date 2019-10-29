package com.standev.lastminute;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@SpringBootApplication
@RestController
public class LastminuteApplication {

	public static void main(String[] args) {
		SpringApplication.run(LastminuteApplication.class, args);
	}
	@RequestMapping("/")
	public String index() {
		return "Last Minute Spring Boot!";
	}

}
