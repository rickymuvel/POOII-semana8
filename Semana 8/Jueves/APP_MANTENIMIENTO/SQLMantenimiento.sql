ALTER TABLE Ventas.Clientes
ADD Activo Bit
go

Update Ventas.clientes Set Activo = 1
go

Select * from Ventas.clientes
go

Create Proc usp_PaisListar
As
Begin
    Select * from Ventas.paises
End
go

Create Proc usp_ClienteListado
As
Begin
    Select C.IdCliente,C.NomCliente,C.DirCliente,P.NombrePais,C.fonoCliente
	from Ventas.clientes C
	INNER JOIN Ventas.paises P ON C.idpais=P.Idpais
	Where C.Activo = 1
End
go

Create Proc usp_ClienteInsertar
@IdCliente VarChar(5),@NomCliente VarChar(40),
@DirCliente VarChar(60),@IdPais Char(3),@fonoCliente VarChar(25)
As
Begin
    Insert Ventas.clientes Values
	(@IdCliente,@NomCliente,@DirCliente,@IdPais,@fonoCliente,1)
End
go

Create Proc usp_ClienteActualizar
@IdCliente VarChar(5),@NomCliente VarChar(40),
@DirCliente VarChar(60),@IdPais Char(3),@fonoCliente VarChar(25)
As
Begin
    Update Ventas.clientes SET NomCliente=@NomCliente,DirCliente=@DirCliente,
	idpais=@IdPais,fonoCliente=@fonoCliente Where IdCliente=@IdCliente
End
go

Create Proc usp_ClienteBaja
@IdCliente VarChar(5)
As
Begin
    Update Ventas.clientes Set Activo = 0
	Where IdCliente=@IdCliente
End
go

