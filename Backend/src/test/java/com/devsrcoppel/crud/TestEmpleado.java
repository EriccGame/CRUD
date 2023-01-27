package com.devsrcoppel.crud;

import com.devsrcoppel.crud.models.Empleado;
import com.devsrcoppel.crud.models.LogCrud;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.ObjectWriter;
import com.fasterxml.jackson.databind.SerializationFeature;
import org.junit.Before;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.web.context.WebApplicationContext;

import static org.springframework.http.MediaType.APPLICATION_JSON_UTF8;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.put;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.delete;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

public class TestEmpleado extends CrudApplicationTests {
    @Autowired
    private WebApplicationContext webApplicationContext;

    private MockMvc mockMvc;

    @Before
    public void setup() {
        mockMvc = MockMvcBuilders.webAppContextSetup(webApplicationContext).build();
    }



    @Test
    public void testGetEmpleado() throws Exception {
        mockMvc.perform(get("/api/empleado"))
                .andExpect(status().isOk())
                .andExpect(content().contentType("application/json"));

    }

    @Test
    public void testPostLog() throws Exception {

        Empleado empleado = new Empleado();
        empleado.setIdEmpleado("99000000");
        empleado.setNombre("Ericc");
        empleado.setApellido("Gaxiola");
        empleado.setIdPuesto("1");
        empleado.setContraseña("12345678");

        ObjectMapper mapper = new ObjectMapper();
        mapper.configure(SerializationFeature.WRAP_ROOT_VALUE, false);

        ObjectWriter writer = mapper.writer().withDefaultPrettyPrinter();
        String requestJson = writer.writeValueAsString(empleado);

        mockMvc.perform(post("/api/empleado").contentType(APPLICATION_JSON_UTF8)
                        .content(requestJson))
                .andExpect(status().isOk());
    }

    @Test
    public void testPutLog() throws Exception {

        Empleado empleado = new Empleado();
        empleado.setIdEmpleado("90000000");
        empleado.setNombre("Ericc");
        empleado.setApellido("Gaxiola Medina");
        empleado.setIdPuesto("1");
        empleado.setContraseña("12345678");

        ObjectMapper mapper = new ObjectMapper();
        mapper.configure(SerializationFeature.WRAP_ROOT_VALUE, false);

        ObjectWriter writer = mapper.writer().withDefaultPrettyPrinter();
        String requestJson = writer.writeValueAsString(empleado);

        mockMvc.perform(put("/api/empleado").contentType(APPLICATION_JSON_UTF8)
                        .content(requestJson))
                .andExpect(status().isOk());
    }

    @Test
    public void testDeleteLog() throws Exception {

        Empleado empleado = new Empleado();
        empleado.setIdEmpleado("99000000");

        mockMvc.perform(delete("/api/empleado/" + empleado.getIdEmpleado()))
                .andExpect(status().isOk())
                .andExpect(content().contentType("application/json"));
    }
}
