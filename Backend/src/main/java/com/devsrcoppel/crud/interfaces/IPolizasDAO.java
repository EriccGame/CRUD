package com.devsrcoppel.crud.interfaces;

import com.devsrcoppel.crud.models.Polizas;

import java.util.List;
import java.util.Map;

public interface IPolizasDAO {
    Map<String, Object> guardar(List<Polizas> polizas);
    int actualizar(Polizas polizas);
    int eliminar(Long idPolizas);
    List<Polizas> obtenerTodas();
    Map<String, Object> obtenerPorId(Long idPolizas);
}
