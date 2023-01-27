package com.devsrcoppel.crud.dao;

import com.devsrcoppel.crud.interfaces.IClienteDAO;
import com.devsrcoppel.crud.models.Cliente;
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
public class ClienteDAO implements IClienteDAO {
    @Autowired(required = false)
    private JdbcTemplate jdbcTemplate;
    private SimpleJdbcCall simpleJdbcCall;

    @Override
    @Transactional(rollbackFor = {Exception.class, RuntimeException.class})
    public int guardar(Cliente cliente) {
        try {
            simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                    .withProcedureName("SP_GuardarCliente");

            SqlParameterSource in = new MapSqlParameterSource()
                    .addValue("idCliente", cliente.getIdCliente())
                    .addValue("nombre", cliente.getNombre())
                    .addValue("apellido", cliente.getApellido())
                    .addValue("fechaNacimiento", cliente.getFechaNacimiento());

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
    @Transactional(rollbackFor = {Exception.class, RuntimeException.class})
    public int actualizar(Cliente cliente) {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_ActualizarCliente");

        SqlParameterSource in = new MapSqlParameterSource()
                .addValue("idCliente", cliente.getIdCliente())
                .addValue("nombre", cliente.getNombre())
                .addValue("apellido", cliente.getApellido())
                .addValue("fechaNacimiento", cliente.getFechaNacimiento());

        Map<String, Object> map = simpleJdbcCall.execute(in);

        if (map != null) {
            return 1;
        }

        return 0;
    }

    @Override
    @Transactional(rollbackFor = {Exception.class, RuntimeException.class})
    public int eliminar(String idcliente) {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_EliminarCliente");

        SqlParameterSource in = new MapSqlParameterSource()
                .addValue("idcliente", idcliente);

        Map<String, Object> map = simpleJdbcCall.execute(in);

        if (map != null) {
            return 1;
        }

        return 0;
    }

    @Override
    public List<Cliente> obtenerTodos() {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_ObtenerCliente")
                .returningResultSet("cliente", BeanPropertyRowMapper.newInstance(Cliente.class));

        Map<String, Object> map = simpleJdbcCall.execute();
        List<Cliente> list = (List<Cliente>)map.get("cliente");

        return list;
    }

    @Override
    public List<Cliente> obtenerPorId(String idCliente) {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_ObtenerClientePorId")
                .returningResultSet("clientePorId", BeanPropertyRowMapper.newInstance(Cliente.class));

        SqlParameterSource in = new MapSqlParameterSource()
                .addValue("idCliente", idCliente);

        Map<String, Object> map = simpleJdbcCall.execute(in);

        List<Cliente> list = (List<Cliente>)map.get("clientePorId");

        return list;
    }

    @Override
    public List<Cliente> obtenerPorNombre(String nombre) {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_ObtenerClientePorNombre")
                .returningResultSet("clientePorNombre", BeanPropertyRowMapper.newInstance(Cliente.class));

        SqlParameterSource in = new MapSqlParameterSource()
                .addValue("nombre", nombre);

        Map<String, Object> map = simpleJdbcCall.execute(in);
        List<Cliente> list = (List<Cliente>)map.get("clientePorNombre");

        return list;
    }
}
