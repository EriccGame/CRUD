package com.devsrcoppel.crud.dao;

import com.devsrcoppel.crud.interfaces.IPolizasDAO;
import com.devsrcoppel.crud.models.Cliente;
import com.devsrcoppel.crud.models.Polizas;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.namedparam.MapSqlParameterSource;
import org.springframework.jdbc.core.namedparam.SqlParameterSource;
import org.springframework.jdbc.core.simple.SimpleJdbcCall;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.RequestBody;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

@Repository
public class PolizasDAO implements IPolizasDAO {
    @Autowired(required = false)
    private JdbcTemplate jdbcTemplate;
    private SimpleJdbcCall simpleJdbcCall;

    @Override
    @Transactional(rollbackFor = {Exception.class, RuntimeException.class})
    public Map<String, Object> guardar(@RequestBody List<Polizas> polizas) {
        try {
            Map<String, Object> map = new HashMap<>();

            for (Polizas p:polizas) {
                simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                        .withProcedureName("SP_GuardarPolizas");

                SqlParameterSource in = new MapSqlParameterSource()
                        .addValue("idEmpleado", p.getEmpleadoGenero())
                        .addValue("sku", p.getSKU())
                        .addValue("cantidad", p.getCantidad())
                        .addValue("fecha", p.getFecha())
                        .addValue("idCliente", p.getIdCliente());

                map = simpleJdbcCall.execute(in);
            }

            return map;
        } catch (Exception ex) {
            return null;
        }
    }

    @Override
    @Transactional(rollbackFor = {Exception.class, RuntimeException.class})
    public int actualizar(Polizas polizas) {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_ActualizarPolizas");

        SqlParameterSource in = new MapSqlParameterSource()
                .addValue("idPolizas", polizas.getIdPolizas())
                .addValue("idEmpleado", polizas.getEmpleadoGenero())
                .addValue("sku", polizas.getSKU())
                .addValue("cantidad", polizas.getCantidad())
                .addValue("fecha", polizas.getFecha())
                .addValue("idCliente", polizas.getIdCliente());

        Map<String, Object> map = simpleJdbcCall.execute(in);

        if (map != null) {
            return 1;
        }

        return 0;
    }

    @Override
    @Transactional(rollbackFor = {Exception.class, RuntimeException.class})
    public int eliminar(Long idPolizas) {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_EliminarPolizas");

        SqlParameterSource in = new MapSqlParameterSource()
                .addValue("idPolizas", idPolizas);

        Map<String, Object> map = simpleJdbcCall.execute(in);

        if (map != null) {
            return 1;
        }

        return 0;
    }

    @Override
    public List<Polizas> obtenerTodas() {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_ObtenerPolizas")
                .returningResultSet("polizas", BeanPropertyRowMapper.newInstance(Polizas.class));

        Map<String, Object> map = simpleJdbcCall.execute();
        List<Polizas> list = (List<Polizas>)map.get("polizas");

        return list;
    }

    @Override
    public Map<String, Object> obtenerPorId(Long idPolizas) {
        try {
            simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                    .withProcedureName("SP_ObtenerPolizasPorId");

            SqlParameterSource in = new MapSqlParameterSource()
                    .addValue("idPolizas", idPolizas);

            return simpleJdbcCall.execute(in);
        } catch (Exception ex) {
            return null;
        }
    }
}
