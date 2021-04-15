# Criando uma Function no SQL Server a Partir de Código C#
[![Build status](https://ci.appveyor.com/api/projects/status/ucxwgqb0ypj73tt9?svg=true)](https://ci.appveyor.com/project/adeildo-oliveira/SQL-Server-CLR)
>Código SQL para criar a function de extrair número de uma string.

```
CREATE DATABASE ClienteTeste
GO

USE ClienteTeste
GO

IF (EXISTS(select * from sys.assemblies where name = 'FunctionCliente')) 
BEGIN 
	EXEC('DROP ASSEMBLY FunctionCliente'); 
END 

CREATE ASSEMBLY FunctionCliente FROM 'D:\PROJETOS\Repository\SqlServerCLR\FunctionCliente\FunctionCliente\bin\Debug\FunctionCliente.dll' with PERMISSION_SET=SAFE;

CREATE FUNCTION dbo.ExtrairNumeroFunction(@parametro nvarchar(max))
	RETURNS nvarchar(max) WITH EXECUTE AS CALLER
AS 
	EXTERNAL NAME FunctionCliente.UserDefinedFunctions.ExtrairNumeroFunction
GO
```
>Habilitar execução de código `clr`.
```
EXEC sp_configure 'clr enabled', 1
GO
 RECONFIGURE
GO
EXEC sp_configure 'clr enabled'
GO
```
>Teste para extração de números.
```
SELECT [dbo].[ExtrairNumeroFunction] ('a1absd	fs2dfasd---a-*3**-_.+-*/    5aaa-4')
```