package com.devsrcoppel.crud.controllers;

import com.devsrcoppel.crud.interfaces.IClienteDAO;
import com.devsrcoppel.crud.interfaces.IPolizasDAO;
import com.devsrcoppel.crud.models.Cliente;
import com.devsrcoppel.crud.models.Polizas;
import com.devsrcoppel.crud.response.ResponseHandler;
import com.fasterxml.jackson.databind.JsonNode;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@CrossOrigin(origins = "http://localhost:8081")
@RestController
@RequestMapping("/api")
public class PolizasController {
    private static final Logger LOGGER = LoggerFactory.getLogger(PolizasController.class);
    @Autowired
    IPolizasDAO iPolizasDAO;

    public PolizasController() {
    }

    @PostMapping("/polizas")
    public ResponseEntity<Object> guardarPoliza(@RequestBody List<Polizas> polizas) {
        try {
            Map<String, Object> mapPolizas = iPolizasDAO.guardar(polizas);
            List<Object> listPoliza = (List<Object>)mapPolizas.get("#result-set-1");

            ObjectMapper mapper = new ObjectMapper();
            String json = mapper.writeValueAsString(listPoliza.get(0));
            JsonNode jsonNode = mapper.readTree(json);

            Map<String, Object> map = new HashMap<String, Object>();
            Map<String, Object> mapPoliza = new HashMap<String, Object>();
            Map<String, Object> mapEmpleado = new HashMap<String, Object>();
            Map<String, Object> mapArticulo = new HashMap<String, Object>();

            mapPoliza.put("IdPoliza", jsonNode.get("IdPolizas"));
            mapPoliza.put("Cantidad", jsonNode.get("Cantidad"));

            map.put("Poliza", mapPoliza);

            mapEmpleado.put("Nombre", jsonNode.get("Nombre"));
            mapEmpleado.put("Apellido", jsonNode.get("Apellido"));

            map.put("Empleado", mapEmpleado);

            mapArticulo.put("SKU", jsonNode.get("SKU"));
            mapArticulo.put("Nombre", jsonNode.get("NombreArticulo"));

            map.put("DetalleArticulo", mapArticulo);

            LOGGER.info("Se creo poliza.");
            return ResponseHandler.generateResponse(HttpStatus.OK, "", map);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Ha ocurrido un error en los grabados de póliza.");
        }
    }

    @PutMapping("/polizas")
    public ResponseEntity<Object> actualizarPoliza(@RequestBody Polizas polizas) {
        try {
            iPolizasDAO.actualizar(polizas);

            LOGGER.info("Se actualizo la poliza con el id: " + polizas.getIdPolizas());
            return ResponseHandler.generateResponse(HttpStatus.OK, "Se actualizó correctamente la poliza #" + polizas.getIdPolizas(), polizas);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Ha ocurrido un error al intentar actualizar la póliza.");
        }
    }

    @DeleteMapping("/polizas/{idPolizas}")
    public ResponseEntity<Object> eliminarCliente(@PathVariable("idPolizas") Long idPolizas) {
        try {
            iPolizasDAO.eliminar(idPolizas);

            LOGGER.info("Se eliminó correctamente la poliza: " + idPolizas);
            return ResponseHandler.generateResponse(HttpStatus.OK, "Se eliminó correctamente la poliza #" + idPolizas, idPolizas);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Ha ocurrido un error al intentar eliminar la póliza.");
        }
    }

    @GetMapping("/polizas/{idPolizas}")
    public ResponseEntity<Object> obtenerPolizaPorId(@PathVariable("idPolizas") Long idPolizas) {
        try {
            Map<String, Object> mapPolizas = new HashMap<String, Object>();

            mapPolizas = iPolizasDAO.obtenerPorId(idPolizas);

            List<Object> listPoliza = (List<Object>)mapPolizas.get("#result-set-1");

            if (listPoliza.isEmpty()) {
                LOGGER.info("Se no se encontro información de la poliza.");
                return ResponseHandler.generateResponse(HttpStatus.NO_CONTENT, "No se encontro de la poliza.", null);
            }

            ObjectMapper mapper = new ObjectMapper();
            String json = mapper.writeValueAsString(listPoliza.get(0));
            JsonNode jsonNode = mapper.readTree(json);

            Map<String, Object> map = new HashMap<String, Object>();
            Map<String, Object> mapPoliza = new HashMap<String, Object>();
            Map<String, Object> mapEmpleado = new HashMap<String, Object>();
            Map<String, Object> mapArticulo = new HashMap<String, Object>();

            mapPoliza.put("IdPoliza", jsonNode.get("IdPolizas"));
            mapPoliza.put("Cantidad", jsonNode.get("Cantidad"));

            map.put("Poliza", mapPoliza);

            mapEmpleado.put("Nombre", jsonNode.get("Nombre"));
            mapEmpleado.put("Apellido", jsonNode.get("Apellido"));

            map.put("Empleado", mapEmpleado);

            mapArticulo.put("SKU", jsonNode.get("SKU"));
            mapArticulo.put("Nombre", jsonNode.get("NombreArticulo"));

            map.put("DetalleArticulo", mapArticulo);

            LOGGER.info("Se obtuvo información de la poliza");
            return ResponseHandler.generateResponse(HttpStatus.OK, "", map);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Ha ocurrido un error al consultar la póliza.");
        }
    }

    @GetMapping("/polizas")
    public ResponseEntity<Object> obtenerPolizas(@RequestBody(required = false) Polizas poliza) {
        try {
            List<Polizas> polizas = new ArrayList<Polizas>();

            iPolizasDAO.obtenerTodas().forEach(polizas::add);

            if (polizas.isEmpty()) {
                LOGGER.info("Se no se encontro información de cliente.");
                return ResponseHandler.generateResponse(HttpStatus.NO_CONTENT, "No se encontro cliente.", null);
            }

            LOGGER.info("Se obtuvo información de cliente.");
            return ResponseHandler.generateResponse(HttpStatus.OK, "", polizas);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al obtener información de cliente.");
        }
    }
}
