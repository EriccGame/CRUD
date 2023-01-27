package com.devsrcoppel.crud.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class Empleado {
    @JsonProperty("IdEmpleado")
    private String IdEmpleado;
    @JsonProperty("Nombre")
    private String Nombre;
    @JsonProperty("Apellido")
    private String Apellido;
    @JsonProperty("IdPuesto")
    private String IdPuesto;
    @JsonProperty("Contraseña")
    private String Contraseña;
    @JsonProperty("Token")
    private String Token;

    public Empleado() {

    }
}