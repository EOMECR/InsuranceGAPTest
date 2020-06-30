# Solución Insurance GAP Test
Información general: La solución cuenta con 2 proyetos, uno .Net Core API y el otro .Net Core MVC Ambos se ejecutan de manera simultánea al correr la aplicación.

#### Ejecución de los proyectos localmente.

1) Descargar la solución del repositorio facilitado
2) Cargar la solución en Visual Studio.
3) Al abrir la solución, por defecto debería permitir la ejecucicón de ambos proyectos simultaneamente, en caso de que esto no ocurra, modificar las propiedades de la solución:
Ir al archivo de la solución InsuranceGAPTest -> Propiedades -> Startup Project. Seleccionar Multiple Startup Project y seleccionar ambos proyectos MVC y API tal como se muestra en la siguiente imagen:
![N|Solid](https://i.ibb.co/XX9N48f/1.png)

4) Ejecutar la solución. Al hacerlo deberá abrir 2 páginas web, similares a las siguientes:
![N|Solid](https://i.ibb.co/pLLbFPf/2.png)

5) La página de la izquierda muestra el proyecto MVC y la derecha muestra el API en ejecución, es normal que muestre el mensaje de This Page isn't working, ya que el API se encuentra protegido con Authentication, y el código de error es 401.

#### Cambiar la Base de datos.
Para efectos del demo, el proyecto está diseñado para utilizar una instancia de base de datos en memoria, para de esta forma no depender de un recurso externo como un servidor físico y además como es información temporal permite eliminar la misma una vez se finaliza la revisión.

En caso de querer conectar a un servidor local y no utilizar la facilidad de la memoria, se procede a:

1)Ir al archivo Startup.cs del proyecto API,y comentar la línea 45 y descomenentar la línea 46, tal como se muestra en la siguiente imagen:
![N|Solid](https://i.ibb.co/2ccSZtf/3.png)

2) Ir al archivo appsettings.json del proyecto API y modificar el connectionString de acuerdo a la configuración de la máquina local.
3) Ejecutar el comando update-database en el Package Manager Console para la conexión con el servidor local
4) Ejecutar la solución de acuerdo al apartado anterior.

Gracias, saludos y bendiciones.
