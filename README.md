# innovacion.mapplics

#Caso de uso 1, proyecto nuevo desde cero.
#1- Redaccion estructura de lo que se quiere hacer, esto deberia contener tecnologia, arquitectura, descripcion del negocio, casos de uso. 

#2- Seleccion del modelo a utilizar:
Opciones a elegir/evaluar Claude 4 pareciera ser el mejor, pero tambien tenemos modelos como gemini 2.5 pro, que se pueden utilizar para redactar y resolver casos mas complejos donde necesitemos modelar o resolver algo antes iniciar el proyecto. Claude 4 en las pruebas que hemos hecho es uno de los que mejor funciona para la escritura de codigo. 

#3- Una ves que tenemos una descripcion basica de lo que queremos hacer, debemos relizar una documentacion detallada con la estructura del proyecto que nos servira luego como contexto para poder desarrollar el proyecto. 
Estrategia iterativa:
1- Le pedimos al chat utilizando como contexto e punto 1 que vaya generando documentacion que respete las definiciones dadas en el punto 1.
2-Revisar lo generado y agregar limitaciones al contenido generado. Si algo no esta dentro del scope aclarar que no corresponde, no borrarlo sino aclararlo dentro de la propia documentacion. Esto es para luego si ese feature o funcionalidad es necesaria ya esta redactada y podemos utilizarla. Esto limita las proximas iteraciones lo cual evita perder tiempo y scope de los que queremos hacer.

3-A partir de la documentacion revisada en el punto 2, generar la documentacion de la arquitectura. Definicion de tecnologias de desarrolo e implementacion. Ej. Deploy, base de datos, servidor, lenguajes, frameworks, conectividad,etc. En este paso es importante utilizar mermaid para poder generar graficas de  fluo de la arquitectura general que luego podran ser utuilizadas como parte del contexto.

4- A partir de aca, le pedimos que genere una documentacion de un plan de desarrollo por etapas. Se puede pedir que genere entregas tempranas, con lo cual podemos subdividir los spinrt del proyecto y estructurarlo en el tiempo.

5 - A partir de ahora para cada una de las etapas pediremos una guia detellada de tareas para el desarrollador. Esto incluye el setup  local para el desarrollo (ej, como levantar el entorno local, paquetas, etc)

6- 






