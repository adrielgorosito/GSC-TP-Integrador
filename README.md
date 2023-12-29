# GSC-TP-Integrador
Trabajo práctico final realizado para el curso fullstack brindado por el Grupo San Cristóbal en conjunto con la UTN FRRo.

## Idea principal
La idea es desarrollar un sistema de préstamos de "cosas" (es decir, objetos). 
¿A quién no le sucedió que le prestó algo a un/a amigo/a y más tarde se olvidó a quién se lo prestó y cuándo? La idea de este sistema es ayudarnos a recordar a qué persona y en qué momento se lo prestamos.

## Modelo de dominio propuesto por el curso
![imagen](https://github.com/adrielgorosito/GSC-TP-Integrador/assets/70348592/a1a8ff06-e671-4cc1-bc1a-4144c58b2253)

Finalmente opté por usar el modelo de dominio propuesto, agregándole a cada entidad el atributo "Id" para identificarla (salvo a la entidad "Persona", la cual tiene como clave primaria el atributo "Dni").

## Requerimientos

### Requisitos técnicos
-	App en NetCore 7 u 8, utilizando el ORM EntityFramework Core en toda la solución. *(en mi caso, utilicé NetCore 8)*
-	Uso de Angular para el frontend. *(en mi caso, utilicé Angular 16.1.1)*
-	La solución debe ser entregada en Github y compartida con el profesor.

### Requisitos de negocio
-	Alta de Categorías por defecto en una aplicación de consola (o WebAPI). La aplicación solo debe agregar las categorías en caso de que las mismas no existan.
-	ABM de Personas con Web API.
-	ABM de Cosas con Web API.
-	Marcar el préstamo como devuelto con una llamada de gRPC.
-	Proyecto de UnitTests que pruebe un controller (proyecto de WebAPI).
-	Del lado del frontend (Angular), armar una página de Login, que me permita acceder al sistema (Llamando a las APIs de Autenticacion). Una vez ingresado vamos a poder acceder a un ABM de personas la cual debe estar segurizada usando JWT. *(en mi caso, decidí segurizar todos los ABM)*.

### Requisitos opcionales
-	Implementar Logging en archivos.
-	Implementar Automapper.

### Imágenes de la aplicación
*Login*
- Usuario: **admin**
- Contraseña: **12345**

![imagen](https://github.com/adrielgorosito/GSC-TP-Integrador/assets/70348592/c3f1e953-2720-4c94-a781-bb5fd48a8da7)

*Lista de personas*

![imagen](https://github.com/adrielgorosito/GSC-TP-Integrador/assets/70348592/59020acc-29f5-4e86-bd1f-f618b20f631f)

*Click en borrar o en búsqueda por dni*

![imagen](https://github.com/adrielgorosito/GSC-TP-Integrador/assets/70348592/cfdffadd-6b0d-4e37-a119-ef27a75e1402)

*Agregar nueva persona*

![imagen](https://github.com/adrielgorosito/GSC-TP-Integrador/assets/70348592/42e9c332-3395-4cb1-bd7a-38f02bde7a6c)

## El curso
Fueron 20 clases sincrónicas (de 3 horas cada una) y dos meses y medio de mucho aprendizaje. 
En lo personal, completar este curso fue muy desafiante, más que nada por las últimas semanas de cursado y el rejunte de parciales, así cómo también tener la tarea de aprender nuevos lenguajes de programación. 
Quiero agradecer a los profesores:
- Luciano Diamand (profesor de frontend).
- Héctor Stessens (profesor de backend).
- Walter Casella (profesor de backend).

Por el arduo trabajo que hicieron y por la predisposición a lo largo del curso. Demostraron interés por nuestro aprendizaje, estando disponibles para cualquier consulta. Gracias a ellos, puedo decir que aprendí muchísimo tanto de Angular como de .NET.<br>
También, quiero darle las gracias a los profesores Andrés Otaduy y Patricio Cullen (a quién también tuve en la asignatura "Metodologías ágiles") por las dos clases magistrales que dieron de Angular y Scrum respectivamente. <br>
Por último, agradecer a Julieta Valenzuela, de Personal y Bienestar, quién estuvo siempre atenta a nuestras inquietudes y nos trató con mucho cariño cada vez que fuimos al edificio del Grupo San Cristóbal.

### Repositorio del cursado
https://github.com/adrielgorosito/GSC-curso-practica

### Tecnologías vistas a lo largo del curso
<div align="center">
  <code><img width="50" src="https://user-images.githubusercontent.com/25181517/117447155-6a868a00-af3d-11eb-9cfe-245df15c9f3f.png" alt="JavaScript" title="JavaScript"/></code>
  <code><img width="50" src="https://user-images.githubusercontent.com/25181517/183890598-19a0ac2d-e88a-4005-a8df-1ee36782fde1.png" alt="TypeScript" title="TypeScript"/></code>
	<code><img width="50" src="https://user-images.githubusercontent.com/25181517/183890595-779a7e64-3f43-4634-bad2-eceef4e80268.png" alt="Angular" title="Angular"/></code>
	<code><img width="50" src="https://user-images.githubusercontent.com/25181517/192107854-765620d7-f909-4953-a6da-36e1ef69eea6.png" alt="HTTP" title="HTTP"/></code>
  <code><img width="50" src="https://user-images.githubusercontent.com/25181517/121405384-444d7300-c95d-11eb-959f-913020d3bf90.png" alt="C#" title="C#"/></code>
  <code><img width="50" src="https://user-images.githubusercontent.com/25181517/121405754-b4f48f80-c95d-11eb-8893-fc325bde617f.png" alt=".NET Core" title=".NET Core"/></code>
  <code><img width="50" src="https://codeopinion.com/wp-content/uploads/2017/10/Bitmap-MEDIUM_Entity-Framework-Core-Logo_2colors_Square_Boxed_RGB-300x300.png" alt="EFCore" title="EFCore"/></code>
  <code><img width="50" height="50" src="https://i.pinimg.com/originals/3e/55/df/3e55dfb0980956b42cac768b740cdad6.png" alt="SQL Server" title="SQL Server"/></code>
	<code><img width="50" src="https://user-images.githubusercontent.com/25181517/192107858-fe19f043-c502-4009-8c47-476fc89718ad.png" alt="REST" title="REST"/></code>
	<code><img width="50" src="https://user-images.githubusercontent.com/25181517/186711335-a3729606-5a78-4496-9a36-06efcc74f800.png" alt="Swagger" title="Swagger"/></code>
	<code><img width="50" src="https://user-images.githubusercontent.com/25181517/192109061-e138ca71-337c-4019-8d42-4792fdaa7128.png" alt="Postman" title="Postman"/></code>
  <code><img width="50" src="https://user-images.githubusercontent.com/25181517/192107855-e669c777-9172-49c5-b7e0-404e29df0fee.png" alt="gRPC" title="gRPC"/></code>  
</div>
