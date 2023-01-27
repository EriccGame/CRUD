package com.devsrcoppel.crud.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Getter;
import lombok.Setter;

import java.util.Date;

@Getter
@Setter
public class LogCrud {
    @JsonProperty("IdLog")
    private String IdLog;
    @JsonProperty("Sistema")
    private String Sistema;
    @JsonProperty("Metodo")
    private String Metodo;
    @JsonProperty("Tipo")
    private String Tipo;
    @JsonProperty("Descripcion")
    private String Descripcion;
    @JsonProperty("Fecha")
    private Date Fecha;

    public LogCrud() {

    }
}
