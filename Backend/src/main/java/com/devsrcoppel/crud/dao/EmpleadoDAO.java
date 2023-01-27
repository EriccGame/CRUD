package com.devsrcoppel.crud.dao;

import com.devsrcoppel.crud.interfaces.IEmpleadoDAO;
import com.devsrcoppel.crud.models.Empleado;

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
public class EmpleadoDAO implements IEmpleadoDAO {
    @Autowired(required = false)
    private JdbcTemplate jdbcTemplate;
    private SimpleJdbcCall simpleJdbcCall;

    @Override
    @Transactional(rollbackFor = {Exception.class, RuntimeException.class})
    public int guardar(Empleado empleado) {
        try {
            simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                    .withProcedureName("SP_GuardarEmpleado");

            SqlParameterSource in = new MapSqlParameterSource()
                    .addValue("idEmpleado", empleado.getIdEmpleado())
                    .addValue("nombre", empleado.getNombre())
                    .addValue("apellido", empleado.getApellido())
                    .addValue("idPuesto", empleado.getIdPuesto())
                    .addValue("contraseña", empleado.getContraseña());

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
    public int actualizar(Empleado empleado) {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                    .withProcedureName("SP_ActualizarEmpleado");

            SqlParameterSource in = new MapSqlParameterSource()
                    .addValue("idEmpleado", empleado.getIdEmpleado())
                    .addValue("nombre", empleado.getNombre())
                    .addValue("apellido", empleado.getApellido())
                    .addValue("idPuesto", empleado.getIdPuesto())
                    .addValue("contraseña", empleado.getContraseña());

            Map<String, Object> map = simpleJdbcCall.execute(in);

            if (map != null) {
                return 1;
            }

        return 0;
    }

    @Override
    @Transactional(rollbackFor = {Exception.class, RuntimeException.class})
    public int eliminar(String idEmpleado) {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_EliminarEmpleado");

        SqlParameterSource in = new MapSqlParameterSource()
                .addValue("idEmpleado", idEmpleado);

        Map<String, Object> map = simpleJdbcCall.execute(in);

        if (map != null) {
            return 1;
        }

        return 0;
    }

    @Override
    public List<Empleado> obtenerTodos() {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_ObtenerEmpleados")
                .returningResultSet("empleados", BeanPropertyRowMapper.newInstance(Empleado.class));

        Map<String, Object> map = simpleJdbcCall.execute();
        List<Empleado> list = (List<Empleado>)map.get("empleados");

        return list;
    }

    @Override
    public List<Empleado> obtenerPorId(String idEmpleado) {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_ObtenerEmpleadoPorId")
                .returningResultSet("empleadosPorId", BeanPropertyRowMapper.newInstance(Empleado.class));

        SqlParameterSource in = new MapSqlParameterSource()
                .addValue("idEmpleado", idEmpleado);

        Map<String, Object> map = simpleJdbcCall.execute(in);

        List<Empleado> list = (List<Empleado>)map.get("empleadosPorId");

        return list;
    }

    @Override
    public List<Empleado> obtenerPorNombre(String nombre) {
        simpleJdbcCall = new SimpleJdbcCall(jdbcTemplate)
                .withProcedureName("SP_ObtenerEmpleadoPorNombre")
                .returningResultSet("empleadosPorNombre", BeanPropertyRowMapper.newInstance(Empleado.class));

        SqlParameterSource in = new MapSqlParameterSource()
                .addValue("nombre", nombre);

        Map<String, Object> map = simpleJdbcCall.execute(in);
        List<Empleado> list = (List<Empleado>)map.get("empleadosPorNombre");

        return list;
    }
}
