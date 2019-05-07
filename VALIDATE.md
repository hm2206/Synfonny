# Validación de Campos en *Synfonny*

*La validación de campos es muy importante a la hora de crear aplicaciones, pero implementarlo es muy tedioso y quita demasiado tiempo en el desarrollo.* <br/> 
*Por ese motivo **Synfonny** te provee de una clase **`Validate`**, el cual cuenta con varios métodos para validar campos*.<br/>


#### Lista de los todos los métodos individuales en `Validate`


| Nombre       | Parámetros     | Descripción        | Tipo de dato  |
|--------------|----------------|--------------------|---------------|
| required | `inputs As Object`, `tags As Object` | se verifica si un campo no este vacío: Si está vacío retorna False, sino True |`Boolean` |
| max | `inputs As Object`, `tags As Object`, `maximo As Object` | se verifica que el campo tenga como máximo **`N`** números de caracteres: Si el campo sobre pasa el limite, retorna False, sino True| `Boolean` |
| min | `inputs As Object`, `tags As Object`, `minimo As Object` | se verifica que el campo tenga como mínimo **`N`** números de caracteres: Si el campo es menor al limite, retorna False, si no True| `Boolean` | 
| number | `inputs As Object`, `tags As Object` | se verifica que los caracteres del campo sean de tipo `Numeric`, Si es de tipo `Numeric`, retorna True, sino False | `Boolean` |
| email | `inputs As Object`, `tags As Object` | se verifica que los caracteres del campo tengan un formato de `Email`, Si el campo es de formato `Email`, retorna True, sino False | `Boolean` |
| unique | `inputs As Object`, `tags As Object`, `obj As Model`, `id As Object` | se verifica que los datos ingresados en el campo, no exista en la base de datos, Si el registro no existe, retorna True, sino False | `Boolean`|


#### Descrición de los parámetros

* **`inputs`**: Hace referencia al `texto` de los `TextBox, RichTextBox`
* **`tags`**: sirve para utilizarlo, como nombre en un `MsgBox("el campo {tags} es {...[required, email, min...]}")`
* **`maximo, minimo`**: sirve para limitar el número de caracteres, con sus metodos correspondientes
* **`obj`**: sirve para obtener la consulta `SQL`, para déspues ser ejecutada
* **`id`**: Hace referencia al atributo de la tabla, el cual será validado con el `inputs` *ejempo: `SELECT * FROM {obj.table} WHERE {id}='{inputs}'` 


*Ejemplos:*

* Creamos un `Windows Forms`
* Agregamos varios `TextBox` al `Windows Forms`
* Cambiamos los nombres de las varibles de los `TextBox` *ejemplo: (txtName, txtEmail, txtCopies)*

*!Para este ejemplo se utilizara la tabla `movies` y una clase `Movie` que herede de `Model`.
Los atributos de la tabla son: `id, name_movie, copies, email_empresa, created_at, updated_at`!*

##### VB
```vb

  Dim val As New Validate()
  
  'Método required
  val.required(Me.txtName.Text, "name")
  'También es posible guardar el resultado
  Dim notIsEmptyName As Boolean = val.required(Me.txtName.Text, "name")
  
  
  'Método max
  val.max(Me.txtName.Text, "name", 20)}
  'También es posible guardar el resultado
  Dim CharsIsLessOfRange As Boolean = val.max(Me.txtName.Text, "name", 20)}
  
  
  'Método min
  val.min(Me.txtName.Text, "name", 5)
  'También es posible guardar el resultado
  Dim CharsIsMajorOfRange As Boolean = val.min(Me.txtName.Text, "name", 5)}
  
  
  'Método number
  val.number(Me.txtCopies.Text, "copies")
  'También es posible guardar el resultado
  Dim isNumber As Boolean = val.number(Me.txtCopies.Text, "copies")
  
  
  'Método email
  val.email(Me.txtEmail.Text, "email")
  'También es posible guardar el resultado
  Dim isEmail As Boolean = val.email(Me.txtEmail.Text, "email")
  
  
  'Método unique
  'Primero creamos un obj de tipo Model
  Dim movie As New Movie()
  
  'Ahora verificamos si el nombre de la película existe
  val.unique(Me.txtName.Text, "name", movie, "name_movie")
  
  'También es posible almacenar el resultado
  Dim NotFoundMovie As Boolean = val.unique(Me.txtName.Text, "name", movie, "name_movie")
  
  If notIsEmptyName AND CharsIsLessOfRange _ 
    AND CharsIsLessOfRange AND isNumber _ 
    AND isEmail AND NotFoundMovie Then
    
    movie.create({"name_movie", "copies"}, {Me.txtName.Text, Me.txtCopies})
    MsgBox("La película fue creada correctamente")
    
  End If
  

```




