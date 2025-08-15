# APISchool

Proyecto desarrollado con .NET y APIREST para la logistoca y control de una inttitucion de enseñanza para manejar las operaciones CRUD y las consultas. 

### Pre-requisitos 📋

Necesitas estas herramientas para ejecuar el software

- Visual Studio Comunity 2022
- Sql
- Sql Server - Express
- Sql Server Management Studio

## Comenzando 🚀

_Estas instrucciones te permitirán obtener una copia del proyecto en funcionamiento en tu máquina local para propósitos de desarrollo y pruebas._

### Instalación

```
git clone https://github.com/AngelLunaS2609/APISchool.git

```
### Edición del archivo appsettings.json

Remplazar:
_Tomando en cuenta que estas en un ambiente de desarrollo_
```
"sql_connection": "Server=localhost\\SQLEXPRESS;Database=Ecommerce.Curso;Trusted_Connection=True;"

```
Por tu propio host local u online:

```
"sql_connection": "Server=TU_PROPIO_LOCAL_HOST;Database=SchoolsDB;Trusted_Connection=True;"

```

### Creacion de base de datos
Abrir el proyecto con Visual Studio Comunity y ejecutar mediante linea de comandos nugget
```
"Update-database"
```
A continuacion se generaran automaticamente las tablas de la base de datos

### Restauracion de base de datos
Si no deseas hacerlo por comando en la carpeta DataBase del proyecto se encuentra un script con la base de datos y registros de prueba.

## Ejecucion ⚙️

### Clone el proyecto y ejecuta la solucion 🔩

Ejucutar el archivo (solucion) en raiz con extencion de Visual Studio
Comenzara la ejecucion en SWAGER donde se puede consumir todas las peticiones
Si deseas pudes utilizar PostMand para consumir las APIs

## Construido con 🛠️

- ASP.NET 8, C# y API REST
- Inyección de dependencias, DTOs
- Entity Framework Core y LINQ
- GIT

## Convenciones utilzadas 🖇️
PascalCase y camelCase

### Variables Enstidades y DTOs
Ingles

## Versionado 📌
### GIT
Sistema de control de vesriones para mantener control de actualizaciones posteriores
### Ramas
Se utiliza Developer para el desarrollo y testeo
Se utiliza Master como rama final y proyecto completo
