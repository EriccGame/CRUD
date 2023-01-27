package com.devsrcoppel.crud.response;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

import java.util.HashMap;
import java.util.Map;

public class ResponseHandler {
    public static ResponseEntity<Object> generateResponse(HttpStatus status, String messageError) {

        Map<String, Object> mapStatus = new HashMap<String, Object>();
        mapStatus.put("Status", "FAILURE");

        Map<String, String> mapMessage = new HashMap<String, String>();
        mapMessage.put("Mensaje", messageError);

        Map<String, Object> map = new HashMap<String, Object>();
        map.put("Meta", mapStatus);
        map.put("Data", mapMessage);

        return new ResponseEntity<Object>(map, status);
    }

    public static ResponseEntity<Object> generateResponse(HttpStatus status, String messageID, Object responseObj) {
        Map<String, Object> mapStatus = new HashMap<String, Object>();
        Map<String, Object> map = new HashMap<String, Object>();

        mapStatus.put("Status", status.name());
        map.put("Meta", mapStatus);

        if (messageID.isEmpty()) {
            map.put("Data", responseObj);
        } else {
            Map<String, Object> mapMensajeID = new HashMap<String, Object>();
            mapMensajeID.put("IDMensaje", messageID);

            Map<String, Object> mapMensaje = new HashMap<String, Object>();
            mapMensaje.put("Mensaje", mapMensajeID);

            map.put("Data", mapMensaje);
        }

        return new ResponseEntity<Object>(map, status);
    }
}