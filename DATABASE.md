## BASE DE DATOS


### Base de Datos
  
  * **Utilizando la clase DB**
    
    *Ejemplo:*
    
    ```vb
      Dim db as new DB()
    ```
    
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
| limite()                | valor As Object     | agregar LIMIT {valor} a la consulta SQL | DB   |
| limite()                | valor1 As Object, valor2 as Object | agregar LIMIT {valor1}, {valor2} a la consulta SQL | DB   |
| join()                  | t2 As Object, val1 As Object, val2 As Object | Agrega un INNER JOIN a la consulta SQL | DB |
| innerJoin()             | t2 As Object, val1 As Object, val2 As Object | Agrega un INNER JOIN a la consulta SQL | DB |
| leftJoin()              | t2 As Object, val1 As Object, val2 As Object | Agrega un LEFT JOIN a la consulta SQL | DB |
| rightJoin()             | t2 As Object, val1 As Object, val2 As Object | Agrega un RIGHT JOIN a la consulta SQL | DB |
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


* **Utilizando la Clase Model**

*Para comenzar a utilizar la Clase **Model** usted debe seguir varias reglas*

1. Debe crear una Clase en **VB** con el nombre en singular(***Item.vb***) en la ruta ``` ./app/models/Item.vb ```
2. Crear tabla pero en plural(***items***) con 2 atributos obligatorios: **created_at y updated_at** de tipo  **timestamp**
```sql
  # Items
  
  CREATE TABLE items(
    id INT(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    descripcion VARCHAR(40),
    created_at TIMESTAMP,
    updated_at TIMESTAMP
  )
  
```
3. A la clase creada(***Item***), se le debe de heredar la clase "***Model***" Ejemplo:

#### Item.vb
```vb  

Public Class Item
    Inherits Model

End Class

```

4. Guardar cambios y manos a la obra 

##### Información de Model
* La clase ***Model***, resuelve el nombre de la tabla de la siguiente manera:
* Model toma el nombre de la clase instanciada(***Item***) y luego lo convierte en plural.
* También es posible ingresar el nombre de la tabla de manera manual, eso es posible gracias al metodo **setTable()**

```vb
  
   'Item.vb
   
Public Class Item
    Inherits Model

    'Es necesario crear un constructor y realizar los SETTING dentro de el
    Sub New()
        Me.setTable("articulo") 'Aquí se renombra la tabla de manera manual
    End Sub

End Class
   
  
```

* Por norma de la clase **Model**, esta espera que como llave primaria de la tabla, sea ``` id ``` de caso contrario, la consulta no se realizarán como se esperba
* También es posible configurar el nombre de la llave primaria, para hacerlo solo se debe agregar un atributo publico con en nombre de ***primaryKey*** y con un valor inicial
```vb
  
   'Item.vb
   
Public Class Item
    Inherits Model
    
    Public primaryKey As Object = "articulo_id"

    'Es necesario crear un constructor y realizar los SETTING dentro de el
    Sub New()
        Me.setTable("articulo") 'Aquí se renombra la tabla de manera manual
    End Sub

End Class
   
  
```


##### Obtener Registos

*Para poder realizar esta operación, Las Clases heredadas de "***Model***" cuentán con el metodo **all() y gets()*** <br/>
*Más adelante veremos otras maneras de realizar dicha operación

###### Información
*Los metodos ***all() y gets()*** retornan un Objeto **DataTable** .* <br/>
*También están disponibles los metodos ***where*** , ***orWhere*** y ***selects*** los cuales funcionan igual,
modificando la consulta antes de ser ejecutada.*
*Para mayor información de los metodos ***where*** , ***orWhere*** y ***selects***, revisar la documentación de la clase **DB**

*Ejemplo: Obtener registos y pasarlo a una grilla(**DataGridView**)

##### VB
```vb
  Dim item As New Item() 'Instanciamos la clase Item
  
  'obtener todos los registos con el metodo all()
  Me.myDataGridView.DataSource = item.all()
  
  'obtener todos los registos con el metodo gets()
  Me.myDataGridView.DataSource = item.gets()
  
  'obtener todos los registos con el metodo gets(params)
  Me.myDataGridView.DataSource = item.gets({"descripcion"})
  
  'obtener todos los registos con el metodo where y gets(params)
  Me.myDataGridView.DataSource = item.where("descripcion", "coffee").gets({"descripcion"})
  
  'obtener todos los registos con el metodo where, selects y gets
  Me.myDataGridView.DataSource = item.where("descripcion", "coffee").selects({"descripcion"}).gets()
  
  'obtener todos los registos con el metodo where, orWhere y gets
  Me.myDataGridView.DataSource = item.where("descripcion", "coffee").orWhere("id", "1").gets()
  
  'obtener todos los registos con el metodo where y gets
  Me.myDataGridView.DataSource = item.where("descripcion", "coffee").where("id", "1").gets()
  
```

##### SQL

```sql
  SELECT * FROM items # all()
  
  SELECT * FROM items # gets()
  
  SELECT descripcion FROM items # gets(params)
  
  SELECT descripcion FROM items WHERE descripcion='coffee' # where(params).gets(params)
  
  SELECT descripcion FROM items WHERE descripcion='coffee' # where(params).selects(params)gets()
  
  SELECT * FROM items WHERE descripcion='coffee' OR id='1' # where(params).orWhere(params)gets()
  
  SELECT * FROM items WHERE descripcion='coffee' AND id='1' # where(params).where(params)gets()
```


- [Synfonny](https://github.com/jocker2206/Synfonny/)
