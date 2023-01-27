package com.devsrcoppel.crud.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Getter;
import lombok.Setter;

import java.util.Date;

@Getter
@Setter
public class Polizas {
    @JsonProperty("IdPolizas")
    private Long IdPolizas;
    @JsonProperty("EmpleadoGenero")
    private String EmpleadoGenero;
    @JsonProperty("SKU")
    private String SKU;
    @JsonProperty("Cantidad")
    private Integer Cantidad;
    @JsonProperty("Fecha")
    private Date Fecha;
    @JsonProperty("IdCliente")
    private String IdCliente;

    public Polizas() {

    }
}
