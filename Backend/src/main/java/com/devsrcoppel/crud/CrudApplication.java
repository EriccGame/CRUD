package com.devsrcoppel.crud;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.HttpMethod;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter;

import com.devsrcoppel.crud.security.JWTAuthorizationFilter;

@SpringBootApplication
public class CrudApplication {

	public static void main(String[] args) {
		 SpringApplication.run(CrudApplication.class, args);
	}

	@EnableWebSecurity
	@Configuration
	class WebSecurityConfig extends WebSecurityConfigurerAdapter {

		@Override
		protected void configure(HttpSecurity http) throws Exception {
			http.csrf().disable()
					.addFilterAfter(new JWTAuthorizationFilter(), UsernamePasswordAuthenticationFilter.class)
					.authorizeRequests()
					.antMatchers(HttpMethod.GET, "/api/puesto").permitAll()
					.antMatchers(HttpMethod.POST, "/api/login").permitAll()
					.antMatchers(HttpMethod.POST, "/api/empleado").permitAll()
					.antMatchers(HttpMethod.POST, "/api/log").permitAll()
					.anyRequest().authenticated();
		}
	}
}
