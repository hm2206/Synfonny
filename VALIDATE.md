# Validación de Campos en *Synfonny*

*La validación de campos es muy importante a la hora de crear aplicaciones, pero implementarlo es muy tedioso y quita demasiado tiempo en el desarrollo.* <br/> 
*Por ese motivo **Synfonny** te provee de una clase **`Validate`**, el cual cuenta con varios métodos para validar campos*.<br/>


#### Lista de los todos los métodos individuales en `Validate`


| Nombre       | Parámetros     | Descripción        | Tipo de dato  |
|--------------|----------------|--------------------|---------------|
| required | `inputs As Object`, `tags As Object` | se verifica si un campo no este vacío: Si está vacío retorna False, si no True |`Boolean` |
| max | `inputs As Object`, `tags As Object`, `maximo As Object` | se verifica que el campo tenga como máximo **`N`** números de caracteres: Si el campo sobre pasa el limite, retorna False, si no True| `Boolean` |
| min | `inputs As Object`, `tags As Object`, `minimo As Object` | se verifica que el campo tenga como mínimo **`N`** números de caracteres: Si el campo es menor al limite, retorna False, si no True| `Boolean` | 
| number | `inputs As Object`, `tags As Object` | se verifica que los caracteres del campo sean de tipo `Numeric`, Si es de tipo `Numeric`, retorna True, si no False | `Boolean` |
| email | `inputs As Object`, `tags As Object` | se verifica que los caracteres del campo tengan un formato de `Email`, Si el campo es de formato `Email`, retorna True, si no False | `Boolean` |
| unique | `inputs As Object`, `tags As Object`, `obj As Model`, `id As Object` | se verifica que los datos ingresados en el campo, no exiesta en la base de datos, Si el registro no existe, retorna True, si no False | `Boolean`|





