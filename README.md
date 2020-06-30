# Soluci�n Insurance GAP Test
Informaci�n general: La soluci�n cuenta con 2 proyetos, uno .Net Core API y el otro .Net Core MVC Ambos se ejecutan de manera simult�nea al correr la aplicaci�n.

#### Ejecuci�n de los proyectos localmente.

1) Descargar la soluci�n del repositorio facilitado
2) Cargar la soluci�n en Visual Studio.
3) Al abrir la soluci�n, por defecto deber�a permitir la ejecucic�n de ambos proyectos simultaneamente, en caso de que esto no ocurra, modificar las propiedades de la soluci�n:
Ir al archivo de la soluci�n InsuranceGAPTest -> Propiedades -> Startup Project. Seleccionar Multiple Startup Project y seleccionar ambos proyectos MVC y API tal como se muestra en la siguiente imagen:
![N|Solid](https://i.ibb.co/XX9N48f/1.png)

4) Ejecutar la soluci�n. Al hacerlo deber� abrir 2 p�ginas web, similares a las siguientes:
![N|Solid](https://i.ibb.co/pLLbFPf/2.png)

5) La p�gina de la izquierda muestra el proyecto MVC y la derecha muestra el API en ejecuci�n, es normal que muestre el mensaje de This Page isn't working, ya que el API se encuentra protegido con Authentication, y el c�digo de error es 401.

#### Cambiar la Base de datos.
Para efectos del demo, el proyecto est� dise�ado para utilizar una instancia de base de datos en memoria, para de esta forma no depender de un recurso externo como un servidor f�sico y adem�s como es informaci�n temporal permite eliminar la misma una vez se finaliza la revisi�n.

En caso de querer conectar a un servidor local y no utilizar la facilidad de la memoria, se procede a:

1)Ir al archivo Startup.cs del proyecto API,y comentar la l�nea 45 y descomenentar la l�nea 46, tal como se muestra en la siguiente imagen:
![N|Solid](https://i.ibb.co/2ccSZtf/3.png)

2) Ir al archivo appsettings.json del proyecto API y modificar el connectionString de acuerdo a la configuraci�n de la m�quina local.
3) Ejecutar el comando update-database en el Package Manager Console para la conexi�n con el servidor local
4) Ejecutar la soluci�n de acuerdo al apartado anterior.

Gracias, saludos y bendiciones.
