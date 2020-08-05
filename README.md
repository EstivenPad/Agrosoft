# Agrosoft

![Logo de Agrosoft](https://user-images.githubusercontent.com/54590857/88723611-2dac7d80-d0f7-11ea-9f4d-44174f64392b.jpg)

Hoy en día se ve como cada vez más los sistemas manuales son desplazados, dando paso a los sistemas automatizados, los cuales nos ofrecen un amplio abanico de posibilidades. Y en un área como la agroproducción estas posibilidades son muy rentables permitiendo el ahorro de espacio, tiempo y dinero.

Agrosoft es un sistema informático desarrollado para la plataforma Web, el cuál tiene como objetivo optimizar y automatizar el proceso de compra y venta de productos agricolas en conjunto con otros modulos caracteristicos de un sistema informático de compra y venta como son: Usuarios, Clientes, Productos, Cobros, etc.

**Link de Agrosoft:** _https://agrosoft20200805171159.azurewebsites.net_

## 🔒 Login

![image](https://user-images.githubusercontent.com/54590857/89126917-b6406a80-d4b7-11ea-956d-fe906d699878.png)

Este es el Login del sistema en el cual el usuario deberá loguearse para poder acceder al sistema. Si es la primera vez que se ejecuta el sistema, existe un usuario creado por defecto con accesos de **"Administrador/a"**, cuyo **Nombre de Usuario** y **Contraseña** son: _**Admin**_ y _**admin**_ respectivamente.

## 📌 Menú

![image](https://user-images.githubusercontent.com/54590857/89125874-72e1fe00-d4af-11ea-9619-d11c2b1b2952.png)

Este es el menú en el cual podrá desplazarse a través de los diferentes registros y consultas. También se muestra el usuario logueado.

## 📝 Registros

### Registro de usuarios

![image](https://user-images.githubusercontent.com/54590857/89126032-8346a880-d4b0-11ea-990f-f89ca8e26a48.png)

Este es el registro de usuarios, a la hora de crear un usuario se debe elegir el tipo de usurio, de entre las posibles opciones están:

* **Administrador/a:** Este tiene acceso a todos los módulos del sistema y es el único capaz de crear nuevos usuarios y consultarlos.
* **Empleado/a:** Este sólo tiene acceso a los siguiente módulos: Clientes, Proveedores, Productos, Marcas, Compras, Ventas y Cobros.

### Registro de proveedores

![image](https://user-images.githubusercontent.com/54590857/89126187-c5241e80-d4b1-11ea-8850-1f2a2af9d6a6.png)

Este es el registro de proveedores, en este registro se agregan los datos de los proveedores a los cuales se les encargará la compra de los productos.

### Registro de clientes

![image](https://user-images.githubusercontent.com/54590857/89126375-30babb80-d4b3-11ea-8331-8b80cf32845b.png)

Este es el registro de clientes, donde podrá agregar los clientes a los que se les podrán realizar ventas.

### Registro de cobros

![image](https://user-images.githubusercontent.com/54590857/89127058-9f4e4800-d4b8-11ea-9615-8029509cbe57.png)

Este es el registro de cobros con el cuál podrá registrar los cobros que afectarán el balance de los clientes que realizaron una compra a crédito.

### Registro de productos

![image](https://user-images.githubusercontent.com/54590857/89126294-a70aee00-d4b2-11ea-8a7a-44f0d4ce6a9d.png)

Este es el registro de productos, este formulario es donde se registrarán los productos que podrán ser comprados. Cabe destacar, que el costo del producto no puede ser mayor que el precio. En caso que el usuario lo coloque de esta forma, no se podrá guardar.

### Registro de marcas

![image](https://user-images.githubusercontent.com/54590857/89126405-6fe90c80-d4b3-11ea-9914-58caa848fe0e.png)

Este es el registro de marcas las cuales se identificaran en cada producto registrado.

### Registro de compra de productos

Imagen

Este es el registro de compra de productos, en este es donde se realizarán las compras de los productos ya registrados. Para ello se debe de seleccionar un Proveedor y un Producto, luego se ingresa la cantidad, y automáticamente se llenan los campos: Marca, Unidad de medida, Costo e Importe. Para agregar dicho producto a la compra, se le da clic al botón 'Agregar'.

En caso de no tener algún proveedor o algún producto registrado, desde ésta ventana se puede hacer. Si es para agregar un proveedor, se procede a dar clic al botón '+' que está a su lado. En caso que desee agregar un producto, es similar, se procede a dar clic al botón '+' que está a su lado.

### Registro de venta de productos

![image](https://user-images.githubusercontent.com/54590857/89126568-7deb5d00-d4b4-11ea-87a2-f975cd21cb82.png)

Este es el registro de venta de productos, en este es donde se realizarán las ventas de los productos ya registrados. Para ello se debe de seleccionar un Tipo de factura, si la factura es "Al contado" entonces el cliente será 'Cliente ocasional', por el contrario, si la factura es 'A crédito' entonces debe de seleccionar un Cliente, y automáticamente se llenarán los campos de Balance y Limite de crédito. Después debe seleccionar un producto y la cantidad que el cliente desea comprar de ese producto, y automaticamente se llenarán los campos: Precio unitario e Importe. Para agregar dicho producto a la factura, se le da clic al botón 'Agregar'.

Si desea registrar un Cliente o un Producto sin dirigirse al menú, lo puede hacer a través de este mismo registro. Si es para agregar un Cliente, se procede a dar clic al botón '+' que está a su lado. En caso que desee agregar un Producto, es similar, se procede a dar clic al botón '+' que está a su lado.

Si desea imprimir la factura, primero debe guardarla para que quede registrada, luego se procede a buscarla y se da clic en el botón 'Imprimir', después se mostrará un modal con una previsualización de la factura, como esta:

![image](https://user-images.githubusercontent.com/54590857/89126888-7aa5a080-d4b7-11ea-9069-3a94d70b7431.png)

## 🗃 Consultas

Cada registro antes mencionado tiene una consulta. Las consultas pueden ser accesibles por todos los tipos de usuarios, excepto la consulta de usuarios, a quien sólo tiene permitido acceder el adminitrador/a.

![image](https://user-images.githubusercontent.com/54590857/89429797-0283e880-d70c-11ea-97c6-91449b7e587d.png)

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
