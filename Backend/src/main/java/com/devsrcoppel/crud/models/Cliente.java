package com.devsrcoppel.crud.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Getter;
import lombok.Setter;

import java.sql.Date;

@Getter
@Setter
public class Cliente {
    @JsonProperty("IdCliente")
    private String IdCliente;
    @JsonProperty("Nombre")
    private String Nombre;
    @JsonProperty("Apellido")
    private String Apellido;
    @JsonProperty("FechaNacimiento")
    private Date FechaNacimiento;

    public Cliente() {

    }
}
