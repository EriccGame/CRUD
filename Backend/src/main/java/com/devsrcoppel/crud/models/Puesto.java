package com.devsrcoppel.crud.models;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class Puesto {
    @JsonProperty("IdPuesto")
    private String IdPuesto;
    @JsonProperty("Nombre")
    private String Nombre;
}
