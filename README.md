# Synfonny
*Framework  VB for Desktop

Crea aplicaciones de escritorio de una manera rapida y sencilla
Preocupate por el diseño que #Synfonny te provee herramientas para 
trabajar con base de datos de una manera sencilla.


## Herramientas
  
  * Conexión a la Base de datos: Mysql y SQLServer
  * Generador y Ejecución de Consultas SQL: DB y Model
  
  
### Base de Datos
  
  * **Clase DB** : Esta clase nos permite realizar consultas sql
    
    *Ejemplo:*
    
    *Obtener registros de la tabla "users"*
    
    * users 
       * id
       * name
       * created_at
       * updated_at
    
  ###### Creamos un objeto de Tipo DB 
     1. Dim db as new DB()
  
  ###### Generamos la consulta para mostrar todos los registros de la tabla "users", allBy genera el SELECT * From... 
  #### VB
     2. db.table("users").allBy()
     
  #### SQL
     1. SELECT * FROM users

  *Insertar un registro a la tabla "users"*
    
  ###### created_at y updated_at, son insertados automaticamente y createBy genera la consulta de insert into
  #### VB
    1. db.table("users").createBy({"name"}, {"Hans"})
    
  #### SQL
    1. INSERT INTO users(name, created_at, updated_at) VALUES("Hans", NOW, NOW)
     
  ###### Actualizar uno o varios registro de la table "users"
  
  *Para actualizar un registro **DB** te proporciona el metodo **updateBy** en cual
  recibe 4 parametros:*
  ***updateBy(row as Object, id as Object, attr() as Object, val() as Object)***
    
created by : ***Hans Medina*** 

email: ***twd2206@gmail.com***
