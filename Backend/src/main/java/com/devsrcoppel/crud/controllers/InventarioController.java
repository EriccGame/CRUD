package com.devsrcoppel.crud.controllers;

import java.util.ArrayList;
import java.util.List;

import com.devsrcoppel.crud.models.Empleado;
import com.devsrcoppel.crud.models.Inventario;
import com.devsrcoppel.crud.interfaces.IInventarioDAO;
import com.devsrcoppel.crud.response.ResponseHandler;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@CrossOrigin(origins = "http://localhost:8081")
@RestController
@RequestMapping("/api")
public class InventarioController {
    private static final Logger LOGGER = LoggerFactory.getLogger(InventarioController.class);
    @Autowired
    IInventarioDAO inventarioDAO;

    public InventarioController(){

    }

    @PostMapping("/inventario")
    public ResponseEntity<Object> guardarInventario(@RequestBody Inventario inventario) {
        try {
            List<Inventario> inventarios = new ArrayList<Inventario>();

            inventarioDAO.obtenerPorSKU(inventario.getSKU()).forEach(inventarios::add);

            if (!inventarios.isEmpty()) {
                LOGGER.info("El articulo ya existe con el id: " + inventario.getSKU());
                return ResponseHandler.generateResponse(HttpStatus.FOUND, "El id del articulo ya existe.", inventario);
            }

            inventarioDAO.guardar(inventario);

            LOGGER.info("Se creo inventario con el sku: " + inventario.getSKU());
            return ResponseHandler.generateResponse(HttpStatus.OK, "", inventario);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al crear inventario.");
        }
    }

    @PutMapping("/inventario")
    public ResponseEntity<Object> actualizarInventario(@RequestBody Inventario inventario) {
        try {
            inventarioDAO.actualizar(inventario);

            LOGGER.info("Se actualizo inventario con el sku: " + inventario.getSKU());
            return ResponseHandler.generateResponse(HttpStatus.OK, "", inventario);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al actualizar inventario.");
        }
    }

    @DeleteMapping("/inventario/{sku}")
    public ResponseEntity<Object> eliminarInventario(@PathVariable("sku") String sku) {
        try {
            inventarioDAO.eliminar(sku);

            LOGGER.info("Se elimino inventario con el sku: " + sku);
            return ResponseHandler.generateResponse(HttpStatus.OK, "Se elimino inventario con el sku: " + sku, sku);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al eliminar inventario.");
        }
    }

    @GetMapping("/inventario")
    public ResponseEntity<Object> obtenerInventario(@RequestBody(required = false) Inventario inventario) {
        try {
            List<Inventario> inventarios = new ArrayList<Inventario>();

            if (inventario == null) {
                inventarioDAO.obtenerTodos().forEach(inventarios::add);
            }
            else if (inventario.getNombre() != null) {
                inventarioDAO.obtenerPorNombre(inventario.getNombre()).forEach(inventarios::add);
            }

            if (inventarios.isEmpty()) {
                return new ResponseEntity<>(HttpStatus.NO_CONTENT);
            }

            LOGGER.info("Se obtuvo información de inventario.");
            return ResponseHandler.generateResponse(HttpStatus.OK, "", inventarios);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al obtener inventario.");
        }
    }
}
