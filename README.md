# Sistema de Búsqueda de Vehículos para Miles Car Rental

## Descripción del Proyecto

Miles Car Rental, una empresa líder en la industria del alquiler de vehículos, busca implementar un sistema de búsqueda avanzado que permita a sus clientes encontrar vehículos disponibles de manera eficiente y precisa. Este sistema se diseñará para cumplir con los criterios específicos de búsqueda que requiere la empresa, asegurando una experiencia óptima para sus usuarios.

### Criterios de Búsqueda

Los vehículos disponibles se deben retornar en base a los siguientes criterios:

- **Localidad de Recogida:** Los clientes podrán especificar la localidad desde donde desean recoger el vehículo. Esta información será fundamental para determinar la disponibilidad de vehículos en esa ubicación.
- **Localidad de Devolución:** Además de la localidad de recogida, los usuarios podrán indicar la localidad donde desean devolver el vehículo. Esto permitirá calcular la disponibilidad y opciones de devolución en función de la ubicación deseada.
- **Carros Disponibles para este Mercado:** El sistema tomará en cuenta tanto la localidad de recogida como la ubicación del cliente para definir el mercado correspondiente. En base a este mercado, se mostrarán únicamente los vehículos disponibles y adecuados para esa área específica.

## Entregables Solicitados

Se solicita construir una Web API donde se evidencie el funcionamiento de la aplicación, utilizando la versión de .NET 6 o superior y donde se implementen los principios de diseño de software y últimas tendencias tecnológicas.

## Despliegue en Azure

El proyecto ha sido desplegado en Azure y está disponible en la siguiente ruta: [https://boxmachineinventaryapi.azurewebsites.net](https://boxmachineinventaryapi.azurewebsites.net)

## Prueba de la Solución

Para probar la solución, se debe consumir primero el siguiente enlace:

- Método: POST
- URL: [https://boxmachineinventaryapi.azurewebsites.net/api/Auth/login](https://boxmachineinventaryapi.azurewebsites.net/api/Auth/login)
- Body (JSON):
  ```json
  {
    "username": "customer",
    "password": "1234"
  }

Luego, se debe tomar el token generado y hacer la siguiente consulta:

- Método: GET
- URL: [https://boxmachineinventaryapi.azurewebsites.net/api/Vehicle?PickupLocation=bogota&DropoffLocation=medellin](https://boxmachineinventaryapi.azurewebsites.net/api/Vehicle?PickupLocation=bogota&DropoffLocation=medellin)