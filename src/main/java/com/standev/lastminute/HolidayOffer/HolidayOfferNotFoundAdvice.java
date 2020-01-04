package com.standev.lastminute.HolidayOffer;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.ResponseStatus;

@ControllerAdvice
class HolidayOfferNotFoundAdvice {

    @ResponseBody
    @ExceptionHandler(HolidayOfferNotFoundException.class)
    @ResponseStatus(HttpStatus.NOT_FOUND)
    String employeeNotFoundHandler(HolidayOfferNotFoundException ex) {
        return ex.getMessage();
    }
}