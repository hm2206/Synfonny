## BASE DE DATOS


### Base de Datos
  
  * **Clase DB** : Esta clase nos permite realizar consultas sql
    
    *Ejemplo:*
    
    *Primero creamos la Base de datos "prueba" y despues la tabla "users"*
    
    *Estructura:*
    
    * users 
       * id(11): Int, AutoIncrement
       * name(40): Varchar, NOTNULL
       * edad(2): Int
    
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
   'O También
   db.table("users").where("id", "<>", 1).selects({"id"}).gets()
   
   'Where AND
   db.table("users").where("name", "hans").where("edad", 19).gets()
   
   
   'Where OR
   db.table("users").where("name", "hans").orWhere("edad", 19).gets()

```
     
  ##### SQL
```sql

  SELECT * FROM users; #all()
  
  SELECT * FROM users; #gets()
   
  SELECT id FROM users; #gets(params)
     
  SELECT name, descripcion FROM users; #selects(params).gets()
    
  SELECT * FROM users WHERE id='1'  #where(params).gets()
  
  SELECT id FROM users WHERE id<>'1'  #where(params).selects(params).gets()
  
  SELECT * FROM users WHERE name='hans' AND edad='19' #where(params).where(params).gets()
  
  SELECT * FROM users WHERE name='hans' OR edad='19' #where(params).orWhere(params).gets()
```
  #### Insertar un registro a la tabla "users"
    
  *Para insertar datos a una tabla, **DB** te proporciona el metodo **create()** el cual genera la consulta SQL y la ejecuta*
  ##### VB
```vb

  Dim db As New DB()
  db.table("users").create({"name", "edad"}, {"Hans", 19})

```
    
  ##### SQL
```sql
  INSERT INTO users(name, edad) VALUES("Hans", 19)
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
  
  'Esta consulta actualizará todos los registros de la tabla users
  db.table("users").update({"name"}, {"Lorenz"})
  
  'Esta consulta actualizará solo el o los registros según la condición
  db.table("users").where("id", 1).update({"name"}, {"Lorenz"})

```
     
  ##### SQL
```sql
  UPDATE users SET name='Lorenz' # update(params)
  
  UPDATE users SET name='Lorenz' WHERE id='1' # where(params).update(params)
```
 
  #### Eliminar registros de la tabla "users"
 
  _Para eliminar registros, ***DB*** te proporciona el metodo ***delete*** el cual
  retorna un **Boolean**, si todo salió bien un **True** y sino **False** y también
  recibe 2 parametros:_ <br/>
  ***delete()*** <br/>
 
  ##### VB
```vb
  
  Dim db As New DB() 'instanciamos la clase DB
  
  'Esta consulta eliminará todos los registros
  db.table("users").delete()
  
  'Esta consulta eliminará los resgistros según la condición
  db.table("users").where("id", 1).delete()
  
```
     
  ##### SQL
```sql
  DELETE FROM users # delete()

  DELETE FROM users WHERE id='1' # where(params).delete()
```


### Todos los metodos de la clase DB


| Nombre                  | Parametros          |  Descripción                  | Tipo de dato   |
| :---------------------: | :-----------------: |:-----------------------------:|:--------------:|
| table()                 |  t As Object        | configurar nombre de la tabla | DB             |
| selects()               | attr() As Object    | configura los atributos de la consulta SQL | DB|
| selectConcat()          | attr() As Object    | agregar más atributos a la consulta SQL | DB   |
| join()                  | t2 As Object, val1 As Object, val2 As Object | Agrega un INNER JOIN a la consulta SQL | DB |
| where()                 | val1 As Object, signo As Object, val2 As Object | Agrega un Where o AND a la consulta SQL | DB |
| where()                 | val1 As Object, val2 As Object | Agrega un Where o AND a la consulta SQL, pero con el operador lógico de "**=**" | DB |
| orWhere()               | val1 As Object, signo As Object, val2 As Object | Agrega un Where o OR a la consulta SQL | DB |
| orWhere()               | val1 As Object, val2 As Object | Agrega un Where o OR a la consulta SQL, pero con el operador lógico de "**=**" | DB |
| create()                | attr() As Object, val() As Object | genera y ejecuta la consulta INSERT INTO | DataTable |
| update()                | attr() As Object, val() As Object | genera y ejecuta la consulta UPDATE {table} SET {...params} | Boolean |
| delete()                | NULL               | genera y ejecuta la consulta DELETE FROM {table} | Boolean |
| rawReturn()             | sql As Object      | genera y ejecuta una consulta RAW(cualquiera) | DataTable |
| raw()                   | sql As Object      | genera y ejecuta una consulta RAW(cualquiera) | Boolean   |
| gets()                  | NULL               | genera y ejecuta una consulta SELECT * FROM {table} | DataTable |
| gets()                  | attr() As Object   | genera y ejecuta una consulta SELECT {attr} FROM {table} | DataTable |



***Clase Relacionada***

- [ORM MODEL](https://github.com/jocker2206/Synfonny/blob/master/Model.md)
