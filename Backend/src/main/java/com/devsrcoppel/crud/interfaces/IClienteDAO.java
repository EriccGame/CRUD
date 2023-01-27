package com.devsrcoppel.crud.interfaces;

import com.devsrcoppel.crud.models.Cliente;

import java.util.List;

public interface IClienteDAO {
    int guardar(Cliente cliente);
    int actualizar(Cliente cliente);
    int eliminar(String idCliente);
    List<Cliente> obtenerTodos();
    List<Cliente> obtenerPorId(String idCliente);
    List<Cliente> obtenerPorNombre(String nombre);
}
