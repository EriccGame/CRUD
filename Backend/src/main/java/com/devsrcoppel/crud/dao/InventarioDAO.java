package com.devsrcoppel.crud.dao;

import com.devsrcoppel.crud.models.Inventario;
import com.devsrcoppel.crud.interfaces.IInventarioDAO;

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
public class InventarioDAO implements IInventarioDAO {
    @Autowired(required = false)
    private JdbcTemplate jdbcTemplate;
    private SimpleJdbcCall simpleJdbcCall;

    @Override
    @Transactional(rollbackFor = {Exception.class, RuntimeException.class})
    public int guardar(Inventario inventario) {
        try {
            simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                    .withProcedureName("SP_GuardarInventario");

            SqlParameterSource in = new MapSqlParameterSource()
                    .addValue("sku", inventario.getSKU())
                    .addValue("nombre", inventario.getNombre())
                    .addValue("cantidad", inventario.getCantidad());

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
    public int actualizar(Inventario inventario) {
        try {
            simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                    .withProcedureName("SP_ActualizarInventario");

            SqlParameterSource in = new MapSqlParameterSource()
                    .addValue("sku", inventario.getSKU())
                    .addValue("nombre", inventario.getNombre())
                    .addValue("cantidad", inventario.getCantidad());

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
    public int eliminar(String sku) {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_EliminarInventario");

        SqlParameterSource in = new MapSqlParameterSource()
                .addValue("sku", sku);

        Map<String, Object> map = simpleJdbcCall.execute(in);

        if (map != null) {
            return 1;
        }

        return 0;
    }

    @Override
    public List<Inventario> obtenerTodos() {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_ObtenerInventario")
                .returningResultSet("inventario", BeanPropertyRowMapper.newInstance(Inventario.class));

        Map<String, Object> map = simpleJdbcCall.execute();
        List<Inventario> list = (List<Inventario>)map.get("inventario");

        return list;
    }

    @Override
    public List<Inventario> obtenerPorSKU(String sku) {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_ObtenerInventarioPorSKU")
                .returningResultSet("inventarioPorSKU", BeanPropertyRowMapper.newInstance(Inventario.class));

        SqlParameterSource in = new MapSqlParameterSource()
                .addValue("sku", sku);

        Map<String, Object> map = simpleJdbcCall.execute(in);
        List<Inventario> list = (List<Inventario>)map.get("inventarioPorSKU");

        return list;
    }

    @Override
    public List<Inventario> obtenerPorNombre(String nombre) {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_ObtenerInventarioPorNombre")
                .returningResultSet("inventarioPorNombre", BeanPropertyRowMapper.newInstance(Inventario.class));

        SqlParameterSource in = new MapSqlParameterSource()
                .addValue("nombre", nombre);

        Map<String, Object> map = simpleJdbcCall.execute(in);
        List<Inventario> list = (List<Inventario>)map.get("inventarioPorNombre");

        return list;
    }
}
