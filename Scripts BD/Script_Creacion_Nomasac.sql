

CREATE TABLE accidente (
    id_accidente            INTEGER NOT NULL,
    id_servicio             INTEGER NOT NULL,
    rut                     VARCHAR2(10) NOT NULL,
    rut_accidentado         VARCHAR2(10) NOT NULL,
    nombre_accidentado      VARCHAR2(50),
    apellidop_accidentado   VARCHAR2(50) NOT NULL,
    apellidom_accidentado   VARCHAR2(50) NOT NULL,
    fecha_hora_accidente    DATE NOT NULL,
    descripcion             VARCHAR2(200) NOT NULL
);

ALTER TABLE accidente ADD CONSTRAINT accidente_pk PRIMARY KEY ( id_servicio,id_accidente );

CREATE TABLE asesoria (
    id_asesoria   INTEGER NOT NULL,
    id_servicio   INTEGER NOT NULL,
    rut           VARCHAR2(10) NOT NULL,
    id_motivo     INTEGER NOT NULL,
    observacion   VARCHAR2(200) NOT NULL,
    realizado     INTEGER NOT NULL,
    dar_baja      INTEGER NOT NULL
);

ALTER TABLE asesoria ADD CONSTRAINT asesoria_pk PRIMARY KEY ( id_asesoria,id_servicio );

CREATE TABLE capacitacion (
    id_capacitacio           INTEGER NOT NULL,
    id_servicio              INTEGER NOT NULL,
    rut                      VARCHAR2(10) NOT NULL,
    fecha_hora_registro      DATE NOT NULL,
    fecha_hora_realizacion   DATE NOT NULL,
    rut_profesional2         VARCHAR2(10),
    rut_profesional3         VARCHAR2(10),
    realizado                INTEGER NOT NULL,
    dar_baja                 INTEGER NOT NULL
);

ALTER TABLE capacitacion ADD CONSTRAINT capacitacion_pk PRIMARY KEY ( id_capacitacio,id_servicio );

CREATE TABLE chequeo (
    id_servicio   INTEGER NOT NULL,
    id_chequeo    INTEGER NOT NULL,
    rut_empresa   VARCHAR2(10) NOT NULL,
    id_visita     INTEGER NOT NULL,
    id_item       INTEGER NOT NULL,
    descripcion   INTEGER NOT NULL,
    cumple        INTEGER NOT NULL,
    dar_baja      INTEGER NOT NULL
);

ALTER TABLE chequeo ADD CONSTRAINT chequeo_pk PRIMARY KEY ( id_visita,id_servicio,id_chequeo,rut_empresa );

CREATE TABLE ciudad (
    id_ciudad   INTEGER NOT NULL,
    nombre      VARCHAR2(50) NOT NULL,
    id_region   INTEGER NOT NULL
);

ALTER TABLE ciudad ADD CONSTRAINT ciudad_pk PRIMARY KEY ( id_ciudad );

CREATE TABLE cliente_empresa (
    rut              VARCHAR2(10) NOT NULL,
    id_giro          INTEGER NOT NULL,
    id_comuna        INTEGER NOT NULL,
    nombre           VARCHAR2(50) NOT NULL,
    telefono         VARCHAR2(12) NOT NULL,
    direccion        VARCHAR2(50) NOT NULL,
    correo           VARCHAR2(50) NOT NULL,
    cliente_moroso   INTEGER NOT NULL
);

ALTER TABLE cliente_empresa ADD CONSTRAINT cliente_empresa_pk PRIMARY KEY ( rut );

CREATE TABLE comuna (
    id_comuna   INTEGER NOT NULL,
    id_ciudad   INTEGER NOT NULL,
    nombre      VARCHAR2(50) NOT NULL
);

ALTER TABLE comuna ADD CONSTRAINT comuna_pk PRIMARY KEY ( id_comuna );

CREATE TABLE detalle_factura (
    id_articulo           INTEGER NOT NULL,
    factura_nro_factura   INTEGER NOT NULL,
    descripcion           VARCHAR2(50) NOT NULL,
    cantidad              INTEGER NOT NULL,
    precio                INTEGER NOT NULL,
    valor                 INTEGER NOT NULL
);

ALTER TABLE detalle_factura ADD CONSTRAINT detalle_factura_pk PRIMARY KEY ( id_articulo,factura_nro_factura );

CREATE TABLE factura (
    nro_factura         INTEGER NOT NULL,
    id_servicio         INTEGER NOT NULL,
    rut_empresa         VARCHAR2(10) NOT NULL,
    giro_empresa        VARCHAR2(50) NOT NULL,
    nombre_empresa      VARCHAR2(50) NOT NULL,
    direccion_empresa   VARCHAR2(50),
    telefono_empresa    VARCHAR2(12) NOT NULL,
    rut_empresa_cli     VARCHAR2(10) NOT NULL,
    nombre_cliente      VARCHAR2(50) NOT NULL,
    giro_cliente        VARCHAR2(50) NOT NULL,
    direccion_cliente   VARCHAR2(50) NOT NULL,
    comuna_cliente      VARCHAR2(50) NOT NULL,
    ciudad_cliente      VARCHAR2(50) NOT NULL,
    contacto_cliente    VARCHAR2(12) NOT NULL,
    fecha               DATE NOT NULL,
    valor_neto          INTEGER NOT NULL,
    iva                 INTEGER NOT NULL,
    total               INTEGER NOT NULL,
    id_pago             INTEGER NOT NULL
);

CREATE UNIQUE INDEX factura__idx ON
    factura ( id_pago ASC );

ALTER TABLE factura ADD CONSTRAINT factura_pk PRIMARY KEY ( nro_factura );

CREATE TABLE giro (
    id_giro   INTEGER NOT NULL,
    nombre    VARCHAR2(50) NOT NULL
);

ALTER TABLE giro ADD CONSTRAINT giro_pk PRIMARY KEY ( id_giro );

CREATE TABLE llamado (
    id_llamado           INTEGER NOT NULL,
    id_servicio          INTEGER NOT NULL,
    rut                  VARCHAR2(10) NOT NULL,
    rut_empresa          VARCHAR2(10) NOT NULL,
    fecha_hora_llamado   DATE NOT NULL,
    duracion_min         INTEGER NOT NULL,
    ruta_grabacion       VARCHAR2(50) NOT NULL,
    observacion          VARCHAR2(300),
    llamada_extra        INTEGER NOT NULL
);

ALTER TABLE llamado ADD CONSTRAINT llamado_pk PRIMARY KEY ( id_llamado,id_servicio );

CREATE TABLE motivo_asesoria (
    id_motivo   INTEGER NOT NULL,
    nombre      VARCHAR2(100) NOT NULL
);

ALTER TABLE motivo_asesoria ADD CONSTRAINT motivo_asesoria_pk PRIMARY KEY ( id_motivo );

CREATE TABLE multa (
    id_multa              INTEGER NOT NULL,
    id_servicio           INTEGER NOT NULL,
    rut                   VARCHAR2(10) NOT NULL,
    fecha_hora_multa      DATE NOT NULL,
    fecha_hora_registro   DATE NOT NULL,
    descripcion           VARCHAR2(200) NOT NULL,
    valor_multa           INTEGER NOT NULL,
    ruta_doc_multa        INTEGER NOT NULL
);

ALTER TABLE multa ADD CONSTRAINT multa_pk PRIMARY KEY ( id_servicio,id_multa );

CREATE TABLE pago (
    id_pago           INTEGER NOT NULL,
    fuera_de_plazo    INTEGER NOT NULL,
    fecha_hora_pago   DATE NOT NULL
);

ALTER TABLE pago ADD CONSTRAINT pago_pk PRIMARY KEY ( id_pago );

CREATE TABLE plan_pago (
    id_plan             INTEGER NOT NULL,
    descripcion         VARCHAR2(200) NOT NULL,
    costo_fijo          INTEGER NOT NULL,
    cant_visitas_mes    INTEGER NOT NULL,
    max_modcheck_anio   INTEGER NOT NULL,
    cost_ext_modcheck   INTEGER NOT NULL,
    max_capac_mes       INTEGER NOT NULL,
    cost_ext_capac      INTEGER NOT NULL,
    hora_ini_llamadas   INTEGER NOT NULL,
    hora_fin_llamadas   INTEGER NOT NULL,
    cost_ext_llamadas   INTEGER NOT NULL,
    max_asesorias_mes   INTEGER NOT NULL,
    cost_ext_aseso      INTEGER NOT NULL,
    max_actinfo_mes     INTEGER NOT NULL,
    cost_ext_actinfo    INTEGER NOT NULL,
    dar_baja            INTEGER NOT NULL
);

ALTER TABLE plan_pago ADD CONSTRAINT plan_pago_pk PRIMARY KEY ( id_plan );

CREATE TABLE region (
    id_region   INTEGER NOT NULL,
    nombre      VARCHAR2(50) NOT NULL
);

ALTER TABLE region ADD CONSTRAINT region_pk PRIMARY KEY ( id_region );

CREATE TABLE servicio (
    id_servicio         INTEGER NOT NULL,
    rut_empresa         VARCHAR2(10) NOT NULL,
    id_plan             INTEGER NOT NULL,
    fecha_vinculacion   DATE NOT NULL,
    dia_facturacion     INTEGER NOT NULL,
    dia_corte           INTEGER NOT NULL,
    modcheck_año        INTEGER NOT NULL,
    visitas_mes         INTEGER NOT NULL,
    capacitacion_mes    INTEGER NOT NULL,
    asesorias_mes       INTEGER NOT NULL,
    actinfo_mes         INTEGER NOT NULL,
    dar_baja            INTEGER NOT NULL
);

CREATE UNIQUE INDEX servicio__idx ON
    servicio ( rut_empresa ASC );

ALTER TABLE servicio ADD CONSTRAINT servicio_pk PRIMARY KEY ( id_servicio );

CREATE TABLE solicitud (
    id_solicitud        INTEGER NOT NULL,
    id_servicio         INTEGER NOT NULL,
    id_tipo_solicitud   INTEGER NOT NULL,
    rut                 VARCHAR2(10) NOT NULL,
    mensaje             VARCHAR2(300) NOT NULL,
    cerrada             INTEGER NOT NULL,
    dar_baja            INTEGER NOT NULL
);

ALTER TABLE solicitud ADD CONSTRAINT solicitud_pk PRIMARY KEY ( id_servicio,id_solicitud );

CREATE TABLE tipo_solicitud (
    id_tipo_solicitud   INTEGER NOT NULL,
    nombre              VARCHAR2(100) NOT NULL
);

ALTER TABLE tipo_solicitud ADD CONSTRAINT tipo_solicitud_pk PRIMARY KEY ( id_tipo_solicitud );

CREATE TABLE tipo_usuario (
    id_tipo   INTEGER NOT NULL,
    nombre    VARCHAR2(50) NOT NULL
);

ALTER TABLE tipo_usuario ADD CONSTRAINT tipo_usuario_pk PRIMARY KEY ( id_tipo );

CREATE TABLE usuario (
    rut           VARCHAR2(10) NOT NULL,
    id_tipo       INTEGER NOT NULL,
    pass          VARCHAR2(250) NOT NULL,
    nombres       VARCHAR2(50) NOT NULL,
    apellidop     VARCHAR2(50) NOT NULL,
    apellidom     VARCHAR2(50) NOT NULL,
    correo        VARCHAR2(50) NOT NULL,
    telefono      VARCHAR2(12) NOT NULL,
    direccion     VARCHAR2(50) NOT NULL,
    moroso        INTEGER NOT NULL,
    dar_baja      INTEGER NOT NULL,
    rut_empresa   VARCHAR2(10)
);

ALTER TABLE usuario ADD CONSTRAINT usuario_pk PRIMARY KEY ( rut );

CREATE TABLE visita (
    id_servicio        INTEGER NOT NULL,
    id_visita          INTEGER NOT NULL,
    rut                VARCHAR2(10) NOT NULL,
    observacion        VARCHAR2(200) NOT NULL,
    propuesta_mejora   VARCHAR2(300) NOT NULL,
    realizado          INTEGER NOT NULL,
    dar_baja           INTEGER NOT NULL
);

ALTER TABLE visita ADD CONSTRAINT visita_pk PRIMARY KEY ( id_visita,id_servicio );

ALTER TABLE accidente ADD CONSTRAINT accidente_servicio_fk FOREIGN KEY ( id_servicio )
    REFERENCES servicio ( id_servicio );

ALTER TABLE accidente ADD CONSTRAINT accidente_usuario_fk FOREIGN KEY ( rut )
    REFERENCES usuario ( rut );

ALTER TABLE asesoria ADD CONSTRAINT asesoria_motivo_asesoria_fk FOREIGN KEY ( id_motivo )
    REFERENCES motivo_asesoria ( id_motivo );

ALTER TABLE asesoria ADD CONSTRAINT asesoria_servicio_fk FOREIGN KEY ( id_servicio )
    REFERENCES servicio ( id_servicio );

ALTER TABLE asesoria ADD CONSTRAINT asesoria_usuario_fk FOREIGN KEY ( rut )
    REFERENCES usuario ( rut );

ALTER TABLE capacitacion ADD CONSTRAINT capacitacion_servicio_fk FOREIGN KEY ( id_servicio )
    REFERENCES servicio ( id_servicio );

ALTER TABLE capacitacion ADD CONSTRAINT capacitacion_usuario_fk FOREIGN KEY ( rut )
    REFERENCES usuario ( rut );

ALTER TABLE chequeo ADD CONSTRAINT chequeo_cliente_empresa_fk FOREIGN KEY ( rut_empresa )
    REFERENCES cliente_empresa ( rut );

ALTER TABLE chequeo ADD CONSTRAINT chequeo_visita_fk FOREIGN KEY ( id_visita,id_servicio )
    REFERENCES visita ( id_visita,id_servicio );

ALTER TABLE ciudad ADD CONSTRAINT ciudad_region_fk FOREIGN KEY ( id_region )
    REFERENCES region ( id_region );

ALTER TABLE cliente_empresa ADD CONSTRAINT cliente_empresa_comuna_fk FOREIGN KEY ( id_comuna )
    REFERENCES comuna ( id_comuna );

ALTER TABLE cliente_empresa ADD CONSTRAINT cliente_empresa_giro_fk FOREIGN KEY ( id_giro )
    REFERENCES giro ( id_giro );

ALTER TABLE comuna ADD CONSTRAINT comuna_ciudad_fk FOREIGN KEY ( id_ciudad )
    REFERENCES ciudad ( id_ciudad );

ALTER TABLE detalle_factura ADD CONSTRAINT detalle_factura_factura_fk FOREIGN KEY ( factura_nro_factura )
    REFERENCES factura ( nro_factura );

ALTER TABLE factura ADD CONSTRAINT factura_cliente_empresa_fk FOREIGN KEY ( rut_empresa_cli )
    REFERENCES cliente_empresa ( rut );

ALTER TABLE factura ADD CONSTRAINT factura_pago_fk FOREIGN KEY ( id_pago )
    REFERENCES pago ( id_pago );

ALTER TABLE factura ADD CONSTRAINT factura_servicio_fk FOREIGN KEY ( id_servicio )
    REFERENCES servicio ( id_servicio );

ALTER TABLE llamado ADD CONSTRAINT llamado_servicio_fk FOREIGN KEY ( id_servicio )
    REFERENCES servicio ( id_servicio );

ALTER TABLE llamado ADD CONSTRAINT llamado_usuario_fk FOREIGN KEY ( rut )
    REFERENCES usuario ( rut );

ALTER TABLE multa ADD CONSTRAINT multa_servicio_fk FOREIGN KEY ( id_servicio )
    REFERENCES servicio ( id_servicio );

ALTER TABLE multa ADD CONSTRAINT multa_usuario_fk FOREIGN KEY ( rut )
    REFERENCES usuario ( rut );

ALTER TABLE servicio ADD CONSTRAINT servicio_cliente_empresa_fk FOREIGN KEY ( rut_empresa )
    REFERENCES cliente_empresa ( rut );

ALTER TABLE servicio ADD CONSTRAINT servicio_plan_pago_fk FOREIGN KEY ( id_plan )
    REFERENCES plan_pago ( id_plan );

ALTER TABLE solicitud ADD CONSTRAINT solicitud_servicio_fk FOREIGN KEY ( id_servicio )
    REFERENCES servicio ( id_servicio );

ALTER TABLE solicitud ADD CONSTRAINT solicitud_tipo_solicitud_fk FOREIGN KEY ( id_tipo_solicitud )
    REFERENCES tipo_solicitud ( id_tipo_solicitud );

ALTER TABLE solicitud ADD CONSTRAINT solicitud_usuario_fk FOREIGN KEY ( rut )
    REFERENCES usuario ( rut );

ALTER TABLE usuario ADD CONSTRAINT usuario_tipo_usuario_fk FOREIGN KEY ( id_tipo )
    REFERENCES tipo_usuario ( id_tipo );

ALTER TABLE visita ADD CONSTRAINT visita_servicio_fk FOREIGN KEY ( id_servicio )
    REFERENCES servicio ( id_servicio );

ALTER TABLE visita ADD CONSTRAINT visita_usuario_fk FOREIGN KEY ( rut )
    REFERENCES usuario ( rut );








commit;