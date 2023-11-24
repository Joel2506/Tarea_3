/*Scaffold-DbContext "Server=MSI\SQLEXPRESS01; Database=sistemaPrestamo; Trusted_Connection=SSPI; Encrypt=false; TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force*/
create database SistemaPrestamo;

use SistemaPrestamo;

create table cliente (
id_cliente int primary key identity ,
cedula varchar(25),
nombre varchar(25),
apellido varchar(25),
direccion varchar(25),
telefono varchar(25)
)



create table Prestamo(
id_prestamo int primary key identity ,
id_fiador int,
id_cliente int,
monto float,
periodo float,
interes decimal
constraint FK_prestamo_id_cliente foreign key (id_cliente) references cliente (id_cliente)
 )



create table cuotaPrestamo(
id_cuotaPre int primary key identity,
monto float,
tipo varchar(25),
fechaRealizado date,
codigoComprobante int,
id_prestamo int
constraint  FK_cuaota_id_prestamo foreign key (id_prestamo) references Prestamo (id_prestamo)
)

create table inversion (
id_inversion int primary key identity,
id_cliente int,
monto float,
periodo float,
interes float
constraint  FK_inversion_id_inversion foreign key (id_inversion) references inversion (id_inversion)
)



create table  CuentaBanco (
id_banco int primary key identity,
nombre varchar(25),
numero  varchar(25),
tipo varchar(25),
id_cliente int ,
id_inversion int 
constraint Fk_Banco_id_cliente foreign key  (id_cliente) references  cliente (id_cliente),
constraint FK_CuentaBanco_id_inversion foreign key  (id_inversion) references inversion (id_inversion)
)

create table CuotaInversion(
id_cuotaIn int primary key identity,
monto float,
tipo varchar(25),
fechaRealizado date,
codigoComprobante  int,
id_inversion int,
id_banco int
constraint FK_CuotaInversion_id_banco foreign key (id_banco) references CuentaBanco (id_banco),
constraint FK_Cuota_id_inversion foreign key (id_inversion) references inversion (id_inversion)
)

create table garantia(
id_garantia int primary key identity,
tipo varchar(25),
valor float,
Ubicacion varchar(25),
id_prestamo int 
constraint Fk_garantia_id_prestamo foreign key (id_prestamo) references Prestamo (id_prestamo)
)


select * from cliente
select*from Prestamo