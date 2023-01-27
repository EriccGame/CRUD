package com.devsrcoppel.crud.controllers;

import com.devsrcoppel.crud.models.Empleado;
import com.devsrcoppel.crud.interfaces.IEmpleadoDAO;
import com.devsrcoppel.crud.response.ResponseHandler;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.web.bind.annotation.*;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.ArrayList;
import java.util.List;

@CrossOrigin(origins = "http://localhost:8081")
@RestController
@RequestMapping("/api")
public class EmpleadoController {

    private static final Logger LOGGER = LoggerFactory.getLogger(EmpleadoController.class);
    @Autowired
    IEmpleadoDAO iEmpleadoDAO;

    public EmpleadoController() {
    }

    @PostMapping("/empleado")
    public ResponseEntity<Object> guardarEmpleado(@RequestBody Empleado empleado) {
        try {
            List<Empleado> empleados = new ArrayList<Empleado>();

            iEmpleadoDAO.obtenerPorId(empleado.getIdEmpleado()).forEach(empleados::add);

            if (!empleados.isEmpty()) {
                LOGGER.info("El empleado ya existe con el id: " + empleado.getIdEmpleado());
                return ResponseHandler.generateResponse(HttpStatus.FOUND, "El id del empleado ya existe.", empleado);
            }

            BCryptPasswordEncoder passwordEncoder = new BCryptPasswordEncoder();

            empleado.setContraseña(passwordEncoder.encode(empleado.getContraseña()));

            iEmpleadoDAO.guardar(empleado);

            LOGGER.info("Se creo empleado con el id: " + empleado.getIdEmpleado());
            return ResponseHandler.generateResponse(HttpStatus.OK, "", empleado);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al crear empleado.");
        }
    }

    @PutMapping("/empleado")
    public ResponseEntity<Object> actualizarEmpleado(@RequestBody Empleado empleado) {
        try {
            BCryptPasswordEncoder passwordEncoder = new BCryptPasswordEncoder();

            empleado.setContraseña(passwordEncoder.encode(empleado.getContraseña()));

            iEmpleadoDAO.actualizar(empleado);

            LOGGER.info("Se actualizo empleado con el id: " + empleado.getIdEmpleado());
            return ResponseHandler.generateResponse(HttpStatus.OK, "", empleado);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al actualizar empleado.");
        }
    }

    @DeleteMapping("/empleado/{idEmpleado}")
    public ResponseEntity<Object> eliminarEmpleado(@PathVariable("idEmpleado") String idEmpleado) {
        try {
            iEmpleadoDAO.eliminar(idEmpleado);

            LOGGER.info("Se elimino empleado con el id: " + idEmpleado);
            return ResponseHandler.generateResponse(HttpStatus.OK, "Se elimino empleado con el id: " + idEmpleado, idEmpleado);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al eliminar empleado.");
        }
    }

    @GetMapping("/empleado")
    public ResponseEntity<Object> obtenerEmpleado(@RequestBody(required = false) Empleado empleado) {
        try {
            List<Empleado> empleados = new ArrayList<Empleado>();

            if (empleado == null) {
                iEmpleadoDAO.obtenerTodos().forEach(empleados::add);
            }
            else if (empleado.getNombre() != null) {
                iEmpleadoDAO.obtenerPorNombre(empleado.getNombre()).forEach(empleados::add);
            }
            else {
                iEmpleadoDAO.obtenerPorId(empleado.getIdEmpleado()).forEach(empleados::add);
            }

            if (empleados.isEmpty()) {
                LOGGER.info("Se no se encontro información de empleado.");
                return ResponseHandler.generateResponse(HttpStatus.NO_CONTENT, "No se encontro empleado.", null);
            }

            LOGGER.info("Se obtuvo información de empleado.");
            return ResponseHandler.generateResponse(HttpStatus.OK, "", empleados);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al obtener información de empleado.");
        }
    }
}
