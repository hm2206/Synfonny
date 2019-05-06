# Synfonny
*Framework  VB for Desktop*

*Crea aplicaciones de escritorio de una manera rapida y sencilla
Preocupate por el diseño que #Synfonny te provee herramientas para 
trabajar con base de datos de una manera sencilla.*


## Herramientas
  
  * Conexión a la Base de datos: Mysql y SQLServer
  * Generador y Ejecución de Consultas SQL: DB y Model
  
  
### Base de Datos
  
  * **Clase DB** : Esta clase nos permite realizar consultas sql
    
    *Ejemplo:*
    
    *Primero creamos la Base de datos "prueba" y despues la tabla "users"*
    
    *Estructura:*
    
    * users 
       * id(11): Integer, AutoIncrement
       * name(40): Varchar, NOTNULL
       * created_at: Timestamp
       * updated_at: Timestamp
    
  #### Obtener registos de la tabla users
  
  _Generamos la consulta para mostrar todos los registros de la tabla "users" <br/> 
  Con los metodos **all()** y **gets** los cuales retornan un **DataTable**_
  ##### VB
     
```vb

   Dim db As New DB()
   db.table("users").all()
  
   'Tambien se puede de esta manera
   db.table("users").gets()
   
   'Tambien se puede definir que atributos se va ha obtener
   db.table("users").gets({"id"})
     
   'Tambien se puede de esta manera
   db.table("users").selects({"name"}).gets()
     
   'Tambien podemos utilizar la sentencia WHERE con sus respectivas condiciones logicas como AND y OR
   'para poder ulilizar existen 2 metodos, los cuales son where y orWhere
   db.table("users").where("id", 1).gets()

```
     
  ##### SQL
```sql

  SELECT * FROM users; // all()
  
  SELECT * FROM users; // gets()
   
  SELECT id FROM users; // gets(params)
     
  SELECT name descripcion FROM users; //  selects(params).gets()
    
   SELECT 
```
  #### Insertar un registro a la tabla "users"
    
  *created_at y updated_at, son insertados automaticamente y createBy genera la consulta de insert into*
  ##### VB
```vb

  Dim db As New DB()
  db.table("users").create({"name"}, {"Hans"})

```
    
  ##### SQL
```sql
  INSERT INTO users(name, created_at, updated_at) VALUES("Hans", NOW, NOW)
```
     
  #### Actualizar uno o varios registro de la tabla "users"
  
  *Para actualizar un registro, **DB** te proporciona el metodo **update** el cual
  retorna un **Boolean**, si todo salió bien un **True** y sino **False** y también
  recibe 2 parametros:* <br/>
  ***update(attr() As Object, val() as Object)*** <br/>
  ***attr()*** *hace referencia a los atributos que serán actualizados <br/>
  ***val()*** *son los valor que **attr()** tomará para actualizar*
  ##### VB
```vb

  Dim db As New DB() 'instanciamos la clase DB
  db.table("users")
  db.updateBy("id", 1, {"name"}, {"Lorenz"})

```
     
  ##### SQL
```sql
  UPDATE users SET name='Lorenz' WHERE id='1'
```
 
  #### Eliminar registros de la tabla "users"
 
  _Para eliminar registros, ***DB*** te proporciona el metodo ***deleteBy*** el cual
  retorna un **Boolean**, si todo salió bien un **True** y sino **False** y también
  recibe 2 parametros:_ <br/>
  ***deleteBy(row As Object, id As Object)*** <br/>
  ***row:*** *hace referencia al atributo de la tabla* <br/>
  ***id:*** *hace referencia a la condición. el cual es tomado así.* **row = id** <br/>
 
  ##### VB
```vb
  
  Dim db As New DB() 'instanciamos la clase DB
  db.table("users")
  db.deleteBy("id", 1)

```
     
  ##### SQL
```sql
  DELETE FROM users WHERE id='1'
```
     
  
created by : ***Hans Medina*** <br/>
email: ***twd2206@gmail.com***
