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
    
  ##### Obtener registos de la tabla users
  
  *Generamos la consulta para mostrar todos los registros de la tabla "users", allBy genera el SELECT * From...*
  #### VB
     1. Dim db As New DB()
     2. db.table("users").allBy()
     
  #### SQL
     1. SELECT * FROM users

  ##### Insertar un registro a la tabla "users"
    
  *created_at y updated_at, son insertados automaticamente y createBy genera la consulta de insert into*
  #### VB
    1. Dim db As New DB()
    2. db.table("users").createBy({"name"}, {"Hans"})
    
  #### SQL
    1. INSERT INTO users(name, created_at, updated_at) VALUES("Hans", NOW, NOW)
     
  ##### Actualizar uno o varios registro de la table "users"
  
  *Para actualizar un registro, **DB** te proporciona el metodo **updateBy** en cual
  recibe 4 parametros:* <br/>
  ***updateBy(row as Object, id as Object, attr() as Object, val() as Object)*** <br/>
  ***row:*** *hace referencia al atributo de la tabla* <br/>
  ***id:*** *hace referencia a la condición. el cual es tomado así.* **row = id** <br/>
  ***attr()*** *hace referencia a los atributos que serán actualizados <br/>
  ***val()*** *son los valor que **attr()** tomará para actualizar*
  #### VB
     1. Dim db As New DB() 'instanciamos la clase DB
     2. db.table("users")
     3. db.updateBy("id", 1, {"name"}, {"Lorenz"})
     
  #### SQL
     1. UPDATE users SET name='Lorenz'
 
  
  
  
  
created by : ***Hans Medina*** 

email: ***twd2206@gmail.com***
