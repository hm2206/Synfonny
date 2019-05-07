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
    
    movie.create({"name_movie", "copies", "email_empresa"}, {Me.txtName.Text, Me.txtCopies.Text, Me.txtEmail.Text})
    MsgBox("La película fue creada correctamente")
    
  End If
  

```


*El ejemplo anterior se utiliza cuando los campos a validar son pocos, pero si tienes que validar varios campos como por ejemplo: <br/>*
*los campos `txtName, txtEmail, txtCopies` deben ser obligatorios. <br/>
*el campo `txtEmail` debe tener el formato de `email`
*el campo `txtCopies` debe ser de tipo `Numeric`

##### VB

`
  'Utilizando los metodos anteriores
  
  Dim val As New Validate()
  
  val.required(Me.txtName.Text, "name")
  val.required(Me.txtEmail.Text, "email")
  val.email(Me.txtEmail.Text, "email")
  val.required(Me.txtCopies.Text, "copies")
  val.number(Me.txtCopies.Text, "copies")

`

*El ejemplo anterior es muy verboso y ocupa muchas líneas de codigo. La clase **Validate** también te permite <br/>
validar varios campos y que cada campo pueda tener varias validaciones.*

> Los unicos métodos disponibles son `required`, `email` y `number`


#### Lista de los todos los métodos de validación masiva en `Validate`


| Nombre       | Parámetros     | Descripción        | Tipo de dato  |
|--------------|----------------|--------------------|---------------|
| verify       | `input As Object`, `tag As Object`, `validates() As Object` | se encarga de validar los campos con los métodos disponibles en la función. Si cualquiera de los métodos retorna False, el método retornará `False`, sino `True`|Boolean|
| verifyBy     | `tags() As Object`, `methods() As Object` | se encarga de validar varios campos a la vez, con los métodos disponibles en la función. Si cualquiera de los métodos retorna False, el método retornará `False`, sino `True`|Boolean|



#### Descrición de los parámetros

* **`input`**: Hace referencia al `texto` de los `TextBox, RichTextBox`
* **`tag`**: sirve para utilizarlo, como nombre en un `MsgBox("el campo {tags} es {...[required, email, min...]}")`
* **`validates()`**: sirve para describir los métodos que se van a ejecutar al momento de validar el campo
* **`tags`**: sirve para acceder a los valores de los campos. tambien se utiliza como `tag`

> !Para poder utilizar el método **`verifyBy`** es necesario utilizar el método **`prepared`**
> El método recibe `inputs` y `tags`, estos parametros ya utilizamos en los `métodos individuales` que están arriba.
> Primero se invoca el método `prepared` y luego el `verifyBy`


*Ejemplo 1:*
*Vamos a utilizar el ejemplo anterior de las películas... <br/>
Pero con el método `verify`*


##### VB
```vb
  
  Dim val As New Validate()
  
  'Utilizando el método verify y campararemos con los métodos anteriomente utlizados.
  
  'el campo TextName debe de ser obligatorio
  val.required(Me.txtName.Text, "name") 'método required
  val.verify(Me.txtName.Text, "name", {"required"}) 'método verify
  
  
  'el campo TextEmail debe de ser obligatorio y de formato Email
  val.required(Me.txtEmail.Text, "email") 'método required
  val.email(Me.txtEmail.Text, "email") 'método email
  val.verify(Me.txtEmail.Text, "email", {"required","email"}) 'método verify
  
  
  'el campo TextCopies debe de ser obligatorio y de tipo Numeric
  val.required(Me.txtCopies.Text, "copies") 'método required
  val.number(Me.txtCopies.Text, "copies") 'método number
  val.verify(Me.txtCopies.Text, "copies", {"required","number"}) 'método verify
  

```



*Ejemplo 2:*
*Vamos a utilizar el ejemplo anterior de las películas... <br/>
Pero con el método `verifyBy`*


##### VB
```vb

  'utilizando los métodos individuales
  Dim val As New Validate()
  
  val.required(Me.txtName.Text, "name")
  val.required(Me.txtEmail.Text, "email")
  val.email(Me.txtEmail.Text, "email")
  val.required(Me.txtCopies.Text, "copies")
  val.number(Me.txtCopies.Text, "copies")
  
  
  'utilizando el método verifyBy
  
  'configurando los campos que se van a poder validar
  val.prepared({Me.txtName.Text, Me.txtEmail.Text, Me.txtCopies.Text}, {"name","email","copies"})
  
  'realizando validaciones multiples, por medio de su tag
  val.verifyBy({"name", "email", "copies"}, {"required", "required|email", "required|number"})


```

