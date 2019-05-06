# Synfonny
*Framework  VB for Desktop

Crea aplicaciones de escritorio de una manera rapida y sencilla
Preocupate por el diseño que #Synfonny te provee herramientas para 
trabajar con base de datos de una manera sencilla.


## Herramientas
  
  * Conexión a la Base de datos: Mysql y SQLServer
  * Generador y Ejecución de Consultas SQL: DB y Model
  
  
### Base de Datos
  
  - **Clase DB** : Esta clase nos permite realizar consultas sql
    
    *Ejemplo:*
    
    *Obtener registros de la tabla "users"*
    
    * users 
       * id
       * name
       * created_at
       * updated_at
    
    Creamos un objeto de Tipo DB <br/>
    <b>Dim db as new DB()<b>
  
    Generamos la consulta para mostrar todos los registros de la tabla "users" <br/>
    **db.table("users").allBy()**
    
    //output
  

created by : ***Hans Medina***
email: ***twd2206@gmail.com***
