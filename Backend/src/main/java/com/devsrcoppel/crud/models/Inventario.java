package com.devsrcoppel.crud.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class Inventario {
    @JsonProperty("SKU")
    private String SKU;
    @JsonProperty("Nombre")
    private String Nombre;
    @JsonProperty("Cantidad")
    private Integer Cantidad;

    public Inventario() {

    }
}