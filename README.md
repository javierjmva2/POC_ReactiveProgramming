# Reactive Programming
![.NET Core-C#](https://img.shields.io/badge/.NET_Core-C%23-blue)

Prueba de concepto utilizando el paradigma [programación reactiva](https://livebook.manning.com/book/rx-dot-net-in-action/chapter-1/).

## Para poder empezar

### Instalar [visual studio 2022](https://visualstudio.microsoft.com/es/vs/community/)

Esto es necesario para poder abrir la solución.

### Instalar [.Net Core (Version 8)](https://dotnet.microsoft.com/en-us/download)

Es el core usado para la plataforma.

### Compilar y ejecutar aplicación

Una vez abierto el proyecto en el visual studio, se debe ejecutar el sitio web:
- Se debe dar clic en https (como se muestra en la imagen):
![imagen](https://github.com/user-attachments/assets/5e6d8af2-0a7c-4ac3-ab5e-50c41a9d2100)

Esto levantará un sitio web donde se podrán ver partidas en tiempo real que se están jugando en la plataforma [Lichess](https://lichess.org/)

## Pruebas

### Descripción de la prueba

La aplicación web muestra en tiempo real partidas de ajedrez transmitidos por un api de Lichess.org (formato nd-json) de 3 diferentes tipos (UltraBullet (15 Segundos), Bullet(30 Segundos) y Blitz(Entre 3 y 5 minutos)), la plataforma usará los siguientes componentes para garantizar una reactividad acorde al paradigma utilizado:

- El API usa Nd-Json para el streaming de los movimientos de las partidas
- La plataforma usará componentes Rx.Net para la configuración del paradigma (Observers) y SignalR para la parte del frontend (Permite manejar los eventos enviados desde el servidor).

### Objetivo de la prueba
El objetivo principal de estas pruebas es mostrar el funcionamiento interno del paradigma de programación reactiva.

### Pasos implementados para llevar a cabo la prueba 
- Para ver el ciclo de pruebas funcionales pueden ver estos [videos](https://drive.google.com/drive/folders/1ruZbUpXg92k1H7KBHRz5zOi9xx-Vx2iC)

- La prueba solo tiene un paso, el cual consiste cargar la pagina principal de la plataforma, la cual mostrará los 3 juegos de ajedrez en forma simultanea, si los juegos se mueven con regularidad y cambian de partida apenas termina una se dará la prueba como satisfactoria:
  ![imagen](https://github.com/user-attachments/assets/f5df4954-b1d1-4fee-9b10-a5eaee849ee9)


### Tecnologías usadas en la prueba (especifique lenguajes, librerías)

![.NET Core-C#](https://img.shields.io/badge/.NET_Core-C%23-blue)
- .NET Core 8
- Rx.Net (Nuget para componentes de programación reactiva) [Documentación](https://github.com/dotnet/reactive)
- SignalR (WebSockets y otros componentes para continuar con el paradigma en el frontend) [Documentación](https://learn.microsoft.com/es-es/aspnet/signalr/overview/getting-started/introduction-to-signalr)
- Api donde se consumen las partidas en tiempo real [Api Lichess (Ajedrez)](https://lichess.org/api)

### Resultados
Despues de esta prueba de concepto se puede observar que este paradigma permite desarrollar una aplicación con una robustes y escalabilidad digna de juegos multijugador, IoT o cualquier plataforma que necesite mostrar datos en tiempo real con el mayor rendimiento y latencia posible.

### Conclusiones 
Este paradigma es totalmente funcional y usado en la industria de desarrollo de software, aportando formas y utilidades para garantizar una transmision a base de eventos que garantiza una transmision casi en tiempo real de los datos. Pero como cualquier paradigma se debe analizar si se puede o no implementar segun las caracteristicas de los requerimientos del sistema en el cual se quiere utilizar. Como todo.. tienes sus ventajas y desventajas.
