package com.devsrcoppel.crud.controllers;

import com.devsrcoppel.crud.interfaces.IEmpleadoDAO;
import com.devsrcoppel.crud.interfaces.ILogCrudDAO;
import com.devsrcoppel.crud.models.Empleado;
import com.devsrcoppel.crud.models.LogCrud;
import com.devsrcoppel.crud.models.Puesto;
import com.devsrcoppel.crud.response.ResponseHandler;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@CrossOrigin(origins = "http://localhost:8081")
@RestController
@RequestMapping("/api")
public class LogCrudController {
    private static final Logger LOGGER = LoggerFactory.getLogger(LoginController.class);
    @Autowired
    ILogCrudDAO iLogCrudDAO;

    public LogCrudController() {
    }

    @PostMapping("/log")
    public ResponseEntity<Object> guardarLogCrud(@RequestBody LogCrud logCrud) {
        try {
            iLogCrudDAO.guardar(logCrud);

            LOGGER.info("Se creo registro en el log.");
            return ResponseHandler.generateResponse(HttpStatus.OK, "", logCrud);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al registrar en el log.");
        }
    }

    @GetMapping("/log")
    public ResponseEntity<Object> obtenerLogCrud() {
        try {
            List<LogCrud> logCruds = new ArrayList<LogCrud>();

            iLogCrudDAO.obtenerTodos().forEach(logCruds::add);

            if (logCruds.isEmpty()) {
                LOGGER.info("Se no se encontro información de log.");
                return ResponseHandler.generateResponse(HttpStatus.NO_CONTENT, "No se encontraron puestos.", null);
            }

            LOGGER.info("Se obtuvo información de log.");
            return ResponseHandler.generateResponse(HttpStatus.OK, "", logCruds);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al obtener información de log.");
        }
    }
}
