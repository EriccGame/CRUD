package com.devsrcoppel.crud.controllers;

import com.devsrcoppel.crud.interfaces.IClienteDAO;
import com.devsrcoppel.crud.models.Cliente;
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
public class ClienteController {
    private static final Logger LOGGER = LoggerFactory.getLogger(ClienteController.class);
    @Autowired
    IClienteDAO iClienteDAO;

    public ClienteController() {
    }
    
    @PostMapping("/cliente")
    public ResponseEntity<Object> guardarCliente(@RequestBody Cliente cliente) {
        try {
            iClienteDAO.guardar(cliente);

            LOGGER.info("Se creo cliente con el id: " + cliente.getIdCliente());
            return ResponseHandler.generateResponse(HttpStatus.OK, "", cliente);
            //return ResponseHandler.generateResponse(HttpStatus.CREATED, "", cliente);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al crear cliente.");
        }
    }

    @PutMapping("/cliente")
    public ResponseEntity<Object> actualizarCliente(@RequestBody Cliente cliente) {
        try {
            iClienteDAO.actualizar(cliente);

            LOGGER.info("Se actualizo cliente con el id: " + cliente.getIdCliente());
            return ResponseHandler.generateResponse(HttpStatus.OK, "", cliente);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al actualizar cliente.");
        }
    }

    @DeleteMapping("/cliente/{idCliente}")
    public ResponseEntity<Object> eliminarCliente(@PathVariable("idCliente") String idCliente) {
        try {
            iClienteDAO.eliminar(idCliente);

            LOGGER.info("Se elimino cliente con el id: " + idCliente);
            return ResponseHandler.generateResponse(HttpStatus.OK, "Se elimino cliente con el id: " + idCliente, idCliente);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al eliminar cliente.");
        }
    }

    @GetMapping("/cliente")
    public ResponseEntity<Object> obtenerCliente(@RequestBody(required = false) Cliente cliente) {
        try {
            List<Cliente> clientes = new ArrayList<Cliente>();

            if (cliente == null) {
                iClienteDAO.obtenerTodos().forEach(clientes::add);
            }
            else if (cliente.getNombre() != null) {
                iClienteDAO.obtenerPorNombre(cliente.getNombre()).forEach(clientes::add);
            }
            else {
                iClienteDAO.obtenerPorId(cliente.getIdCliente()).forEach(clientes::add);
            }

            if (clientes.isEmpty()) {
                LOGGER.info("Se no se encontro información de cliente.");
                return ResponseHandler.generateResponse(HttpStatus.NO_CONTENT, "No se encontro cliente.", null);
            }

            LOGGER.info("Se obtuvo información de cliente.");
            return ResponseHandler.generateResponse(HttpStatus.OK, "", clientes);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al obtener información de cliente.");
        }
    }
}
