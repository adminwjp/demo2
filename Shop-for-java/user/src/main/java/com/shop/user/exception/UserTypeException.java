package com.shop.user.exception;

public class UserTypeException extends Exception {
    public UserTypeException(){
        super();
    }
    public UserTypeException(String message){
        super(message);
    }
    public UserTypeException(String message, Throwable cause){
        super(message, cause);
    }
    public UserTypeException(Throwable cause){
        super(cause);
    }
    public UserTypeException(String message, Throwable cause,
                             boolean enableSuppression,
                             boolean writableStackTrace){
        super(message, cause, enableSuppression, writableStackTrace);
    }
}
