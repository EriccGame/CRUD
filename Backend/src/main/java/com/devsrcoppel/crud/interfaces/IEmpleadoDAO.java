package com.devsrcoppel.crud.interfaces;

import com.devsrcoppel.crud.models.Empleado;

import java.util.List;

public interface IEmpleadoDAO {
    int guardar(Empleado empleado);
    int actualizar(Empleado empleado);
    int eliminar(String idEmpleado);
    List<Empleado> obtenerTodos();
    List<Empleado> obtenerPorId(String idEmpleado);
    List<Empleado> obtenerPorNombre(String nombre);
}