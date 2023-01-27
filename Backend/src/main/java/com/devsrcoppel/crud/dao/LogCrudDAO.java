package com.devsrcoppel.crud.dao;

import com.devsrcoppel.crud.interfaces.ILogCrudDAO;
import com.devsrcoppel.crud.models.Empleado;
import com.devsrcoppel.crud.models.LogCrud;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.namedparam.MapSqlParameterSource;
import org.springframework.jdbc.core.namedparam.SqlParameterSource;
import org.springframework.jdbc.core.simple.SimpleJdbcCall;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;
import java.util.Map;

@Repository
public class LogCrudDAO implements ILogCrudDAO {
    @Autowired(required = false)
    private JdbcTemplate jdbcTemplate;
    private SimpleJdbcCall simpleJdbcCall;

    @Override
    @Transactional(rollbackFor = {Exception.class, RuntimeException.class})
    public int guardar(LogCrud logCrud) {
        try {
            simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                    .withProcedureName("SP_GuardarLogCrud");

            SqlParameterSource in = new MapSqlParameterSource()
                    .addValue("sistema", logCrud.getSistema())
                    .addValue("metodo", logCrud.getMetodo())
                    .addValue("tipo", logCrud.getTipo())
                    .addValue("descripcion", logCrud.getDescripcion());

            Map<String, Object> map = simpleJdbcCall.execute(in);

            if (map != null) {
                return 1;
            }
        } catch (Exception ex) {
            return 0;
        }

        return 0;
    }

    @Override
    public List<LogCrud> obtenerTodos() {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_ObtenerLogCrud")
                .returningResultSet("logCrud", BeanPropertyRowMapper.newInstance(LogCrud.class));

        Map<String, Object> map = simpleJdbcCall.execute();
        List<LogCrud> list = (List<LogCrud>)map.get("logCrud");

        return list;
    }
}
