package com.devsrcoppel.crud.interfaces;

import com.devsrcoppel.crud.models.LogCrud;

import java.util.List;

public interface ILogCrudDAO {
    int guardar(LogCrud logCrud);
    List<LogCrud> obtenerTodos();
}
