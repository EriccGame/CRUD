package com.devsrcoppel.crud.controllers;

import com.devsrcoppel.crud.models.Empleado;
import com.devsrcoppel.crud.interfaces.IEmpleadoDAO;
import com.devsrcoppel.crud.response.ResponseHandler;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import io.jsonwebtoken.security.Keys;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.AuthorityUtils;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.web.bind.annotation.*;

import java.nio.charset.Charset;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

@CrossOrigin(origins = "http://localhost:8081")
@RestController
@RequestMapping("/api")
public class LoginController {
    private static final Logger LOGGER = LoggerFactory.getLogger(LoginController.class);
    @Autowired
    IEmpleadoDAO empleadoRepository;

    public LoginController() {
        /*BCryptPasswordEncoder passwordEncoder = new BCryptPasswordEncoder();
        String password = "12345678";
        String encodedPassword = passwordEncoder.encode(password);
        System.out.println();
        System.out.println("Contraseña           : " + password);
        System.out.println("Contraseña encriptada: " + encodedPassword);
        System.out.println();

        boolean isPasswordMatch = passwordEncoder.matches(password, encodedPassword);
        System.out.println("Contraseña: " + password + "   Coincide: " + isPasswordMatch);*/
    }

    @PostMapping("login")
    public ResponseEntity<Object> login(@RequestBody Empleado empleado) {
        try {
            Map<String, Object> map = new HashMap<String, Object>();
            BCryptPasswordEncoder passwordEncoder = new BCryptPasswordEncoder();
            List<Empleado> empleados = empleadoRepository.obtenerPorId(empleado.getIdEmpleado());

            if (empleados != null) {

                if (empleados.isEmpty()) {
                    LOGGER.info("El número de empleado no existe.");
                    return ResponseHandler.generateResponse(HttpStatus.NOT_ACCEPTABLE, "El número de empleado no existe.", null);
                }

                Empleado emp = empleados.get(0);
                boolean isPasswordMatch = passwordEncoder.matches(empleado.getContraseña(), emp.getContraseña());

                if (isPasswordMatch) {
                    String token = getJWTToken(empleado.getIdEmpleado());

                    map.put("IDEmpleado", empleado.getIdEmpleado());
                    map.put("Token", token);
                } else {
                    LOGGER.info("La contraseña no coincide.");
                    return ResponseHandler.generateResponse(HttpStatus.NOT_ACCEPTABLE, "La contraseña no coincide.", null);
                }
            } else {
                LOGGER.info("El número de empleado no existe.");
                return ResponseHandler.generateResponse(HttpStatus.NOT_ACCEPTABLE, "El número de empleado no existe.", null);
            }

            LOGGER.info("Se consulto el empleado con id:" + empleado.getIdEmpleado());
            return ResponseHandler.generateResponse(HttpStatus.OK, "", map);
        } catch (Exception e) {
            LOGGER.error(e.getMessage(), e);
            return ResponseHandler.generateResponse(HttpStatus.INTERNAL_SERVER_ERROR, "Error al autenticar.", null);
        }
    }

    private String getJWTToken(String username) {
        String secretKey = "ヽ(^o^)丿 (^_^)/　(^_^)/~　(^_^)v　(^_^.)　(=_=) (~_~)　＼(^o^)／ (^。^)y";
        List<GrantedAuthority> grantedAuthorities = AuthorityUtils
                .commaSeparatedStringToAuthorityList("ROLE_USER");

        String token = Jwts
                .builder()
                .setId("JWT_CRUD")
                .setSubject(username)
                .claim("authorities",
                        grantedAuthorities.stream()
                                .map(GrantedAuthority::getAuthority)
                                .collect(Collectors.toList()))
                .setIssuedAt(new Date(System.currentTimeMillis()))
                .setExpiration(new Date(System.currentTimeMillis() + 600000))
                .signWith(Keys.hmacShaKeyFor(secretKey.getBytes(Charset.forName("UTF-8"))), SignatureAlgorithm.HS512)
                .compact();

        return "Bearer " + token;
    }
}
