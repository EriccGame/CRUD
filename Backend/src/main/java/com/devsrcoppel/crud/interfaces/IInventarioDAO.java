package com.devsrcoppel.crud.interfaces;

import com.devsrcoppel.crud.models.Inventario;

import java.util.List;

public interface IInventarioDAO {
    int guardar(Inventario inventario);
    int actualizar(Inventario inventario);
    int eliminar(String sku);
    List<Inventario> obtenerTodos();
    List<Inventario> obtenerPorSKU(String sku);
    List<Inventario> obtenerPorNombre(String nombre);
}
