# Agrosoft

![Logo de Agrosoft](https://user-images.githubusercontent.com/54590857/88723611-2dac7d80-d0f7-11ea-9f4d-44174f64392b.jpg)

Hoy en día se ve como cada vez más los sistemas manuales son desplazados, dando paso a los sistemas automatizados, los cuales nos ofrecen un amplio abanico de posibilidades. Y en un área como la agroproducción estas posibilidades son muy rentables permitiendo el ahorro de espacio, tiempo y dinero.

Agrosoft es un sistema informático desarrollado para la plataforma Web, el cuál tiene como objetivo optimizar y automatizar el proceso de compra y venta de productos agricolas en conjunto con otros modulos caracteristicos de un sistema informático de compra y venta como son: Usuarios, Clientes, Productos, Cobros, etc.

## 🔒 Login

Imagen

Este es el Login del sistema en el cual el usuario deberá loguearse para poder acceder al sistema. Si es la primera vez que se ejecuta el sistema, existe un usuario creado por defecto con accesos de **"Administrador/a"**, cuyo **Nombre de Usuario** y **Contraseña** son: _**Admin**_ y _**admin**_ respectivamente.

## 📌 Menú

Imagen

Este es el menú en el cual podrá desplazarse a través de los diferentes registros y consultas. También se muestra el usuario logueado.

## 📝 Registros

### Registro de usuarios

Imagen

Este es el registro de usuarios, a la hora de crear un usuario se debe elegir el tipo de usurio, de entre las posibles opciones están:

* **Administrador/a:** Este tiene acceso a todos los módulos del sistema y es el único capaz de crear nuevos usuarios y consultarlos.
* **Empleado/a:** Este sólo tiene acceso a los siguiente módulos: Clientes, Proveedores, Productos, Marcas, Compras, Ventas y Cobros.

### Registro de proveedores

Imagen

Este es el registro de proveedores, en este registro se agregan los datos de los proveedores a los cuales se les encargará la compra de los productos.

### Registro de clientes

Imagen

Este es el registro de clientes, donde podrá agregar los clientes a los que se les podrán realizar ventas.

### Registro de cobros

Imagen

Este es el registro de cobros con el cuál podrá registrar los cobros que afectarán el balance de los clientes que realizaron una compra a crédito.

### Registro de productos

Imagen

Este es el registro de productos, este formulario es donde se registrarán los productos que podrán ser comprados. Cabe destacar, que el costo del producto no puede ser mayor que el precio. En caso que el usuario lo coloque de esta forma, no se podrá guardar.

### Registro de marcas

Imagen

Este es el registro de marcas las cuales se identificaran en cada producto registrado.

### Registro de compra de productos

Imagen

Este es el registro de compra de productos, en este es donde se realizarán las compras de los productos ya registrados. Para ello se debe de seleccionar un Proveedor y un Producto, luego se ingresa la cantidad, y automáticamente se llenan los campos: Marca, Unidad de medida, Costo e Importe. Para agregar dicho producto a la compra, se le da clic al botón 'Agregar'.

En caso de no tener algún proveedor o algún producto registrado, desde ésta ventana se puede hacer. Si es para agregar un proveedor, se procede a dar clic al botón '+' que está a su lado. En caso que desee agregar un producto, es similar, se procede a dar clic al botón '+' que está a su lado.

### Registro de venta de productos

Imagen

Este es el registro de venta de productos, en este es donde se realizarán las ventas de los productos ya registrados. Para ello se debe de seleccionar un Tipo de factura y un Cliente, y automáticamente se llenarán los campos: Balance y Limite de crédito. Después debe seleccionar un producto y la cantidad que el cliente desea comprar de ese producto, y automaticamente se llenarán los campos: Precio unitario e Importe. Para agregar dicho producto a la factura, se le da clic al botón 'Agregar'.

Si desea registrar un Cliente o un Producto sin dirigirse al menú, lo puede hacer a través de este mismo registro. Si es para agregar un Cliente, se procede a dar clic al botón '+' que está a su lado. En caso que desee agregar un Producto, es similar, se procede a dar clic al botón '+' que está a su lado.

## 🗃 Consultas

Cada registro antes mencionado tiene una consulta. Las consultas pueden ser accesibles por todos los tipos de usuarios, excepto la consulta de usuarios, a quien sólo tiene permitido acceder el adminitrador/a.

Imagen de cualquier consulta

Todas las consultas funcionan de la misma manera, en estas se pueden realizar consultas específicas de los registros que se tengan guardados, también se permite filtrar por diversos campos así como también por un rango de fecha. Además de incluir un botón llamado "Imprimir" con el que podremos visualizar los registros consultados con anterioridad en un reporte como el siguiente:

Imagen de un reporte

## 🛠️ Herramientas 

* Visual Studio (Blazor Server).
* SQLite.
* Photoshop CC (Para el logo de la empresa).
* Google Chrome.

## ✒️ Desarrolladores 

* _**Estiven de Jesús Padilla Santos (2017-0596).**_
* _**José Armando Flores Baldera (2017-0599).**_
