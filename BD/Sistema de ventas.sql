create table Categorias(
       idcategoria integer primary key auto_increment,
       nombre varchar(50) not null unique,
       descripcion varchar(256) null,
       estado bit default(1)
);



create table Articulos(
       idarticulo integer primary key auto_increment,
       idcategoria integer not null,
       codigo varchar(50) null,
       nombre varchar(100) not null unique,
       precio_venta decimal(11,2) not null,
       stock integer not null,
       descripcion varchar(256) null,
       estado bit default(1),
       FOREIGN KEY (idcategoria) REFERENCES Categorias(idcategoria)
);


create table Personas(
       idpersona integer primary key auto_increment,
       tipo_persona varchar(20) not null,
       nombre varchar(100) not null,
       tipo_documento varchar(20) null,
       num_documento varchar(20) null,
       direccion varchar(70) null,
       telefono varchar(20) null,
       email varchar(50) null
);




create table Rol(
       idrol integer primary key auto_increment,
       nombre varchar(30) not null,
       descripcion varchar(100) null,
       estado bit default(1)
);


create table Usuarios(
       idusuario integer primary key,
       idrol integer not null,
       nombre varchar(100) not null,
       tipo_documento varchar(20) null,
       num_documento varchar(20) null,
       direccion varchar(70) null,
       telefono varchar(20) null,
       email varchar(50) not null,
       password varchar(40),
       estado bit default(1),
       FOREIGN KEY (idrol) REFERENCES Rol (idrol)
);


create table Ingresos(
       idingreso integer primary key auto_increment,
       idproveedor integer not null,
       idusuario integer not null,
       tipo_comprobante varchar(20) not null,
       serie_comprobante varchar(7) null,
       num_comprobante varchar (10) not null,
       fecha datetime not null,
       impuesto decimal (4,2) not null,
       total decimal (11,2) not null,
       estado varchar(20) not null,
       FOREIGN KEY (idproveedor) REFERENCES Personas (idpersona),
       FOREIGN KEY (idusuario) REFERENCES Usuarios (idusuario)
);


create table DetalleIngreso(
       iddetalle_ingreso integer primary key auto_increment,
       idingreso integer not null,
       idarticulo integer not null,
       cantidad integer not null,
       precio decimal(11,2) not null,
       FOREIGN KEY (idingreso) REFERENCES Ingresos (idingreso) ON DELETE CASCADE,
       FOREIGN KEY (idarticulo) REFERENCES Articulos (idarticulo)
);



create table Ventas(
       idventa integer primary key auto_increment,
       idcliente integer not null,
       idusuario integer not null,
       tipo_comprobante varchar(20) not null,
       serie_comprobante varchar(7) null,
       num_comprobante varchar (10) not null,
       fecha_hora datetime not null,
       impuesto decimal (4,2) not null,
       total decimal (11,2) not null,
       estado varchar(20) not null,
       FOREIGN KEY (idcliente) REFERENCES Personas (idpersona),
       FOREIGN KEY (idusuario) REFERENCES Usuarios (idusuario)
);


create table detalleVentas(
       iddetalle_venta integer primary key auto_increment,
       idventa integer not null,
       idarticulo integer not null,
       cantidad integer not null,
       precio decimal(11,2) not null,
       descuento decimal(11,2) not null,
       FOREIGN KEY (idventa) REFERENCES Ventas (idventa) ON DELETE CASCADE,
       FOREIGN KEY (idarticulo) REFERENCES Articulos (idarticulo)
);