CREATE database veterinaria;

USE veterinaria;

CREATE TABLE raza
(
    id_r     varchar(3) PRIMARY KEY,
    nombre_r varchar(20)
);

CREATE TABLE especie
(
    id_e     varchar(3) PRIMARY KEY,
    nombre_e varchar(15)
);

CREATE TABLE cliente
(
    id_c              VARCHAR(10) PRIMARY KEY,
    nombre_c          VARCHAR(20),
    apellido_c        VARCHAR(30),
    fechaNacimineto_c DATE,
    edad_c            INT
);

CREATE TABLE mascotas
(
    id_m              VARCHAR(5) PRIMARY KEY,
    id_e              VARCHAR(3),
    id_r              VARCHAR(3),
    nombre_m VARCHAR(),
    edad_m            INT,
    sexo_m            VARCHAR(6),
    id_c              VARCHAR(10),
    fechaNacimineto_m DATE,
    FOREIGN KEY (id_e) REFERENCES especie (id_e),
    FOREIGN KEY (id_r) REFERENCES raza (id_r),
    FOREIGN KEY (id_c) REFERENCES cliente (id_c)
);

CREATE TABLE tipoProducto
(
    codigo_tp VARCHAR(3) PRIMARY KEY,
    nombre_tp VARCHAR(30)
);

CREATE TABLE productos
(
    codigo_pd VARCHAR(4) PRIMARY KEY,
    nombre_pd VARCHAR(20),
    codigo_tp VARCHAR(3),
    precio_pd FLOAT,
    FOREIGN KEY (codigo_tp) REFERENCES tipoProducto (codigo_tp)
);

CREATE TABLE servicio
(
    codigo_s VARCHAR(3) PRIMARY KEY,
    nombre_s VARCHAR(20),
    precio_s FLOAT
);

CREATE TABLE profesional
(
    codigo_pf   VARCHAR(4) PRIMARY KEY,
    nombre_pf   VARCHAR(20),
    apellido_pf VARCHAR(30),
    telefono_pf VARCHAR(7),
    celular_pf  VARCHAR(10)
);

CREATE TABLE venta
(
    codigo_v  VARCHAR(8) PRIMARY KEY,
    fecha_v   DATE,
    id_m      VARCHAR(5),
    codigo_pf varchar(4),
    FOREIGN KEY (id_m) REFERENCES mascotas (id_m),
    FOREIGN KEY (codigo_pf) REFERENCES profesional (codigo_pf)

);

CREATE TABLE venta_productos
(
    codigo_v  VARCHAR(8),
    codigo_pd VARCHAR(4),
    FOREIGN KEY (codigo_v) REFERENCES venta (codigo_v),
    FOREIGN KEY (codigo_pd) REFERENCES productos (codigo_pd)

);

CREATE TABLE venta_servicio
(
    codigo_v VARCHAR(8),
    codigo_s VARCHAR(3),
    FOREIGN KEY (codigo_v) REFERENCES venta (codigo_v),
    FOREIGN KEY (codigo_s) REFERENCES servicio (codigo_s)

);

# CREATE TABLE venta_profecional
# (
#     codigo_v  VARCHAR(8),
#     codigo_pf VARCHAR(4),
#     FOREIGN KEY (codigo_pf) REFERENCES profesional (codigo_pf),
#     FOREIGN KEY (codigo_v) REFERENCES venta (codigo_v)
# );
