USE [EjerciciosTich]
GO
/****** Object:  UserDefinedFunction [dbo].[Calculadora]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create function [dbo].[Calculadora] (@a int, @b int, @Ope char(10))
returns int
as
begin

declare @resultado int = 0

set @resultado = case
when @Ope = '+' then @a + @b
when @Ope = '-' then @a - @b
when @Ope = '*' then @a * @b
when @Ope = '%' then
	CASE 
	WHEN @b = 0 THEN 0 
	ELSE @a % @b
	END			
WHEN @Ope = '/' THEN
	CASE 
	WHEN @b = 0 THEN 0 
	ELSE @a / @b 
	END

else 0000 
END

return @resultado
end
GO
/****** Object:  UserDefinedFunction [dbo].[calcularImpuestos]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[calcularImpuestos](@Instructor smallint, @Curso smallint)
returns decimal (9,2)
as 
begin

declare @TotalImpuestos decimal (9,2)
declare @Honorarios decimal (9,2)
declare @HorasCurso decimal (9,2)
declare @CodEst varchar(10)
declare @HonorariosCurso decimal (9,2)

select TOP 1
@Honorarios = cuotaHora,
@CodEst = substring(curp, 12,2)
from Instructores ins
where id = @Instructor

select TOP 1
@HorasCurso = cc.horas
from Cursos cu
inner join CatCursos cc
on cu.idCatCurso = cc.id
where cu.id = @Curso

--CS -> CHIAPAS = 5 % 
--SR -> Sonora = 10 % 
--VZ -> Veracruz = 7 % 
--El resto del país 8 %

set @HonorariosCurso = @Honorarios * @HorasCurso

set @TotalImpuestos = case
when @CodEst = 'CS' then @HonorariosCurso * .05
when @CodEst = 'SR' then @HonorariosCurso * .1
when @CodEst = 'VZ' then @HonorariosCurso * .07
else @HonorariosCurso * .08
END



return @TotalImpuestos
end
GO
/****** Object:  UserDefinedFunction [dbo].[calculoDescuentos]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[calculoDescuentos](@Meses int, @Salario decimal(9,2))
returns varchar(150)
as 
begin

declare @TotalPagar decimal(9,2) = @Salario * 2.5
declare @Descuento decimal(9,2) = @Salario / 1000
declare @DescuentoTotal decimal(9,2)
declare @returnVal varchar(150)

set @DescuentoTotal = case
when @Meses = 1 then @Descuento
when @Meses = 2 then (@Descuento * .75)
when @Meses = 3 then (@Descuento * .50)
when @Meses = 4 then (@Descuento * .25)
when @Meses <= 5 then 0
else 0
end

SET @returnVal = case
when @Meses <= 6 then CONVERT(varchar(150), @DescuentoTotal)
else 'Ingrese un mes valido'
end

return @returnVal
end
GO
/****** Object:  UserDefinedFunction [dbo].[cambiarMayusculasPalabras]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[cambiarMayusculasPalabras](@PALABRITA NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @valsal NVARCHAR(MAX);

   
SET @valsal = LOWER(@PALABRITA)
SET @valsal = STUFF(@valsal, 1, 1, UPPER(SUBSTRING(@valsal, 1, 1)));

    
DECLARE @conta INT = 1;
WHILE @conta <= LEN(@valsal)
BEGIN
IF SUBSTRING(@valsal, @conta, 1) = ' '
BEGIN
SET @valsal = STUFF(@valsal, @conta + 1, 1, UPPER(SUBSTRING(@valsal, @conta + 1, 1)));
END
SET @conta = @conta + 1;
END

RETURN @valsal;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[Genero]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[Genero](@CURP Varchar(50))
returns varchar(50)
as
Begin

declare @SexoCurp varchar(50) = IIF(substring(@CURP, 11,1) = 'H', 'Hombre', ( IIF (substring(@CURP, 11,1) = 'M', 'Mujer', 'Invalido' ) ))

return @Sexocurp
End
GO
/****** Object:  UserDefinedFunction [dbo].[GetEdad]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[GetEdad](@Nacimiento date,@FechaDeseada date)
returns decimal(4,2)
as
begin
declare @edadActual decimal(4,2) = (DATEDIFF(DAY,@Nacimiento,@FechaDeseada)) / 365

return @edadActual
end
GO
/****** Object:  UserDefinedFunction [dbo].[getFactorial]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[getFactorial](@Factorial int)
returns int as 
begin
declare @Acumulable int = @Factorial
declare @ResAcu int = 1

while @Acumulable != 1
begin
set @ResAcu = @ResAcu * @Acumulable
set @Acumulable = @Acumulable - 1 
end

return @ResAcu
end
GO
/****** Object:  UserDefinedFunction [dbo].[GetHonorarios]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[GetHonorarios](@idInstructor smallint, @idCurso smallint)
returns decimal (9,2)
as
begin

declare @Honorarios decimal
declare @HorasCurso decimal

select
@HorasCurso = cc.horas
from Cursos cu
inner join CatCursos cc
on cu.idCatCurso = cc.id
where cu.id = @idCurso

select @Honorarios = cuotaHora from Instructores

declare @TotalPagar decimal = @Honorarios * @HorasCurso

return @TotalPagar
end
GO
/****** Object:  UserDefinedFunction [dbo].[GetidEstado]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[GetidEstado](@CURP VARCHAR(50))
RETURNS VARCHAR(50)
AS
Begin

DECLARE @CodEst varchar(10) = substring(@CURP, 12,2)
DECLARE @ESTADO VARCHAR(50) 

select @ESTADO = Nombre
from EstadosCurp 
where CURP = @CodEst

return @ESTADO
End
GO
/****** Object:  UserDefinedFunction [dbo].[getPagos]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[getPagos](@Sueldo decimal(10,2))
returns DECIMAL(9,2)
as
begin

DECLARE @Deuda decimal(9,2) = @Sueldo * 2.5
declare @totalQuincenal DECIMAL(9,2)= @Deuda / 12

return @totalQuincenal
end
GO
/****** Object:  UserDefinedFunction [dbo].[prestamosInstructores]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[prestamosInstructores] (@IdInstructor int)
returns @InsPres table 
(Mes int identity(1,1), [Saldo Anterior] decimal(9,1), Intereses decimal(9,1), Pago Decimal(9,1), [Saldo Nuevo] decimal(9,1))
as
begin

declare @CuotaHora decimal (9,2)
declare @DeudaTotal decimal(9,2)
declare @DeudaTotalIntereses decimal(9,2)
declare @Pago decimal(9,2)
declare @PagoIntereses decimal(9,2)
declare @conta int = 12 
declare @intereses decimal(9,5)
declare @deudaIntereses decimal(9,5)
DECLARE @SALDONUEVO decimal(9,1)

select top 1
@CuotaHora = CuotaHora 
from Instructores
where id = @IdInstructor

set @DeudaTotal = @CuotaHora * 200

set @intereses = case
when @CuotaHora > 200 then .24
else .18
end

set @Pago = @CuotaHora * 25

while @conta > 0
begin

set @deudaIntereses = @DeudaTotal * (@intereses / 12)
set @DeudaTotalIntereses = @DeudaTotal + @deudaIntereses
SET @SALDONUEVO = case 
WHEN ((@DeudaTotal + @deudaIntereses) - @Pago ) < 0 THEN 0
else ((@DeudaTotal + @deudaIntereses) - @Pago )
END

insert into @InsPres ([Saldo Anterior], Intereses, Pago , [Saldo Nuevo]) 
values(@DeudaTotal,@deudaIntereses, CASE
WHEN @SALDONUEVO <= 0 THEN @DeudaTotal + @deudaIntereses
ELSE @Pago
END
, @SALDONUEVO)

set @DeudaTotal = @DeudaTotalIntereses - @Pago
set @DeudaTotalIntereses = @DeudaTotalIntereses - @Pago
set @conta = CASE
WHEN @SALDONUEVO <= 0 THEN 0
ELSE @conta - 1
END
end

return
end
GO
/****** Object:  UserDefinedFunction [dbo].[SUMA]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[SUMA]( @a decimal(9,2), @b decimal(9,2))
returns decimal(9,2)
as
Begin

declare @resultado decimal(9,2) = @a + @b

return @resultado
End
GO
/****** Object:  UserDefinedFunction [dbo].[tablaAmortización]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[tablaAmortización](@IdAlumno int)
returns @Tablita table (Quincena int identity(1,1), [Saldo Anterior] decimal(9,1), Pago decimal(9,1), [SaldoNuevo] decimal(9,1) )
as
begin

declare @sueldoAlu decimal(9,2)
declare @DeudaTotal decimal(9,2)
declare @Pago decimal(9,2)
declare @conta int

select
@sueldoAlu = sueldo
from Alumnos
where id = @IdAlumno

set @DeudaTotal = @sueldoAlu * 2.5
set @Pago = @DeudaTotal / 12
set @conta = 12

while @conta > 0
begin
insert into @Tablita ([Saldo Anterior], Pago , [SaldoNuevo]) 
values(@DeudaTotal,@Pago, (@DeudaTotal - @Pago) )
set @DeudaTotal = @DeudaTotal - @Pago
set @conta = @conta - 1
end

return
end
GO
/****** Object:  UserDefinedFunction [dbo].[GetFechaNacimiento]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[GetFechaNacimiento](@CURP varchar (50))
returns table
as
return
select
CONVERT(date,substring(@CURP, 5,6)) as 'Fecha de Nacimiento',
IIF(DATEPART(YEAR,CONVERT(date,substring(@CURP, 5,6))) BETWEEN 1900 AND 1999, 'Noventas', 'Dosmiles') as 'Siglo de nacimiento',
DATEPART(MONTH,CONVERT(date,substring(@CURP, 5,6))) as 'Mes de Nacimiento',
DATEPART(DAY,CONVERT(date,substring(@CURP, 5,6))) as 'Dia de Nacimiento'
GO
/****** Object:  StoredProcedure [dbo].[actualizarAlumnos]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[actualizarAlumnos](@id int, @Nombre nvarchar(60), @pap nvarchar(50), @sap nvarchar(60), @cor varchar(80), @tel nchar(10), @fn date, @curp char(18), @sueldo decimal(9,2), @idestado int, @idest smallint)
as
begin

declare @ContaReg int = (select count(id)
from Alumnos
where id = @id)

if @ContaReg >= 1

begin
update Alumnos set
nombre = @Nombre,
primerApellido = @pap,
segundoApellido = @sap,
correo = @cor,
telefono = @tel,
fechaNacimiento = @fn,
curp = @curp,
sueldo = @sueldo,
idEstadoOrigen = @idestado,
idEstatus = @idest
where id = @id

print 'Cantidad de registros actualizados: ' + convert(varchar, @ContaReg)

end

else
begin
print 'Alumno no encontrado'
end

end
GO
/****** Object:  StoredProcedure [dbo].[actualizarEstatusAlumnos]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   proc [dbo].[actualizarEstatusAlumnos] (@idAlumno int, @idEstatus int)
as
begin

if (select count(id)
from Alumnos
where id = @idAlumno) = 1 and 
(select count(id)
from EstatusAlumnos
where id = @idEstatus) = 1

begin 
update Alumnos set idEstatus = @idEstatus where id = @idAlumno

select
alu.nombre as Alumno,
ea.nombre
from Alumnos alu
inner join EstatusAlumnos ea
on alu.idEstatus = ea.id
where alu.id = @idAlumno

end



else

begin
Print 'Verifique sus datos'
end

end
GO
/****** Object:  StoredProcedure [dbo].[agregarAlumnos]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[agregarAlumnos](@Nombre nvarchar(60), @pap nvarchar(50), @sap nvarchar(60), @cor varchar(80), @tel nchar(10), @fn date, @curp char(18), @sueldo decimal(9,2), @idestado int, @idest smallint)
as
begin
insert into Alumnos (nombre,primerApellido,segundoApellido,correo,telefono,fechaNacimiento,curp,sueldo,idEstadoOrigen,idEstatus)
values (@Nombre,@pap,@sap,@cor, @tel, @fn, @curp, @sueldo, @idestado, @idest)

declare @id int = (SELECT top 1 MAX(id) FROM Alumnos)

print convert(varchar,@id)

end
GO
/****** Object:  StoredProcedure [dbo].[consultarAlumnos]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   proc [dbo].[consultarAlumnos] (@idAlumno int)
as
begin

if @idAlumno <= 0 or @idAlumno > ((SELECT MAX(id) FROM vAlumnos))
begin 
select * from vAlumnos
end

else
begin
select * from vAlumnos where id = @idAlumno
end

end
GO
/****** Object:  StoredProcedure [dbo].[consultarEAlumnos]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   proc [dbo].[consultarEAlumnos] (@idAlumno int)
as
begin

if @idAlumno <= 0 or @idAlumno > ((SELECT MAX(id) FROM Alumnos))
begin 
select * from Alumnos
end

else
begin
select * from Alumnos where id = @idAlumno
end

end
GO
/****** Object:  StoredProcedure [dbo].[consultarEstados]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   proc [dbo].[consultarEstados] (@idEstado int)
as
begin

if @idEstado <= 0 or @idEstado > ((SELECT MAX(id) FROM EstadosCurp))
begin 
select id as Id, Nombre as Estado from EstadosCurp
end
else
begin
select id as Id, Nombre as Estado from EstadosCurp where id = @idEstado
end

end
GO
/****** Object:  StoredProcedure [dbo].[consultarEstatusAlumnos]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   proc [dbo].[consultarEstatusAlumnos] (@idEstatus int)
as
begin

if @idEstatus <= 0 or @idEstatus > ((SELECT MAX(id) FROM EstatusAlumnos))
begin 
select id as Id, nombre as Estatus from EstatusAlumnos
end

else
begin
select id as Id, nombre as Estatus from EstatusAlumnos where id = @idEstatus
end

end
GO
/****** Object:  StoredProcedure [dbo].[eliminarAlumnos]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   proc [dbo].[eliminarAlumnos](@idAlumno int)
as
begin

declare @validar int = (select count(id)
from Alumnos
where id = @idAlumno)

begin try
BEGIN TRANSACTION;


        IF @validar >= 1
        BEGIN
            delete from Alumnos where id = @idAlumno
            COMMIT;
            PRINT 'Datos eliminados correctamente';
        END
        
		ELSE
        BEGIN
            ROLLBACK;
            PRINT 'Error al eliminar, no se encontro el alumno';
        END
end try


begin catch
 PRINT 'Error en la transacci�n. Se ha realizado un rollback.';
 THROW 51000,'Error al realizar la transferencia', 1;
end catch

end
GO
/****** Object:  StoredProcedure [dbo].[TransaccionMonetaria]    Script Date: 22/11/2024 02:04:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[TransaccionMonetaria]
    @CuentaOrigen INT,
    @CuentaDestino INT,
    @Cantidad DECIMAL(18, 2)
AS
BEGIN
	
	DELETE FROM Transacciones WHERE idDestino IS NULL
	DELETE FROM Transacciones WHERE monto < 0

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Verificar saldo suficiente en la cuenta origen
        DECLARE @SaldoOrigen DECIMAL(18, 2);
        SELECT @SaldoOrigen = salado FROM saldos WHERE ID = @CuentaOrigen;

        IF @SaldoOrigen >= @Cantidad
        BEGIN
            -- Restar la cantidad de la cuenta origen
            UPDATE saldos SET salado = salado - @Cantidad WHERE ID = @CuentaOrigen;

            -- Sumar la cantidad a la cuenta destino
            UPDATE saldos SET salado = salado + @Cantidad WHERE ID = @CuentaDestino;
            COMMIT;
            PRINT 'Transacci�n completada exitosamente.';
        END
        ELSE
        BEGIN
            ROLLBACK;
            PRINT 'Saldo insuficiente en la cuenta origen.';
        END
    END TRY
    BEGIN CATCH
        ROLLBACK;
        PRINT 'Error en la transacci�n. Se ha realizado un rollback.';
		THROW 51000,'Error al realizar la transferencia', 1;
    END CATCH;
END;
GO
