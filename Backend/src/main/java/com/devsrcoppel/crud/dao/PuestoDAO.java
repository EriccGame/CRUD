package com.devsrcoppel.crud.dao;

import com.devsrcoppel.crud.interfaces.IPuestoDAO;
import com.devsrcoppel.crud.models.Cliente;
import com.devsrcoppel.crud.models.Puesto;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.simple.SimpleJdbcCall;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Map;

@Repository
public class PuestoDAO implements IPuestoDAO {
    @Autowired(required = false)
    private JdbcTemplate jdbcTemplate;
    private SimpleJdbcCall simpleJdbcCall;

    @Override
    public List<Puesto> obtenerTodos() {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_ObtenerPuestos")
                .returningResultSet("puestos", BeanPropertyRowMapper.newInstance(Puesto.class));

        Map<String, Object> map = simpleJdbcCall.execute();
        List<Puesto> list = (List<Puesto>)map.get("puestos");

        return list;
    }
}
