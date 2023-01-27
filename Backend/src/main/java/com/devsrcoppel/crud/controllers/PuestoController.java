package com.devsrcoppel.crud.controllers;

import com.devsrcoppel.crud.interfaces.IClienteDAO;
import com.devsrcoppel.crud.interfaces.IPuestoDAO;
import com.devsrcoppel.crud.models.Cliente;
import com.devsrcoppel.crud.models.Puesto;
import com.devsrcoppel.crud.response.ResponseHandler;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@CrossOrigin(origins = "http://localhost:8081")
@RestController
@RequestMapping("/api")
public class PuestoController {
    private static final Logger LOGGER = LoggerFactory.getLogger(PuestoController.class);
    @Autowired
    IPuestoDAO iPuestoDAO;

    public PuestoController() {
    }

    @GetMapping("/puesto")
    public ResponseEntity<Object> obtenerPuestos() {
        try {
            List<Puesto> puestos = new ArrayList<Puesto>();

            iPuestoDAO.obtenerTodos().forEach(puestos::add);

            if (puestos.isEmpty()) {
                LOGGER.info("Se no se encontro información de puestos.");
                return ResponseHandler.generateResponse(HttpStatus.NO_CONTENT, "No se encontraron puestos.", null);
            }

            LOGGER.info("Se obtuvo información de puestos.");
            return ResponseHandler.generateResponse(HttpStatus.OK, "", puestos);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al obtener información de puestos.");
        }
    }
}
